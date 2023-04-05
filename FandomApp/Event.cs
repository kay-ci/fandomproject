namespace UserInfo;
public class Event
{
    public string? Title {get; set;}
    public DateTime Date {get; set;}
    public string? Location {get; set;}
    public List<string>? Categories {get; set;}
    public int MinAge {get; set;}
    public User Owner {get; set;}
    public List<User>? Attendees {get; set;}
    
    //constructor
    public Event() {

    }
    public void CreateEvent() {
        throw new NotImplementedException();
    }

    public void EditEvent() {
        throw new NotImplementedException();
    }

    public void AddAttendee() {
        throw new NotImplementedException();
    }

    public void RemoveAttendee() {
        throw new NotImplementedException();
    }

    public void ShowAttendees() {
        throw new NotImplementedException();
    }
}
