using Microsoft.EntityFrameworkCore;
using Moq;
using UserInfo;
namespace FandomAppTests;

[TestClass]
public class MessageServiceTests{
    [TestMethod]
    public void Get_Inbox_Test_Succeed(){
        //Arrange
        var recipients = new List<UserMessage>();
        recipients.Add(new UserMessage(new User("KayciUsername", new Profile("Kayci", "she/her", 19, "Canada", "Montreal"))));
        recipients.Add(new UserMessage(new User("liliUsername", new Profile("Lili", "they/them", 20, "Ireland", "Dublin"))));
        recipients.Add(new UserMessage(new User("bestUser", new Profile("Jim", "he/him", 16, "Canada", "Laval"))));


        User sender = new User("kare", new Profile("Karekin", "he/him", 22, "Canada", "Montreal"));
        var recipients2 = new List<UserMessage>();
        recipients2.Add(recipients[1]);
        var recipients3 = new List<UserMessage>();
        recipients3.Add(recipients[2]);
        sender.Messages.CreateMessage("test", "testTitle", recipients);
        sender.Messages.CreateMessage("test2", "test2Title", null, recipients[1]);
        sender.Messages.CreateMessage("test3", "test3Title", null, recipients[2]);

        var data = recipients.AsQueryable();

        var mockSet = new Mock<DbSet<UserMessage>>();
        mockSet.As<IQueryable<UserMessage>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<UserMessage>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<UserMessage>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<UserMessage>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.FandomUserMessages).Returns(mockSet.Object);

        var service = MessageService.getInstance();
        service.setFanAppContext(mockContext.Object);

        //Act
        var Inbox_Test = new List<Message>();
        Inbox_Test = service.GetBox(recipients[2].Owner, true);

        //Assert
        Assert.AreEqual("test3", Inbox_Test[1].Text);
    }

    [TestMethod]
    public void Get_Outbox_Test_Succeed(){
        //Arrange
        var recipients = new List<UserMessage>();
        recipients.Add(new UserMessage(new User("KayciUsername", new Profile("Kayci", "she/her", 19, "Canada", "Montreal"))));
        recipients.Add(new UserMessage(new User("liliUsername", new Profile("Lili", "they/them", 20, "Ireland", "Dublin"))));
        recipients.Add(new UserMessage(new User("bestUser", new Profile("Jim", "he/him", 16, "Canada", "Laval"))));

        User sender = new User("kare", new Profile("Karekin", "he/him", 22, "Canada", "Montreal"));
        sender.Messages.CreateMessage("test", "testTitle", recipients);
        sender.Messages.CreateMessage("test2", "test2Title", null, recipients[1]);
        sender.Messages.CreateMessage("test3", "test3Title", null, recipients[2]);

        recipients.Add(sender.Messages);

        var data = recipients.AsQueryable();

        var mockSet = new Mock<DbSet<UserMessage>>();
        mockSet.As<IQueryable<UserMessage>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<UserMessage>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<UserMessage>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<UserMessage>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.FandomUserMessages).Returns(mockSet.Object);

        var service = MessageService.getInstance();
        service.setFanAppContext(mockContext.Object);

        //Act
        var Outbox_Test = new List<Message>();
        Outbox_Test = service.GetBox(sender, false);

        //Assert
        Assert.AreEqual("test3", Outbox_Test[2].Text);
    }

    [TestMethod]
    public void Get_Message_Test_Succeed(){
        //Arrange
        var sender = new User("KayciUsername", new Profile("Kayci", "she/her", 19, "Canada", "Montreal"));
        var receiver1 = new User("liliUsername", new Profile("Lili", "they/them", 20, "Ireland", "Dublin"));
        var receiver2 = new User("bestUser", new Profile("Jim", "he/him", 16, "Canada", "Laval"));
        var recipients = new List<UserMessage>();
        recipients.Add(receiver1.Messages);
        recipients.Add(receiver2.Messages);

        var listdata = new List<Message>();
        listdata.Add(new Message(sender.Messages, recipients, "text1", "title1"));
        listdata.Add(new Message(sender.Messages, recipients, "text2", "title2"));
        listdata.Add(new Message(sender.Messages, recipients, "text3", "title3"));

        var data = listdata.AsQueryable();

        var mockSet = new Mock<DbSet<Message>>();
        mockSet.As<IQueryable<Message>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Message>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Message>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Message>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.FandomMessages).Returns(mockSet.Object);

        var service = MessageService.getInstance();
        service.setFanAppContext(mockContext.Object);

        //Act
        var msg_expectation = new Message(sender.Messages, recipients, "text1", "title1");
        var msg_actual = service.GetMessage(msg_expectation);

        //Assert
        Assert.AreEqual(msg_expectation, msg_actual);
    }

    [TestMethod]
    public void Get_UserMessage_Test_Succeed(){
        //Arrange
        var recipients = new List<User>();
        recipients.Add(new User("KayciUsername", new Profile("Kayci", "she/her", 19, "Canada", "Montreal")));
        recipients.Add(new User("liliUsername", new Profile("Lili", "they/them", 20, "Ireland", "Dublin")));
        recipients.Add(new User("bestUser", new Profile("Jim", "he/him", 16, "Canada", "Laval")));

        var data = recipients.AsQueryable();

        var mockSet = new Mock<DbSet<User>>();
        mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.FandomUsers).Returns(mockSet.Object);

        var service = MessageService.getInstance();
        service.setFanAppContext(mockContext.Object);

        //Act
        var usr = new User("KayciUsername", new Profile("Kayci", "she/her", 19, "Canada", "Montreal"));
        var umsg_expectation = usr.Messages;
        var umsg_actual = service.GetUserMessage(recipients[0]);

        //Assert
        Assert.AreEqual(umsg_actual, umsg_expectation); //Cant complete now....
    }

    [TestMethod]
    public void Add_Message_Test_Succeed(){
        //Arrange
        var sender = new User("KayciUsername", new Profile("Kayci", "she/her", 19, "Canada", "Montreal"));
        var receiver1 = new User("liliUsername", new Profile("Lili", "they/them", 20, "Ireland", "Dublin"));
        var receiver2 = new User("bestUser", new Profile("Jim", "he/him", 16, "Canada", "Laval"));
        var recipients = new List<UserMessage>();
        recipients.Add(receiver1.Messages);
        recipients.Add(receiver2.Messages);

        var listdata = new List<Message>();
        listdata.Add(new Message(sender.Messages, recipients, "text1", "title1"));
        listdata.Add(new Message(sender.Messages, recipients, "text2", "title2"));
        listdata.Add(new Message(sender.Messages, recipients, "text3", "title3"));

        var data = listdata.AsQueryable();

        var mockSet = new Mock<DbSet<Message>>();
        mockSet.As<IQueryable<Message>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Message>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Message>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Message>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.FandomMessages).Returns(mockSet.Object);

        var service = MessageService.getInstance();
        service.setFanAppContext(mockContext.Object);

        //Act
        var new_msg = new Message(sender.Messages, recipients, "text0", "title0");
        service.Add_Message(new_msg);

        //Assertt
        mockSet.Verify(m => m.Add(It.IsAny<Message>()), Times.Once());
        mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }

    [TestMethod]
    public void Delete_Message_Test_Succeed(){
        //Arrange
        var sender = new User("KayciUsername", new Profile("Kayci", "she/her", 19, "Canada", "Montreal"));
        var receiver1 = new User("liliUsername", new Profile("Lili", "they/them", 20, "Ireland", "Dublin"));
        var receiver2 = new User("bestUser", new Profile("Jim", "he/him", 16, "Canada", "Laval"));
        var recipients = new List<UserMessage>();
        recipients.Add(receiver1.Messages);
        recipients.Add(receiver2.Messages);

        var listdata = new List<Message>();
        listdata.Add(new Message(sender.Messages, recipients, "text1", "title1"));
        listdata.Add(new Message(sender.Messages, recipients, "text2", "title2"));
        listdata.Add(new Message(sender.Messages, recipients, "text3", "title3"));

        var data = listdata.AsQueryable();

        var mockSet = new Mock<DbSet<Message>>();
        mockSet.As<IQueryable<Message>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Message>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Message>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Message>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.FandomMessages).Returns(mockSet.Object);

        var service = MessageService.getInstance();
        service.setFanAppContext(mockContext.Object);

        //Act
        service.Delete_Message(listdata[0]);

        //Assert
        mockSet.Verify(m => m.Remove(It.IsAny<Message>()), Times.Once());
        mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }

    [TestMethod]
    public void Edit_Message_Test_Succeed(){
        //Arrange
        var sender = new User("KayciUsername", new Profile("Kayci", "she/her", 19, "Canada", "Montreal"));
        var receiver1 = new User("liliUsername", new Profile("Lili", "they/them", 20, "Ireland", "Dublin"));
        var receiver2 = new User("bestUser", new Profile("Jim", "he/him", 16, "Canada", "Laval"));
        var recipients = new List<UserMessage>();
        recipients.Add(receiver1.Messages);
        recipients.Add(receiver2.Messages);

        var listdata = new List<Message>();
        listdata.Add(new Message(sender.Messages, recipients, "text1", "title1"));
        listdata.Add(new Message(sender.Messages, recipients, "text2", "title2"));
        listdata.Add(new Message(sender.Messages, recipients, "text3", "title3"));

        var data = listdata.AsQueryable();

        var mockSet = new Mock<DbSet<Message>>();
        mockSet.As<IQueryable<Message>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Message>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Message>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Message>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.FandomMessages).Returns(mockSet.Object);

        var service = MessageService.getInstance();
        service.setFanAppContext(mockContext.Object);

        //Act
        service.Edit_Message(listdata[0], "blah", "new_title");
        var msg_expectation = new Message(sender.Messages, recipients, "blah", "new_title");
        var msg_actual = service.GetMessage(msg_expectation);

        //Assert
        Assert.AreEqual(msg_actual, msg_expectation);
    }
}