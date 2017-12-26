using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonalTaxCal
{
    public class InsuranceDetailVm : INotifyPropertyChanged
    {
        private decimal _totalAllowance;
        private decimal _travelAllowance;
        private decimal _monthlyIncome;
        private decimal _mealAllowance;
        private decimal _personalPension;
        private decimal _companyPension;
        private decimal _companyMedical;

        public decimal MonthlyIncome
        {
            get
            {
                return _monthlyIncome;
            }
            set
            {
                _monthlyIncome = value;
                NotifyPropertyChanged();
            }
        }

        public decimal TotalAllowance
        {
            get
            {
                return _totalAllowance;
            }
            set
            {
                _totalAllowance = value;
                NotifyPropertyChanged();
            }
        }

        public decimal TravelAllowance
        {
            get
            {
                return _travelAllowance;
            }
            set
            {
                _travelAllowance = value;
                NotifyPropertyChanged();
            }

        }

        public decimal MealAllowance
        {
            get
            {
                return _mealAllowance;
            }
            set
            {
                _mealAllowance = value;
                NotifyPropertyChanged();
            }
        }

        public decimal PersonalPension
        {
            get
            {
                return _personalPension;
            }

            set
            {
                _personalPension = value;
                NotifyPropertyChanged();
            }
        }

        public decimal CompanyPension
        {
            get
            {
                return _companyPension;
            }

            set
            {
                _companyPension = value;
                NotifyPropertyChanged();
            }
        }

        public decimal PersonalMedical
        {
            get;set;            
        }

        public decimal CompanyMedical
        {
            get
            {
                return _companyMedical;
            }

            set
            {
                _companyMedical = value;
                NotifyPropertyChanged();
            }
        }

        public decimal PersonalUnemployment
        {
            get; set;
        }

        public decimal CompanyUnemployment
        {
            get; set;
        }

        public decimal PersonalHousingAccumulationFundLoan
        {
            get; set;
        }

        public decimal InjuryInsurance
        {
            get; set;
        }

        public decimal BirthInsurance
        {
            get; set;
        }

        public double HeatingFee
        {
            get; set;
        }

        public decimal CompanyHousingAccumulationFundLoan
        {
            get; set;
        }

        public decimal TaxedIncome
        {
            get; set;
        }

        public decimal PersonalTaxTotal
        {
            get; set;
        }

        public decimal TotalBeforeTaxIncome
        {
            get; set;
        }

        public decimal TotalTaxedNotPay
        {
            get; set;
        }

        public decimal TotalSubstracBeforeTax
        {
            get;set;
        }

        public decimal RealTotalIncome
        {
            get; set;
        }


        public InsuranceDetailVm(decimal baseIncome)
        {
            MonthlyIncome = baseIncome;
            TravelAllowance = ConfigDataMgr.GetTravelAllowance();
            MealAllowance = ConfigDataMgr.GetMealAllowance();
            TotalAllowance = TravelAllowance + MealAllowance;
            var societyAvgInc = ConfigDataMgr.GetSocietyAverageIncome();
            var InsuranceCapIncome = societyAvgInc * 3;

            //Income bigger than 3 times of society average income
            if (MonthlyIncome < InsuranceCapIncome)
            {
                InsuranceCapIncome = MonthlyIncome;
            }


            //PersonalPension - %8 of income
            PersonalPension = (decimal)((double)InsuranceCapIncome * 0.08);

            //CompanyPension - 18% of income
            CompanyPension = (decimal)((double)InsuranceCapIncome * 0.18);

            //PersonalMedical - 2% of income
            PersonalMedical = (decimal)((double)InsuranceCapIncome * 0.02);

            //PersonalMedical - 8% of income
            CompanyMedical = (decimal)((double)InsuranceCapIncome * 0.08);

            //Personal Unemployment - 0.5% of income
            PersonalUnemployment = (decimal)((double)InsuranceCapIncome * 0.005);

            //Company Unemployment - 0.5% of income
            CompanyUnemployment = (decimal)((double)InsuranceCapIncome * 0.005);

            //PersonalHousingAccumulationFundLoan - 12% of income
            var lastYearAvg = ConfigDataMgr.GetLastYearMyAvgInc();
            bool tooLargeIncome = false;
            if (lastYearAvg > InsuranceCapIncome)
            {
                tooLargeIncome = true;
            }
            PersonalHousingAccumulationFundLoan = (decimal)((double)lastYearAvg * 0.12);

            //PersonalHousingAccumulationFundLoan - 12% of income
            CompanyHousingAccumulationFundLoan = (decimal)((double)lastYearAvg * 0.12);

            //InjuryInsurance - 0.4% of income
            InjuryInsurance = (decimal)((double)InsuranceCapIncome * 0.004);

            //InjuryInsurance - 1.2% of income
            BirthInsurance = (decimal)((double)InsuranceCapIncome * 0.012);

            //Should taxed income            
            if (tooLargeIncome)
            {
                //var fixInsurance = PersonalPension + PersonalMedical + PersonalUnemployment;
                var societyHouseFound = societyAvgInc * (decimal)0.12;
                TaxedIncome = MonthlyIncome - societyHouseFound - 2000;
            }
            else
            {
                TaxedIncome = MonthlyIncome - PersonalHousingAccumulationFundLoan - 2000;
            }

            //Tax of income
            PersonalTaxTotal = (decimal)Utils.CalcPersonalIncomeTax((double)TaxedIncome);

            //Before taxed income
            TotalBeforeTaxIncome = MonthlyIncome + TotalAllowance;

            //TotalSubstracBeforeTax
            TotalSubstracBeforeTax = PersonalMedical + PersonalPension + PersonalUnemployment + PersonalHousingAccumulationFundLoan;

            //Substract insurance before Tax 

            //Real income
            RealTotalIncome = TotalBeforeTaxIncome - TotalSubstracBeforeTax - PersonalTaxTotal;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
