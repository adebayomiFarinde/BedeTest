using Bede.Services;
using Castle.Core.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace BedeTest.Services
{
    internal class InputServiceTest
    {
        private Mock<IAccountService> _accountServiceMock;
        private IInputService _inputServiceMock;
        [SetUp]
        public void SetUp()
        {
            
            _accountServiceMock = new Mock<IAccountService>();
            _inputServiceMock = new InputService(_accountServiceMock.Object);
        }

        [TestCase(100.50)]
        [TestCase(2000.90)]
        [TestCase(1.0)]
        [Test]
        public void HandleEnterDeposit_Calls_AccountService_ValidateDeposit_When_Entering_Deposit_Via_Console(double amount)
        {
            _accountServiceMock.Setup(x => x.ValidateDeposit(It.Is<double>(y => y > 0))).Returns(true);

            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader(amount.ToString());

            Console.SetIn(input);

            _inputServiceMock.HandleEnterDeposit();

            _accountServiceMock.Verify(x => x.ValidateDeposit(It.Is<double>(x => x > 0)), Times.AtLeastOnce);
        }

        [TestCase(-100)]
        [TestCase(-1000)]
        public void HandleEnterDeposit_Throws_Out_Memory_Exception_When_Continuous_Supplying_Invalid_Input(double amount)
        {
            _accountServiceMock.Setup(x => x.ValidateDeposit(It.Is<double>(y => y > 0))).Returns(true);

            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader(amount.ToString());

            Console.SetIn(input);

            Assert.Throws<OutOfMemoryException>(() => _inputServiceMock.HandleEnterDeposit());
            _accountServiceMock.Verify(x => x.ValidateDeposit(It.Is<double>(x => x < 0)), Times.AtLeastOnce);

        }

        [TestCase(100.50)]
        [TestCase(2000.90)]
        [TestCase(1.0)]
        [Test]
        public void HandleEnterStake_Calls_AccountService_ValidateStake_When_Entering_Stake_Via_Console(double amount)
        {
            _accountServiceMock.Setup(x => x.ValidateStake(It.Is<double>(y => y > 0))).Returns(true);

            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader(amount.ToString());

            Console.SetIn(input);

            _inputServiceMock.HandleEnterStakes();

            _accountServiceMock.Verify(x => x.ValidateStake(It.Is<double>(x => x > 0)), Times.AtLeastOnce);
        }

        [TestCase(-100)]
        [TestCase(-1000)]
        public void HandleEnterStake_Throws_Out_Memory_Exception_When_Continuous_Supplying_Invalid_Input(double amount)
        {
            _accountServiceMock.Setup(x => x.ValidateStake(It.Is<double>(y => y > 0))).Returns(true);

            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader(amount.ToString());

            Console.SetIn(input);

            Assert.Throws<OutOfMemoryException>(() => _inputServiceMock.HandleEnterStakes());
            _accountServiceMock.Verify(x => x.ValidateStake(It.Is<double>(x => x < 0)), Times.AtLeastOnce);

        }

        [TestCase(100.5)]
        [TestCase(2000.9)]
        [TestCase(1.0)]
        [Test]
        public void HandleSpinResult_Calls_AccountService_GetLastStake_DepositAmount_And_ClearStakeGameOver_To_Handle_Spin_Result(double score)
        {
            var account = 90000.0;
            var output = new StringWriter();
            Console.SetOut(output);
            var deposit = 200;
            var input = new StringReader(deposit.ToString());

            Console.SetIn(input);
            _accountServiceMock.Setup(x => x.GetLastStake()).Returns(account);
            _accountServiceMock.Setup(x => x.ClearStakeGameOver()).Verifiable();
            _accountServiceMock.Setup(x => x.DepositAmount(It.Is<double>(y => y > 0))).Verifiable();

            _inputServiceMock.HandleSpinResult(score);

            _accountServiceMock.Verify(x => x.GetLastStake(), Times.AtLeastOnce);
            _accountServiceMock.Verify(x => x.DepositAmount(It.Is<double>(x => x > 0)), Times.AtLeastOnce);
            _accountServiceMock.Verify(x => x.ClearStakeGameOver(), Times.AtLeastOnce);
        }

        [TestCase(0.0)]
        [Test]
        public void HandleSpinResult_Does_Not_Call_AccountService_GetLastStake_DepositAmount_And_ClearStakeGameOver_To_Handle_Spin_Result_When_Score_Is_Zero(double score)
        {
            var account = 90000.0;
            var output = new StringWriter();
            Console.SetOut(output);
            var deposit = 200;
            var input = new StringReader(deposit.ToString());

            Console.SetIn(input);
            _accountServiceMock.Setup(x => x.GetLastStake()).Returns(account);
            _accountServiceMock.Setup(x => x.ClearStakeGameOver()).Verifiable();
            _accountServiceMock.Setup(x => x.DepositAmount(It.Is<double>(y => y > 0))).Verifiable();

            _inputServiceMock.HandleSpinResult(score);

            _accountServiceMock.Verify(x => x.GetLastStake(), Times.Never);
            _accountServiceMock.Verify(x => x.DepositAmount(It.Is<double>(x => x > 0)), Times.Never);
            _accountServiceMock.Verify(x => x.ClearStakeGameOver(), Times.Never);
        }
    }
}
