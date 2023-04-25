using UserInfo;
public class UserManager{
    //this class will handle interactions relating to Users in the database.

    public User CurrentUser;
    public UserManager(User currentUser){
        CurrentUser = currentUser;
    }
    //This method fetches events for a given user
        public void GetEvents(){
            
        }

        //Database function that will delete the current logged in user
        public void DeleteUser(Login userManager){
            //delete user from database
        }
}