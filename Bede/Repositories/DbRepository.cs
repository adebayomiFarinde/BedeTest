using Bede.Model;
using Bede.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bede.Repositories
{
    public class DbRepository : IDbRepository
    {
        public List<Slot> GetAllSlots()
        {
            int minValue = default;
            int maxValue = default;
            var listSlots = new List<Slot>();

            MockData.SetupDB.ForEach(x =>
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

        public Slot? GetSlotByProbabilityNumberValue(int numberValue)
        {
            return GetAllSlots().FirstOrDefault(x => x.ProbabilityRangeFrom <= numberValue && x.ProbabilityRangeTo >= numberValue);
        }
    }
}
