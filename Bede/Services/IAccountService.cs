using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bede.Services
{
    public interface IAccountService
    {
        public void ClearStakeGameOver();
        public double GetLastStake();
        bool ValidateDeposit(double amount);
        void DepositAmount(double amount);
        double ShowCurrentAmount();
        void StakeAmount(double amoount);
        bool ValidateStake(double amount);
    }
}
