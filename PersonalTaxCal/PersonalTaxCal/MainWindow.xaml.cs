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

    private void BtCalculate_OnClick(object sender, RoutedEventArgs e)
    {
      double baseInc = BaseIncome - InsuranceValue;
      double bonus = YearBonus;
      //Get personal tax of month salary
      TaxOfMon = CalcPersonalIncomeTax(baseInc);

      if (DecGetType)
      {
        //Dec tax
        double taxofDec = CalcPersonalIncomeTax(baseInc + BaseIncome);
        TaxOfDec = taxofDec;
        if (baseInc < 3500)
        {
          bonus = bonus - 3500 + baseInc;
        }
        //Apr tax
        double taxofApr = CalcBonusIncomeTax(bonus) + TaxOfMon;
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
        double taxofApr = CalcBonusIncomeTax(bonus) + taxofOneMon;
        TaxOfApr = taxofApr;
        TotalTax = taxofOneMon + taxofApr;
      }
    }

    private double CalcBonusIncomeTax(double bonus)
    {
      double result = 0;
      double bonusPerMon = bonus / 12;

      if (bonusPerMon > 1500)
      {
        if (bonusPerMon <= 4500)
        {
          result = bonus*0.10 - 105;
        }
        else if (bonusPerMon <= 9000)
        {
          result = bonus*0.20 - 555;
        }
        else if (bonusPerMon <= 35000)
        {
          result = bonus*0.25 - 1005;
        }
        else if (bonusPerMon <= 55000)
        {
          result = bonus*0.3 - 2755;
        }
        else if (bonusPerMon <= 80000)
        {
          result = bonus*0.35 - 5505;
        }
        else
        {
          result = bonus * 0.45 - 13505;
        }
      }
      else
      {
        result = bonus*0.03;
      }
      
      return result;
    }

    private double CalcPersonalIncomeTax(double baseIncome)
    {
      double result = 0;
      if (baseIncome > 3500)
      {
        if (baseIncome - 3500 <= 1500)
        {
          result = (baseIncome - 3500)*0.03 - 0;
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
          result = (baseIncome - 3500)*0.35 - 5505;
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

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      var handler = PropertyChanged;
      if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
