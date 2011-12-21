using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tweetasse.Models
{
	public class TweetEntity
	{
		public TweetasseEntities _entity { get; set; }

		public TweetEntity()
		{
			_entity = new TweetasseEntities();
		}

		public void AddTweet(Decimal idTwitter, string text, string username, string avatar, int owner, int date) {
			
			_entity.AddToTweets(new Tweet {
				Text = text,
				IDTwitter = idTwitter,
				Username = username,
				Avatar = avatar,
				Owner = owner,
				Datetime = date
			});

			_entity.SaveChanges();
		}

		public Tweet GetTweet(Decimal id)
		{
			Tweet tweet = (from t in _entity.Tweets
						   where t.ID == id
						   select t).FirstOrDefault();
			return tweet;
		}

		public List<Tweet> GetTweetsForOwner(int owner)
		{
			List<Tweet> list = (from t in _entity.Tweets where t.Owner == owner orderby t.Datetime select t).ToList();
			list.Reverse();
			return list;
		}

		public void EditTweet(int id, string text)
		{
			Tweet tweet = (from t in _entity.Tweets
					   where t.ID == id
					   select t).FirstOrDefault();
			tweet.Text = text;

			_entity.SaveChanges();

		}

		public void EditTweet(int id, Decimal idTwitter, int timestamp)
		{
			Tweet tweet = (from t in _entity.Tweets
						   where t.ID == id
						   select t).FirstOrDefault();
			tweet.IDTwitter = idTwitter;
			tweet.Datetime = timestamp;
			_entity.SaveChanges();
		}

		public void EditTweet(int id, int timestamp)
		{
			Tweet tweet = (from t in _entity.Tweets
						   where t.ID == id
						   select t).FirstOrDefault();
			tweet.Datetime = timestamp;
			_entity.SaveChanges();
		}

		public void RemoveTweet(Decimal id)
		{
			Tweet tweet = (from t in _entity.Tweets
						   where t.IDTwitter == id
						   select t).FirstOrDefault();
			_entity.DeleteObject(tweet);

			_entity.SaveChanges();
		}

		public void RemoveTweetFromOwner(int owner)
		{ 
			List<Tweet> listOfTweets = (from t in _entity.Tweets where t.Owner == owner select t).ToList();
			foreach (var item in listOfTweets)
				_entity.DeleteObject(item);
		}
	}
}