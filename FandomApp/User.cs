using System.Text.RegularExpressions;

namespace userInfo{
    public class User{
        public string? UserName {get; set;}
        public Profile? UserProfile {get; set;}
        public UserMessage Messages {get; set;}

        public List<Event> Events {get;}
        
        //constructor
        public User(string userName, Profile userProfile, List<Event> events){
            UserName = userName;
            UserProfile = userProfile;
            Events = events;
            Messages = new UserMessage(this);
        }
        public User(string userName, Profile userProfile){
            UserName = userName;
            UserProfile = userProfile;
            Messages = new UserMessage(this);
        }

        //This method will allow a user to change their password
        public void ChangePassword(Login user, string newPassword){
            
        }

        //This method allows a user to change username
        public void ChangeUsername(){

        }

        //This method fetches events a user is a part of 
        public void GetEvents(){

        }

        public override string ToString()
        {
            return this.ToString();
        }
    }
}