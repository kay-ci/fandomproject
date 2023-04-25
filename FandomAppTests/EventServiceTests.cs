using UserInfo;
namespace FandomAppTests;

[TestClass]
public class EventServiceTests{
    [TestMethod]
    //[ExpectedException(typeof(ArgumentException))] 
    public void GetEvent_Event_ThrowException()
    {
        //Arrange
        List<Category> categories = new List<Category>();
        List<Fandom> fandoms = new List<Fandom>();
        List<Badge> badges = new List<Badge>();

        //List<Event> events = new List<Event>();
    
        //Profile attendee_profile = new Profile("User", "they/them", 15, "Canada", "Montreal", categories, fandoms, badges, "description", "pictures", "interests");
        Profile owner_profile = new Profile("Owner", "they/them", 21, "Canada", "Montreal", categories, fandoms, badges, "description", "pictures", "interests");

        //User attendee = new User("usertest", attendee_profile, events);
        User owner = new User("Owner", owner_profile);

        DateTime date = new DateTime(2023, 12, 12);
        Event event_test = new Event("title", date, "location", categories, 18, owner);
        FanAppContext db = new FanAppContext();

        EventService ES = new EventService();
        ES.CreateEvent(event_test);

        //Act

        //Assert

    }
}