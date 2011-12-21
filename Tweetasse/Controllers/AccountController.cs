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
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
			if (Session["LoggedASP"] != null)
			{
				ViewData["username"] = ((User)Session["LoggedUser"]).Username;
				if (!String.IsNullOrEmpty(Request.QueryString["oauth_token"]))
				{
					OAuthTokenResponse tokens = OAuthUtility.GetAccessTokenDuringCallback(ConfigurationManager.AppSettings["consumerKey"], ConfigurationManager.AppSettings["consumerSecret"]);


					UserEntity entity = new UserEntity();

					entity.EditUser(((User)Session["LoggedUser"]).ID, tokens.Token, tokens.TokenSecret, tokens.UserId.ToString(), tokens.ScreenName);

					Session["LoggedUser"] = entity.GetUserFromUsername(((User)Session["LoggedUser"]).Username);
					Session["LoggedTwitter"] = true;

					ViewData["TwitterUsername"] = TwitterUser.Show(Decimal.Parse(((User)Session["LoggedUser"]).TwitterID)).ResponseObject.ScreenName;

					//Session["accessToken"] = myToken;
					//ViewData["Logged"] = true;
				}
				else if (Session["LoggedTwitter"] != null)
				{
					OAuthTokens token = new OAuthTokens();
					token.ConsumerKey = ConfigurationManager.AppSettings["consumerKey"];
					token.ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
					token.AccessToken = ((User)Session["LoggedUser"]).TwitterToken;
					token.AccessTokenSecret = ((User)Session["LoggedUser"]).TwitterTokenSecret;

					/*ViewData["TwitterUsername"] = TwitterUser.Show(token,Decimal.Parse(((User)Session["LoggedUser"]).TwitterID)).ResponseObject.ScreenName;*/
				}

				return View();
			}
			else
				return Redirect("http://" + Request.Url.Authority.ToString());
        }

		public ActionResult SignupOrLogin()
		{
			UserEntity entity = new UserEntity();

			if (entity.UserExist(Request.Form["username"]))
			{
				if (entity.CheckPassword(Request.Form["username"], Request.Form["password"]))
				{
					User myUser = entity.GetUserFromUsername(Request.Form["username"]);
					Session["LoggedUser"] = myUser;
					Session["LoggedASP"] = true;
					if (!String.IsNullOrEmpty(myUser.TwitterToken))
						Session["LoggedTwitter"] = true;
				}
				else
					Session["ErrorLogin"] = true;
				return Redirect(Request.UrlReferrer.ToString());
			}
			else
			{
				entity.AddUser(Request.Form["username"], Request.Form["password"]);
				User myUser = entity.GetUserFromUsername(Request.Form["username"]);
				Session["LoggedUser"] = myUser;
				Session["LoggedASP"] = true;
				return Redirect(Request.UrlReferrer.ToString());
			}
		}

		public ActionResult Deconnexion()
		{
			Session["LoggedASP"] = null;
			Session["LoggedTwitter"] = null;
			Session["LoggedUser"] = null;
			Session["DatabaseMode"] = null;
			return Redirect(Request.UrlReferrer.ToString());
		}

		public ActionResult SwitchMode()
		{
			if (Session["LoggedASP"] != null)
			{
				if (Session["DatabaseMode"] != null)
					Session["DatabaseMode"] = null;
				else
					Session["DatabaseMode"] = true;
				if (Request.UrlReferrer != null)
					return Redirect(Request.UrlReferrer.ToString());
				else
					return Redirect("http://" + Request.Url.Authority);
			}
			else
			{
				return Redirect("http://" + Request.Url.Authority);
			}
		}

		public ActionResult ConnectToTwitter()
		{
			OAuthTokenResponse response = OAuthUtility.GetRequestToken(ConfigurationManager.AppSettings["consumerKey"], ConfigurationManager.AppSettings["consumerSecret"], "http://" + Request.Url.Authority.ToString() + "/Account");

			Uri authorizationUri = OAuthUtility.BuildAuthorizationUri(response.Token);

			return Redirect(authorizationUri.ToString());
		}
    }
}
