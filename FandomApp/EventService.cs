using UserInfo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            _context.Events.Add(new_event);
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
                from events in _context.Events 
                where events.EventId == eventID
                select events;

            eventFound = eventQuery.First<Event>();
        }
        catch (System.Exception)
        {
            Console.WriteLine("No event was found");
        }

        return eventFound;
    }

    //this method gets all the events
    public List<Event> GetAllEvents()
    {
        List<Event> events = _context.Events
            .Include(e => e.Categories)
            .ToList<Event>();
        
        return events;
    }

    //this method allow owner of event to edit it
    public void EditEvent(User user, Event fandomEvent) {
        
        var oldEvent = GetEvent(fandomEvent.EventId);
        

    }

    //this method remove eventfrom database
    public void DeleteEvent(User user, Event fandomEvent) {
        _context.Events.Remove(fandomEvent);
        _context.SaveChanges();
    }

    //this method will print out the list of attendees
    //may not be needed because it's not a console app
    public List<User> GetEventAttendees() {
        throw new NotImplementedException();
    }

    //this method find event in database based on country, city, category, fandom, keyword in (title/description)
    public void SearchEvent() {
        throw new NotImplementedException();
    }
    
}