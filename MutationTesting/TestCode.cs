using System;
using NUnit;
using NUnit.Framework;
using MyAppToTest;

namespace MutationTesting
{
    class TestCode
    {
        [Test]
        public void Kor_Tobb_Test()
        {
            var kor = new BusinessLogic();

            var tenyleges = kor.korellenorzes(19);

            NUnit.Framework.Assert.AreEqual("Nagykorú", tenyleges);
        }

        [Test]
        public void Kor_Kevesebb_Test()
        {
            var kor = new BusinessLogic();

            var tenyleges = kor.korellenorzes(17);

            NUnit.Framework.Assert.AreEqual("Kiskorú", tenyleges);
        }

        [Test]
        public void Kor_Egyenlo_Test()
        {
            var kor = new BusinessLogic();

            var tenyleges = kor.korellenorzes(18);

            NUnit.Framework.Assert.AreEqual("Nagykorú", tenyleges);
        }





    }
}
