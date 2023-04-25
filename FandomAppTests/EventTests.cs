using UserInfo;
namespace FandomAppTests;

[TestClass]
public class EventTests{
    [TestMethod]
    public void AddAttendee_UserUnderMinAge_ThrowException()
    {
        List<string> categories = new List<string>();
        List<Fandom> fandoms = new List<Fandom>();
        List<string> badges = new List<string>();
        List<string> interests = new List<string>();

        List<Event> events = new List<Event>();
    
        Profile profile = new Profile("User", "they/them", 20, "Canada", "Montreal", categories, fandoms, badges, "description", "pictures", interests);
        User user = new User("usertest", profile, events);
        User owner = new User("userOwner", profile, events);

        DateTime date = new DateTime(2023, 12, 12);
        Event event_test = new Event("title", date, "location", categories, 21, owner);
    }
}