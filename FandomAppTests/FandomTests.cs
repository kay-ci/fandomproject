using UserInfo;
namespace FandomAppTests;
//TODO: Test these tests (cannot acces my c: from home)
[TestClass]
    public class FandomTests{
        [TestMethod]
        public void null_name_set_test(){
            //Arrange
            string expectedMessage = "Name can not be null or number";
            Fandom army = new Fandom("army", "k-pop", "fans of the k-pop band BTS");
            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => army.Name = "");
            
            //Assert
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [TestMethod]
        public void number_category_set_test(){
            //Arrange
            string expectedMessage = "Category can not be null or a number";
            Fandom army = new Fandom("army", "k-pop", "fans of the k-pop band BTS");
            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => army.Category = "2013");
            
            //Assert
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [TestMethod]
        public void null_constructor_test(){
            //Arrange
            string expectedMessage = "name and category cannot be null or numbers";
           
            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => new Fandom("","","Best fandom ever!"));
            
            //Assert
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [TestMethod]
        public void only_numbers_constructor_test(){
            //Arrange
            string expectedMessage = "name and category cannot be null or numbers";
           
            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => new Fandom("121", "music", "Second best fandom"));
            
            //Assert
            Assert.AreEqual(expectedMessage, exception.Message);
        }
         [TestMethod]
        public void null_description_constructor_test(){
            //Arrange
            string expectedMessage = "description can not be null";

            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => new Fandom("Genshin","gaming",""));
            
            //Assert
            Assert.AreEqual(expectedMessage, exception.Message);
        }
    }