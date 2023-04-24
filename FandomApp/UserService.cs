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

    public void setLibraryContext(FanAppContext context){
        _context = context;
    }

}
