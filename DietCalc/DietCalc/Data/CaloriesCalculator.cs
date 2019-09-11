using DietCalc.Configuration;

namespace DietCalc.Data
{
    public class CaloriesCalculator
    {
        public void CalculateBaseCal()
        {
            LocalParameters.BMRAmount = (LocalParameters.heightVal*6.25) + (LocalParameters.weightVal*10) - (LocalParameters.ageVal * 4.92);
        }
        public void CalculateDailyCal()
        {
            LocalParameters.TDEEAmount = LocalParameters.BMRAmount * LocalParameters.exerciseFactor;
        }
        public void SelectSexFactor(int option)
        {
            if (option == 0)
            {
                CalculateBaseCal();
                LocalParameters.BMRAmount += LocalParameters.femaleFactor;
            }
            else if (option == 1)
            {
                CalculateBaseCal();
                LocalParameters.BMRAmount += LocalParameters.maleFactor;
            }
        }
        public void SelectActivityFactor(int option)
        {
            if (option == 0)
            {
                LocalParameters.exerciseFactor = 1.2;
                CalculateDailyCal();
            }
            else if (option == 1)
            {
                LocalParameters.exerciseFactor = 1.375;
                CalculateDailyCal();
            }
            else if (option == 2)
            {
                LocalParameters.exerciseFactor = 1.55;
                CalculateDailyCal();
            }
            else if (option == 3)
            {
                LocalParameters.exerciseFactor = 1.7;
                CalculateDailyCal();
            }
            else
            {
                LocalParameters.exerciseFactor = 1.9;
                CalculateDailyCal();
            }
        }
        public void SelectTargetFactor(int option)
        {
            if (option == 0)
            {
                LocalParameters.targetFactor = LocalParameters.TDEEAmount * 0.1;
            }
            else if (option == 1)
            {
                LocalParameters.targetFactor = 0;
            }
            else
            {
                LocalParameters.targetFactor = LocalParameters.TDEEAmount * 0.15;
            }
        }
    }
}
