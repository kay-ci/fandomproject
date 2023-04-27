using UserInfo;
namespace FandomAppTests;
    [TestClass]
    public class UserTests{
        [TestMethod]
        public void constructor_null_test(){
            //Arrange
            string expectedMessage = "Username should contain only 1 word";
            Profile testProfile = new Profile("Kayci", "she/her", 19, "Canada", "Montreal");

            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => new User(" ", testProfile));
            
            //Assert
            Assert.AreEqual(expectedMessage, exception.Message); 
        }
        [TestMethod]
        public void constructor_regex_test(){
            //Arrange
            string expectedMessage = "Username should contain only 1 word";
            Profile testProfile = new Profile("Kayci", "she/her", 19, "Canada", "Montreal");

            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => new User("Kayci more that 1 word username", testProfile));
            
            //Assert
            Assert.AreEqual(expectedMessage, exception.Message); 
        }
        [TestMethod]
        public void change_username_null_test(){
            //Arrange
            string expectedMessage = "Username should contain only 1 word";
            Profile testProfile = new Profile("Kayci", "she/her", 19, "Canada", "Montreal");
            User activeUser = new User("Kayci", testProfile);

            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => activeUser.Username = "");
            
            //Assert
            Assert.AreEqual(expectedMessage, exception.Message); 
        }
        [TestMethod]
        public void change_username_regex_test(){
            //Arrange
            string expectedMessage = "Username should contain only 1 word";
            Profile testProfile = new Profile("Kayci", "she/her", 19, "Canada", "Montreal");
            User activeUser = new User("Kayci", testProfile);

            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => activeUser.Username = "username longer than 1 word");
            
            //Assert
            Assert.AreEqual(expectedMessage, exception.Message); 
        }
}
