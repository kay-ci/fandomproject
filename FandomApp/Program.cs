using UserInfo;

public class Program{

    static void Main(string[] args){

        //Proof of Concept

        //Setting all the services needed
        FanAppContext context = new FanAppContext();

        //Clearing tables to start
        //context.FandomUsers.RemoveRange(context.FandomUsers);
        //context.FandomProfiles.RemoveRange(context.FandomProfiles);
        //context.FandomMessages.RemoveRange(context.FandomMessages);
        //context.FandomEvents.RemoveRange(context.FandomEvents);
        //context.FandomCategories.RemoveRange(context.FandomCategories);
        //context.FandomBadges.RemoveRange(context.FandomBadges);
        //context.FandomUserMessages.RemoveRange(context.FandomUserMessages);
        //context.Fandoms.RemoveRange(context.Fandoms);
        //context.SaveChanges();

        UserService uService = UserService.getInstance();
        uService.setFanAppContext(context);

        EventService evService = EventService.getInstance();
        evService.setFanAppContext(context);

        //List<Fandom> fandoms = new List<Fandom>(){new Fandom("Beyhive", "Music","This is Beyonce's fandom")};
        //List<Badge> badges = new List<Badge>(){new Badge("Special Fan")};

        // Step 1 and 2. User1 Account and Profile
        Profile profile1 = new Profile("User1", "they/them", 18, "Canada", "Montreal");
        User user1 = uService.CreateUser("User1", "hello123", profile1);
        Login login1 = uService.LogIn("User1", "hello123");

        // Step 3. Create event for user1
        List<Category> categories1 = new List<Category>(){new Category("music")};
        Event event1 = new Event("User1 Event", new DateTime(2023, 12, 12), "Toronto", categories1, 18, user1);
        evService.CreateEvent(event1);

        // Step 4. Log out of user1
        uService.LogOff(login1);

        // Step 5 and 6. Create user2 account and profile
        Profile profile2 = new Profile("User2", "they/them", 24, "Canada", "Vancouver");
        User user2 = uService.CreateUser("User2", "hello123", profile2);
        Login login2 = uService.LogIn("User2", "hello123");

        //List<Category> categories2 = new List<Category>(){new Category("art")};
        //Event event2 = new Event("User2 Event", new DateTime(2023, 12, 12), "Montreal", categories2, 18, user2);
        //evService.CreateEvent(event2);

        // Step 7. Perform a search to find the event created by user1
        Event user1_event = evService.SearchEvent("owner", "user1").First();

        // Step 8. Mark user2 as attending user1’s event
        user1_event.AddAttendee(user2);

        // Step 9. Attempt to edit user1’s event as user2 (should fail)
        try
        {
            evService.EditEvent(login2, user1_event);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

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