using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bede.Data.Helpers;

namespace Bede.Services
{
    internal class InputService : IInputService
    {
        private readonly IAccountService _accountService;
        public InputService(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public double HandleAmountDeposit()
        {
            double deposit = 0;
            int depositAttemptCount = 0;

            do
            {
                if (depositAttemptCount > 0)
                {
                    Console.WriteLine("Invalid amount- Account should be equal or lesser than zero: ");
                }

                Console.WriteLine("Please deposit money you will like to play with");
                depositAttemptCount++;
            }
            while (!(double.TryParse(Console.ReadLine(), out deposit) && _accountService.ValidateDeposit(deposit)));

            return deposit;
        }

        public void HandleEndProgram()
        {
            Console.WriteLine("**********************");

            if (_accountService.ShowCurrentAmount() == default)
            {
                Console.WriteLine("Insufficient funds, game ends ....");
                Environment.Exit(0);

            }

            Console.WriteLine("**********************");

            Console.WriteLine("Type 0 to end the game");

            string? endCode = Console.ReadLine();

            if (endCode?.Trim() == "0")
            {
                Environment.Exit(0);
            }

            Console.WriteLine("**********************");

            Console.WriteLine(" ");
        }

        public void HandleSpinResult(double score)
        {
            if (score == 0.0)
            {
                Console.WriteLine("You loss");

            }
            else
            {
                Console.WriteLine("You have won: " + (score * _accountService.GetLastStake()).DoubleToOneDecimalToString());
                _accountService.DepositAmount(score * _accountService.GetLastStake());
                _accountService.ClearStakeGameOver();
            }

            Console.WriteLine("Current balance now: " + _accountService.ShowCurrentAmount().DoubleToOneDecimalToString());
            Console.WriteLine(" ");
        }

        public double HandleStakes()
        {
            int stakeInputCount = 0;
            double stake = 0;

            do
            {
                if (stakeInputCount > 0)
                {
                    Console.WriteLine("Invalid stake- Stake should be equal or lesser than available balance: ");

                }
                Console.WriteLine("Enter stake amount: ");

                stakeInputCount++;
            }
            while (!(double.TryParse(Console.ReadLine(), out stake) && _accountService.ValidateStake(stake)));

            Console.WriteLine(" ");

            return stake;
        }
    }
}
