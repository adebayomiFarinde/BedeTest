# Simplified-Slot-Machine
This is a Simplied Slot Machine that handles a player spinning and expecting 
a random output based on different configuration.

Setups before running the program

1. Configure the Setup the Data in the Configuration.cs File in the Setup directory
   based on desired configuration
  a. NumberOfSlotColumnsInAPiece is based on the number of Columns of entries of the spinned slots
  b. NumberOfSlotRowsInAPiece is based on the number of Rows of entries of the spinned slots
  c. NumberOfPlayableGames is the maximum playable game within a deposit

2. Data within the MockData.cs file can also be configured based on the Spin Slots
   desired to be see. If more Slots needs to be added, the MockData SetupDB can be defined to fit into this.
   Another consideration is making sure the summation of the Slots PercentProbability adds up to 100percent as expected.

After these SetUps, then run program.
