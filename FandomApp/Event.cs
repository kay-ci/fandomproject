using userInfo;
public class Event
{
    private int minAge;
    public string? Title {get; private set;}
    public DateTime Date {get; private set;}
    public string? Location {get; private set;}
    public List<string>? Categories {get; private set;}
    public int MinAge {
        get{ return this.minAge; } 
        private set
        {
            if (value < 13) {
                throw new  ArgumentException("The minimum age must be over 13!");
            }
            this.minAge = value;
        }
    }
    public User Owner {get; private set;}
    public List<User>? Attendees {get; private set;}
    
    //constructor
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

    //this method 
    public void EditEvent() {
        
        //Console.WriteLine("Enter 'E' if you want to edit the categories");
        //char choice;
        //string[] options = {"title", "date", "location", "categories", "minimum age"};
    }

    public void AddAttendee(User attendee) {
        bool check = true;
        if (check) {
            throw new ArgumentException("You must pass a user object");
        }

        this.Attendees.Add(attendee);
    }

    public void RemoveAttendee() {
        throw new NotImplementedException();
    }

    //this method will print out the list of attendees
    public void ShowAttendees() {
        throw new NotImplementedException();
    }
}