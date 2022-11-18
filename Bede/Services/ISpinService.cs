using Bede.Model;

namespace Bede.Services
{
    internal interface ISpinService
    {
        Slot GenerateRandomSlotOnProbabiltyOfOccurrence();

        bool AnalyzeRandomSlotSequence(List<Slot> slots);
    }
}
