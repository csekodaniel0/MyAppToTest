using System;
using NUnit;
using NUnit.Framework;
using MyAppToTest;
using Moq;

namespace MutationTesting
{
    class TestCode
    {
        [Test]
        public void Age_Greater_Test()
        {
            // Arrange
            var age = new BusinessLogic();
            // Act
            var actualAge = age.AgeCheck(19);
            // Assert
            NUnit.Framework.Assert.AreEqual("Nagykorú", actualAge);
        }

        [Test]
        public void Age_Less_Test()
        {
            // Arrange
            var age = new BusinessLogic();
            // Act
            var actualAge = age.AgeCheck(17);
            // Assert
            NUnit.Framework.Assert.AreEqual("Kiskorú", actualAge);
        }

        [Test]
        public void Age_Equal_Test()
        {
            // Arrange
            var age = new BusinessLogic();
            // Act
            var actualAge = age.AgeCheck(18);
            // Assert
            NUnit.Framework.Assert.AreEqual("Nagykorú", actualAge);
        }

        [Test]
        
        public void ActionFail()
        {
            // Arrange
            var task= new BusinessLogic();      // Crucial Business Action

            // Act
            var ActionStatus = task.Perform(false);

            // Assert
            NUnit.Framework.Assert.AreEqual("HIBA", ActionStatus);

        }

        [Test]

        public void ActionOK()
        {
            // Arrange
            var task = new BusinessLogic();     // Crucial Business Action

            // Act
            var ActionStatus = task.Perform(true);

            // Assert
            NUnit.Framework.Assert.AreEqual("OK", ActionStatus);

        }
        [Test]
        public void MangerTest()
        {
            // Arrange
            var item = new BusinessLogic();         //only Manager call check
            // Assert
            Assert.AreEqual(item.Manager.Accounts.Count, 0);
        }

        [Test,
            TestCase("password", false),
            TestCase("Passw0rd1*", true)
        ]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            // Arrange
            var bl = new BusinessLogic();

            // Act
            var actualResult = bl.ValidatePassword(password);

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedResult, actualResult);
        }


        



        //[Test]

        //public void vegFeladatCalled()
        //{ 
        //    var feladat = new BusinessLogic();


        //    var mock = new Mock<BusinessLogic>();
        //    mock.Setup(p => p.vegrehajtas(true)).Returns("OK");
        //    var sut = new BusinessLogic(mock.Object);


        //    mock.Verify(sut =>sut.vegrehajtandoFeladat(), Times.Once);


        //}

    }
}
