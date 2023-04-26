using UserInfo;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
public class Event
{
    
    public int EventId {get; set;}
    private int _minAge;
    private string _title;
    private DateTime _date;
    private string _location;
    public List<Category> Categories {get; set;}
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
                throw new ArgumentException("Date can't be set before today");
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
    public User Owner {get; set;}
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

    }

    //this method add the event to the database
    public void CreateEvent() {
        throw new NotImplementedException();
    }

    public void AddAttendee(User attendee) 
    {
        var profile = attendee.UserProfile;
        if (profile?.Age < this.MinAge){
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

}
