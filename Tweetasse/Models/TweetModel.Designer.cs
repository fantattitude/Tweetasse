﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace Tweetasse.Models
{
    #region Contextes
    
    /// <summary>
    /// Aucune documentation sur les métadonnées n'est disponible.
    /// </summary>
    public partial class TweetasseEntities : ObjectContext
    {
        #region Constructeurs
    
        /// <summary>
        /// Initialise un nouvel objet TweetasseEntities à l'aide de la chaîne de connexion trouvée dans la section 'TweetasseEntities' du fichier de configuration d'application.
        /// </summary>
        public TweetasseEntities() : base("name=TweetasseEntities", "TweetasseEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialisez un nouvel objet TweetasseEntities.
        /// </summary>
        public TweetasseEntities(string connectionString) : base(connectionString, "TweetasseEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialisez un nouvel objet TweetasseEntities.
        /// </summary>
        public TweetasseEntities(EntityConnection connection) : base(connection, "TweetasseEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Méthodes partielles
    
        partial void OnContextCreated();
    
        #endregion
    
        #region Propriétés ObjectSet
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        public ObjectSet<User> Users
        {
            get
            {
                if ((_Users == null))
                {
                    _Users = base.CreateObjectSet<User>("Users");
                }
                return _Users;
            }
        }
        private ObjectSet<User> _Users;
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        public ObjectSet<Tweet> Tweets
        {
            get
            {
                if ((_Tweets == null))
                {
                    _Tweets = base.CreateObjectSet<Tweet>("Tweets");
                }
                return _Tweets;
            }
        }
        private ObjectSet<Tweet> _Tweets;

        #endregion
        #region Méthodes AddTo
    
        /// <summary>
        /// Méthode déconseillée pour ajouter un nouvel objet à l'EntitySet Users. Utilisez la méthode .Add de la propriété ObjectSet&lt;T&gt; associée à la place.
        /// </summary>
        public void AddToUsers(User user)
        {
            base.AddObject("Users", user);
        }
    
        /// <summary>
        /// Méthode déconseillée pour ajouter un nouvel objet à l'EntitySet Tweets. Utilisez la méthode .Add de la propriété ObjectSet&lt;T&gt; associée à la place.
        /// </summary>
        public void AddToTweets(Tweet tweet)
        {
            base.AddObject("Tweets", tweet);
        }

        #endregion
    }
    

    #endregion
    
    #region Entités
    
    /// <summary>
    /// Aucune documentation sur les métadonnées n'est disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="TweetasseModel", Name="Tweet")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Tweet : EntityObject
    {
        #region Méthode de fabrique
    
        /// <summary>
        /// Créez un nouvel objet Tweet.
        /// </summary>
        /// <param name="id">Valeur initiale de la propriété ID.</param>
        /// <param name="iDTwitter">Valeur initiale de la propriété IDTwitter.</param>
        /// <param name="avatar">Valeur initiale de la propriété Avatar.</param>
        /// <param name="username">Valeur initiale de la propriété Username.</param>
        /// <param name="text">Valeur initiale de la propriété Text.</param>
        /// <param name="owner">Valeur initiale de la propriété Owner.</param>
        /// <param name="datetime">Valeur initiale de la propriété Datetime.</param>
        public static Tweet CreateTweet(global::System.Int32 id, global::System.Decimal iDTwitter, global::System.String avatar, global::System.String username, global::System.String text, global::System.Int32 owner, global::System.Int32 datetime)
        {
            Tweet tweet = new Tweet();
            tweet.ID = id;
            tweet.IDTwitter = iDTwitter;
            tweet.Avatar = avatar;
            tweet.Username = username;
            tweet.Text = text;
            tweet.Owner = owner;
            tweet.Datetime = datetime;
            return tweet;
        }

        #endregion
        #region Propriétés primitives
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Int32 _ID;
        partial void OnIDChanging(global::System.Int32 value);
        partial void OnIDChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal IDTwitter
        {
            get
            {
                return _IDTwitter;
            }
            set
            {
                OnIDTwitterChanging(value);
                ReportPropertyChanging("IDTwitter");
                _IDTwitter = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IDTwitter");
                OnIDTwitterChanged();
            }
        }
        private global::System.Decimal _IDTwitter;
        partial void OnIDTwitterChanging(global::System.Decimal value);
        partial void OnIDTwitterChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Avatar
        {
            get
            {
                return _Avatar;
            }
            set
            {
                OnAvatarChanging(value);
                ReportPropertyChanging("Avatar");
                _Avatar = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Avatar");
                OnAvatarChanged();
            }
        }
        private global::System.String _Avatar;
        partial void OnAvatarChanging(global::System.String value);
        partial void OnAvatarChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Username
        {
            get
            {
                return _Username;
            }
            set
            {
                OnUsernameChanging(value);
                ReportPropertyChanging("Username");
                _Username = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Username");
                OnUsernameChanged();
            }
        }
        private global::System.String _Username;
        partial void OnUsernameChanging(global::System.String value);
        partial void OnUsernameChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Text
        {
            get
            {
                return _Text;
            }
            set
            {
                OnTextChanging(value);
                ReportPropertyChanging("Text");
                _Text = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Text");
                OnTextChanged();
            }
        }
        private global::System.String _Text;
        partial void OnTextChanging(global::System.String value);
        partial void OnTextChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Owner
        {
            get
            {
                return _Owner;
            }
            set
            {
                OnOwnerChanging(value);
                ReportPropertyChanging("Owner");
                _Owner = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Owner");
                OnOwnerChanged();
            }
        }
        private global::System.Int32 _Owner;
        partial void OnOwnerChanging(global::System.Int32 value);
        partial void OnOwnerChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Datetime
        {
            get
            {
                return _Datetime;
            }
            set
            {
                OnDatetimeChanging(value);
                ReportPropertyChanging("Datetime");
                _Datetime = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Datetime");
                OnDatetimeChanged();
            }
        }
        private global::System.Int32 _Datetime;
        partial void OnDatetimeChanging(global::System.Int32 value);
        partial void OnDatetimeChanged();

        #endregion
    
    }
    
    /// <summary>
    /// Aucune documentation sur les métadonnées n'est disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="TweetasseModel", Name="User")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class User : EntityObject
    {
        #region Méthode de fabrique
    
        /// <summary>
        /// Créez un nouvel objet User.
        /// </summary>
        /// <param name="id">Valeur initiale de la propriété ID.</param>
        /// <param name="username">Valeur initiale de la propriété Username.</param>
        /// <param name="password">Valeur initiale de la propriété Password.</param>
        public static User CreateUser(global::System.Int32 id, global::System.String username, global::System.String password)
        {
            User user = new User();
            user.ID = id;
            user.Username = username;
            user.Password = password;
            return user;
        }

        #endregion
        #region Propriétés primitives
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Int32 _ID;
        partial void OnIDChanging(global::System.Int32 value);
        partial void OnIDChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Username
        {
            get
            {
                return _Username;
            }
            set
            {
                OnUsernameChanging(value);
                ReportPropertyChanging("Username");
                _Username = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Username");
                OnUsernameChanged();
            }
        }
        private global::System.String _Username;
        partial void OnUsernameChanging(global::System.String value);
        partial void OnUsernameChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Password
        {
            get
            {
                return _Password;
            }
            set
            {
                OnPasswordChanging(value);
                ReportPropertyChanging("Password");
                _Password = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Password");
                OnPasswordChanged();
            }
        }
        private global::System.String _Password;
        partial void OnPasswordChanging(global::System.String value);
        partial void OnPasswordChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TwitterToken
        {
            get
            {
                return _TwitterToken;
            }
            set
            {
                OnTwitterTokenChanging(value);
                ReportPropertyChanging("TwitterToken");
                _TwitterToken = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TwitterToken");
                OnTwitterTokenChanged();
            }
        }
        private global::System.String _TwitterToken;
        partial void OnTwitterTokenChanging(global::System.String value);
        partial void OnTwitterTokenChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TwitterTokenSecret
        {
            get
            {
                return _TwitterTokenSecret;
            }
            set
            {
                OnTwitterTokenSecretChanging(value);
                ReportPropertyChanging("TwitterTokenSecret");
                _TwitterTokenSecret = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TwitterTokenSecret");
                OnTwitterTokenSecretChanged();
            }
        }
        private global::System.String _TwitterTokenSecret;
        partial void OnTwitterTokenSecretChanging(global::System.String value);
        partial void OnTwitterTokenSecretChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TwitterID
        {
            get
            {
                return _TwitterID;
            }
            set
            {
                OnTwitterIDChanging(value);
                ReportPropertyChanging("TwitterID");
                _TwitterID = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TwitterID");
                OnTwitterIDChanged();
            }
        }
        private global::System.String _TwitterID;
        partial void OnTwitterIDChanging(global::System.String value);
        partial void OnTwitterIDChanged();
    
        /// <summary>
        /// Aucune documentation sur les métadonnées n'est disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TwitterUsername
        {
            get
            {
                return _TwitterUsername;
            }
            set
            {
                OnTwitterUsernameChanging(value);
                ReportPropertyChanging("TwitterUsername");
                _TwitterUsername = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TwitterUsername");
                OnTwitterUsernameChanged();
            }
        }
        private global::System.String _TwitterUsername;
        partial void OnTwitterUsernameChanging(global::System.String value);
        partial void OnTwitterUsernameChanged();

        #endregion
    
    }

    #endregion
    
}
