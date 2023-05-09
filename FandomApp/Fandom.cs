namespace UserInfo;
public class Fandom
{
    public int FandomId {get; set;}
    private string _name;
    private string _category;
    private string _description;
    public string Name {
        get{ return _name; }
        set{
            if (!IsValid(value)) {
                throw new ArgumentException("Name can not be null or a number");
            }
            _name = value;
        }
    }
    public string Category {
        get{ return _category; } 
        set{
            if (!IsValid(value)){
                throw new ArgumentException("Category can not be null or a number");
            }
            _category = value;
        }
    }
    public string? Description {
        get{ return _description; } 
        set{
            if (string.IsNullOrEmpty(value)){
                throw new ArgumentNullException();
            }
            _description = value;
        }
    }

    public List<User> Fans { get; set; } = new ();
    public List<Event>? Events {get; set;} = new ();


    //constructor
    private Fandom(){}
    public Fandom(string name, string category, string? description) {
        if (!IsValid(name) || !IsValid(category)){
            throw new ArgumentException("name and category cannot be null or numbers");
        }
        if (string.IsNullOrEmpty(description)){
            throw new ArgumentException("description can not be null");
        }
        this.Name = name;
        this.Category = category;
        this.Description = description;
    }

    //validate if the field is null or just a number
    public bool IsValid(string field){
        int number;
        if (int.TryParse(field, out number) || string.IsNullOrEmpty(field)){
            return false;
        }
        else{
            return true;
        }   
    } 
    public override bool Equals(object? obj){
        var item = obj as Fandom;
        if(ReferenceEquals(item, this)){
            return true;
        }
        if(item == null){
            return false;
        }
        return (
            this.Name == item.Name &&
            this.Category == item.Category &&
            this.Description == item.Description &&
            this.Fans.SequenceEqual(this.Fans)
        );
    } 
}
