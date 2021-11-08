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






        [Test,
            TestCase("Cseko","dani*1Gxx",18,"Nagykorú"),
            TestCase("Cseko Daniel", "C3f*dadade", 1, "Kiskorú")
            
        ]

        public void CreateAccTest(string name, string password, int age, string agestatus)
        {
            // Arrange
            var accServiceMock = new Mock<IManager>(MockBehavior.Strict);
            accServiceMock
                .Setup(m => m.CreateAccount(It.IsAny<Account>()))
                .Returns<Account>(a => a);
            var bLogic = new BusinessLogic();
            bLogic.Manager = accServiceMock.Object;

            // Act
            var actResult = bLogic.Register(name, password, age, agestatus);

            // Assert
            Assert.AreEqual(name, actResult.Name);
            Assert.AreEqual(password, actResult.Password);
            Assert.AreEqual(age, actResult.Age);
            Assert.AreEqual(agestatus, actResult.AgeStatus);
            accServiceMock.Verify(m => m.CreateAccount(actResult), Times.Once);
        }
        [Test]
        public void CBusinessActionCall()
        {
            // Arrange
            var mock = new Mock<IManager>(MockBehavior.Strict);
            mock.Setup(p => p.CrucialBusinessAction());
            var bLogic = new BusinessLogic();
            bLogic.Manager = mock.Object;

            // Act
            bLogic.Perform(true);

            // Assert
            mock.Verify(p => p.CrucialBusinessAction(), Times.Once);

        }

    }
}
