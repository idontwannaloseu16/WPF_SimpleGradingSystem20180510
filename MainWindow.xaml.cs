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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_SimpleGradingSystem20180510
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(InputGradeText.Text))
                GradeList.Items.Add(InputGradeText.Text);

            InputGradeText.Clear();
            InputGradeText.Focus();
        }

        private void ComputeAveButton_Click(object sender, RoutedEventArgs e)
        {
            //!Compute Avverage
            int i = 0, result = 0;

            if (GradeList.Items.IsEmpty)
                return; 

            while (i < GradeList.Items.Count)
            {
                result += Convert.ToInt32(GradeList.Items[i++]);
            }

            result = result / i;

            //!Show Display Average
            Window1 window = new Window1();
            window.OutputNameText.Text = InputNameText.Text;
            window.OutputGradeText.Text = Convert.ToString((double)result);
            window.OutputRemarksText.Text = GetRemarks(result);
            
            window.Show();

        }

        private string GetRemarks(int grade)
        {
            string remarks = " ";

            if(grade > 74)
            {
                remarks = "passed";
            }
            else
            {
                remarks = "failed";
            }

            return remarks;
        }
    }
}
