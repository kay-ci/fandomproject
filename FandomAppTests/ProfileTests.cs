using UserInfo;
namespace FandomAppTests;
[TestClass]
    public class ProfileTests{
        [TestMethod]
        public void constructor_null_test(){
            //Arrange
            string expectedMessage = "String field cannot be null";

            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => new Profile(" ", "she/her", 19, "Canada", "Montreal"));
            
            //Assert
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [TestMethod]
        public void constructor_age_test(){
            //Arrange
            string expectedMessage = "Age should be between 0-130";

            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => new Profile("Kayci", "she/her", -1, "Canada", "Montreal"));
            
            //Assert
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [TestMethod]
        public void edit_null_name_test(){
            //Arrange
            string expectedMessage = "Name cannot be null or contain numbers";
            Profile testProfile = new Profile("Kayci", "she/her", 19, "Canada", "Montreal");

            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => testProfile.Name = "");

            //Assert
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [TestMethod]
        public void edit_null_pronoun_test(){
            //Arrange
            string expectedMessage = "Pronouns cannot be null or contain numbers";
            Profile testProfile = new Profile("Kayci", "she/her", 19, "Canada", "Montreal");

            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => testProfile.Pronouns = "123");

            //Assert
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [TestMethod]
        public void edit_null_country_test(){
            //Arrange
            string expectedMessage = "Country cannot be null or contain numbers";
            Profile testProfile = new Profile("Kayci", "she/her", 19, "Canada", "Montreal");

            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => testProfile.Country = "");

            //Assert
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [TestMethod]
        public void edit_null_city_test(){
            //Arrange
            string expectedMessage = "City cannot be null or contain numbers";
            Profile testProfile = new Profile("Kayci", "she/her", 19, "Canada", "Montreal");

            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => testProfile.City = "123");

            //Assert
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [TestMethod]
        public void wrong_age_range_test(){
            //Arrange
            string expectedMessage = "Age should be between 0-130";
            Profile testProfile = new Profile("Kayci", "she/her", 19, "Canada", "Montreal");

            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => testProfile.Age = -1);

            //Assert
            Assert.AreEqual(expectedMessage, exception.Message);
        }

    }