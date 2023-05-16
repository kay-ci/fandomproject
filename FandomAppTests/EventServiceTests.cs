using UserInfo;
using Moq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FandomAppTests;

[TestClass]
public class EventServiceTests{

    [TestMethod]
    public void CreateEvent_NewEvent()
    {
        //Arrange
        Profile owner_profile = new Profile("Owner", "they/them", 21, "Canada", "Montreal", new List<Category>(),  new List<Fandom>(), new List<Badge>(), "description", "pictures", "interests");
        User owner = new User("Owner", owner_profile);

        Event event_test = new Event("title", new DateTime(2023, 12, 12), "location", 18, owner);

        var mockSet = new Mock<DbSet<Event>>();
        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.EVENTS).Returns(mockSet.Object);

        EventService service = EventService.getInstance();
        service.setFanAppContext(mockContext.Object);
        
        //Act
        service.CreateEvent(event_test);

        //Assert
        mockSet.Verify(m => m.Add(It.IsAny<Event>()), Times.Once());
        mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }

    [TestMethod]
    public void GetEvent_EventExist_ReturnEvent()
    {
        //Arrange
        Profile owner_profile = new Profile("Owner", "they/them", 21, "Canada", "Montreal", new List<Category>(),  new List<Fandom>(), new List<Badge>(), "description", "pictures", "interests");
        User owner = new User("Owner", owner_profile);

        var events = new List<Event>();
        events.Add(new Event("Event1", new DateTime(2023, 12, 12), "Montreal", 18, owner));
        events.Add(new Event("Event2", new DateTime(2023, 12, 12), "Toronto", 18, owner));
        events.Add(new Event("Event3", new DateTime(2023, 12, 12), "Vancouver", 18, owner));

        var data = events.AsQueryable();

        var mockSet = new Mock<DbSet<Event>>();
        mockSet.As<IQueryable<Event>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Event>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Event>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Event>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.EVENTS).Returns(mockSet.Object);

        EventService service = EventService.getInstance();
        service.setFanAppContext(mockContext.Object);

        //Act
        var event_found = service.GetEvent("Event1");

        //Assert
        Assert.AreEqual("Event1", event_found.Title);
        Assert.AreEqual("Montreal", event_found.Location);
    }

    [TestMethod]
    public void GetEvent_EventDoesntExist_ReturnNull()
    {
        //Arrange
        Profile owner_profile = new Profile("Owner", "they/them", 21, "Canada", "Montreal", new List<Category>(),  new List<Fandom>(), new List<Badge>(), "description", "pictures", "interests");
        User owner = new User("Owner", owner_profile);

        var events = new List<Event>();
        events.Add(new Event("Event1", new DateTime(2023, 12, 12), "Montreal", 18, owner));
        events.Add(new Event("Event2", new DateTime(2023, 12, 12), "Toronto", 18, owner));
        events.Add(new Event("Event3", new DateTime(2023, 12, 12), "Vancouver", 18, owner));

        var data = events.AsQueryable();

        var mockSet = new Mock<DbSet<Event>>();
        mockSet.As<IQueryable<Event>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Event>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Event>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Event>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.EVENTS).Returns(mockSet.Object);

        EventService service = EventService.getInstance();
        service.setFanAppContext(mockContext.Object);

        //Act
        var event_found = service.GetEvent("Event");

        //Assert
        Assert.IsNull(event_found);
    }

    [TestMethod]
    public void GetAllEvents_3Events_ReturnListEvent()
    {
        //Arrange
        Profile owner_profile = new Profile("Owner", "they/them", 19, "Canada", "Montreal", new List<Category>(),  new List<Fandom>(), new List<Badge>(), "description", "pictures", "interests");
        Profile user_profile = new Profile("Fred", "they/them", 21, "Canada", "Montreal", new List<Category>(),  new List<Fandom>(), new List<Badge>(), "description", "pictures", "interests");
        User owner = new User("Owner", owner_profile);
        User user = new User("Fred", user_profile);

        var event_list = new List<Event>();
        event_list.Add(new Event("Event1", new DateTime(2023, 12, 12), "Montreal", 18, owner));
        event_list.Add(new Event("Event2", new DateTime(2023, 12, 12), "Toronto", 18, owner));
        event_list.Add(new Event("Event3", new DateTime(2023, 12, 12), "Vancouver", 18, owner));

        var data = event_list.AsQueryable();

        var mockSet = new Mock<DbSet<Event>>();
        mockSet.As<IQueryable<Event>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Event>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Event>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Event>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.EVENTS).Returns(mockSet.Object);

        EventService service = EventService.getInstance();
        service.setFanAppContext(mockContext.Object);
        
        //Act
        var events = service.GetAllEvents();

        //Assert
        Assert.AreEqual("Montreal", events[0].Location);
        Assert.AreEqual("Event2", events[1].Title);
        Assert.AreEqual("Fred", events[2].Owner.Username);
        Assert.AreEqual(3, events.Count);
    }

}