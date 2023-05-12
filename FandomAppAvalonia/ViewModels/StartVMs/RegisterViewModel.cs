using System.ComponentModel.DataAnnotations;
using System.Reactive;
using System.Reactive.Linq;
using Avalonia.Data;
using FandomAppSpace;
using ReactiveUI;
using UserInfo;

namespace FandomAppSpace.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        public string _username;
        public string _password;
        public string _name;
        public string _pronouns;
        public int _age;
        public string _country;
        public string _city;

        [Required]
        public string Username
        {
            get => _username;
            private set { 
                this.RaiseAndSetIfChanged(ref _username, value);
                
            }
        }
        [Required]
        public string Password 
        {
            get => _password;
            private set => this.RaiseAndSetIfChanged(ref _password, value);
        }
        [Required, RegularExpression("^[a-zA-z]+$", ErrorMessage = ("Only letters are allowed!"))]
        public string Name 
        {
            get => _name;
            private set{ 
                this.RaiseAndSetIfChanged(ref _name, value);
                
            }
        }
        [RegularExpression("^[a-zA-z]+$", ErrorMessage = ("Only letters are allowed!"))]
        public string Pronouns 
        {
            get => _pronouns;
            private set{
                this.RaiseAndSetIfChanged(ref _pronouns, value);
                
            }
        }
        [Range(0, 130, ErrorMessage = ("Age must be between 0 and 130"))]
        public int Age 
        {
            get => _age;
            private set{
                this.RaiseAndSetIfChanged(ref _age, value);
                
            }
        }
        [Required, RegularExpression("^[a-zA-z]+$", ErrorMessage = ("Only letters are allowed!"))]
        public string Country 
        {
            get => _country;
            private set{
                this.RaiseAndSetIfChanged(ref _country, value);
                
            }
        }
        [Required, RegularExpression("^[a-zA-z]+$", ErrorMessage = ("Only letters are allowed!"))]
        public string City 
        {
            get => _city;
            private set{
                this.RaiseAndSetIfChanged(ref _city, value);
                
            }
        }
        
        public Profile Profile {get; set;}
        public ReactiveCommand<Unit, Unit> Register { get; }
        public ReactiveCommand<Unit, Unit> Login {get;}
        public RegisterViewModel(){
            Profile = new Profile("...", "...",0,"...", "...");
            var registerEnabled = this.WhenAnyValue(
                x => x.Username, x=> x.Password, x=>x.Country, x=>x.City, x=>x.Name, x=>x.Age, x=>x.Pronouns,
                (user_name, pass_word, country, city, name, age, pronouns) =>
                    !string.IsNullOrWhiteSpace(user_name) &&
                    !string.IsNullOrWhiteSpace(pass_word) &&
                    !string.IsNullOrWhiteSpace(country) &&
                    !string.IsNullOrWhiteSpace(city) &&
                    !string.IsNullOrWhiteSpace(name) &&
                    !string.IsNullOrWhiteSpace(pronouns) &&
                    age >= 0 && age <= 130)   
            .DistinctUntilChanged();
            
            Register = ReactiveCommand.Create(() => { }, registerEnabled);
            Login = ReactiveCommand.Create(() =>{ });
        }

        public void RegisterUser(){
            Profile = new Profile(Name,Pronouns,Age,Country, City);
            User newUser = uService.CreateUser(Username, Password, Profile);
            // this.UserManager = new Login(newUser);
            // return this.UserManager;
        }
        
    }
}