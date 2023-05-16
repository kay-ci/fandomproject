using UserInfo;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Class <c>EventService</c> handles interactions with DbSets EVENTS, FANDOMS and managing the events.
/// </summary>
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
    
    /// <summary>
    /// This method add an event to the DbSet EVENTS. 
    /// <para> It verifies first that the <paramref name="new_event"/>'s Title is not taken </para>
    /// </summary>
    public void CreateEvent(Event new_event) 
    {
        if (GetEvent(new_event.Title) == null)
        {
            var state = _context.Entry(new_event.Owner);
            state.State = EntityState.Unchanged;
            
            //foreach(User attendee in new_event.Attendees){
            //state = _context.Entry(attendee);
            //state.State = EntityState.Unchanged;
            //}
    
            _context.EVENTS.Add(new_event);
            _context.SaveChanges();
        }
       
    }


    /// <summary>
    /// This method retrieve a single event from the database by using it's <paramref name="title"/>. 
    /// </summary>
    /// <returns> An <c>Event</c> with the informations or a nullable </returns>
    public Event? GetEvent(string title)
    {
        Event? eventFound = null;
        try
        {
            var query = from ev in _context.EVENTS
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

    /// <summary>
    /// This method retrieve a single event from the database by using it's <paramref name="EventID"/>. 
    /// </summary>
    /// <returns> An <typeparamref name="Event"/> with the informations or a <typeparamref name="nullable"/> </returns>
    public Event? GetEvent(int id)
    {
        Event? eventFound = null;
        try
        {
            var query = from ev in _context.EVENTS
                        where ev.EventID == id
                        select ev;
            eventFound = query.First();
        }
        catch (Exception)
        {
            return null;
        }
        return eventFound;
    }

    /// <summary>
    /// This method fetches all the Events from DbSet EVENTS.
    /// </summary>
    /// <returns> A list of <typeparamref name="Event"/> </returns>
    public List<Event> GetAllEvents()
    {
        List<Event> events = _context.EVENTS
                            .Include(e => e.Categories)
                            .Include(e => e.Fandoms)
                            .Include(e => e.Owner)
                            .Include(e => e.Attendees)
                            .ToList<Event>();
        
        return events;
    }

    /// <summary>
    /// This method allows the owner of an event to edit it and update the DbSet EVENTS. 
    /// <para> It verifies first that the <paramref name="login"/>'s Current user is the <paramref name="updatedEvent"/>'s Owner </para>
    /// </summary>
    public void EditEvent(Login login, Event updatedEvent) {
        
        User? user = login.CurrentUser;
        if (user?.Username != updatedEvent.Owner.Username)
        {
            throw new ArgumentException("Only the creator of this event can modify it.");
        }
        
        if (GetEvent(updatedEvent.EventID) != null || GetEvent(updatedEvent.Title) != null)
        {
            _context.EVENTS.Update(updatedEvent);
            _context.SaveChanges();
        }
    }

    public void EditEvent(Login login, Event updatedEvent, string old_title) {
        
        User? user = login.CurrentUser;
        if (user?.Username != updatedEvent.Owner.Username)
        {
            throw new ArgumentException("Only the creator of this event can modify it.");
        }
        
        if (GetEvent(old_title) != null)
        {
            _context.EVENTS.Update(updatedEvent);
            _context.SaveChanges();
        }
    }

    public void UpdateEvent(Event updatedEvent) {
        
        if (GetEvent(updatedEvent.EventID) != null || GetEvent(updatedEvent.Title) != null)
        {
            //_context.ChangeTracker.Clear();
            _context.EVENTS.Update(updatedEvent);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// This method removes the event from the DbSet EVENTS. 
    /// </summary>
    /// <param name="login"> The Login object holding the Current User </param>
    /// <param name="fandomEvent"> The event to delete </param>
    public void DeleteEvent(Login login, Event fandomEvent) 
    {
        User? user = login.CurrentUser;
        if (user?.Username != fandomEvent.Owner.Username)
        {
            throw new ArgumentException("Only the creator of this event can delete it.");
        }
        _context.EVENTS.Remove(fandomEvent);
        _context.SaveChanges();
    }

    /// <summary>
    /// This method fetches all the Event's attendees from DbSet USERS.
    /// </summary>
    /// <param name="fandomEvent"> The event to fetch </param>
    /// <returns> A list of <typeparamref name="User"/> </returns>
    public List<User> GetEventAttendees(Event fandomEvent) {
        
        var attendees = _context.USERS
                        .Include(user => user.UserProfile)
                        .Include(user => user.Fandoms)
                        .Include(user => user.EventsAttending)
                        .Include(user => user.Inbox)
                        .Include(user => user.Outbox)
                        .Where(user => user.EventsAttending.Contains(fandomEvent))
                        .OrderBy(user => user.UserID)
                        .ToList<User>();

        return attendees;
    }

    /// <summary>
    /// This helper method gets a queryable of events in DbSet EVENTS 
    /// so they can be filtered. <see cref="SearchEvent"/>
    /// </summary>
    /// <returns> A IQueryable of <typeparamref name="Event"/> </returns>
    private IQueryable<Event> GetQueryableEvents()
    {
        var events = _context.EVENTS
                    .Include(e => e.Categories)
                    .Include(e => e.Fandoms)
                    .Include(e => e.Owner)
                    .Include(e => e.Attendees);
        
        return events;
    }

    /// <summary>
    /// This method fetches all the Events based on either the location, category, fandom, event owner or a word in the title.
    /// </summary>
    /// <returns> A list of <typeparamref name="Event"/> of the matching events </returns>
    /// <param name="keyword"> The string representing the type property to use as a filter.</param>
    /// <param name="searchInput"> The string value that the property must match. </param>
    public List<Event>? SearchEvent(string keyword, string searchInput) {
        
        List<Event>? events_found = null;
        keyword = keyword.ToLower();
        searchInput = searchInput.ToLower();

        try
        {
            if (keyword == "location") 
            {
                events_found = GetQueryableEvents()
                                .Where(e => e.Location.Equals(searchInput))
                                .ToList<Event>();
            }
            else if (keyword == "category") 
            {
                events_found = GetQueryableEvents()
                                .Where(e => e.Categories.Any(c => c.Name.Equals(searchInput)))
                                .ToList<Event>();
            }
            else if (keyword.ToLower() == "word") 
            {
                events_found = GetQueryableEvents()
                                .Where(e => e.Title.Contains(searchInput))
                                .ToList<Event>();
            }
            else if (keyword.ToLower() == "fandom") 
            {
                events_found = GetQueryableEvents()
                                .Where(e => e.Fandoms.Any(f => f.Name.Equals(searchInput)))
                                .ToList<Event>();
            }
            else if (keyword.ToLower() == "owner") 
            {
                events_found = GetQueryableEvents()
                                .Where(e => e.Owner.Username.Equals(searchInput))
                                .ToList<Event>();
            }
        }
        catch (Exception) { return null; }
        
        return events_found;
    }

}