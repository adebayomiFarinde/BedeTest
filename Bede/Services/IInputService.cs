using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bede.Services
{
    public interface IInputService
    {
        double HandleEnterDeposit();
        double HandleEnterStakes();
        void HandleSpinResult(double score);
        void HandleEndProgram();
        void HandleEndMessage(double balance);
    }
}
