using System.Windows;
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
            else if (option == 4)
            {
                LocalParameters.proteinAmount = 1;
                LocalParameters.carbsAmount = 1;
                LocalParameters.fatsAmount = 1;
            }
        }
        public void Calculate()
        {
            LocalParameters.MacroPercentage = LocalParameters.proteinAmount * 4 + LocalParameters.carbsAmount * 4 + LocalParameters.fatsAmount * 9;
            if (LocalParameters.MacroPercentage >= LocalParameters.TDEEAmount)
            {
                MessageBox.Show("You overextended your calorie demand, please step down a little bit with Protein, Carbs or fats.");
            }
        }
    }
}
