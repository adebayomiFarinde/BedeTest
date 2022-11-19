using Bede.Setup;
using Bede.Model;
using Bede.Model.Constants;

namespace Bede.Services
{
    internal class SpinService : ISpinService
    {
        public bool AnalyzeRandomSlotSequence(List<Slot> slots)
        {
            List<Slot> distinct = slots.DistinctBy(x => x.Data).ToList();
            int count = distinct.Count;

            if (count == 2)
            {
                return distinct
                    .Exists(x => x.Description?.Trim().ToLower() == SymbolConstant.WildCard.Trim().ToLower());
            }
            if(count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Slot GenerateRandomSlotOnProbabiltyOfOccurrence()
        {
            int rand = new Random().Next(1, 101);

            return MockData.SlotDB().First(x => x.ProbabilityRangeFrom <= rand && x.ProbabilityRangeTo >= rand);
        }
    }
}
