﻿using Bede.Setup;
using Bede.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bede.Services
{
    internal class SlotMachineService : ISlotMachineService
    {
        private readonly ISpinService _spinService;
        public SlotMachineService(ISpinService spinService)
        {
            _spinService = spinService;
        }
        public double HandleSlotSprint()
        {
            double score = default;

            for (int x = 0; x < Configuration.NumberOfSlotRowsInAPiece; x++)
            {
                string result = string.Empty;
                List<Slot> slots = new();

                for (int i = 0; i < Configuration.NumberOfSlotColumnsInAPiece; i++)
                {
                    slots.Add(_spinService.GenerateRandomSlotOnProbabiltyOfOccurrence());
                }

                slots.ForEach(x =>
                {
                    result += x.Data.ToString() + " ";
                });

                Console.WriteLine(result);

                bool wins = _spinService.AnalyzeRandomSlotSequence(slots);

                if (wins)
                {
                    score = slots.Sum(x => x.Coefficient);
                }
            }

            Console.WriteLine(" ");

            return score;
        }
    }
}
