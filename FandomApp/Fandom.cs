namespace UserInfo;
public class Fandom
{
    private string _name;
    private string _category;
    public string Name {
        get{ return _name; }
        set{
            if (string.IsNullOrEmpty(value)) {
                throw new ArgumentNullException();
            }
            _name = value;
        }
    }
    public string Category {
        get{ return _category; }
        set{
            if (string.IsNullOrEmpty(value)) {
                throw new ArgumentNullException();
            }
            _category = value;
        }
    }
    public string? Description {get; set;}

    //constructor
    public Fandom(string name, string category, string? description) {
        this.Name = name;
        this.Category = category;
        this.Description = description;
    }

    public override string ToString() {
        return $"Fandom name: {this.Name}, category: {this.Category} \nDescription: {this.Description}";
    }
}
