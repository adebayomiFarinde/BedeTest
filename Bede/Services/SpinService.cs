using Bede.Setup;
using Bede.Model;
using Bede.Model.Constants;
using Bede.Repositories;

namespace Bede.Services
{
    public class SpinService : ISpinService
    {
        private readonly IDbRepository _dbRespository;
        public SpinService(IDbRepository dbRespository)
        {
            _dbRespository = dbRespository;
        }
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

        public Slot? GenerateRandomSlotOnProbabiltyOfOccurrence()
        {
            int rand = new Random().Next(1, 101);

            return _dbRespository.GetSlotByProbabilityNumberValue(rand);
        }
    }
}
