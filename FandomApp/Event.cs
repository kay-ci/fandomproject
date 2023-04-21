using UserInfo;
public class Event
{
    private int _minAge;
    public string? Title {get; set;}
    public DateTime Date {get; set;}
    public string? Location {get; set;}
    public List<string>? Categories {get; set;}
    public int MinAge {
        get{ return _minAge; } 
        private set
        {
            const int MinimumAge = 13;

            if (value < MinimumAge) {
                throw new  ArgumentException("The minimum age must be over 13!");
            }
            _minAge = value;
        }
    }
    //need to check if owner also meet age requirement of event created
    public User Owner {get; set;}
    public List<User>? Attendees {get; set;} = new();

    
    //constructor
    private Event(){}
    public Event(string title, DateTime date, string location, List<String> categories, int minAge, User owner) {

        this.Title = title;
        this.Date = date;
        this.Location = location;
        this.Categories = categories;
        this.MinAge = minAge;
        this.Owner = owner;

    }

    //this method add the event to the database
    public void CreateEvent() {
        throw new NotImplementedException();
    }

    public void AddAttendee(User attendee) {

        var profile = attendee.UserProfile;

        if (profile?.Age >= this.MinAge){
            throw new ArgumentException("Attendee must meet the event's age requirement");
        }

        this.Attendees?.Add(attendee);
    }

    //
    public void RemoveAttendee() {
        throw new NotImplementedException();
    }

    //this method will print out the list of attendees
    //may not be needed because it's not a console app
    public void ShowAttendees() {
        throw new NotImplementedException();
    }

    //possible helper method
    //private bool AttendeeVerification() {}
}
