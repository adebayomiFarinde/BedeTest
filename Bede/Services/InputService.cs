﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bede.Setup.Helpers;

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
            int depositAttemptCount = default;

            double deposit;
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
            if (score == default)
            {
                Console.WriteLine("You lose");
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
            int stakeInputCount = default;
            double stake;
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

        public void HandleEndMessage(double balance)
        {
            Console.WriteLine("Congratulations");
            Console.WriteLine("*****************************");
            Console.WriteLine("You have earned " + balance);
            Console.WriteLine("*****************************");
            Console.WriteLine("You have reached the end game of your current game deposit");
            Console.WriteLine("Start a fresh game");
            Console.WriteLine("The Game Ends..");
        }
    }
}
