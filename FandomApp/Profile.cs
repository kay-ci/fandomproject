namespace FandomApp{
    public class Profile{
        public string? Name {get; set;}
        string? Pronouns {get; set;}
        int Age {get;}
        string? Country {get; set;}
        string? City {get; set;}
        List<string>? Categories {get; set;} //might change to enum
        List<Fandom>? Fandoms {get; set;}
        List<string>? Badges {get; set;} //might change to enum
        string? Description {get; set;}
        string? Picture {get; set;}
        List<string>? Interests {get; set;}

        public Profile(string name, string pronouns, int age, string country,string city, List<string>categories, List<Fandom> fandoms, List<string> badges, string description, string picture, List<string> interests){
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(pronouns) || string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(city)){
                throw new ArgumentException ("String field cannot be null");
            }
            if (age < 0 || age > 130){
                throw new ArgumentException ("Age should be between 0-130");
            }
            Name = name;
            Pronouns = pronouns;
            Age = age;
            Country = country;
            City = city;
            Categories = categories;
            Fandoms = fandoms;
            Badges = badges;
            Description = description;
            Picture = picture;
            Interests = interests;
        }
        public Profile(string name, string pronouns, int age, string country, string city){
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(pronouns) || string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(city)){
                throw new ArgumentException ("String field cannot be null");
            }
            if (age < 0 || age > 130){
                throw new ArgumentException ("Age should be between 0-130");
            }
            Name = name;
            Pronouns = pronouns;
            Age = age;
            Country = country;
            City = city;
            Description = " ";
        }

        //This method creates a profile for a user
        public void CreateProfile(Login userManager){
            
        }
        public void EditProfile(string newName, string newPronoun, int newAge, string newCountry, string newCity, List<string>newCategories, List<Fandom> newFandoms, List<string> newBadges, string newDescription, string newPicture, List<string> newInterests){
            //guard statements
            if(string.IsNullOrWhiteSpace(newName)){
                throw new ArgumentException("Name cannot be null");
            }
            if(string.IsNullOrWhiteSpace(newPronoun)){
                throw new ArgumentException("Pronouns cannot be null");
            }
            if(string.IsNullOrWhiteSpace(newCountry)){
                throw new ArgumentException("Country cannot be null");
            }
            if(string.IsNullOrWhiteSpace(newCity)){
                throw new ArgumentException("City cannot be null");
            }
            
            //modifying database based on new info provided
        }
        public void ClearProfile(){}
    }
}