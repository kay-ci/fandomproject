using UserInfo;
using Microsoft.EntityFrameworkCore;
public class EventService
{
    private FanAppContext _context = null!;
    public EventService(FanAppContext context) 
    {
        _context = context;
    }

    //this method add the event to the database
    public void CreateEvent(Event new_event) 
    {
        if (GetEvent(new_event.EventId) is null)
        {
            _context.FandomEvents.Add(new_event);
            _context.SaveChanges();
            Console.WriteLine("New event added to database!");
        }
       
    }

    //this method retrieve a single event using it's ID
    public Event? GetEvent(int eventID)
    {
        Event? eventFound = null;
        try
        {
            var eventQuery = 
                from events in _context.FandomEvents 
                where events.EventId == eventID
                select events;

            eventFound = eventQuery.First<Event>();
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
            .ToList<Event>();
        
        return events;
    }

    //this method allow owner of event to edit it
    public void EditEvent(User user, Event updatedEvent) {
        
        var oldEvent = _context.FandomEvents.Where(e => e.EventId == updatedEvent.EventId);
        if (oldEvent != null)
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
                        .Include(user => user.Events)
                        .Include(user => user.Messages)
                        .Where(user => user.Events.Contains(fandomEvent))
                        .OrderBy(user => user.userID)
                        .ToList<User>();

        return attendees;
    }

    //this method find event in database based on country, city, category, fandom, keyword in (title/description)
    public void SearchEvent() {
        throw new NotImplementedException();
    }
    
}