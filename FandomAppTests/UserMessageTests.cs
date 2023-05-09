namespace FandomAppTests;
using UserInfo;

[TestClass]
public class UserMessageTests{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Creating_Messsage_Test_Fail1(){
        //Arrange
        Profile sender_prof = new Profile("KarekinKiyici", "he/him", 22, "Canada", "Montreal");
        User sender = new User("kareking", sender_prof);
    
        Profile receiver_prof1 = new Profile("mista", "he/him", 28, "Canada", "Montreal");
        User receiver = new User("SexPistols", receiver_prof1);    
        Profile receiver_prof2 = new Profile("Goffy", "he/him", 28, "Canada", "Montreal");
        User receiver2 = new User("Gaffy", receiver_prof2);
        Profile receiver_prof3 = new Profile("Teedus", "he/him", 28, "Canada", "Montreal");
        User receiver3 = new User("HAHA", receiver_prof3);
        
        //Should fail!
        string textTest1 = "";

        //Act
        List<UserMessage> recipients = new List<UserMessage>();
        recipients.Add(receiver.Messages);
        recipients.Add(receiver2.Messages);
        recipients.Add(receiver3.Messages);
        //This will automatically throw if text is no good!
        sender.Messages.CreateMessage(textTest1, "test title, doesn't matter yet", recipients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))] 
    public void Creating_Messsage_Test_Fail2(){
        //Arrange
        Profile sender_prof = new Profile("KarekinKiyici", "he/him", 22, "Canada", "Montreal");
        User sender = new User("kareking", sender_prof);
    
        Profile receiver_prof1 = new Profile("mista", "he/him", 28, "Canada", "Montreal");
        User receiver = new User("SexPistols", receiver_prof1);    
        Profile receiver_prof2 = new Profile("Goffy", "he/him", 28, "Canada", "Montreal");
        User receiver2 = new User("Gaffy", receiver_prof2);
        Profile receiver_prof3 = new Profile("Teedus", "he/him", 28, "Canada", "Montreal");
        User receiver3 = new User("HAHA", receiver_prof3);
        
        //Should also fail
        string textTest2 = "   ";

        //Act
        List<UserMessage> recipients = new List<UserMessage>();
        recipients.Add(receiver.Messages);
        recipients.Add(receiver2.Messages);
        recipients.Add(receiver3.Messages);
        //This will automatically throw if text is no good!
        sender.Messages.CreateMessage(textTest2, "test title, doesn't matter yet", recipients);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))] 
    public void Creating_Messsage_Test_Fail3(){
        //Arrange
        Profile sender_prof = new Profile("KarekinKiyici", "he/him", 22, "Canada", "Montreal");
        User sender = new User("kareking", sender_prof);
    
        Profile receiver_prof1 = new Profile("mista", "he/him", 28, "Canada", "Montreal");
        User receiver = new User("SexPistols", receiver_prof1);    
        Profile receiver_prof2 = new Profile("Goffy", "he/him", 28, "Canada", "Montreal");
        User receiver2 = new User("Gaffy", receiver_prof2);
        Profile receiver_prof3 = new Profile("Teedus", "he/him", 28, "Canada", "Montreal");
        User receiver3 = new User("HAHA", receiver_prof3);
        
        //Should also fail
        string? textTest3 = null;

        //Act
        List<UserMessage> recipients = new List<UserMessage>();
        recipients.Add(receiver.Messages);
        recipients.Add(receiver2.Messages);
        recipients.Add(receiver3.Messages);
        //This will automatically throw if text is no good!
        sender.Messages.CreateMessage(textTest3, "test title, doesn't matter yet", recipients);
    }

    [TestMethod]
    public void Creating_Message_Then_Read_Message_Test_Succeed(){
        //Arrange
        Profile sender_prof = new Profile("KarekinKiyici", "he/him", 22, "Canada", "Montreal");
        User sender = new User("kareking", sender_prof);
    
        Profile receiver_prof1 = new Profile("mista", "he/him", 28, "Canada", "Montreal");
        User receiver = new User("SexPistols", receiver_prof1);    
        Profile receiver_prof2 = new Profile("Goffy", "he/him", 28, "Canada", "Montreal");
        User receiver2 = new User("Gaffy", receiver_prof2);
        Profile receiver_prof3 = new Profile("Teedus", "he/him", 28, "Canada", "Montreal");
        User receiver3 = new User("HAHA", receiver_prof3);

        
        //Should succeed!
        string textTest4 = "blahh sjefjhsifseji blahhh";

        //Act
        List<UserMessage> recipients = new List<UserMessage>();
        recipients.Add(receiver.Messages);
        recipients.Add(receiver2.Messages);
        recipients.Add(receiver3.Messages);

        //Assert
        sender.Messages.CreateMessage(textTest4, "test title, doesn't matter yet", null, receiver.Messages);
        StringAssert.Equals(receiver.Messages.ReadMessage(0), textTest4);
    }
}