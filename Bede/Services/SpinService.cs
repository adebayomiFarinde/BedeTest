using Bede.Data;
using Bede.Model;
using Bede.Model.Constants;

namespace Bede.Services
{
    internal class SpinService : ISpinService
    {
        public bool AnalyzeRandomSlotSequence(List<Slot> slots)
        {
            var distinct = slots.DistinctBy(x => x.Data);
            int count = distinct.Count();

            if(count == 3)
            {
                return false;
            }
            if (count == 2)
            {
                return distinct.ToList()
                    .Exists(x => x.Description.Trim().ToLower() == SymbolConstant.WildCard.Trim().ToLower());
            }
            else
            {
                return true;
            }
        }

        public Slot GenerateRandomSlotOnProbabiltyOfOccurrence()
        {
            int rand = new Random().Next(0, 101);

            return MockData.SlotDB.First(x => x.ProbabilityRangeFrom <= rand && x.ProbabilityRangeTo >= rand);
        }
    }
}
