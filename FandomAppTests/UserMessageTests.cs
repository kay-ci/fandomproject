namespace FandomAppTests;
using userInfo;

[TestClass]
public class UserMessageTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Creating_Messsage_Test_Fail1(){
        //Arrange
        List<string> categories = new List<string>();
        List<Fandom> fandoms = new List<Fandom>();
        List<string> badges = new List<string>();
        List<string> interests = new List<string>();
        List<Event> events = new List<Event>();
        Profile sender_prof = new Profile("Karekin Kiyici", "he/him", 22, "Canada", "Montreal", categories, fandoms, badges, "", interests);
        User sender = new User("kareking1", sender_prof, events);
    
        Profile receiver_prof1 = new Profile("mista", "he/him", 28, "Canada", "Montreal", categories, fandoms, badges, "", interests);
        User receiver = new User("Sex Pistols", receiver_prof1);    
        Profile receiver_prof2 = new Profile("Goffy", "he/him", 28, "Canada", "Montreal", categories, fandoms, badges, "", interests);
        User receiver2 = new User("Gaffy", receiver_prof2);
        Profile receiver_prof3 = new Profile("Teedus", "he/him", 28, "Canada", "Montreal", categories, fandoms, badges, "", interests);
        User receiver3 = new User("HA HA HA HA HA", receiver_prof3);
        
        //Should fail!
        string textTest1 = "";

        //Act
        List<User> recipients = new List<User>();
        recipients.Add(receiver);
        recipients.Add(receiver2);
        recipients.Add(receiver3);

        //Assert
        //This will automatically throw if text is no good!
        sender.Messages.CreateMessage(recipients, textTest1);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))] 
    public void Creating_Messsage_Test_Fail2(){
        //Arrange
        List<string> categories = new List<string>();
        List<Fandom> fandoms = new List<Fandom>();
        List<string> badges = new List<string>();
        List<string> interests = new List<string>();
        List<Event> events = new List<Event>();
        Profile sender_prof = new Profile("Karekin Kiyici", "he/him", 22, "Canada", "Montreal", categories, fandoms, badges, "", interests);
        User sender = new User("kareking1", sender_prof, events);
    
        Profile receiver_prof1 = new Profile("mista", "he/him", 28, "Canada", "Montreal", categories, fandoms, badges, "", interests);
        User receiver = new User("Sex Pistols", receiver_prof1);    
        Profile receiver_prof2 = new Profile("Goffy", "he/him", 28, "Canada", "Montreal", categories, fandoms, badges, "", interests);
        User receiver2 = new User("Gaffy", receiver_prof2);
        Profile receiver_prof3 = new Profile("Teedus", "he/him", 28, "Canada", "Montreal", categories, fandoms, badges, "", interests);
        User receiver3 = new User("HA HA HA HA HA", receiver_prof3);
        
        //Should also fail
        string textTest2 = "   ";

        //Act
        List<User> recipients = new List<User>();
        recipients.Add(receiver);
        recipients.Add(receiver2);
        recipients.Add(receiver3);

        //Assert
        //This will automatically throw if text is no good!
        sender.Messages.CreateMessage(recipients, textTest2);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))] 
    public void Creating_Messsage_Test_Fail3(){
        //Arrange
        List<string> categories = new List<string>();
        List<Fandom> fandoms = new List<Fandom>();
        List<string> badges = new List<string>();
        List<string> interests = new List<string>();
        List<Event> events = new List<Event>();
        Profile sender_prof = new Profile("Karekin Kiyici", "he/him", 22, "Canada", "Montreal", categories, fandoms, badges, "", interests);
        User sender = new User("kareking1", sender_prof, events);
    
        Profile receiver_prof1 = new Profile("mista", "he/him", 28, "Canada", "Montreal", categories, fandoms, badges, "", interests);
        User receiver = new User("Sex Pistols", receiver_prof1);    
        Profile receiver_prof2 = new Profile("Goffy", "he/him", 28, "Canada", "Montreal", categories, fandoms, badges, "", interests);
        User receiver2 = new User("Gaffy", receiver_prof2);
        Profile receiver_prof3 = new Profile("Teedus", "he/him", 28, "Canada", "Montreal", categories, fandoms, badges, "", interests);
        User receiver3 = new User("HA HA HA HA HA", receiver_prof3);
        
        //Should also fail
        string textTest3 = null;

        //Act
        List<User> recipients = new List<User>();
        recipients.Add(receiver);
        recipients.Add(receiver2);
        recipients.Add(receiver3);

        //Assert
        //This will automatically throw if text is no good!
        sender.Messages.CreateMessage(recipients, textTest3);
    }

    [TestMethod]
    public void Creating_Messsage_Test_Succeed(){
        //Arrange
        List<string> categories = new List<string>();
        List<Fandom> fandoms = new List<Fandom>();
        List<string> badges = new List<string>();
        List<string> interests = new List<string>();
        List<Event> events = new List<Event>();
        Profile sender_prof = new Profile("Karekin Kiyici", "he/him", 22, "Canada", "Montreal", categories, fandoms, badges, "", interests);
        User sender = new User("kareking1", sender_prof, events);
    
        Profile receiver_prof1 = new Profile("mista", "he/him", 28, "Canada", "Montreal", categories, fandoms, badges, "", interests);
        User receiver = new User("Sex Pistols", receiver_prof1);    
        Profile receiver_prof2 = new Profile("Goffy", "he/him", 28, "Canada", "Montreal", categories, fandoms, badges, "", interests);
        User receiver2 = new User("Gaffy", receiver_prof2);
        Profile receiver_prof3 = new Profile("Teedus", "he/him", 28, "Canada", "Montreal", categories, fandoms, badges, "", interests);
        User receiver3 = new User("HA HA HA HA HA", receiver_prof3);
        
        //Should succeed!
        string textTest4 = "blahh sjefjhsifseji blahhh";

        //Act
        List<User> recipients = new List<User>();
        recipients.Add(receiver);
        recipients.Add(receiver2);
        recipients.Add(receiver3);

        //Assert
        //This will automatically throw if text is no good!
        sender.Messages.CreateMessage(recipients, textTest4);
    }
}