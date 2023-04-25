namespace FandomAppTests;
using Microsoft.EntityFrameworkCore;
using Moq;
using UserInfo;

[TestClass]
public class UserServiceTests{
    [TestMethod]
    public void GetAllUsers_getsAllUsers()
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
        service.setLibraryContext(mockContext.Object);

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
        service.setLibraryContext(mockContext.Object);

        //Act
        User user = service.GetUser("KayciUsername");

        //Assert
        Assert.AreEqual("KayciUsername", user.Username);
        Assert.AreEqual(19, user.UserProfile.Age);
    }

    [TestMethod]
    public void CreateAccountTest()
    {
        //Arrange
        var mockSet = new Mock<DbSet<User>>();
        var mockContext = new Mock<FanAppContext>();
        mockContext.Setup(m => m.FandomUsers).Returns(mockSet.Object);
        var service = UserService.getInstance();
        service.setLibraryContext(mockContext.Object);

        //Act
        service.createAccount("User101", "potato101");

        //Assert
        mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once());
        mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }

    [TestMethod]
    public void LogInTest(){
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
        service.setLibraryContext(mockContext.Object);

        //Act
        service.createAccount("User101", "potato101");
        Login loggedInUser = service.LogIn("User101", "potato101")

        //Assert
        Assert.AreEqual("User101", loggedInUser.CurrentUser.Username);
    }
   
}