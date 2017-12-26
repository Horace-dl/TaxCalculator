using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalTaxCal
{
    public static class Utils
    {
        public static double CalcPersonalIncomeTax(double baseIncome)
        {
            double result = 0;
            if (baseIncome > 3500)
            {
                if (baseIncome - 3500 <= 1500)
                {
                    result = (baseIncome - 3500) * 0.03 - 0;
                }
                else if (baseIncome - 3500 <= 4500)
                {
                    result = (baseIncome - 3500) * 0.1 - 105;
                }
                else if (baseIncome - 3500 <= 9000)
                {
                    result = (baseIncome - 3500) * 0.2 - 555;
                }
                else if (baseIncome - 3500 <= 35000)
                {
                    result = (baseIncome - 3500) * 0.25 - 1005;
                }
                else if (baseIncome - 3500 <= 55000)
                {
                    result = (baseIncome - 3500) * 0.3 - 2755;
                }
                else if (baseIncome - 3500 <= 80000)
                {
                    result = (baseIncome - 3500) * 0.35 - 5505;
                }
                else
                {
                    result = (baseIncome - 3500) * 0.45 - 13505;
                }
            }
            else
            {
                result = 0;
            }
            return result;
        }

        public static double CalcBonusIncomeTax(double bonus)
        {
            double result = 0;
            double bonusPerMon = bonus / 12;

            if (bonusPerMon > 1500)
            {
                if (bonusPerMon <= 4500)
                {
                    result = bonus * 0.10 - 105;
                }
                else if (bonusPerMon <= 9000)
                {
                    result = bonus * 0.20 - 555;
                }
                else if (bonusPerMon <= 35000)
                {
                    result = bonus * 0.25 - 1005;
                }
                else if (bonusPerMon <= 55000)
                {
                    result = bonus * 0.3 - 2755;
                }
                else if (bonusPerMon <= 80000)
                {
                    result = bonus * 0.35 - 5505;
                }
                else
                {
                    result = bonus * 0.45 - 13505;
                }
            }
            else
            {
                result = bonus * 0.03;
            }

            return result;
        }
    }
}
