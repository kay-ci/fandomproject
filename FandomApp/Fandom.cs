public class Fandom
{
    public string Name {get; set;}
    public string Category {get; set;}
    public string? Description {get; set;}

    //constructor
    public Fandom(string name, string category, string description) {
        this.Name = name;
        this.Category = category;
        this.Description = description;
    }

    public override string ToString() {
        return $"Fandom name: {this.Name}, category: {this.Category} \nDescription: {this.Description}";
    }
}