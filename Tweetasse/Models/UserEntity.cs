using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tweetasse.Models
{
    public class UserEntity 
    {
        public TweetasseEntities _entity { get; set; }

		public UserEntity()
		{
			_entity = new TweetasseEntities();
		}

		public bool UserExist(string username){
			User user = (from t in _entity.Users where t.Username == username select t).FirstOrDefault();
			if(user == null){
				return false;
			}
			return true;
		}

		public User GetUserFromUsername(string username) {
			return (from t in _entity.Users
					where t.Username == username
					select t).FirstOrDefault();
		}

		public void AddUser(string username, string password) {
			_entity.AddToUsers(new User {
				Username = username,
				Password = password
			});

			_entity.SaveChanges();
		}

		public void EditUser(int id, string token, string tokenSecret, string userid, string username)
		{
			User user = (from t in _entity.Users
					   where t.ID == id
					   select t).FirstOrDefault();
			user.TwitterUsername = username;
			user.TwitterToken = token;
			user.TwitterTokenSecret = tokenSecret;
			user.TwitterID = userid;
			_entity.SaveChanges();
		}

		public void RemoveUser(int id)
		{
			User user = (from t in _entity.Users
						   where t.ID == id
						   select t).FirstOrDefault();
			_entity.DeleteObject(user);

			_entity.SaveChanges();
		}

		public bool CheckPassword(string username, string password)
		{
			User user = (from t in _entity.Users where t.Username == username select t).FirstOrDefault();
			if (user.Password == password)
				return true;
			else
				return false;
		}
	}
}
