using Bede.Model;
using Bede.Repositories;
using Moq;

namespace BedeTest.Setup
{
    public class DDeRepositoryTest
    {
        private IDbRepository _repository;
        [SetUp]
        public void Setup()
        {
            _repository = new DbRepository();
        }

        [Test]
        public void GetAllSlots_Returns_Slot()
        {
            List<Slot> allSlot = _repository.GetAllSlots();

            Assert.Multiple(() =>
            {
                Assert.That(allSlot, Is.InstanceOf(typeof(List<Slot>)));
                Assert.That(allSlot, Is.Not.Null);
                Assert.That(allSlot, Has.Count.EqualTo(4));
            });
        }

        [Test]
        [TestCase(90)]
        [TestCase(50)]
        [TestCase(20)]
        [TestCase(60)]
        public void GetSlotByProbabilityNumberValue_Returns_Slot_For_RandomNumber_Greater_Than_0_Or_Less_Than_100(int randomNumber)
        {
            Slot? slot = _repository.GetSlotByProbabilityNumberValue(randomNumber);

            Assert.Multiple(() =>
            {
                Assert.That(slot, Is.InstanceOf(typeof(Slot)));
                Assert.That(slot, Is.Not.Null);
            });
        }

        [Test]
        [TestCase(101)]
        [TestCase(500)]
        [TestCase(0)]
        [TestCase(-20)]
        [TestCase(-60)]
        public void GetSlotByProbabilityNumberValue_Returns_Null_For_RandomNumber_Greater_Than_100_Or_Less_Than_0(int randomNumber)
        {
            var slot = _repository.GetSlotByProbabilityNumberValue(randomNumber);

            Assert.That(slot, Is.Null);
        }
    }
}