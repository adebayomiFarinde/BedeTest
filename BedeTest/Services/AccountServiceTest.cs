using Bede.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BedeTest.Services
{
    internal class AccountServiceTest
    {
        private IAccountService accountService;
        [SetUp]
        public void SetUp()
        {
            accountService = new AccountService();
        }

        [TestCase(2000)]
        [TestCase(4000)]
        [TestCase(500)]
        [TestCase(10000)]
        [Test]
        public void DepositAmount_Can_Add_Amount_To_Player_Account(double amount)
        {
            accountService.DepositAmount(amount);

            var account = accountService.GetType().GetField("_account",
                            BindingFlags.NonPublic | BindingFlags.Public
                                | BindingFlags.Instance | BindingFlags.Static)?.GetValue(accountService);

            Assert.Multiple(() =>
            {
                Assert.That(account, Is.Not.Null);
                Assert.That(account, Is.EqualTo(amount));
            });

        }

        [TestCase(2000)]
        [TestCase(4000)]
        [TestCase(500)]
        [TestCase(10000)]
        [Test]
        public void ShowCurrentAmount_Can_Show_Current_Amount(double amount)
        {

            accountService.GetType().GetField("_account",
                            BindingFlags.NonPublic | BindingFlags.Public
                                | BindingFlags.Instance | BindingFlags.Static)?.SetValue(accountService, amount);

            Assert.Multiple(() =>
            {
                Assert.That(amount, Is.EqualTo(accountService.ShowCurrentAmount()));
            });
        }

        [TestCase(2000)]
        [TestCase(4000)]
        [TestCase(500)]
        [TestCase(1)]
        [Test]
        public void StakeAmount_Can_Make_Stake(double amount)
        {
            accountService.StakeAmount(amount);

            var stake = accountService.GetType().GetField("_stake",
                            BindingFlags.NonPublic | BindingFlags.Public
                                | BindingFlags.Instance | BindingFlags.Static)?.GetValue(accountService);

            Assert.Multiple(() =>
            {
                Assert.That(stake, Is.Not.Null);
                Assert.That(stake, Is.EqualTo(amount));
            });
        }

        [TestCase(2000)]
        [TestCase(4000)]
        [TestCase(500)]
        [TestCase(10000)]
        [Test]
        public void ValidateDeposit_Can_Validate_True_For_Amount_Greater_Than_Zero(double amount)
        {
            var isValid = accountService.ValidateDeposit(amount);
            var expectedResult = true;

            Assert.Multiple(() =>
            {
                Assert.That(isValid, Is.InstanceOf(typeof(bool)));
                Assert.That(isValid, Is.EqualTo(expectedResult));
            });
        }

        [TestCase(-1000)]
        [TestCase(-100)]
        [Test]
        public void ValidateDeposit_Can_Validate_False_For_Amount_Equal_Or_Less_Than_Zero(double amount)
        {
            var isValid = accountService.ValidateDeposit(amount);
            var expectedResult = false;

            Assert.Multiple(() =>
            {
                Assert.That(isValid, Is.InstanceOf(typeof(bool)));
                Assert.That(isValid, Is.EqualTo(expectedResult));
            });
        }
        [TestCase(2000, 500)]
        [TestCase(4000, 2000)]
        [TestCase(500, 500)]
        [TestCase(10000, 3000)]
        [Test]
        public void ValidateStake_Can_Validate_True_Stake_Equal_Or_Less_Than_Deposited(double amount, double stake)
        {
            var expectedResult = true;

            accountService.GetType().GetField("_account",
                            BindingFlags.NonPublic | BindingFlags.Public
                                | BindingFlags.Instance | BindingFlags.Static)?.SetValue(accountService, amount);

            var isStake = accountService.ValidateStake(stake);

            Assert.Multiple(() =>
            {
                Assert.That(isStake, Is.InstanceOf(typeof(bool)));
                Assert.That(isStake, Is.EqualTo(expectedResult));
            });
        }

        [TestCase(4000, 0)]
        [TestCase(500, -500)]
        [TestCase(10000, 30000)]
        [Test]
        public void ValidateStake_Can_Validate_False_Stake_Equal_Or_Less_Than_Deposited_Or_Zero(double amount, double stake)
        {
            var expectedResult = false;

            accountService.GetType().GetField("_account",
                            BindingFlags.NonPublic | BindingFlags.Public
                                | BindingFlags.Instance | BindingFlags.Static)?.SetValue(accountService, amount);

            var isStake = accountService.ValidateStake(stake);

            Assert.Multiple(() =>
            {
                Assert.That(isStake, Is.InstanceOf(typeof(bool)));
                Assert.That(isStake, Is.EqualTo(expectedResult));
            });
        }

        [TestCase(4000, 300)]
        [TestCase(500, 500)]
        [TestCase(10000, 5000)]
        [Test]
        public void GetLastStake_Can_The_Last_Stake(double amount, double stake)
        {
            accountService.GetType().GetField("_account",
                            BindingFlags.NonPublic | BindingFlags.Public
                                | BindingFlags.Instance | BindingFlags.Static)?.SetValue(accountService, amount);

            accountService.StakeAmount(stake);

            Assert.Multiple(() =>
            {
                Assert.That(accountService.GetLastStake(), Is.InstanceOf(typeof(double)));
                Assert.That(accountService.GetLastStake(), Is.EqualTo(stake));
            });
        }

        [TestCase(4000, 300)]
        [TestCase(500, 500)]
        [TestCase(10000, 5000)]
        [Test]
        public void ClearStakeGameOver_Can_Restore_Stake_To_Zero(double amount, double stake)
        {
            var emptyStake = 0;

            accountService.GetType().GetField("_account",
                            BindingFlags.NonPublic | BindingFlags.Public
                                | BindingFlags.Instance | BindingFlags.Static)?.SetValue(accountService, amount);

            accountService.StakeAmount(stake);
            accountService.ClearStakeGameOver();

            Assert.Multiple(() =>
            {
                Assert.That(accountService.GetLastStake(), Is.InstanceOf(typeof(double)));
                Assert.That(accountService.GetLastStake(), Is.EqualTo(emptyStake));
            });
        }
    }
}
