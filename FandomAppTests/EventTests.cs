using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        List<Event> events = new List<Event>();
    
        Profile attendee_profile = new Profile("User", "they/them", 15, "Canada", "Montreal", categories, fandoms, badges, "description", "pictures", "interests");
        Profile owner_profile = new Profile("Owner", "they/them", 21, "Canada", "Montreal", categories, fandoms, badges, "description", "pictures", "interests");

        User attendee = new User("usertest", attendee_profile, events);
        User owner = new User("userOwner", owner_profile, events);

        DateTime date = new DateTime(2023, 12, 12);
        Event event_test = new Event("title", date, "location", 21, owner);

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
        Profile profile = new Profile("Owner", "they/them", 21, "Canada", "Montreal");
        User user = new User("user", profile);

        //Act
        //this should throw error because minimum age can't be under 13
        Event event_test = new Event("title", new DateTime(2023, 12, 12), "location", 12, user);

    }

    [TestMethod]
    public void SetTitle_NullString_ThrowsException()
    {
        //Arrange
        List<Category> categories = new List<Category>();
        Profile profile = new Profile("User", "they/them", 21, "Canada", "Montreal");
        User user = new User("user", profile);
       
        //Act
        //Assert
        Exception exception = Assert.ThrowsException<ArgumentNullException>(() => new Event("",new DateTime(2023, 12, 12), "location", 12, user));
        
    }

    [TestMethod]
    public void SetDateInThePast_DateBeforeToday_ThrowsException()
    {
        //Arrange
        List<Category> categories = new List<Category>();
        Profile profile = new Profile("User", "they/them", 21, "Canada", "Montreal");
        User user = new User("user", profile);

        DateTime old_date = new DateTime(2021, 12, 12);
       
        //Act
        Exception exception = Assert.ThrowsException<ArgumentException>(() => new Event("title", old_date, "location", 12, user));

        //Assert
         Assert.AreEqual("Date must be set in the future", exception.Message);
        
    }

    [TestMethod]
    public void AddAttendee_3Users_AttendeeCountEqual3()
    {
        //Arrange
        User user = new User("user", new Profile("User", "they/them", 21, "Canada", "Montreal"));
        User user2 = new User("user2", new Profile("User2", "they/them", 18, "Canada", "Toronto"));
        User user3 = new User("user3", new Profile("User3", "she/her", 20, "US", "Detroit"));

        //Act
        Event ev =  new Event("title", new DateTime(2023, 12, 12), "Montreal", 18, user);
        ev.AddAttendee(user);
        ev.AddAttendee(user2);
        ev.AddAttendee(user3);

        //Assert
        Assert.AreEqual(3, ev.Attendees.Count);
    }
}