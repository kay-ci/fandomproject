namespace UserInfo;
public class Mock {
    public Profile Profile1;
    public User User1;
    public Mock (){
        Profile1 = new Profile("Fred", "", 20 ,"Canada", "Montreal");
        User1 = new User ("fredd_the_best", Profile1);
    }
}
