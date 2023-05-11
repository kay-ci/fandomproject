using System.ComponentModel.DataAnnotations.Schema;
namespace UserInfo{
    public class Profile{
        public int ProfileID {get; set;}
        private string? _name;
        private string? _pronouns;
        private int _age;
        private string? _country;
        private string? _city;
        private string? _description;
        public string Name {
            get{ return _name; } 
            set{
                if (!IsValid(value)){
                    throw new ArgumentException("Name cannot be null or contain numbers");
                }
                _name = value;
            }
        }
        public string Pronouns {
            get{ return _pronouns;} 
            set{
                if (!IsValid(value)){
                    throw new ArgumentException("Pronouns cannot be null or contain numbers");
                }
                _pronouns = value;
            }
        }
        public int Age {
            get{ return _age; }
            set{
                if (value < 0 || value > 130){
                    throw new ArgumentException("Age should be between 0-130");
                }
                Console.WriteLine(value);
                _age = value;
            }
        }
        public string Country {
            get{ return _country; } 
            set{
                if (!IsValid(value)){
                    throw new ArgumentException("Country cannot be null or contain numbers");
                }
                _country = value;
            }
        }
        public string City {
            get{ return _city; } 
            set{
                if (!IsValid(value)){
                    throw new ArgumentException("City cannot be null or contain numbers");
                }
                _city = value;
            }
        }
        public List<Category>? Categories {get; set;}
        public List<Fandom>? Fandoms {get; set;}
        public List<Badge>? Badges {get; set;} 
        public string? Description {
            get{return _description;} 
            set{if (string.IsNullOrEmpty(value)){
                    throw new ArgumentException();
                }
                _description = value;
            }
        }
        public string? Picture {get; set;}
        public string? Interests {get; set;}

        [ForeignKey("UserID")]
        public User user {get; set;} = null!;

        private Profile(){}

        public Profile(string name, string pronouns, int age, string country,string city, List<Category>categories, List<Fandom> fandoms, List<Badge> badges, string description, string picture, string interests){
            if (!IsValid(name) || !IsValid(pronouns) || !IsValid(country) || !IsValid(city)){
                throw new ArgumentException ("String field cannot be null");
            }
            if (age < 0 || age > 130){
                throw new ArgumentException ("Age should be between 0-130");
            }
            _name = name;
            _pronouns = pronouns;
            _age = age;
            _country = country;
            _city = city;
            Categories = categories;
            Fandoms = fandoms;
            Badges = badges;
            _description = description;
            Picture = picture;
            Interests = interests;
        }
        public Profile(string name, string pronouns, int age, string country, string city){
            if (!IsValid(name) || !IsValid(pronouns) || !IsValid(country) || !IsValid(city)){
                throw new ArgumentException ("String field cannot be null");
            }
            if (age < 0 || age > 130){
                throw new ArgumentException ("Age should be between 0-130");
            }
            
            _name = name;
            _pronouns = pronouns;
            _age = age;
            _country = country;
            _city = city;
            _description = " ";
            Categories = new List<Category>();
            Fandoms = new List<Fandom>();
            Badges = new List<Badge>();
            Picture = "default/pic/url";
            Interests = "";
        }
        // this is only to clear the data for visuals but will not be applied to the database
        // this might get split into smaller methods 
        public void ClearProfile(Login UserManager){
            if(Interests != null)
            Interests = "Interests";
            if(Categories != null)
            Categories.Clear();
            if(Fandoms != null)
            Fandoms.Clear();
            if(Badges != null)
            Badges.Clear();
            Name = "Name";
            Pronouns = "Pronouns";
            Country = "Country";
            City = "Country";
            Description = " ";
            Picture = "default/pic/url";
        }

        // this helper validates string fields that should not be null or contain numbers
        public bool IsValid(string field){
            int number;
            if (int.TryParse(field, out number) || string.IsNullOrWhiteSpace(field)){
                return false;
            }
            else{
                return true;
            }   
        }
        public override bool Equals(object obj){
            var item = obj as Profile;
            if(ReferenceEquals(item, this)){
                return true;
            }
            if(item == null && this == null){
                return true;
            }
            if(item == null){
                return false;
            }
            return(
                this.Name == item.Name &&
                this.Pronouns == item.Pronouns &&
                this.Age == item.Age &&
                this.Country == item.Country &&
                this.City == item.City &&
                this.Categories.SequenceEqual(item.Categories) &&
                this.Fandoms.SequenceEqual(item.Fandoms) &&
                this.Badges.SequenceEqual(item.Badges) &&
                this.Description == item._description &&
                this.Picture == item.Picture &&
                this.Interests == item.Interests &&
                this.user == item.user
            );
        }
    }
}