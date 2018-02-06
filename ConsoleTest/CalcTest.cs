using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleCalc;

namespace ConsoleTest
{
    [TestClass]
    public class CalcTest
    {
        [TestMethod]
        public void TestSub()
        {
            //Arange
            var calc = new Calc();
            var x = 10;
            var y = 5;
            
            //Act
            var result =calc.Sub(x, y);
            //Assert
            Assert.AreEqual(5,result);
            //result = 5;
            result = calc.sqr(x, 0);
            Assert.AreEqual(100,result);
            result = calc.umn(x, y);
            Assert.AreEqual(50, result);
            result = calc.del(x, y);
            Assert.AreEqual(2,result);
            result = calc.sum(x, y);
            Assert.AreEqual(15, result);
        }
    }
}
