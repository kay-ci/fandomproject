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
    public void setLibraryContext(FanAppContext context){
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
    public User GetUser(string username){
        var query = from user in _context.FandomUsers
           where user.Username == username
           select user;
        var fetcheduser = query.First<User>();
        return fetcheduser;
    }
    public void createAccount(string username, string password){
        byte[] salt = new byte[8];
        using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider()){
            rngCsp.GetBytes(salt);
        }
        Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, Iterations);
        byte[] hash = key.GetBytes(32);

        Profile newProfile = new Profile("..name", "..pronouns", 0, "..country", "..city");
        //add validation make sure username is unique
        User newUser = new User(username, newProfile);
        newUser.Salt = salt;
        newUser.Hash = hash;
        _context.FandomUsers.Add(newUser);
        _context.SaveChanges();
    }
    public Login LogIn(string username, string password){
        User currentUser;
        try{
            currentUser = GetUser(username);}
        catch{
            throw new ArgumentException("Invalid User, Create account");}
        //getting hash of password input
        Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, currentUser.Salt, Iterations);
        byte[] hash = key.GetBytes(32);
        //comparing hashes 
        if(currentUser.Hash == hash){
            return new Login(currentUser);
        }
        else throw new ArgumentException("Wrong credentials provided");
    }
    // public void UpdateUser(Login currentUser){}
    // public Profile GetProfile(int userId){}
    // public void AddProfile(int id){}
    // public void UpdateProfile(){}
    // public void Logoff(){}
}
