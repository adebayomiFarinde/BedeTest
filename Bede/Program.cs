// See https://aka.ms/new-console-template for more information
using Bede.Data;
using Bede.Services;

IAccountService accountService = new AccountService();
ISpinService spinService = new SpinService();
ISlotMachineService slotMachineService = new SlotMachineService(spinService);
IInputService inputService = new InputService(accountService);

double deposit = inputService.HandleAmountDeposit();

accountService.DepositAmount(deposit);

int gameCount = default;

while (Configuration.NumberOfPlayableGames > gameCount)
{
    double stake = inputService.HandleStakes();

    accountService.StakeAmount(stake);

    double score = slotMachineService.HandleSlotSprint();

    inputService.HandleSpinResult(score);

    inputService.HandleEndProgram();

    gameCount += 1;
}
