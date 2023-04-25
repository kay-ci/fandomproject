namespace UserInfo;
public class Fandom
{
    public int FandomId {get; set;}
    private string name;
    private string category;
    public string Name {
        get{ return name; }
        set{
            if (string.IsNullOrEmpty(value)) {
                throw new ArgumentNullException();
            }
            name = value;
        }
    }
    public string Category {get; set;}
    public string? Description {get; set;}

    public List<User> Fans {get; set;} = new();


    //constructor
    private Fandom(){}
    public Fandom(string name, string category, string? description) {
        this.Name = name;
        this.Category = category;
        this.Description = description;
    }

    public override string ToString() {
        return $"Fandom name: {this.Name}, category: {this.Category} \nDescription: {this.Description}";
    }
}
