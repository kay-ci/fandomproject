using System.Text.RegularExpressions;

namespace userInfo{
    public class User{
        public string? Username {get; set;}
        public Profile? UserProfile {get; set;}
        public UserMessage Messages {get; set;}

        public List<Event> Events {get;}
        
        //constructors
        public User(string userName, Profile userProfile, List<Event> events){
            Username = userName;
            UserProfile = userProfile;
            Events = events;
            Messages = new UserMessage(this);
        }
        public User(string userName, Profile userProfile){
            Username = userName;
            UserProfile = userProfile;
            Messages = new UserMessage(this);
        }

        //This method will allow a user to change their password
        public void ChangePassword(Login userManager, string newPassword){
            if (string.IsNullOrWhiteSpace(newPassword)){
                throw new ArgumentException("new password cannot be null");
            };
            
            // set the currenly logged in users password
        }

        //This method allows a user to change username
        public void ChangeUsername(Login userManager, string newUsername){
            if (string.IsNullOrWhiteSpace(Username)){
                throw new ArgumentException("new username cannot be null");
            }

            //check newUsername is 1 word (numbers allowed)
            Regex pattern = new Regex("[A-Za-Z0-9]");
            if (!pattern.IsMatch(newUsername)){
                throw new ArgumentException("Username can only be 1 word!");
            }

            //check that it doesnt match another username in database

            //set username
            userManager.CurrentUser.Username = newUsername;


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