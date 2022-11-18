using Bede.Model;
using Bede.Model.Constants;

namespace Bede.Data
{
    internal static class MockData
    {
        public static List<Slot> SlotDB => new()
        {
            new Slot
            {
                Data = 'A',
                Description = SymbolConstant.Apple,
                Coefficient = 0.4,
                PercentProbability = 45,
                ProbabilityRangeFrom = 0,
                ProbabilityRangeTo = 44
            },
            new Slot {
                Data = 'B',
                Description = SymbolConstant.Banana,
                Coefficient = 0.6,
                PercentProbability = 35,
                ProbabilityRangeFrom = 45,
                ProbabilityRangeTo = 79
            },
            new Slot
            {
                Data = 'P',
                Description = SymbolConstant.Pineapple,
                Coefficient = 0.8,
                PercentProbability = 15,
                ProbabilityRangeFrom = 80,
                ProbabilityRangeTo = 94

            },
            new Slot
            {
                Data = '*',
                Description = SymbolConstant.WildCard,
                Coefficient = 0,
                PercentProbability = 5,
                ProbabilityRangeFrom = 95,
                ProbabilityRangeTo = 100
            },
           
        };

    }
}
