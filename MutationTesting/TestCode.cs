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
        public void Kor_Tobb_Test()
        {
            // Arrange
            var kor = new BusinessLogic();
            // Act
            var tenyleges = kor.AgeCheck(19);
            // Assert
            NUnit.Framework.Assert.AreEqual("Nagykorú", tenyleges);
        }

        [Test]
        public void Kor_Kevesebb_Test()
        {
            // Arrange
            var kor = new BusinessLogic();
            // Act
            var tenyleges = kor.AgeCheck(17);
            // Assert
            NUnit.Framework.Assert.AreEqual("Kiskorú", tenyleges);
        }

        [Test]
        public void Kor_Egyenlo_Test()
        {
            // Arrange
            var kor = new BusinessLogic();
            // Act
            var tenyleges = kor.AgeCheck(18);
            // Assert
            NUnit.Framework.Assert.AreEqual("Nagykorú", tenyleges);
        }

        [Test]
        
        public void ActionFail()
        {
            // Arrange
            var task= new BusinessLogic();

            // Act
            var ActionStatus = task.Perform(false);

            // Assert
            NUnit.Framework.Assert.AreEqual("HIBA", ActionStatus);

        }

        [Test]

        public void ActionOK()
        {
            // Arrange
            var task = new BusinessLogic();

            // Act
            var ActionStatus = task.Perform(true);

            // Assert
            NUnit.Framework.Assert.AreEqual("OK", ActionStatus);

        }
        [Test]
        public void MangerTest()
        {
            // Arrange
            var item = new BusinessLogic();
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
