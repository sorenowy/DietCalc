using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietCalc.Configuration;

namespace DietCalc.Data
{
    public class MacroCalculator
    {
        public void SelectDiet(int option)
        {
            if (option == 0)
            {
                LocalParameters.proteinAmount = LocalParameters.TDEEAmount * 0.3;
                LocalParameters.proteinAmount = LocalParameters.proteinAmount / 4;
                LocalParameters.carbsAmount = LocalParameters.TDEEAmount * 0.4;
                LocalParameters.carbsAmount = LocalParameters.carbsAmount / 4;
                LocalParameters.fatsAmount = LocalParameters.TDEEAmount * 0.3;
                LocalParameters.fatsAmount = LocalParameters.fatsAmount / 9;
            }
            else if (option == 1)
            {
                LocalParameters.proteinAmount = LocalParameters.TDEEAmount * 0.3;
                LocalParameters.proteinAmount = LocalParameters.proteinAmount / 4;
                LocalParameters.carbsAmount = LocalParameters.TDEEAmount * 0.5;
                LocalParameters.carbsAmount = LocalParameters.carbsAmount / 4;
                LocalParameters.fatsAmount = LocalParameters.TDEEAmount * 0.2;
                LocalParameters.fatsAmount = LocalParameters.fatsAmount / 9;
            }
            else if (option == 2)
            {
                LocalParameters.proteinAmount = LocalParameters.TDEEAmount * 0.4;
                LocalParameters.proteinAmount = LocalParameters.proteinAmount / 4;
                LocalParameters.carbsAmount = LocalParameters.TDEEAmount * 0.2;
                LocalParameters.carbsAmount = LocalParameters.carbsAmount / 4;
                LocalParameters.fatsAmount = LocalParameters.TDEEAmount * 0.4;
                LocalParameters.fatsAmount = LocalParameters.fatsAmount / 9;
            }
            else if (option == 3)
            {
                LocalParameters.proteinAmount = LocalParameters.TDEEAmount * 0.2;
                LocalParameters.proteinAmount = LocalParameters.proteinAmount / 4;
                LocalParameters.carbsAmount = LocalParameters.TDEEAmount * 0.05;
                LocalParameters.carbsAmount = LocalParameters.carbsAmount / 4;
                LocalParameters.fatsAmount = LocalParameters.TDEEAmount * 0.75;
                LocalParameters.fatsAmount = LocalParameters.fatsAmount / 9;
            }
        }
    }
}
