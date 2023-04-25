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

}