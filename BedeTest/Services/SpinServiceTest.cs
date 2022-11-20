using Bede.Model;
using Bede.Repositories;
using Bede.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedeTest.Services
{
    internal class SpinServiceTest
    {
        private ISpinService spinService;
        private const double Coefficient = 0.3;
        private Mock<IDbRepository> repository;
        [SetUp]
        public void SetUp()
        {
            repository = new Mock<IDbRepository>();
            repository.Setup(x => x.GetSlotByProbabilityNumberValue(It.Is<int>(x => x > 0 && x < 101))).Returns(new Slot
            {
                Coefficient = Coefficient,
                Data = 'A',
                Description = "Apple",
                PercentProbability = 100,
                ProbabilityRangeFrom = 1,
                ProbabilityRangeTo = 100
            });

            spinService = new SpinService(repository.Object);
        }

        [Test]
        public void GenerateRandomSlotOnProbabiltyOfOccurrence_Can_Generate_Slot()
        {
            var result = spinService.GenerateRandomSlotOnProbabiltyOfOccurrence();
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.SameAs(spinService));
            repository.Verify(x => x.GetSlotByProbabilityNumberValue(It.Is<int>(x => x >0 && x < 101)), Times.AtLeastOnce());
        }
    }
}
