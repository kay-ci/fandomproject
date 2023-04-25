namespace UserInfo;
using UserInfo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class UserService{
    private static UserService? _instance;
    private FanAppContext _context = null!;
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
            .Include(user => user.Profile)
            .Include(user => user.Fandom)
            .Include(user => user.Event)
            .OrderBy(user => user.userID)
            .ToList<User>();
    }
    public User GetUser(int id){}
    public Login AddUser(){}
    public void UpdateUser(Login currentUser){}
    public Profile GetProfile(int userId){}
    public void AddProfile(int id){}
    public void UpdateProfile(){}

    public void Login(Login currentUser){}
    public void Logoff(){}
}
