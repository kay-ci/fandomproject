using UserInfo;

public class Proof
{
    private static FanAppContext context = new FanAppContext();
    private UserService uService;
    private EventService evService;
    private MessageService mService;
    private static Login? login;
    
    public Proof() 
    {
        //Setting all the services needed
        this.uService = UserService.getInstance();
        uService.setFanAppContext(context);

        this.evService = EventService.getInstance();
        evService.setFanAppContext(context);

        this.mService = MessageService.getInstance();
        mService.setFanAppContext(context);

    }
    static void Main(string[] args){

        //Proof of Concept
        Proof proof = new Proof();
        clearTables();

        UserService uService = proof.uService;
        EventService evService = proof.evService;
        MessageService mService = proof.mService;

        createUser1(uService, evService);
        createUser2(uService, evService, mService);
        modifyUser1(uService, evService, mService);

        Console.WriteLine("Program done");
    }

    private static void clearTables()
    {
        //Clearing tables to start
        // Proof.context.FandomUsers.RemoveRange(context.FandomUsers);
        // Proof.context.FandomProfiles.RemoveRange(context.FandomProfiles);
        // Proof.context.FandomMessages.RemoveRange(context.FandomMessages);
        // Proof.context.FandomEvents.RemoveRange(context.FandomEvents);
        // Proof.context.FandomCategories.RemoveRange(context.FandomCategories);
        // Proof.context.FandomBadges.RemoveRange(context.FandomBadges);
        // Proof.context.FandomUserMessages.RemoveRange(context.FandomUserMessages);
        // Proof.context.Fandoms.RemoveRange(context.Fandoms);
        // Proof.context.SaveChanges();
    }

    private static void createUser1(UserService uService, EventService evService) 
    {
         // Step 1 and 2. User1 Account and Profile
        Profile profile1 = new Profile("User1", "they/them", 18, "Canada", "Montreal");
        User user1 = uService.CreateUser("User1", "hello123", profile1);
        Proof.login = uService.LogIn("User1", "hello123");
        Console.WriteLine($"User {Proof.login.CurrentUser.Username} is logged in");

        // Step 3. Create event for user1
        List<Category> categories1 = new List<Category>(){new Category("music")};
        Event event1 = new Event("User1 Event", new DateTime(2023, 12, 12), "Toronto", categories1, 18, user1);
        evService.CreateEvent(event1);

        // Step 4. Log out of user1
        uService.LogOff(Proof.login);
    }

    private static void createUser2(UserService uService, EventService evService, MessageService mService) 
    {
        // Step 5 and 6. Create user2 account and profile
        Profile profile2 = new Profile("User2", "they/them", 24, "Canada", "Vancouver");
        User user2 = uService.CreateUser("User2", "hello123", profile2);
        Proof.login = uService.LogIn("User2", "hello123");
        Console.WriteLine($"User {Proof.login.CurrentUser.Username} is now logged in");

        // Step 7. Perform a search to find the event created by user1
        Event user1_event = evService.GetEvent("User1 Event");

        // Step 8. Mark user2 as attending user1’s event
        user1_event.AddAttendee(user2);

        // Step 9. Attempt to edit user1’s event as user2 (should fail)
        Console.WriteLine("User2 will attempt to edit user1's event.\n");
        try
        {
            evService.EditEvent(Proof.login, user1_event);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        // Step 10. Perform a search that finds user1’s profile
        try
        {
            User user1 = uService.GetUser("User1");
            Profile user1profile = uService.GetProfile(user1);
            // Step 11. Send 3 messages from user2 to user1
            Message msg1 = login.CurrentUser.Messages.CreateMessage("Message 1", "Message 1 Title", null, user1.Messages);
            Message msg2 = login.CurrentUser.Messages.CreateMessage("Message 2", "Message 2 Title", null, user1.Messages);
            Message msg3 = login.CurrentUser.Messages.CreateMessage("Message 3", "Message 3 Title", null, user1.Messages);
            mService.Update_UserMessage(login.CurrentUser);
            mService.Update_UserMessage(user1);
            mService.Add_Message(msg1);
            mService.Add_Message(msg2);
            mService.Add_Message(msg3);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        // Step 12. Log out from user2
        uService.LogOff(login);
    }

    private static void modifyUser1(UserService uService, EventService evService, MessageService mService) 
    {
        // 13. Log in as user1
        Proof.login = uService.LogIn("User1", "hello123");
        Console.WriteLine($"User {Proof.login.CurrentUser.Username} is now logged in");

        // 14. Change user1’s password
        try
        {
            uService.ChangePassword(Proof.login, "hello123", "abc12345");
            Console.WriteLine($"User {Proof.login.CurrentUser.Username} password changed");
        }
        catch (Exception e)
        {
           Console.WriteLine(e.Message);
        }
        
        // 15. Modify user1’s profile
        Profile new_profile = Proof.login.CurrentUser.UserProfile;
        new_profile.Badges = new List<Badge>(){new Badge("Special Fan")};
        new_profile.Fandoms = new List<Fandom>(){new Fandom("Beyhive", "Music","This is Beyonce's fandom")};
        new_profile.City = "Toronto";

        try
        {
            uService.UpdateProfile(Proof.login, new_profile);
            Console.WriteLine("User1 profile updated");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }


        // 16. Access messages, viewing text of the messages sent by user2
        login.CurrentUser.Messages.ReadMessage(0);
        login.CurrentUser.Messages.ReadMessage(1);
        login.CurrentUser.Messages.ReadMessage(2);
        // 17. Send a message to user2 from user1.
        User user2 = uService.GetUser("User 2");
        Message msg1 = login.CurrentUser.Messages.CreateMessage("Reply", "Reply Title", null, user2.Messages);
        mService.Update_UserMessage(login.CurrentUser);
        mService.Update_UserMessage(user2);
        mService.Add_Message(msg1);

        // 18. Find and view the attendees of user1’s event
        try
        {
            Event ev = evService.GetEvent("User1 Event");
            var attendees = evService.GetEventAttendees(ev);
            foreach (var attendee in attendees)
            {
                Console.WriteLine($"Attendee: {attendee.Username}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        // 19. Modify user1’s event.
        try
        {
            Event ev = evService.GetEvent("User1 event");
            ev.Location= "Las Vegas";
            evService.EditEvent(Proof.login, ev);
            Console.WriteLine("User1 event updated");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void deleteUser1(UserService uService)
    {
        // 20. Delete user1’s profile
        
        //uService.Delete(Program.login);

        // 21. Delete user1’s account
    }

    private static void deleteUser2(UserService uService)
    {
        // 22. Log in as user2

        // 23. Delete user2’s account

    }
}