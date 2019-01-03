using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests
{
    [TestClass()]
    public class CalculatorViewModelTests
    {
        //[TestMethod()]
        //public void SetDisplayTextTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void ClearDisplayTextTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void CalculateResultTest()
        //{
        //    Assert.Fail();
        //}
        [DataRow("2,25", "1+2-3/4")]
        [DataRow("31,50", "9x((8-7)x(6+5)+(1+2))/4")]
        [DataRow("-9","1+2-3x4")]
        [DataRow("-3","1+(2-3)x4")]
        [DataRow("37","1+3x3x4")]
        [DataRow("48","(1+3)x(3x4)")]
        [DataRow("12345()747", "12345()747")]
        [DataRow("", "")]
        [DataTestMethod()]
        public void MathHelperTester(string expected, string equation)
        {
            string result = StringManipulation.CalculateString(equation);

            Assert.AreEqual(expected, result);

        }
    }
}