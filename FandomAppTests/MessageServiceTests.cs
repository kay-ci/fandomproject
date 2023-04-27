using Microsoft.EntityFrameworkCore;
using Moq;
using UserInfo;
namespace FandomAppTests;

[TestClass]
public class MessageServiceTests{
    [TestMethod]
    public void Get_Inbox_Test_Succeed(){
        //Arrange
        var listdata = new List<UserMessage>();
        listdata.Add(new UserMessage(new User("KayciUsername", new Profile("Kayci", "she/her", 19, "Canada", "Montreal"))));
        listdata.Add(new UserMessage(new User("liliUsername", new Profile("Lili", "they/them", 20, "Ireland", "Dublin"))));
        listdata.Add(new UserMessage(new User("bestUser", new Profile("Jim", "he/him", 16, "Canada", "Laval"))));


        User sender = new User("kare", new Profile("Karekin", "he/him", 22, "Canada", "Montreal"));
        var recipients2 = new List<UserMessage>();
        recipients2.Add(listdata[1]);
        var recipients3 = new List<UserMessage>();
        recipients3.Add(listdata[2]);
        sender.Messages.CreateMessage(listdata, "test", "testTitle");
        sender.Messages.CreateMessage(recipients2, "test2", "test2Title");
        sender.Messages.CreateMessage(recipients3, "test3", "test3Title");

        var data = listdata.AsQueryable();

        var mockSet = new Mock<DbSet<UserMessage>>();
        mockSet.As<IQueryable<UserMessage>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<UserMessage>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<UserMessage>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<UserMessage>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.FandomUserMessages).Returns(mockSet.Object);

        var service = MessageService.getInstance();
        service.setLibraryContext(mockContext.Object);

        //Act
        var Inbox_Test = new List<Message>();
        Inbox_Test = service.GetBox(listdata[1].user, true);

        //Assert
        Assert.AreEqual("test2", Inbox_Test[1].Text);
    }

    [TestMethod]
    public void Get_Outbox_Test_Succeed(){
        //Arrange
        var listdata = new List<UserMessage>();
        listdata.Add(new UserMessage(new User("KayciUsername", new Profile("Kayci", "she/her", 19, "Canada", "Montreal"))));
        listdata.Add(new UserMessage(new User("liliUsername", new Profile("Lili", "they/them", 20, "Ireland", "Dublin"))));
        listdata.Add(new UserMessage(new User("bestUser", new Profile("Jim", "he/him", 16, "Canada", "Laval"))));

        User sender = new User("kare", new Profile("Karekin", "he/him", 22, "Canada", "Montreal"));
        var recipients2 = new List<UserMessage>();
        recipients2.Add(listdata[1]);
        var recipients3 = new List<UserMessage>();
        recipients3.Add(listdata[2]);
        sender.Messages.CreateMessage(listdata, "test", "testTitle");
        sender.Messages.CreateMessage(recipients2, "test2", "test2Title");
        sender.Messages.CreateMessage(recipients3, "test3", "test3Title");

        listdata.Add(sender.Messages);

        var data = listdata.AsQueryable();

        var mockSet = new Mock<DbSet<UserMessage>>();
        mockSet.As<IQueryable<UserMessage>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<UserMessage>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<UserMessage>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<UserMessage>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.FandomUserMessages).Returns(mockSet.Object);

        var service = MessageService.getInstance();
        service.setLibraryContext(mockContext.Object);

        //Act
        var Outbox_Test = new List<Message>();
        Outbox_Test = service.GetBox(sender.Messages.user, false);

        //Assert
        Assert.AreEqual("test3", Outbox_Test[2].Text);
    }

    
}