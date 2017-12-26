using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PersonalTaxCal
{
    public static class ConfigDataMgr
    {
        public static decimal GetSocietyAverageIncome()
        {
            string averageString = ConfigurationManager.AppSettings["SocietyAverange"];
            decimal averageDecimal = decimal.Zero;
            decimal.TryParse(averageString, out averageDecimal);
            return averageDecimal;
        }


        public static decimal GetTravelAllowance()
        {
            string travelAllowanceString = ConfigurationManager.AppSettings["TravelAllowance"];
            decimal travelDecimal = decimal.Zero;
            decimal.TryParse(travelAllowanceString, out travelDecimal);
            return travelDecimal;
        }

        public static decimal GetMealAllowance()
        {
            string mealAllowanceString = ConfigurationManager.AppSettings["MealAllowance"];
            decimal mealAllowanceDecimal = decimal.Zero;
            decimal.TryParse(mealAllowanceString, out mealAllowanceDecimal);
            return mealAllowanceDecimal;
        }

        public static decimal GetLastYearMyAvgInc()
        {
            string lastYearMyAvgInc = ConfigurationManager.AppSettings["LastYearMyAverangeIncome"];
            decimal lastYearMyAvgIncDecimal = decimal.Zero;
            decimal.TryParse(lastYearMyAvgInc, out lastYearMyAvgIncDecimal);
            return lastYearMyAvgIncDecimal;
        }

    }
}
