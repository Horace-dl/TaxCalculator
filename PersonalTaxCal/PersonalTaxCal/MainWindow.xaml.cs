using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PersonalTaxCal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private double _baseIncome;
        private double _yearBonus;
        private bool _decGetType;
        private bool _apriGetType;
        private double _taxOfDec;
        private double _taxOfApr;
        private double _totalTax;
        private double _taxOfMon;
        private double _insuranceValue;

        public double BaseIncome
        {
            get { return _baseIncome; }
            set { _baseIncome = value; }
        }

        public double YearBonus
        {
            get { return _yearBonus; }
            set
            {
                _yearBonus = value;
                OnPropertyChanged();
            }
        }

        public bool DecGetType
        {
            get { return _decGetType; }
            set
            {
                _decGetType = value;
                OnPropertyChanged();
            }
        }

        public bool ApriGetType
        {
            get { return _apriGetType; }
            set
            {
                _apriGetType = value;
                OnPropertyChanged();
            }
        }

        public double TaxOfDec
        {
            get { return _taxOfDec; }
            set
            {
                _taxOfDec = value;
                OnPropertyChanged();
            }
        }

        public double TaxOfApr
        {
            get { return _taxOfApr; }
            set
            {
                _taxOfApr = value;
                OnPropertyChanged();
            }
        }

        public double TotalTax
        {
            get { return _totalTax; }
            set
            {
                _totalTax = value;
                OnPropertyChanged();
            }
        }

        public double TaxOfMon
        {
            get { return _taxOfMon; }
            set
            {
                _taxOfMon = value;
                OnPropertyChanged();
            }
        }

        public double InsuranceValue
        {
            get { return _insuranceValue; }
            set
            {
                _insuranceValue = value;
                OnPropertyChanged();
            }
        }



        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void InitCtrolData ()
            {
            
        }

        private void BtCalculate_OnClick(object sender, RoutedEventArgs e)
        {
            InsuranceDetailVm detail = new InsuranceDetailVm((decimal)BaseIncome);
            TaxOfMon = (double)detail.PersonalTaxTotal;
            double baseInc = (double)detail.TaxedIncome;
            double bonus = YearBonus;
            //Get personal tax of month salary
            //TaxOfMon = Utils.CalcPersonalIncomeTax(baseInc);

            if (DecGetType)
            {
                //Dec tax
                double taxofDec = Utils.CalcPersonalIncomeTax(baseInc + BaseIncome);
                TaxOfDec = taxofDec;
                if (baseInc < 3500)
                {
                    bonus = bonus - 3500 + baseInc;
                }
                //Apr tax
                double taxofApr = Utils.CalcBonusIncomeTax(bonus) + TaxOfMon;
                TaxOfApr = taxofApr;
                TotalTax = taxofDec + taxofApr;
            }
            else if (ApriGetType)
            {
                //Dec tax
                double taxofOneMon = TaxOfMon;
                TaxOfDec = taxofOneMon;
                if (baseInc < 3500)
                {
                    bonus = baseInc + BaseIncome + bonus - 3500;
                }
                else
                {
                    bonus = BaseIncome + bonus;
                }
                //Apr tax
                double taxofApr = Utils.CalcBonusIncomeTax(bonus) + taxofOneMon;
                TaxOfApr = taxofApr;
                TotalTax = taxofOneMon + taxofApr;
            }
        }
              
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btDetailIncome_Click(object sender, RoutedEventArgs e)
        {
            InsuranceDetailWin detailDlg = new InsuranceDetailWin((decimal)BaseIncome);
            detailDlg.ShowDialog();
        }
    }
}
