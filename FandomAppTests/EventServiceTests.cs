using UserInfo;
using Moq;
using Microsoft.EntityFrameworkCore;
namespace FandomAppTests;

[TestClass]
public class EventServiceTests{
    [TestMethod]
    public void CreateEvent_NewEvent()
    {
        //Arrange
        Profile owner_profile = new Profile("Owner", "they/them", 21, "Canada", "Montreal", new List<Category>(),  new List<Fandom>(), new List<Badge>(), "description", "pictures", "interests");
        User owner = new User("Owner", owner_profile);

        Event event_test = new Event("title", new DateTime(2023, 12, 12), "location", new List<Category>(), 18, owner);

        var mockSet = new Mock<DbSet<Event>>();
        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.FandomEvents).Returns(mockSet.Object);

        EventService ES = new EventService(mockContext.Object);
        
        //Act
        ES.CreateEvent(event_test);

        //Assert
        mockSet.Verify(m => m.Add(It.IsAny<Event>()), Times.Once());
        mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }
}