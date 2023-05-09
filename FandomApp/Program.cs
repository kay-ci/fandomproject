using UserInfo;

public class Program{

    static void Main(string[] args){

        //Proof of Concept

        List<Category> categories = new List<Category>(){new Category("music")};
        List<Category> categories2 = new List<Category>(){new Category("art")};
        List<Category> categories3 = new List<Category>(){new Category("movies"), new Category("music")};

        List<Fandom> fandoms = new List<Fandom>(){new Fandom("Beyhive", "Music","This is Beyonce's fandom")};
        List<Badge> badges = new List<Badge>(){new Badge("Special")};
        //List<Event> events = new List<Event>();

        // Step 1 and 2. User1 Account and Profile
        Profile profile1 = new Profile("User1", "they/them", 18, "Canada", "Montreal");

        FanAppContext context = new FanAppContext();
        UserService uService = UserService.getInstance();
        uService.setFanAppContext(context);

        //User new_user1 = uService.CreateUser("User1", "hello123");
        //setting user1 profile
        Login login = uService.LogIn("User1", "hello123");
        User user1 = login.CurrentUser;
        user1.UserProfile = profile1;

        
        // Step 3. Create event for user1
        EventService evService = EventService.getInstance();
        evService.setFanAppContext(context);

        Event event_test = new Event("User1 Event", new DateTime(2023, 12, 12), "Toronto", categories, 18, user1);
        Event event_test2 = new Event("User1 Event", new DateTime(2023, 12, 12), "Toronto", categories3, 18, user1);
        Event event2 = new Event("User2 Event", new DateTime(2023, 12, 12), "Montreal", categories2, 18, user1);

        evService.CreateEvent(event_test);
        evService.CreateEvent(event_test2);
        evService.CreateEvent(event2);
        var events_found = evService.GetEventsByCategory("music");
    
        // Step 4. Log out of user1

        // Step 5 and 6. Create user2 account and profile
        //Profile profile2 = new Profile("User2", "they/them", 24, "Canada", "Montreal", categories, fandoms, badges, "description", "pictures", "interests");
        //User user2 = new User("User2", profile2, events);

        // Step 7. Perform a search to find the event created by user1

        // Step 8. Mark user2 as attending user1’s event
        
        // Step 9. Attempt to edit user1’s event as user2 (should fail)

        // Step 10. Perform a search that finds user1’s profile

        // Step 11. Send 3 messages from user2 to user1

        // Step 12. Log out from user2

        // 13. Log in as user1

        // 14. Change user1’s password

        // 15. Modify user1’s profile

        // 16. Access messages, viewing text of the messages sent by user2
        // 17. Send a message to user2 from user1.

        // 18. Find and view the attendees of user1’s event

        // 19. Modify user1’s event.

        // 20. Delete user1’s profile

        // 21. Delete user1’s account



        // 22. Log in as user2

        // 23. Delete user2’s account


    }
}