using UserInfo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class EventService
{
    private FanAppContext _context = null!;
    public EventService() 
    {
    }

    public void setLibraryContext(FanAppContext context) 
    {
        _context = context;
    }

    //this method add the event to the database
    public void CreateEvent(Event new_event) {

        try
        {
            _context.Events.Add(new_event);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {
           Console.Write("An error happened!");
        }
        
    }

    //this method retrieve a single event using it's ID
    public Event GetEvent(int eventID)
    {
        var query = from events in _context.Events 
            where events.EventId == eventID
            select events;
        
        var eventFound = query.First<Event>();
        return eventFound;
    }

    //this method allow owner of event to edit it
    public void EditEvent(User user, Event fandomEvent) {
        if (true)
        {
            
        }
    }

    //this method will print out the list of attendees
    //may not be needed because it's not a console app
    public void ShowAttendees() {
        throw new NotImplementedException();
    }

    //this method find event in database based on country, city, category, fandom, keyword in (title/description)
    public void SearchEvent() {
        throw new NotImplementedException();
    }
    
}