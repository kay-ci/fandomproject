using UserInfo;
namespace FandomAppTests;
    [TestClass]
    public class UserTests{
        [TestMethod]
        public void constructor_null_test(){
            //Arrange
            string expectedMessage = "username cannot be null";
            Profile testProfile = new Profile("Kayci", "she/her", 19, "Canada", "Montreal");

            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => new User(" ", testProfile));
            
            //Assert
            Assert.AreEqual(expectedMessage, exception.Message); 
        }
        [TestMethod]
        public void constructor_regex_test(){
            //Arrange
            string expectedMessage = "Username can only be 1 word!";
            Profile testProfile = new Profile("Kayci", "she/her", 19, "Canada", "Montreal");

            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => new User("Kayci more that 1 word username", testProfile));
            
            //Assert
            Assert.AreEqual(expectedMessage, exception.Message); 
        }
        [TestMethod]
        public void change_password_null_test(){
            //Arrange
            string expectedMessage = "new password cannot be null";
            Profile testProfile = new Profile("Kayci", "she/her", 19, "Canada", "Montreal");
            User activeUser = new User("Kayci more that 1 word username", testProfile);
            Login userManager = new Login(activeUser);

            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => activeUser.ChangePassword(userManager, " "));
            
            //Assert
            Assert.AreEqual(expectedMessage, exception.Message); 
        }
        [TestMethod]
        public void change_username_null_test(){
            //Arrange
            string expectedMessage = "new username cannot be null";
            Profile testProfile = new Profile("Kayci", "she/her", 19, "Canada", "Montreal");
            User activeUser = new User("Kayci more that 1 word username", testProfile);
            Login userManager = new Login(activeUser);

            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => activeUser.ChangeUsername(userManager, " "));
            
            //Assert
            Assert.AreEqual(expectedMessage, exception.Message); 
        }
        [TestMethod]
        public void change_username_regex_test(){
            //Arrange
            string expectedMessage = "Username can only be 1 word!";
            Profile testProfile = new Profile("Kayci", "she/her", 19, "Canada", "Montreal");
            User activeUser = new User("Kayci more that 1 word username", testProfile);
            Login userManager = new Login(activeUser);

            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() =>activeUser.ChangeUsername(userManager, "bad username") );
            
            //Assert
            Assert.AreEqual(expectedMessage, exception.Message); 
        }
}
