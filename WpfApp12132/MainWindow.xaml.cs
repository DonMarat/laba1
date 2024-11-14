using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp12132.Classes;

namespace WpfApp12132
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            CalculateIntegral();

        }
        private void CalculateIntegral()
        {
            double upperBound = Convert.ToDouble(tbUpperBound.Text);
            double lowerBound = Convert.ToDouble(tbLowerBound.Text);
            int count = Convert.ToInt32(tbCount.Text);

            Icalculatorintegral calculatorIntegral = GetCalculator();

            // Последовательное вычисление
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            double sequentialResult = calculatorIntegral.Calculate(lowerBound, upperBound, count, x => 2 * x - Math.Log(2 * x) + 234);
            stopwatch.Stop();
            double sequentialTime = stopwatch.ElapsedMilliseconds;

            // Параллельное вычисление
            stopwatch.Restart();
            double parallelResult = calculatorIntegral.Calculate(lowerBound, upperBound, count, x => 2 * x - Math.Log(2 * x) + 234);
            stopwatch.Stop();
            double parallelTime = stopwatch.ElapsedMilliseconds;

            // Отображаем результаты
            tbAnswer.Text = $"Sequential: {sequentialResult} (Time: {sequentialTime} ms)\nParallel: {parallelResult} (Time: {parallelTime} ms)";
        }
        
        private Icalculatorintegral GetCalculator()
        {
            switch (cmbBoxIntegralType.SelectedIndex)
            {
                case 0:
                    return new CalculateRectangle();
                case 1:
                    return new Calculatetrap();
                default:
                    return new CalculateRectangle();
            }

        }
    }
}