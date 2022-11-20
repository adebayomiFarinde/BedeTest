using Bede.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bede.Repositories
{
    public interface IDbRepository
    {
        List<Slot> GetAllSlots();
        Slot? GetSlotByProbabilityNumberValue(int numberValue);
    }
}
