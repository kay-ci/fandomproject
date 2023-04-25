using UserInfo;
using Microsoft.EntityFrameworkCore;

public class Login {

    public User CurrentUser;

    public Login(User CurrentUser){
        this.CurrentUser = CurrentUser;
    }

}
