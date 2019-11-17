using Infrastructure;
using TWHelp.Models.DTOs;

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

using Microsoft.AspNetCore.Mvc;

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

        // POST: api/prediction/create/{twitter_nick}/{count}
        [HttpPost("create/{twitter_nick}/{count}")]
        public ActionResult<PredictionDTO> CreateRequestForPrediction(string twitter_nick, int count)
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
                    ActivityChartPath = $"../../PythonAPI/output/activity_{twitter_nick}.png",
                    PieChartPath = $"../../PythonAPI/output/activity_{twitter_nick}.png",
                    LastModified = analytics.LastUpdated,
                    BadEmotionRate = analytics.BadEmotionRate,
                    GoodEmotionRate = analytics.GoodEmotionRate,
                };

                return Ok(response);
            }
            else
            {
                string link = $"http://localhost:5000/api/analytics?twitter_nick={twitter_nick}&count={count}";
                string predictionResponse = SendHttpRequest(new Uri(link), "POST");
                dynamic parsedResponse = JsonConvert.DeserializeObject(predictionResponse);

                Domain.Models.Domain.TwitterUserStatistic userStatistic = new Domain.Models.Domain.TwitterUserStatistic()
                {
                    TwitterNick = twitter_nick,
                    LastUpdated = DateTime.Now,
                    GoodEmotionRate = double.Parse(parsedResponse.good),
                    BadEmotionRate = double.Parse(parsedResponse.bad),
                };

                _context.TwitterUserStatistics.Add(userStatistic);
                _context.SaveChanges();

                var response = new PredictionDTO()
                {
                    ActivityChartPath = $"../../PythonAPI/output/activity_{twitter_nick}.png",
                    PieChartPath = $"../../PythonAPI/output/activity_{twitter_nick}.png",
                    LastModified = userStatistic.LastUpdated,
                    BadEmotionRate = userStatistic.BadEmotionRate,
                    GoodEmotionRate = userStatistic.GoodEmotionRate,
                };

                return Ok(response);
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

        public static string SendHttpRequest(Uri uri, string httpMethod, string requestJsonBody = null)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Method = httpMethod;
            httpWebRequest.Timeout = 20000;

            //for post/put methods etc.
            if (requestJsonBody != null)
            {
                httpWebRequest.ContentType = "application/json";

                using (var reqStream = httpWebRequest.GetRequestStream())
                using (var sw = new StreamWriter(reqStream, Encoding.UTF8))
                {
                    sw.Write(requestJsonBody);
                }
            }

            var webResponse = httpWebRequest.GetResponse();

            using (var webStream = webResponse.GetResponseStream())
            using (var responseReader = new StreamReader(webStream))
            {
                return responseReader.ReadToEnd();
            }
        }
    }
}