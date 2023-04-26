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
        sender.Messages.CreateMessage(listdata, "test", "testTitle");
        sender.Messages.CreateMessage(new List<UserMessage>(listdata[1]), "test2", "test2Title");
        sender.Messages.CreateMessage(listdata, "test3", "test3Title");

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
        
    }

    
}