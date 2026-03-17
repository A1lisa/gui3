using Microsoft.VisualStudio.TestTools.UnitTesting;
using gui3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace gui3.Tests
{
    [TestClass()]
    public class TemperatureTests
    {
        [TestMethod()]
        public void VerboseTest()
        {
            var temp = new Temperature(15, MeasureType.C);
            Assert.AreEqual("15 °C", temp.Verbose());

            temp= new Temperature(15, MeasureType.F);
            Assert.AreEqual("15 °F", temp.Verbose());

            temp = new Temperature(15, MeasureType.Ra);
            Assert.AreEqual("15 °Ra", temp.Verbose());

            temp = new Temperature(15, MeasureType.K);
            Assert.AreEqual("15 K", temp.Verbose());

        }
        [TestMethod()]
        public void AddNumberTest()
        {
            var temp=new Temperature(1, MeasureType.C);
            temp = temp + 10.5;
            Assert.AreEqual("11.5 °C", temp.Verbose());
        }


    }
}