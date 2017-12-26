using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PersonalTaxCal
{
    /// <summary>
    /// Interaction logic for InsuranceDetailWin.xaml
    /// </summary>
    public partial class InsuranceDetailWin : Window
    {
        private InsuranceDetailVm _insuranceDetail;
        public InsuranceDetailWin()
        {
            InitializeComponent();        
        }

        public InsuranceDetailWin(decimal baseIncome)
        {
            InitializeComponent();
            InitCtrlData(baseIncome);
        }

        private void InitCtrlData(decimal baseIncome)
        {
            _insuranceDetail = new InsuranceDetailVm(baseIncome);
            DataContext = _insuranceDetail;
        }
    }
}
