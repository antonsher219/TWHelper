using Infrastructure;
using TWHelp.Models.DTOs;
using TWHelp.Models.Infrastructure;

using System;
using System.Linq;
using Newtonsoft.Json;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Net.Sockets;

namespace TWHelp.API
{
    [Route("api/prediction")]
    [ApiController]
    public class PredictionModelController : ControllerBase
    {
        private ApplicationDbContext _context;

        public PredictionModelController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/prediction/create/{twitter_nick}/{count}
        [HttpGet("create/{twitter_nick}/{count}")]
        public ActionResult<PredictionDTO> GetUserPrediction(string twitter_nick, int count)
        {
            if(string.IsNullOrEmpty(twitter_nick) || count == 0)
            {
                return BadRequest();
            }

            if(UserHasRecentAnalytics(twitter_nick))
            {
                var analytics = _context.TwitterUserStatistics
                    .Where(account => account.TwitterNick.Equals(twitter_nick))
                    .FirstOrDefault();

                var response = new PredictionDTO()
                {
                    ActivityChartPath = $"/output/activity_{twitter_nick}.png",
                    PieChartPath = $"/output/piechart_{twitter_nick}.png",
                    LastModified = analytics.LastUpdated,
                    BadEmotionRate = analytics.BadEmotionRate,
                    GoodEmotionRate = analytics.GoodEmotionRate,
                };

                return Ok(response);
            }
            else
            {
                try
                {
                    string link = $"http://localhost:5000/api/analytics?twitter_nick={twitter_nick}&count={count}";
                    string predictionResponse = HttpSender.SendHttpRequest(new Uri(link), "POST");

                    dynamic parsedResponse = JsonConvert.DeserializeObject(predictionResponse);

                    Domain.Models.Domain.TwitterUserStatistic userStatistic = new Domain.Models.Domain.TwitterUserStatistic()
                    {
                        TwitterNick = twitter_nick,
                        LastUpdated = DateTime.Now,
                        GoodEmotionRate = double.Parse(parsedResponse["good"].ToString()),
                        BadEmotionRate = double.Parse(parsedResponse["bad"].ToString()),
                    };

                    _context.TwitterUserStatistics.Add(userStatistic);
                    _context.SaveChanges();

                    var response = new PredictionDTO()
                    {
                        ActivityChartPath = $"/output/activity_{twitter_nick}.png",
                        PieChartPath = $"/output/activity_{twitter_nick}.png",
                        LastModified = userStatistic.LastUpdated,
                        BadEmotionRate = userStatistic.BadEmotionRate,
                        GoodEmotionRate = userStatistic.GoodEmotionRate,
                    };

                    return Ok(response);
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        //if user has analytics this week
        private bool UserHasRecentAnalytics(string twitter_nick)
        {
            var analytics = _context.TwitterUserStatistics
                .Where(account => account.TwitterNick.Equals(twitter_nick))
                .FirstOrDefault();

            if(analytics == null || (DateTime.Now - analytics.LastUpdated).Days > 7)
            {
                return false;
            }

            return true;
        }
    }
}