using Bede.Model;
using Bede.Repositories;
using Bede.Setup.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedeTest.Setup
{
    public class ObjectExtensionTest
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void DoubleToOneDecimalToString_Returns_One_Decimal_String()
        {
            var number = 12.9012112;
            var expectedResult = "12.9";
            var result = number.DoubleToOneDecimalToString();

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.InstanceOf(typeof(string)));
                Assert.That(expectedResult, Is.EqualTo(result));
            });
        }

        [Test]
        public void IsNull_Returns_True_When_Value_Is_Null()
        {
            Slot? slot = null;

            Assert.Multiple(() =>
            {
                Assert.That(slot.IsNull(), Is.True);
            });
        }

        [Test]
        public void IsNull_Returns_False_When_Value_Is_Not_Null()
        {
            var stringValue = string.Empty;

            Assert.Multiple(() =>
            {
                Assert.That(stringValue.IsNull(), Is.False);
            });
        }
    }
}