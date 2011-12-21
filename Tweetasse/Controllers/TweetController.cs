using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tweetasse.Models;
using Twitterizer;
using System.Configuration;

namespace Tweetasse.Controllers
{
    public class TweetController : Controller
    {
        //
        // GET: /Tweet/

        public ActionResult Index()
        {
            return Redirect("http://"+Request.Url.Authority.ToString());
        }

		public string Delete(string id)
		{
			if (Session["LoggedASP"] != null && Session["LoggedTwitter"] != null)
			{
				new TweetEntity().RemoveTweet(Decimal.Parse(id));
				
				OAuthTokens token = new OAuthTokens();
				token.ConsumerKey = ConfigurationManager.AppSettings["consumerKey"];
				token.ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
				token.AccessToken = ((User)Session["LoggedUser"]).TwitterToken;
				token.AccessTokenSecret = ((User)Session["LoggedUser"]).TwitterTokenSecret;

				if (TwitterStatus.Delete(token, Decimal.Parse(id)).ErrorMessage == null)
					return "Success";
				else
					return "Fail1";

			}
			else
			{
				return "Fail2";
			}
		}

		public string EditGet(string id)
		{
			if (Session["LoggedASP"] != null && Session["LoggedTwitter"] != null)
			{
				Tweet tweet = new TweetEntity().GetTweet(Decimal.Parse(id));
				return tweet.Text;
			}
			else
				return "Fail";
		}

		public string EditPost(string id, string text)
		{
			if (Session["LoggedASP"] != null && Session["LoggedTwitter"] != null)
			{
				Tweet tweet = new TweetEntity().GetTweet(Decimal.Parse(id));
				new TweetEntity().EditTweet(int.Parse(id),text);
				new TweetEntity().EditTweet(int.Parse(id), ((int)((TimeSpan)(DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime())).TotalSeconds));

				OAuthTokens token = new OAuthTokens();
				token.ConsumerKey = ConfigurationManager.AppSettings["consumerKey"];
				token.ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
				token.AccessToken = ((User)Session["LoggedUser"]).TwitterToken;
				token.AccessTokenSecret = ((User)Session["LoggedUser"]).TwitterTokenSecret;

				if (TwitterStatus.Delete(token, Decimal.Parse(tweet.IDTwitter.ToString())).ErrorMessage == null)
				{
					TwitterResponse<TwitterStatus> status = TwitterStatus.Update(token, text);
					if (status.ErrorMessage == null)
					{
						new TweetEntity().EditTweet(int.Parse(id), status.ResponseObject.Id, ((int)((TimeSpan)(status.ResponseObject.CreatedDate - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime())).TotalSeconds));

						return "Success";
					}
					else
						return "Fail";
				}
				else
				{
					return "Fail1";
				}

			}
			else
			{
				return "Fail2";
			}
		}

		public string GetTweetCode(string id)
		{
			Tweet item = new TweetEntity().GetTweet(Decimal.Parse(id));
			return "<div class='editTweet'><a class='editTweetA' rel='" + item.ID.ToString() + "' href='/Tweet/EditGet/" + item.ID.ToString() + "'>Edit</a> <a class='deleteLink' href='/Tweet/Delete/" + item.IDTwitter.ToString() + "'>Delete</a></div><div class='tweetP'><img class='inTweetImg' src='" + item.Avatar + "' /><a href=\"/User/" + item.Username + "\">" + item.Username + "</a> ---- " + item.Text + "</div>";
		}

    }
}
