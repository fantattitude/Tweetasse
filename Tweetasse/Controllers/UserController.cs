using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitterizer;
using System.Configuration;
using Tweetasse.Models;

namespace Tweetasse.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
			Response.Redirect("/Home");
            return View();
        }

		public ActionResult Profile(String screenname)
		{
			if (Session["LoggedASP"] != null)
				ViewData["username"] = ((User)Session["LoggedUser"]).Username;

			try
			{
				TwitterResponse<TwitterUser> user;
				if (Session["LoggedTwitter"] != null)
				{
					OAuthTokens token = new OAuthTokens();
					token.ConsumerKey = ConfigurationManager.AppSettings["consumerKey"];
					token.ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
					token.AccessToken = ((User)Session["LoggedUser"]).TwitterToken;
					token.AccessTokenSecret = ((User)Session["LoggedUser"]).TwitterTokenSecret;
					user = TwitterUser.Show(token, screenname);

				}
				else
					user = TwitterUser.Show(screenname);

				if (String.IsNullOrEmpty(user.ErrorMessage))
				{
					ViewData["content"] = "<img class='userImg' src='" + user.ResponseObject.ProfileImageLocation.ToString() + "' />Profil de <em>@" + user.ResponseObject.ScreenName + "</em> qui possède l'ID N°" + user.ResponseObject.Id + "<br />Il s'est enregistré sur Twitter le : " + user.ResponseObject.CreatedDate + " et il possède " + user.ResponseObject.NumberOfFollowers + " followers.";

					UserTimelineOptions options = new UserTimelineOptions();
					options.ScreenName = screenname;
					options.Count = 100;
					options.IncludeRetweets = true;

					if (Session["LoggedTwitter"] != null)
					{
						OAuthTokens token = new OAuthTokens();
						token.ConsumerKey = ConfigurationManager.AppSettings["consumerKey"];
						token.ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
						token.AccessToken = ((User)Session["LoggedUser"]).TwitterToken;
						token.AccessTokenSecret = ((User)Session["LoggedUser"]).TwitterTokenSecret;

						bool taRaceVanStaen = false;
						if (screenname.ToLower() == TwitterUser.Show(token, Decimal.Parse(((User)Session["LoggedUser"]).TwitterID)).ResponseObject.ScreenName.ToLower())
							taRaceVanStaen = false;

						TwitterResponse<TwitterStatusCollection> truc = TwitterTimeline.UserTimeline(token, options);



						if (String.IsNullOrEmpty(truc.ErrorMessage))
						{
							foreach (var item in truc.ResponseObject)
							{
								if (taRaceVanStaen)
									ViewData["tweets"] += "<div class='editTweet'><a href=''>Edit</a> <a href=''>Delete</a></div><div><a href=\"/User/" + item.User.ScreenName + "\">" + item.User.ScreenName + "</a> ---- " + item.Text.Replace("\n", "<br />").ToString() + "</div>";
								else
									ViewData["tweets"] += "<div><a href=\"/User/" + item.User.ScreenName + "\">" + item.User.ScreenName + "</a> ---- " + item.Text.Replace("\n", "<br />").ToString() + "</div>";
							}
						}
						else
							ViewData["tweets"] = "Les tweets de cet utilisateur sont protégés.";
					}
					else
					{
						TwitterResponse<TwitterStatusCollection> truc = TwitterTimeline.UserTimeline(options);

						if (String.IsNullOrEmpty(truc.ErrorMessage))
						{
							foreach (var item in truc.ResponseObject)
							{
								ViewData["tweets"] += "<div><a href=\"/User/" + item.User.ScreenName + "\">" + item.User.ScreenName + "</a> ---- " + item.Text.Replace("\n", "<br />").ToString() + "</div>";
							}
						}
						else
							ViewData["tweets"] = "Les tweets de cet utilisateur sont protégés.";
					}
					return View("Index");
				}
				else
				{
					ViewData["errorMessage"] = user.ErrorMessage;
					return View("Error");
				}
			}
			catch (Exception exception)
			{
				ViewData["errorMessage"] = exception.Message;
				return View("Error");
			}
		}
    }
}
