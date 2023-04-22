namespace UserInfo;
public class Fandom
{
    private string _name;
    private string _category;
    private string _description;
    public string Name {
        get{ return _name; }
        set{
            if (!IsValid(value)) {
                throw new ArgumentNullException();
            }
            _name = value;
        }
    }
    public string Category {
        get{ return _category; } 
        set{
            if (!IsValid(value)){
                throw new ArgumentException("Category cannot be null or a number");
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
}
