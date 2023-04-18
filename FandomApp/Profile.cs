namespace UserInfo{
    public class Profile{
        public string? Name {get; set;}
        public string? Pronouns {get; set;}
        public int Age {get;}
        public string? Country {get; set;}
        public string? City {get; set;}
        public List<string>? Categories {get; set;} //might change to enum
        public List<Fandom>? Fandoms {get; set;}
        public List<string>? Badges {get; set;} //might change to enum
        public string? Description {get; set;}
        public string? Picture {get; set;}
        public List<string>? Interests {get; set;}

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
            Categories = new List<string>();
            Fandoms = new List<Fandom>();
            Badges = new List<string>();
            Picture = "default/pic/url";
            Interests = new List<string>();
        }

        //This method creates a profile for a user
        public void CreateProfile(Login userManager){
            
        }

        // this is only to clear the data for visuals but will not be applied to the database
        // this might get split into smaller methods 
        public void ClearProfile(Login UserManager){
            if(Interests != null)
            Interests.Clear();
            if(Categories != null)
            Categories.Clear();
            if(Fandoms != null)
            Fandoms.Clear();
            if(Badges != null)
            Badges.Clear();
            Name = " ";
            Pronouns = " ";
            Country = " ";
            City = " ";
            Description = " ";
            Picture = "default/pic/url";
        }
    }
}