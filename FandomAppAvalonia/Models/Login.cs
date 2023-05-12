using UserInfo;
using Microsoft.EntityFrameworkCore;

public class Login {

    public User? CurrentUser{get;set;}

    public Login(User CurrentUser){
        this.CurrentUser = CurrentUser;
    }

    public Login(){
    }

}
