namespace UserInfo;
using UserInfo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
public class UserService{
    private static UserService? _instance;
    private FanAppContext _context = null!;
    public const int Iterations = 1000;
    private UserService(){
    }
    
    public static UserService getInstance(){
        if(_instance is null){
            _instance = new UserService();
        }
        return _instance;
    }

// Do not forget to set context in the class using this service
    public void setFanAppContext(FanAppContext context){
        _context = context;
    }
    public List<User> GetUsers(){
        List<User> userList = _context.FandomUsers
            .Include(user => user.UserProfile)
            .Include(user => user.Fandoms)
            .Include(user => user.Events)
            .Include(user => user.Messages)
            .OrderBy(user => user.userID)
            .ToList<User>();
        return userList;
    }
    // This method returns a user with a given username 
    public User? GetUser(string username){
        User fetcheduser;
        var query = from user in _context.FandomUsers
           where user.Username == username
           select user;
        try{
            fetcheduser = query.First<User>();}
        catch (InvalidOperationException){
            return null;}
        return fetcheduser;
    }
    // This method inserts a new user in the FandomUsers table
    public void CreateUser(string username, string password){
        if(string.IsNullOrWhiteSpace(password)){
            throw new ArgumentNullException();
        }
        //creatign hashed password
        byte[] salt = new byte[8];
        using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider()){
            rngCsp.GetBytes(salt);
        }
        Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, Iterations);
        byte[] hash = key.GetBytes(32);

        Profile newProfile = new Profile("..name", "..pronouns", 0, "..country", "..city");
    
        //making sure username is unique
        User? checkUser = GetUser(username);
        if (checkUser != null){
            throw new ArgumentException("User with that username already exist");
        }
        else{
            User newUser = new User(username, newProfile);
            newUser.Salt = salt;
            newUser.Hash = hash;
            _context.FandomUsers.Add(newUser);
            _context.SaveChanges();
        }
    }
    public Login LogIn(string username, string password){
        User? currentUser = GetUser(username);
        if (currentUser == null){
            throw new ArgumentException("Invalid User, Create account");}

        if(validPassword(currentUser, password)){
            return new Login(currentUser);}
        else{
            throw new ArgumentException("Wrong credentials provided");}
    }
    public void Logoff(Login userManager){
        userManager.CurrentUser = null;
    }
    public void UpdateUser(Login userManager, User UpdatedUser){
        if (userManager.CurrentUser != null){
        userManager.CurrentUser.UserProfile = UpdatedUser.UserProfile;
        userManager.CurrentUser.Events = UpdatedUser.Events;
        userManager.CurrentUser.Fandoms = UpdatedUser.Fandoms;
        _context.SaveChanges();}
    }
    public Profile GetProfile(int userId){
        var query = from profile in _context.FandomProfiles
           where profile.userID == userId
           select profile;
        var fetchedProfile = query.First<Profile>();
        return fetchedProfile;
    }
    //This method will allow a user to change their password
        public void ChangePassword(Login userManager, string newPassword){
            if (string.IsNullOrWhiteSpace(newPassword)){
                throw new ArgumentException("new password cannot be null");
            };
            
            // set the currenly logged in users password
        }
    // public void UpdateProfile(){}
    
    // This helper method compares the logged in user's hash with the password's hash
    public bool validPassword (User currentUser, string password){
        //hashing password
        Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, currentUser.Salt, Iterations);
        byte[] hash = key.GetBytes(32);

        //comparing with the username's hash 
        if(currentUser.Hash.SequenceEqual(hash)){
            return true;
        }
        return false;
    }
}
