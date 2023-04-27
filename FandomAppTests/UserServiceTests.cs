namespace FandomAppTests;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Moq;
using UserInfo;


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
        service.CreateUser("newUser", "potato101");

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
        Exception exception = Assert.ThrowsException<ArgumentException>(() => service.CreateUser("User101", "potato101"));

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
        
        //Act
        service.CreatePassword(listdata[0], "potato101");
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

        //creating hashed password to test Log In method
        byte[] salt = new byte[8];
        using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider()){
            rngCsp.GetBytes(salt);
        }
        Rfc2898DeriveBytes key = new Rfc2898DeriveBytes("potato101", salt, Iterations);
        byte[] hash = key.GetBytes(32);

        listdata[0].Hash = hash;
        listdata[0].Salt = salt;

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
        Login loggedInUser = service.LogIn("User101", "potato101");

        //Assert
        Assert.AreEqual("User101", loggedInUser.CurrentUser.Username);
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

        //Act
        User loggedInUser = new User("User101", new Profile("Kayci", "she/her", 19, "Canada", "Montreal"));
        Login userManager = new Login(loggedInUser);
        Profile profile = service.GetProfile(userManager.CurrentUser.userID);

        //Assert
        Assert.AreEqual("she/her", profile.Pronouns);
        Assert.AreEqual("Kayci", profile.Name);
    }
}