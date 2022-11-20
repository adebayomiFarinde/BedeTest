// See https://aka.ms/new-console-template for more information
using Bede.Setup;
using Bede.Services;
using Bede.Repositories;

IAccountService accountService = new AccountService();
IDbRepository dbRespository = new DbRepository();
ISpinService spinService = new SpinService(dbRespository);
ISlotMachineService slotMachineService = new SlotMachineService(spinService);
IInputService inputService = new InputService(accountService);

double deposit = inputService.HandleEnterDeposit();

accountService.DepositAmount(deposit);

int gameCount = default;

while (Configuration.NumberOfPlayableGames > gameCount)
{
    double stake = inputService.HandleEnterStakes();

    accountService.StakeAmount(stake);

    double score = slotMachineService.HandleSlotSprint();

    inputService.HandleSpinResult(score);

    inputService.HandleEndProgram();

    gameCount += 1;
}

inputService.HandleEndMessage(accountService.ShowCurrentAmount());