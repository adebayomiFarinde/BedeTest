using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bede.Services
{
    internal interface IInputService
    {
        double HandleAmountDeposit();
        double HandleStakes();
        void HandleSpinResult(double score);
        void HandleEndProgram();
    }
}
