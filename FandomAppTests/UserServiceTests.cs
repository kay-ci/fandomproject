namespace FandomAppTests;
using Microsoft.EntityFrameworkCore;
using Moq;
using UserInfo;

/// <summary>
/// Class <c>UserServiceTests</c> Tests all interactions made in the Class UserService.
/// </summary>
[TestClass]
public class UserServiceTests{
    public const int Iterations = 1000;
    [TestMethod]
    public void GetAllUsers()  
    {
        //Arrange
        var listdata = new List<User>();
        listdata.Add(new User("KayciUsername", new Profile("Kayci", "she/her", 19, "Canada", "Montreal")));
        listdata.Add(new User("liliUsername", new Profile("Lili", "they/them", 20, "Ireland", "Dublin")));
        listdata.Add(new User("bestUser", new Profile("Jim", "he/him", 16, "Canada", "Laval")));

        var data = listdata.AsQueryable();

        var mockSet = new Mock<DbSet<User>>();
        mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
 
        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.FandomUsers).Returns(mockSet.Object);
        
        var service = UserService.getInstance();
        service.setFanAppContext(mockContext.Object);

        //Act
        var users = service.GetUsers();

        //Assert
        Assert.AreEqual(3, users.Count);
        Assert.AreEqual("KayciUsername", users[0].Username);
        Assert.AreEqual("they/them", users[1].UserProfile.Pronouns);
        Assert.AreEqual(16, users[2].UserProfile.Age);
    }

     [TestMethod]
    public void GetUserTest()
    {
        //Arrange
        var listdata = new List<User>();
        listdata.Add(new User("KayciUsername", new Profile("Kayci", "she/her", 19, "Canada", "Montreal")));
        listdata.Add(new User("liliUsername", new Profile("Lili", "they/them", 20, "Ireland", "Dublin")));
        listdata.Add(new User("bestUser", new Profile("Jim", "he/him", 16, "Canada", "Laval")));

        var data = listdata.AsQueryable();

        var mockSet = new Mock<DbSet<User>>();
        mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
 
        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.FandomUsers).Returns(mockSet.Object);
        
        var service = UserService.getInstance();
        service.setFanAppContext(mockContext.Object);

        //Act
        User user = service.GetUser("KayciUsername");

        //Assert
        Assert.AreEqual("KayciUsername", user.Username);
        Assert.AreEqual(19, user.UserProfile.Age);
    }

    [TestMethod]
    public void CreateUserTest()
    {
        //Arrange
        var listdata = new List<User>();
        listdata.Add(new User("KayciUsername", new Profile("Kayci", "she/her", 19, "Canada", "Montreal")));
        listdata.Add(new User("liliUsername", new Profile("Lili", "they/them", 20, "Ireland", "Dublin")));
        listdata.Add(new User("bestUser", new Profile("Jim", "he/him", 16, "Canada", "Laval")));

        var data = listdata.AsQueryable();

        var mockSet = new Mock<DbSet<User>>();
        mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
 
        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.FandomUsers).Returns(mockSet.Object);
        
        var service = UserService.getInstance();
        service.setFanAppContext(mockContext.Object);

        //Act
        service.CreateUser("newUser", "potato101", new Profile("User", "they/them", 21, "Canada", "Montreal"));

        //Assert
        mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once());
        mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }
    [TestMethod]
    public void CreateUserFailTest()
    {
        //Arrange
        string expectedMessage = "User with that username already exist";
        var listdata = new List<User>();
        listdata.Add(new User("User101", new Profile("Kayci", "she/her", 19, "Canada", "Montreal")));
        var data = listdata.AsQueryable();

        var mockSet = new Mock<DbSet<User>>();
        mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
 
        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.FandomUsers).Returns(mockSet.Object);
        
        var service = UserService.getInstance();
        service.setFanAppContext(mockContext.Object);

        //Act
        Exception exception = Assert.ThrowsException<ArgumentException>(() => service.CreateUser("User101", "potato101",new Profile("User", "they/them", 21, "Canada", "Montreal")));

        //Assert
        Assert.AreEqual(expectedMessage, exception.Message);
    }

    [TestMethod]
    public void LogInTest(){
        //Arrange
        var listdata = new List<User>();
        listdata.Add(new User("User101", new Profile("Kayci", "she/her", 19, "Canada", "Montreal")));
        listdata.Add(new User("liliUsername", new Profile("Lili", "they/them", 20, "Ireland", "Dublin")));
        listdata.Add(new User("bestUser", new Profile("Jim", "he/him", 16, "Canada", "Laval")));
        var data = listdata.AsQueryable();

        var mockSet = new Mock<DbSet<User>>();
        mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
 
        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.FandomUsers).Returns(mockSet.Object);
        
        var service = UserService.getInstance();
        service.setFanAppContext(mockContext.Object);
        service.CreatePassword(listdata[0], "potato101"); //sets mock users password for test
        
        //Act
        Login loggedInUser = service.LogIn("User101", "potato101");

        //Assert
        Assert.AreEqual("User101", loggedInUser.CurrentUser.Username);
    }
    [TestMethod]
    public void ChangePasswordTest(){
        //Arrange
        var listdata = new List<User>();
        listdata.Add(new User("User101", new Profile("Kayci", "she/her", 19, "Canada", "Montreal")));
        listdata.Add(new User("liliUsername", new Profile("Lili", "they/them", 20, "Ireland", "Dublin")));
        listdata.Add(new User("bestUser", new Profile("Jim", "he/him", 16, "Canada", "Laval")));
        var data = listdata.AsQueryable();

        var mockSet = new Mock<DbSet<User>>();
        mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
 
        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.FandomUsers).Returns(mockSet.Object);
        
        var service = UserService.getInstance();
        service.setFanAppContext(mockContext.Object);
        service.CreatePassword(listdata[0], "potato101"); //sets mock users password for test
        Login userManager = new Login(listdata[0]); //the currently logged in user
        //Act
        
        service.ChangePassword(userManager, "potato101", "newPassword101");

        //Assert
        Assert.IsTrue(service.validPassword(userManager.CurrentUser, "newPassword101"));
    }
    [TestMethod]
    public void change_password_null_test(){
        //Arrange
        var mockSet = new Mock<DbSet<Profile>>();
        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.FandomProfiles).Returns(mockSet.Object);
        var service = UserService.getInstance();
        service.setFanAppContext(mockContext.Object);

        string expectedMessage = "Password field cannot be null";
        Profile testProfile = new Profile("Kayci", "she/her", 19, "Canada", "Montreal");
        User activeUser = new User("Kayci", testProfile);
        Login userManager = new Login(activeUser);

        //Act
        Exception exception = Assert.ThrowsException<ArgumentException>(() => service.ChangePassword(userManager," "," "));
        
        //Assert
        Assert.AreEqual(expectedMessage, exception.Message); 
    }
    [TestMethod]
    public void GetAllProfilesTest()  
    {
        //Arrange
        var listdata = new List<Profile>();
        listdata.Add(new Profile("Kayci", "she/her", 19, "Canada", "Montreal"));
        listdata.Add(new Profile("Aya", "she/her", 18, "Ireland", "Dublin"));
        listdata.Add(new Profile("Christopher", "he/him", 26, "Canada", "Laval"));

        var data = listdata.AsQueryable();

        var mockSet = new Mock<DbSet<Profile>>();
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
 
        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.FandomProfiles).Returns(mockSet.Object);
        
        var service = UserService.getInstance();
        service.setFanAppContext(mockContext.Object);

        //Act
        var profiles = service.GetProfiles();

        //Assert
        Assert.AreEqual(3, profiles.Count);
        Assert.AreEqual("Kayci", profiles[0].Name);
        Assert.AreEqual("Ireland", profiles[1].Country);
        Assert.AreEqual(26, profiles[2].Age);
    }

    [TestMethod]
    public void GetProfileTest()
    {
        //Arrange
        var listdata = new List<Profile>();
        listdata.Add(new Profile("Kayci", "she/her", 19, "Canada", "Montreal"));
        listdata.Add(new Profile("Lili", "they/them", 20, "Ireland", "Dublin"));
        listdata.Add(new Profile("Christopher", "he/him", 16, "Canada", "Laval"));

        var data = listdata.AsQueryable();

        var mockSet = new Mock<DbSet<Profile>>();
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Profile>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
 
        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.FandomProfiles).Returns(mockSet.Object);
        
        var service = UserService.getInstance();
        service.setFanAppContext(mockContext.Object);
        User loggedInUser = new User("User101", new Profile("Kayci", "she/her", 19, "Canada", "Montreal"));
        Login userManager = new Login(loggedInUser);

        //Act
        
        Profile profile = service.GetProfile(userManager.CurrentUser);

        //Assert
        Assert.AreEqual("she/her", profile.Pronouns);
        Assert.AreEqual("Kayci", profile.Name);
    }
    [TestMethod]
    public void UpdateProfileTest()
    {
        //Arrange
        var mockSet = new Mock<DbSet<Profile>>();
        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.FandomProfiles).Returns(mockSet.Object);
        var service = UserService.getInstance();
        service.setFanAppContext(mockContext.Object);

        User loggedInUser = new User("User101", new Profile("Kayci", "she/her", 19, "Canada", "Montreal"));
        Login userManager = new Login(loggedInUser); //the logged in user
        Profile newProfile = new Profile("Kayci Davila", "she/them", 20, "Russia", "Moscow"); //this profile will be created from user input 
        //Act
        service.UpdateProfile(userManager, newProfile);

        //Assert
        Assert.AreEqual("Kayci Davila", userManager.CurrentUser.UserProfile.Name);
        Assert.AreEqual("she/them", userManager.CurrentUser.UserProfile.Pronouns);
        Assert.AreEqual(20, userManager.CurrentUser.UserProfile.Age);
        Assert.AreEqual("Russia", userManager.CurrentUser.UserProfile.Country);
        Assert.AreEqual("Moscow", userManager.CurrentUser.UserProfile.City);
    }
}