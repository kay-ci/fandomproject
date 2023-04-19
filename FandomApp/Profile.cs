namespace UserInfo{
    public class Profile{
        public string? Name {
            get{ return this.Name; } 
            set{
                if (!IsValid(value)){
                    throw new ArgumentException("Name cannot be null or contain numbers");
                }
            }
        }
        public string? Pronouns {
            get{ return this.Pronouns;} 
            set{
                if (!IsValid(value)){
                    throw new ArgumentException("Pronouns cannot be null or contain numbers");
                }
            }
        }
        public int Age {
            get{ return this.Age; }
            set{
                if (value < 0 || value > 130){
                    throw new ArgumentException("Age should be between 0-130");
                }
            }
        }
        public string? Country {
            get{ return this.Country; } 
            set{
                if (!IsValid(value)){
                    throw new ArgumentException("Country cannot be null or contain numbers");
                }
            }
        }
        public string? City {
            get{ return this.City; } 
            set{
                if (!IsValid(value)){
                    throw new ArgumentException("City cannot be null or contain numbers");
                }
            }
        }
        public List<string>? Categories {get; set;} //might change to enum
        public List<Fandom>? Fandoms {get; set;}
        public List<string>? Badges {get; set;} //might change to enum
        public string? Description {get; set;}
        public string? Picture {get; set;}
        public List<string>? Interests {get; set;}

        // this helper validates string fields that should not be null or contain numbers
        public bool IsValid(string field){
            if (field.Any(char.IsDigit) || string.IsNullOrWhiteSpace(field)){
                return false;
            }
            else{
                return true;
            }   
        }  
        public Profile(string name, string pronouns, int age, string country,string city, List<string>categories, List<Fandom> fandoms, List<string> badges, string description, string picture, List<string> interests){
            if (!IsValid(name) || !IsValid(pronouns) || !IsValid(country) || !IsValid(city)){
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
            if (!IsValid(name) || !IsValid(pronouns) || !IsValid(country) || !IsValid(city)){
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
            Name = "Name";
            Pronouns = "Pronouns";
            Country = "Country";
            City = "Country";
            Description = " ";
            Picture = "default/pic/url";
        }
    }
}