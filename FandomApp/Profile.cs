namespace userInfo{
    public class Profile{
        string? Name {get; set;}
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
            Name = name;
            Pronouns = pronouns;
            Age = age;
            Country = country;
            City = city;
            Description = " ";
        }

        public void CreateProfile(){}
        public void EditProfile(string userChoice){}
        public void ClearProfile(){}
    }
}