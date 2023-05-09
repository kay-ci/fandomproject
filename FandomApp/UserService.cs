namespace UserInfo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

/// <summary>
/// Class <c>UserService</c> handles interactions with DbSets FandomUsers, FandomProfiles as well as user authentification.
/// </summary>
public class UserService{
    private static UserService? _instance;
    private FanAppContext _context = null!;
    public const int Iterations = 1000;
    private UserService(){}
    public static UserService getInstance(){
        if(_instance is null){
            _instance = new UserService();
        }
        return _instance;
    }
    public void setFanAppContext(FanAppContext context){
        _context = context;
    }
    /// <summary>
    /// Method <c>GetUsers</c> fetches all users from DbSet FandomUsers.
    /// </summary>
    public List<User> GetUsers(){
        List<User> usersList = _context.FandomUsers
            .Include(user => user.UserProfile)
            .Include(user => user.Fandoms)
            .Include(user => user.EventsAttending)
            .Include(user => user.Messages)
            .OrderBy(user => user.userID)
            .ToList<User>();
        return usersList;
    }
    /// <summary>
    /// Method <c>GetUser</c> returns a user with a given username.
    /// </summary> 
    public User? GetUser(string username){
        User fetcheduser;
        var query = from user in _context.FandomUsers
           where user.Username == username
           select user;
        try{
            fetcheduser = query.First<User>();}
        catch (Exception){
            return null;}
        return fetcheduser;
    }
    /// <summary>
    /// Method <c>UpdateUser</c> updates a user.
    /// </summary>
    public void UpdateUser(Login userManager, User UpdatedUser){
        if (userManager.CurrentUser != null){
        userManager.CurrentUser.UserProfile = UpdatedUser.UserProfile;
        userManager.CurrentUser.EventsAttending = UpdatedUser.EventsAttending;
        userManager.CurrentUser.Fandoms = UpdatedUser.Fandoms;
        _context.SaveChanges();}
    }
    /// <summary>
    /// Method <c>ChangePassword</c> updates a user's password, using their old password to authentificate.
    /// </summary>
    public void ChangePassword(Login userManager, string oldPassword, string newPassword){
        if (string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(oldPassword)){
            throw new ArgumentException("Password field cannot be null");}
        if (userManager.CurrentUser == null){
            throw new ArgumentException("Current user is null");} 
        //Validating current user's old password before allowing a new password
        if (!validPassword(userManager.CurrentUser, oldPassword)){
            throw new ArgumentException("Old password is not correct");
        }
        CreatePassword(userManager.CurrentUser, newPassword);
        _context.SaveChanges();
    }
    public void DeleteUser(Login UserManager){

    }
    /// <summary>
    /// Method <c>GetProfiles</c> fetches all profiles from the table DbSet FandomProfiles.
    /// </summary>
    public List<Profile> GetProfiles(){
        List<Profile> profilesList = _context.FandomProfiles
            .Include(profile => profile.Categories)
            .Include(profile => profile.Fandoms)
            .Include(profile => profile.Badges)
            .Include(profile => profile.user)
            .OrderBy(profile => profile.ProfileId)
            .ToList<Profile>();
        return profilesList;
    }
    /// <summary>
    /// Method <c>GetProfile</c> fetches a specific profile based on userId.
    /// </summary>
    public Profile GetProfile(User user){
        var query = from profile in _context.FandomProfiles
           where profile.user == user
           select profile;
        var fetchedProfile = query.First<Profile>();
        return fetchedProfile;
    }
    /// <summary>
    /// Method <c>UpdateProfile</c> updates the currently logged user's profile.
    /// </summary>
    public void UpdateProfile(Login userManager, Profile newProfile){
        if(userManager.CurrentUser == null){
            throw new ArgumentException("Current user is null");}
        if(userManager.CurrentUser.UserProfile == null){
          throw new ArgumentException("Current user profile is null");}  

        Profile currentProfile = userManager.CurrentUser.UserProfile; //added for readability
        currentProfile.Name = newProfile.Name;
        currentProfile.Pronouns = newProfile.Pronouns;
        currentProfile.Age = newProfile.Age;
        currentProfile.Country = newProfile.Country;
        currentProfile.City = newProfile.City;
        currentProfile.Description = newProfile.Description;
        currentProfile.Categories = newProfile.Categories;
        currentProfile.Fandoms = newProfile.Fandoms;
        currentProfile.Badges = newProfile.Badges;
        currentProfile.Picture = newProfile.Picture;
        currentProfile.Interests = newProfile.Interests;
        _context.SaveChanges();
    }
    /// <summary>
    /// Method <c>CreateUser</c> inserts a new user in the DbSet FandomUsers.
    /// </summary>
    public User CreateUser(string username, string password){
        User newUser;
        if(string.IsNullOrWhiteSpace(password)){
            throw new ArgumentNullException();
        }
        // Make sure username is not already taken
        User? checkUser = GetUser(username);
        if (checkUser != null){
            throw new ArgumentException("User with that username already exist");
        }
        else{
            Profile newProfile = new Profile("..name", "..pronouns", 0, "..country", "..city");
            newUser = new User(username, newProfile);
            CreatePassword(newUser, password);
            _context.FandomUsers.Add(newUser);
            _context.SaveChanges();
        }
        return newUser;
    }
    /// <summary>
    /// Method <c>LogIn</c> takes in a <param>username</param> and <param>password</param> to store the currently logged in user.
    /// </summary>
    public Login LogIn(string username, string password){
        User? currentUser = GetUser(username);
        if (currentUser == null){
            throw new ArgumentException("Invalid User, Create account");}

        if(validPassword(currentUser, password)){
            return new Login(currentUser);}
        else{
            throw new ArgumentException("Wrong credentials provided");}
    }
    /// <summary>
    /// Method <c>LogOff</c> sets the currently logged in user to null.
    /// </summary>
    public void LogOff(Login userManager){
        userManager.CurrentUser = null;
    }
    /// <summary>
    /// Method <c>LogIn</c> compares the logged in user's hash with <param>password</param>'s hash.
    /// </summary>
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
    /// <summary>
    /// Method <c>LogIn</c> creates a new password for a User.
    /// </summary>
    public void CreatePassword (User currentUser, string password){
        //creating hashed password
        byte[] salt = new byte[8];
        using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider()){
            rngCsp.GetBytes(salt);
        }
        Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, Iterations);
        byte[] hash = key.GetBytes(32);

        currentUser.Salt = salt;
        currentUser.Hash = hash;
    }
}
