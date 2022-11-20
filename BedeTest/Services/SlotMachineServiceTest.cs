using Bede.Model;
using Bede.Services;
using Bede.Setup;
using Moq;

namespace BedeTest.Services
{
    internal class SlotMachineServiceTest
    {
        private ISlotMachineService slotMachineService;
        private Mock<ISpinService> spinService;
        private const double coefficient = 0.3;

        [SetUp]
        public void SetUp()
        {
            spinService = new Mock<ISpinService>();
            spinService.Setup(x => x.AnalyzeRandomSlotSequence(It.IsAny<List<Slot>>())).Returns(true);
            spinService.Setup(x => x.GenerateRandomSlotOnProbabiltyOfOccurrence()).Returns(new Slot
            {
                Coefficient = coefficient,
                Data = 'A',
                Description = "Apple",
                PercentProbability = 30,
                ProbabilityRangeFrom = 1,
                ProbabilityRangeTo = 30
            });

            slotMachineService = new SlotMachineService(spinService.Object);
        }

        [Test]
        public void HandleSlotSprint_Calls_AnalyzeRandomSlotSequence_And_GenerateRandomSlotOnProbabiltyOfOccurrence_In_SpinService_Atlease_Once_And_Return_Expected_Result()
        {
            var expectedResult = coefficient * Configuration.NumberOfSlotColumnsInAPiece * Configuration.NumberOfSlotRowsInAPiece;
            var result = slotMachineService.HandleSlotSprint();

            Assert.That(result, Is.EqualTo(expectedResult));
            spinService.Verify(x => x.AnalyzeRandomSlotSequence(It.IsAny<List<Slot>>()), Times.AtLeastOnce);
            spinService.Verify(x => x.GenerateRandomSlotOnProbabiltyOfOccurrence(), Times.AtLeastOnce);
        }
    }
}
