using UserInfo;
namespace FandomAppTests;

[TestClass]
    public class MessageTests{
        [TestMethod]
        public void Equals_Method_Single_Recipient_Test_Succeed(){
            //Arrange
            Profile sender_prof = new Profile("KarekinKiyici", "he/him", 22, "Canada", "Montreal");
            User sender = new User("kareking", sender_prof);
        
            Profile receiver_prof = new Profile("mista", "he/him", 28, "Canada", "Montreal");
            User receiver = new User("SexPistols", receiver_prof);    
            string title = "test titleeeeeeeeeeeeeee";
            string textTest4 = "blahh sjefjhsifseji blahhh";

            //Act
            Message msg = new Message(sender.Messages, receiver.Messages, textTest4, title);
            Message msg2 = new Message(sender.Messages, receiver.Messages, textTest4, title);

            //Assert
            Assert.IsTrue(msg.Equals(msg2));
        }

        [TestMethod]
        public void Equals_Method_Recipients_Test_Succeed(){
            //Arrange
            Profile sender_prof = new Profile("KarekinKiyici", "he/him", 22, "Canada", "Montreal");
            User sender = new User("kareking", sender_prof);
        
            Profile receiver_prof = new Profile("mista", "he/him", 28, "Canada", "Montreal");
            User receiver = new User("SexPistols", receiver_prof);    
            Profile receiver_prof2 = new Profile("mista", "he/him", 28, "Canada", "Montreal");
            User receiver2 = new User("SexPistols", receiver_prof);  
            Profile receiver_prof3 = new Profile("mista", "he/him", 28, "Canada", "Montreal");
            User receiver3 = new User("SexPistols", receiver_prof);  
            Profile receiver_prof4 = new Profile("mista", "he/him", 28, "Canada", "Montreal");
            User receiver4 = new User("SexPistols", receiver_prof);  
            Profile receiver_prof5 = new Profile("mista", "he/him", 28, "Canada", "Montreal");
            User receiver5 = new User("SexPistols", receiver_prof);  
            Profile receiver_prof6 = new Profile("mista", "he/him", 28, "Canada", "Montreal");
            User receiver6 = new User("SexPistols", receiver_prof);
            List<UserMessage> recipients = new List<UserMessage>();
            recipients.Add(receiver.Messages);
            recipients.Add(receiver2.Messages);
            recipients.Add(receiver3.Messages);
            recipients.Add(receiver4.Messages);
            recipients.Add(receiver5.Messages);
            recipients.Add(receiver6.Messages);
            string title = "test titleeeeeeeeeeeeeee";
            string textTest4 = "blahh sjefjhsifseji blahhh";

            //Act
            Message msg = new Message(sender.Messages, recipients, textTest4, title);
            Message msg2 = new Message(sender.Messages, recipients, textTest4, title);

            //Assert
            Assert.IsTrue(msg.Equals(msg2));
        }
    }