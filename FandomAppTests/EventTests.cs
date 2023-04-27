using UserInfo;
namespace FandomAppTests;

[TestClass]
public class EventTests{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))] 
    public void AddAttendee_AttendeeUnderEventMinAge_ThrowException()
    {
        //Arrange
        List<Category> categories = new List<Category>();
        List<Fandom> fandoms = new List<Fandom>();
        List<Badge> badges = new List<Badge>();
        string interests = "List of interests";

        List<Event> events = new List<Event>();
    
        Profile attendee_profile = new Profile("User", "they/them", 15, "Canada", "Montreal", categories, fandoms, badges, "description", "pictures", interests);
        Profile owner_profile = new Profile("Owner", "they/them", 21, "Canada", "Montreal", categories, fandoms, badges, "description", "pictures", interests);

        User attendee = new User("usertest", attendee_profile, events);
        User owner = new User("userOwner", owner_profile, events);

        DateTime date = new DateTime(2023, 12, 12);
        Event event_test = new Event("title", date, "location", categories, 21, owner);

        //Act
        //this should throw error because Attendee is under minimum age
        event_test.AddAttendee(attendee);

    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))] 
    public void SetMinAge_MinAgeUnder13_ThrowException()
    {
        //Arrange
       List<Category> categories = new List<Category>();
        List<Fandom> fandoms = new List<Fandom>();
        List<Badge> badges = new List<Badge>();
        string interests = "List of interests";
        List<Event> events = new List<Event>();
    
        Profile profile = new Profile("Owner", "they/them", 21, "Canada", "Montreal", categories, fandoms, badges, "description", "pictures", interests);

        User user = new User("user", profile, events);
        DateTime date = new DateTime(2023, 12, 12);
        
        //Act
        //this should throw error because minimum age can't be under 13
        Event event_test = new Event("title", date, "location", categories, 12, user);

    }

    
}