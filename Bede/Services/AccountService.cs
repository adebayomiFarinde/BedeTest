
namespace Bede.Services
{
    public class AccountService : IAccountService
    {
        private double _account = 0;
        private double _stake = 0;

        public double GetLastStake()
        {
            return _stake;
        }

        public void ClearStakeGameOver()
        {
            _stake = 0;
        }
        public void DepositAmount(double amount)
        {
            _account += amount;
        }

        public double ShowCurrentAmount()
        {
            return _account;
        }

        public void StakeAmount(double amount)
        {
            _stake = amount;
            _account -= _stake;
        }

        public bool ValidateDeposit(double amount)
        {
            return amount > 0;
        }

        public bool ValidateStake(double amount)
        {
            if(amount <= 0)
            {
                return false;
            }
            return _account >= amount;
        }
    }
}
