using UserInfo;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Class <c>EventService</c> handles interactions with DbSets EVENTS, FANDOMS and managing the events.
/// </summary>
public class EventService
{
    //private FanAppContext context = null!;
    private static EventService? _instance;
    private EventService(){}
    public static EventService getInstance(){
        if(_instance is null){
            _instance = new EventService();
        }
        return _instance;
    }
    //public void setFanAppContext(FanAppContext context){
    //    this.context = context;
    //}
    
    /// <summary>
    /// This method add an event to the DbSet EVENTS. 
    /// <para> It verifies first that the <paramref name="new_event"/>'s Title is not taken </para>
    /// </summary>
    public void CreateEvent(Event new_event) 
    {
        using (var context = new FanAppContext())
        {
            if (GetEvent(new_event.Title) == null)
            {
                context.EVENTS.Attach(new_event);
                context.SaveChanges();
            }
        }
    }


    /// <summary>
    /// This method retrieve a single event from the database by using it's <paramref name="title"/>. 
    /// </summary>
    /// <returns> An <c>Event</c> with the informations or a nullable </returns>
    public Event? GetEvent(string title)
    {
        using (var context = new FanAppContext())
        {
            Event? eventFound = null;
            try
            {
                var query = from ev in context.EVENTS
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
        
    }

    /// <summary>
    /// This method fetches all the Events from DbSet EVENTS.
    /// </summary>
    /// <returns> A list of <typeparamref name="Event"/> </returns>
    public List<Event> GetAllEvents()
    {
        using (var context = new FanAppContext())
        {
            List<Event> events = context.EVENTS
                                .Include(e => e.Categories)
                                .Include(e => e.Fandoms)
                                .Include(e => e.Owner)
                                .Include(e => e.Attendees)
                                .ToList<Event>();
            return events;
        }
    }

    /// <summary>
    /// This method allows the owner of an event to edit it and update the DbSet EVENTS. 
    /// <para> It verifies first that the <paramref name="login"/>'s Current user is the <paramref name="updatedEvent"/>'s Owner </para>
    /// </summary>
    public void UpdateEvent(Login login, Event updatedEvent) 
    {
        User? user = login.CurrentUser;
        if (user?.Username != updatedEvent.Owner.Username)
        {
            throw new ArgumentException("Only the creator of this event can modify it.");
        }
        using (var context = new FanAppContext())
        {
            context.EVENTS.Update(updatedEvent);
            context.SaveChanges();
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
        using (var context = new FanAppContext())
        {
            context.EVENTS.Remove(fandomEvent);
            context.SaveChanges();
        }
    }

    /// <summary>
    /// Obsolete.This helper method gets a queryable of events in DbSet EVENTS 
    /// so they can be filtered. <see cref="SearchEvent"/>
    /// </summary>
    /// <returns> A IQueryable of <typeparamref name="Event"/> </returns>
    private IQueryable<Event> GetQueryableEvents()
    {
        using (var context = new FanAppContext())
        {
            var events = context.EVENTS
                    .Include(e => e.Categories)
                    .Include(e => e.Fandoms)
                    .Include(e => e.Owner)
                    .Include(e => e.Attendees);
            return events;
        }
    }

    /// <summary>
    /// Obsolete. This method fetches all the Events based on either the location, category, fandom, event owner or a word in the title.
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