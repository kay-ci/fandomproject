namespace FandomAppTests;

[TestClass]
public class UserMessageTests
{
    [TestMethod]
    public void Creating_Messsage_Test(){

        List<string> categories = new List<string>();
        List<Fandom> fandoms = new List<Fandom>();
        List<string> badges = new List<string>();
        List<string> interests = new List<string>();
        List<Event> events = new List<Event>();
        Profile sender_prof = new Profile("Karekin Kiyici", "he/him", 22, "Canada", "Montreal", categories, fandoms, badges, "", interests);
        User sender = new User("kareking1", sender_prof, events);
    }
}