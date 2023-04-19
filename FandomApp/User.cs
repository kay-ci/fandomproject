using System.Text.RegularExpressions;

namespace UserInfo{
    public class User{
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
        public UserMessage Messages {get; set;}

        public List<Event> Events {get;}
        
        //constructors
        public User(string userName, Profile userProfile, List<Event> events){
            if (!IsValidUsername(userName)){
                throw new ArgumentException("Username should contain only 1 word");
            }
            Username = userName;
            UserProfile = userProfile;
            Events = events;
            Messages = new UserMessage(this);
        }
        public User(string userName, Profile userProfile){
            if (!IsValidUsername(userName)){
                throw new ArgumentException("Username should contain only 1 word");
            }

            Username = userName;
            UserProfile = userProfile;
            Messages = new UserMessage(this);
            Events = new List<Event>();
        }

        //This method will allow a user to change their password
        public void ChangePassword(Login userManager, string newPassword){
            if (string.IsNullOrWhiteSpace(newPassword)){
                throw new ArgumentException("new password cannot be null");
            };
            
            // set the currenly logged in users password
        }

        //This method fetches events a user is a part of using query
        public void GetEvents(){

        }

        //Database function that will delete the current logged in user
        public void DeleteUser(Login userManager){
            //delete user from database
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
    }
}