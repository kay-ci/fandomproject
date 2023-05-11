using UserInfo;
using System.ComponentModel.DataAnnotations.Schema;
public class Event
{
    
    public int EventID {get; set;}
    private int _minAge;
    private string _title;
    private DateTime _date;
    private string _location;
    public List<Category> Categories {get; set;} = new();
    public List<Fandom> Fandoms {get; set;}
    public string Title 
    {
        get{ return _title;} 
        set{
            if (string.IsNullOrWhiteSpace(value)) {
                throw new ArgumentNullException();
            }
            _title = value;
        }
    }
    
    public DateTime Date {
        get{ return _date;} 
        set{
            if (DateTime.Compare( value, DateTime.Today) < 0) {
                throw new ArgumentException("Date must be set in the future");
            }
            _date = value;
        }
    }
    public string Location 
    {
        get{ return _location;} 
        set{
            if (string.IsNullOrWhiteSpace(value)) {
                throw new ArgumentNullException();
            }
            _location = value;
        }
    }
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

    [ForeignKey("UserID")]
    public User Owner {get; set;} = null!;
    public List<User>? Attendees {get; set;} = new();

    //constructor
    private Event(){}
    public Event(string title, DateTime date, string location, List<Category> categories, int minAge, User owner) {

        this.Title = title;
        this.Date = date;
        this.Location = location;
        this.Categories = categories;
        this.MinAge = minAge;
        this.Owner = owner;
        this.Attendees = new List<User>();
    }

    public void AddAttendee(User attendee) 
    {
        var profile = attendee.UserProfile;
        if (profile?.Age < this.MinAge){
            throw new ArgumentException("Attendee must meet the event's age requirement");
        }

        this.Attendees?.Add(attendee);
    }

    public void RemoveAttendee(User attendee) 
    {
        if(!Attendees.Contains(attendee))
        {
            throw new ArgumentException("This attendee isn't part of the event");
        }
        this.Attendees?.Remove(attendee);
    }

    public override bool Equals(object? obj){
            var item = obj as Event;
            if(ReferenceEquals(item, this)){
                return true;
            }
            if(item == null){
                return false;
            }
            return (
                this.MinAge == item.MinAge &&
                this.Title == item.Title &&
                this.Location == item.Location &&
                this.Owner == item.Owner &&
                this.Date == item.Date &&
                this.Categories.SequenceEqual(item.Categories) &&
                this.Attendees == item.Attendees
            );
        }

}
