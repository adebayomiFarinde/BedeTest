using Bede.Model;
using Bede.Model.Constants;
using System.Reflection.Metadata.Ecma335;

namespace Bede.Setup
{
    internal static class MockData
    {
        public static List<Slot> SlotDB()
        {
            int minValue = default;
            int maxValue = default;
            var listSlots = new List<Slot>();

            SetupDB.ForEach(x =>
            {
                minValue = maxValue + 1;
                maxValue += x.PercentProbability;
                listSlots.Add(new Slot
                {
                    Data = x.Data,
                    Description = x.Description,
                    PercentProbability = x.PercentProbability,
                    Coefficient = x.Coefficient,
                    ProbabilityRangeFrom = minValue,
                    ProbabilityRangeTo = maxValue,
                });
            });

            return listSlots;
        }

        public static List<SetupModel> SetupDB => new()
        {
            new SetupModel
            {
                Data = 'A',
                Description = SymbolConstant.Apple,
                Coefficient = 0.4,
                PercentProbability = 45,
            },
            new SetupModel {
                Data = 'B',
                Description = SymbolConstant.Banana,
                Coefficient = 0.6,
                PercentProbability = 35,
            },
            new SetupModel
            {
                Data = 'P',
                Description = SymbolConstant.Pineapple,
                Coefficient = 0.8,
                PercentProbability = 15,

            },
            new SetupModel
            {
                Data = '*',
                Description = SymbolConstant.WildCard,
                Coefficient = 0,
                PercentProbability = 5,
            },

        };

    }
}
