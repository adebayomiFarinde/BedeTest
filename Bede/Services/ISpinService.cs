using Bede.Model;

namespace Bede.Services
{
    public interface ISpinService
    {
        Slot? GenerateRandomSlotOnProbabiltyOfOccurrence();

        bool AnalyzeRandomSlotSequence(List<Slot> slots);
    }
}
