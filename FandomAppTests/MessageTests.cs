using UserInfo;
namespace FandomAppTests;
//TODO: finish up tests here (need to communitcate with teammates)
[TestClass]
    public class ProfileTests{
        [TestMethod]
        public void null_text_set_test(){
            //Arrange
            string expectedMessage = "Text property cannot be null or whitespace";
           
            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => Message);
            
            //Assert
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [TestMethod]
        public void null_title_set_test(){
            //Arrange
            string expectedMessage = "Title cannot be null or whitespace";

            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => Message);
            
            //Assert
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [TestMethod]
        public void null_text_constructor_test(){
            //Arrange
            string expectedMessage = "text can not be null";

            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => Message);
            
            //Assert
            Assert.AreEqual(expectedMessage, exception.Message);
        }
        [TestMethod]
        public void null_title_constructor_test(){
            //Arrange
            string expectedMessage = "title can not be null";

            //Act
            Exception exception = Assert.ThrowsException<ArgumentException>(() => Message);
            
            //Assert
            Assert.AreEqual(expectedMessage, exception.Message);
        }
    }