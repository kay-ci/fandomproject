using UserInfo;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class EventService
{
    private FanAppContext _context = null!;
    private static EventService? _instance;
    private EventService(){}
    public static EventService getInstance(){
        if(_instance is null){
            _instance = new EventService();
        }
        return _instance;
    }
    public void setFanAppContext(FanAppContext context){
        _context = context;
    }
    
    //this method add the event to the database
    public void CreateEvent(Event new_event) 
    {
        if (GetEvent(new_event.Title) == null)
        {
            _context.FandomEvents.Add(new_event);
            _context.SaveChanges();
        }
       
    }

    //this method retrieve a single event using it's ID
    public Event? GetEvent(string title)
    {
        Event? eventFound = null;
        try
        {
            var query = from ev in _context.FandomEvents
                        where ev.Title == title
                        select ev;
            eventFound = query.First();
        }
        catch (Exception)
        {
            return null;
        }
        return eventFound;
    }

    //this method gets all the events
    public List<Event> GetAllEvents()
    {
        List<Event> events = _context.FandomEvents
                            .Include(e => e.Categories)
                            .Include(e => e.Fandoms)
                            .Include(e => e.Owner)
                            .Include(e => e.Attendees)
                            .ToList<Event>();
        
        return events;
    }

    //this method allow owner of event to edit it
    public void EditEvent(Login login, Event updatedEvent) {
        
        User? user = login.CurrentUser;
        if (user?.Username != updatedEvent.Owner.Username)
        {
            throw new ArgumentException("Only the creator of this event can modify it.");
        }
        var ev = _context.FandomEvents
                .Any(e => e.EventId == updatedEvent.EventId);
        if (!ev)
        {
            _context.FandomEvents.Update(updatedEvent);
            _context.SaveChanges();
        }

    }

    //this method remove eventfrom database
    public void DeleteEvent(User user, Event fandomEvent) {
        _context.FandomEvents.Remove(fandomEvent);
        _context.SaveChanges();
    }

    //this method will print out the list of attendees
    //may not be needed because it's not a console app
    public List<User> GetEventAttendees(Event fandomEvent) {
        
        var attendees = _context.FandomUsers
                        .Include(user => user.UserProfile)
                        .Include(user => user.Fandoms)
                        .Include(user => user.EventsAttending)
                        .Include(user => user.Messages)
                        .Where(user => user.EventsAttending.Contains(fandomEvent))
                        .OrderBy(user => user.userID)
                        .ToList<User>();

        return attendees;
    }

    //helper method to get Queryable of all the events so i can filter them
    private IQueryable<Event> GetEvents()
    {
        var events = _context.FandomEvents
                            .Include(e => e.Categories)
                            .Include(e => e.Fandoms)
                            .Include(e => e.Owner)
                            .Include(e => e.Attendees);
        
        return events;
    }

    //this method find event in database based on country, city, category, fandoms, keyword in (title/description)
    public List<Event>? SearchEvent(string keyword, string searchInput) {
        
        List<Event>? events_found = null;
        keyword = keyword.ToLower();
        searchInput = searchInput.ToLower();

        try
        {
            if (keyword == "location") 
            {
                events_found = GetEvents()
                                .Where(e => e.Location.Equals(searchInput))
                                .ToList<Event>();
            }
            else if (keyword == "category") 
            {
                events_found = GetEvents()
                                .Where(e => e.Categories.Any(c => c.Category_name.Equals(searchInput)))
                                .ToList<Event>();
            }
            else if (keyword.ToLower() == "keyword") 
            {
                events_found = GetEvents()
                                .Where(e => e.Title.Contains(searchInput))
                                .ToList<Event>();
            }
            else if (keyword.ToLower() == "fandom") 
            {
                events_found = GetEvents()
                                .Where(e => e.Fandoms.Any(f => f.Name.Equals(searchInput)))
                                .ToList<Event>();
            }
            else if (keyword.ToLower() == "owner") 
            {
                events_found = GetEvents()
                                .Where(e => e.Owner.Username.Equals(searchInput))
                                .ToList<Event>();
            }
        }
        catch (Exception) { return null; }
        
        return events_found;
    }

    private List<Event>? GetEventsByLocation(string location)
    {
        List<Event>? events = null;
        try
        {
            events = GetEvents()
                    .Where(e => e.Location.Equals(location))
                    .ToList<Event>();
        }
        catch (Exception)
        {
            return null;
        }
        return events;
    }

    private List<Event>? GetEventsByCategory(string category)
    {
        List<Event>? events = null;
        try
        {
            events = _context.FandomEvents
                    .Include(e => e.Categories)
                    .Include(e => e.Fandoms)
                    .Include(e => e.Owner)
                    .Include(e => e.Attendees)
                    .Where(e => e.Categories.Any(c => c.Category_name.Equals(category)))
                    .ToList<Event>();
        }
        catch (Exception)
        {
            return null;
        }
        return events;
    }

    
}