using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace UserInfo{
    public class User{
        public int userID {get; set;}
        private string _username; 
        public string? Username {
            get{ return _username; } 
            set{
                if (!IsValidUsername(value)){
                    throw new ArgumentException("Username should contain only 1 word");
                }
                _username = value;
            }
        }
        public Profile? UserProfile {get; set;}

        //Messages properties of user
        [InverseProperty("Recipients")]
        public List<Message> Inbox {get; set;} = new();

        [InverseProperty("Sender")]
        public List<Message> Outbox {get; set;} = new();

        //Events properties of user
        [InverseProperty("Owner")]
        public List<Event> EventsCreated {get; set;} = new();
        
        [InverseProperty("Attendees")]
        public List<Event> EventsAttending {get; set;} = new();

        public List<Fandom> Fandoms {get; set;} = new();
        public byte[] Salt {get; set;}
        public byte[] Hash {get; set;}
        
        private User(){}
        //constructors
        public User(string userName, Profile userProfile, List<Event> events){
            if (!IsValidUsername(userName)){
                throw new ArgumentException("Username should contain only 1 word");
            }
            Username = userName;
            UserProfile = userProfile;
            EventsAttending = events;
           // Messages = new UserMessage(this);
            
        }
        public User(string userName, Profile userProfile){
            if (!IsValidUsername(userName)){
                throw new ArgumentException("Username should contain only 1 word");
            }

            Username = userName;
            UserProfile = userProfile;
            EventsAttending = new List<Event>();
        }


        //this method basically send the message by adding it to the Outbox and Marking the message as sent
        public void SendMessage(Message message)
        {
            if (message.Sender != this){
                throw new ArgumentException("The user is not the message's sender. Can't add to Outbox");
            }
            message.Sent = true;
            this.Outbox?.Add(message);
        }

        public bool IsValidUsername(string username){
            if (string.IsNullOrWhiteSpace(username)){
                return false;
            }
            //check newUsername is 1 word (numbers allowed)
            Regex pattern = new Regex("^[A-Za-z0-9]+$");
            if (!pattern.IsMatch(username)){
                return false;
            }
            
            return true;
            
        }
        public override bool Equals(object obj){
            var item = obj as User;
            if(ReferenceEquals(item, this)){
                return true;
            }
            if(item == null){
                return false;
            }
            return (
                this.Username == item.Username &&
                this.UserProfile == item.UserProfile &&
                this.Inbox == item.Inbox &&
                this.EventsAttending.SequenceEqual(item.EventsAttending) &&
                this.Fandoms.SequenceEqual(item.Fandoms) &&
                this.Hash.SequenceEqual(item.Hash) &&
                this.Salt.SequenceEqual(item.Salt));
        }
    }
}