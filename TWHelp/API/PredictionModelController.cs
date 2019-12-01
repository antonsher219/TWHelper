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
using Domain.Models.Domain;
using System.Collections.Generic;

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

        // for simple REST requests
        #region REST
        // GET: api/prediction/create/{twitter_nick}/{count}
        [HttpGet("create/{twitter_nick}/{count}")]
        public ActionResult<PredictionDTO> GetUserPrediction(string twitter_nick, int count)
        {
            if (string.IsNullOrEmpty(twitter_nick) || count == 0)
            {
                return BadRequest();
            }

            var analytics = UserRecentAnalytics(twitter_nick);

            if (analytics != null)
            {
                var response = new PredictionDTO()
                {
                    ActivityChartPath = $"/output/activity_{twitter_nick}.png",
                    PieChartPath = $"/output/piechart_{twitter_nick}.png",
                    LastModified = analytics.LastUpdated,
                    TopPositiveWordsJson = analytics.TopPositiveWordsJson,
                    TopNegativeWordsJson = analytics.TopNegativeWordsJson
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

                    TwitterUserStatistic statistic = CreateOrUpdateUserStatistic(
                        twitter_nick,
                        double.Parse(parsedResponse["good"].ToString()),
                        double.Parse(parsedResponse["bad"].ToString()));

                    var response = new PredictionDTO()
                    {
                        ActivityChartPath = $"/output/activity_{twitter_nick}.png",
                        PieChartPath = $"/output/activity_{twitter_nick}.png",
                        LastModified = statistic.LastUpdated,
                        TopPositiveWordsJson = analytics.TopPositiveWordsJson,
                        TopNegativeWordsJson = analytics.TopNegativeWordsJson
                    };

                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        #endregion


        // GET: api/prediction/get/{twitter_nick}
        [HttpGet("get/{twitter_nick}")]
        public ActionResult<PredictionDTO> UserRecentPrediction(string twitter_nick)
        {
            if(twitter_nick == null)
            {
                return BadRequest();
            }

            var analytics = UserRecentAnalytics(twitter_nick);

            if(analytics == null)
            {
                return NotFound();
            }

            var response = new PredictionDTO()
            {
                ActivityChartPath = $"/output/activity_{twitter_nick}.png",
                PieChartPath = $"/output/piechart_{twitter_nick}.png",
                LastModified = analytics.LastUpdated,
                TopPositiveWordsJson = analytics.TopPositiveWordsJson,
                TopNegativeWordsJson = analytics.TopNegativeWordsJson
            };

            return Ok(response);
        }


        //TODO: add updating statistic from frontend
        #region TODO
        // GET: api/prediction/tweets/get/{twitter_nick}
        [HttpGet("tweets/get/{twitter_nick}")]
        public ActionResult<List<TwitterUserTweet>> UserRecentTweets(string twitter_nick)
        {
            var tweets = _context.TwitterUserTweets
                .Where(t => t.TwitterNick.Equals(twitter_nick))
                .ToList();

            if (tweets.Count == 0)
            {
                return NotFound();
            }

            return Ok(tweets);
        }

        // POST: api/prediction/statistic/create
        [HttpPost("api/prediction/statistic/create/{twitter_nick}/{good_rate}/{bad_rate}")]
        public ActionResult CreateOrUpdateTwitterStatistic(string twitter_nick, string topPositiveWordsJson, string topNegativeWordsJson)
        {
            CreateOrUpdateUserStatistic(twitter_nick, topNegativeWordsJson, topNegativeWordsJson);

            return Ok();
        }
        #endregion

        //has user had analytics this week
        private TwitterUserStatistic UserRecentAnalytics(string twitter_nick)
        {
            var analytics = _context.TwitterUserStatistics
                .Where(account => account.TwitterNick.Equals(twitter_nick))
                .FirstOrDefault();

            if(analytics == null || (DateTime.Now - analytics.LastUpdated).Days > 7)
            {
                return null;
            }

            return analytics;
        }

        private TwitterUserStatistic CreateOrUpdateUserStatistic(string twitter_nick, string topPositiveWordsJson, string topNegativeWordsJson)
        {
            var existedStatistic = _context.TwitterUserStatistics.FirstOrDefault(stat => stat.TwitterNick.Equals(twitter_nick));

            if(existedStatistic == null)
            {
                existedStatistic = new TwitterUserStatistic()
                {
                    TwitterNick = twitter_nick,
                    LastUpdated = DateTime.Now,
                    TopPositiveWordsJson = topPositiveWordsJson,
                    TopNegativeWordsJson = topNegativeWordsJson
                };

                _context.TwitterUserStatistics.Add(existedStatistic);
            }
            else
            {
                existedStatistic.LastUpdated = DateTime.Now;
                existedStatistic.TopNegativeWordsJson = topPositiveWordsJson;
                existedStatistic.TopNegativeWordsJson = topNegativeWordsJson;

                _context.TwitterUserStatistics.Update(existedStatistic);
            }

            _context.SaveChanges();

            return existedStatistic;
        }
    }
}