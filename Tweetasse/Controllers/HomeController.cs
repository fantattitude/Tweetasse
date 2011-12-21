using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitterizer;
using System.Diagnostics;
using Tweetasse.Models;
using System.Configuration;
using System.Net;

namespace Tweetasse.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

		public string AjaxSaveToDB()
		{
			if (Session["LoggedASP"] != null)
			{
				TimelineOptions options = new TimelineOptions();

				options.Count = 200;
				options.IncludeRetweets = true;
				
				OAuthTokens token = new OAuthTokens();
				token.ConsumerKey = ConfigurationManager.AppSettings["consumerKey"];
				token.ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
				token.AccessToken = ((User)Session["LoggedUser"]).TwitterToken;
				token.AccessTokenSecret = ((User)Session["LoggedUser"]).TwitterTokenSecret;

				TwitterResponse<TwitterStatusCollection> truc = TwitterTimeline.HomeTimeline(token, options);

				TweetEntity tweetEntity = new TweetEntity();

				tweetEntity.RemoveTweetFromOwner(((User)Session["LoggedUser"]).ID);

				foreach (var item in truc.ResponseObject)
				{
					//int lol = ;

					tweetEntity.AddTweet(item.Id, item.Text, item.User.ScreenName, item.User.ProfileImageLocation, ((User)Session["LoggedUser"]).ID, ((int)((TimeSpan)(item.CreatedDate - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime())).TotalSeconds));
				}
				return "Success";
			}
			else
				return "Fail";
		}

        public ActionResult Index()
        {
			if (Session["LoggedASP"] != null && Session["DatabaseMode"] != null)
			{
				User myUser = (User)Session["LoggedUser"];
				ViewData["Username"] = myUser.Username;
				
				TweetEntity entity = new TweetEntity();
				List<Tweet> list = entity.GetTweetsForOwner(((User)Session["LoggedUser"]).ID);

				OAuthTokens token = new OAuthTokens();
				token.ConsumerKey = ConfigurationManager.AppSettings["consumerKey"];
				token.ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
				token.AccessToken = ((User)Session["LoggedUser"]).TwitterToken;
				token.AccessTokenSecret = ((User)Session["LoggedUser"]).TwitterTokenSecret;

				//string loggedUserName = TwitterUser.Show(token, Decimal.Parse(((User)Session["LoggedUser"]).TwitterID)).ResponseObject.ScreenName.ToLower();

				if (list.Count != 0)
				{
					foreach (var item in list)
					{
						ViewData["message"] += "<div class='message'><div class='editTweet'><a class='editTweetA' rel='" + item.ID.ToString() + "' href='/Tweet/EditGet/" + item.ID.ToString() + "'>Edit</a> <a class='deleteLink' href='/Tweet/Delete/" + item.IDTwitter.ToString() + "'>Delete</a></div><div class='tweetP'><img class='inTweetImg' src='" + item.Avatar + "' /><a href=\"/User/" + item.Username + "\">" + item.Username + "</a> ---- " + item.Text + "</div></div>";
					}
				}
				else
				{
					ViewData["message"] = "<p style='text-align: center;'>Aucun rang dans la base de donnée. :(</p>";
				}
				return View();

			}
			else
			{

				if (Session["LoggedASP"] != null)
				{
					User myUser = (User)Session["LoggedUser"];
					ViewData["Username"] = myUser.Username;
				}

				if (Session["LoggedTwitter"] != null)
				{
					TimelineOptions options = new TimelineOptions();

					options.Count = 200;
					options.IncludeRetweets = true;

					OAuthTokens token = new OAuthTokens();
					token.ConsumerKey = ConfigurationManager.AppSettings["consumerKey"];
					token.ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
					token.AccessToken = ((User)Session["LoggedUser"]).TwitterToken;
					token.AccessTokenSecret = ((User)Session["LoggedUser"]).TwitterTokenSecret;

					try
					{
						TwitterResponse<TwitterStatusCollection> truc = TwitterTimeline.HomeTimeline(token, options);

						foreach (var item in truc.ResponseObject)
						{
							ViewData["message"] += "<p class='tweetP'><img class='inTweetImg' src='" + item.User.ProfileImageLocation + "' /><a href=\"/User/" + item.User.ScreenName + "\">" + item.User.ScreenName + "</a> ---- " + item.Text + "</p>";
						}
					}
					catch (WebException exception)
					{
						ViewData["message"] = "<p style='text-align:center;'>Erreur : " + exception.Message + "</p>";
					}
					catch (Exception exception)
					{
						ViewData["message"] = "<p style='text-align:center;'>Erreur : " + exception.Message + "</p>";
					}
				}
				else
				{
					if (Session["LoggedASP"] != null)
						ViewData["message"] = "<p style='text-align:center;'>Bonjour " + ((User)Session["LoggedUser"]).Username + ", ton compte existe mais il n'est pas associé a un compte Twitter pour le moment, si tu veux associer ton compte Twitter avec ton Compte Tweetasse, rends toi sur la page Manage via le menu en haut.</p><hr />";
					
					try
					{
						TwitterResponse<TwitterStatusCollection> publicTimeline = TwitterTimeline.PublicTimeline();
						if (String.IsNullOrEmpty(publicTimeline.ErrorMessage))
						{
							foreach (var item in publicTimeline.ResponseObject)
							{
								ViewData["message"] += "<p class='tweetP'><img class='inTweetImg' src='" + item.User.ProfileImageLocation + "' /><a href=\"/User/" + item.User.ScreenName + "\">" + item.User.ScreenName + "</a> ---- " + item.Text + "</p>";
							}
						}
						else
							ViewData["message"] = "<p style='text-align:center;'>Bonjour shagasse, l'application a excedé le nombre de demandes maximum sur l'API Twitter Publique sans Login oAuth pour cette heure. Démerdes-toi, merssi!</p>";
					}
					catch (WebException exception)
					{
						ViewData["message"] = "<p style='text-align:center;'>Erreur : "+exception.Message+"</p>";
						return View();
					}
					catch (Exception exception)
					{
						ViewData["message"] = "<p style='text-align:center;'>Erreur : " + exception.Message + "</p>";
					}

					
				}
				return View();
			}
        }

		public ActionResult HandleTweet(string tweet) {
			if (Session["LoggedTwitter"] != null)
			{
				OAuthTokens token = new OAuthTokens();
				token.ConsumerKey = ConfigurationManager.AppSettings["consumerKey"];
				token.ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
				token.AccessToken = ((User)Session["LoggedUser"]).TwitterToken;
				token.AccessTokenSecret = ((User)Session["LoggedUser"]).TwitterTokenSecret;
				TwitterResponse<TwitterStatus> status = TwitterStatus.Update(token, tweet);
			}
			return Redirect("http://"+Request.Url.Authority.ToString());
		}

		public ActionResult GoToUser(string username) {
			return Redirect("http://" + Request.Url.Authority.ToString() + "/User/" + username);
		}

    }
}
