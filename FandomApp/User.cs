namespace userInfo{
    public class User{
        string? UserName {get; set;}
        Profile? UserProfile {get; set;}
        List<UserMessage>? Messages {get; set;}

        List<Event> Events {get;}
        
        //constructor
        public User(string userName, Profile userProfile, List<UserMessage> messages, List<Event> events){
            UserName = userName;
            UserProfile = userProfile;
            Messages = messages;
            Events = events;
        }
        //This method adds a user to the database
        public void RegisterAccount(User user){
            
        }
        //This method will allow a user to change their password
        public void ChangePassword(){
            
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