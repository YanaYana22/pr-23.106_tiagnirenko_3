using System;
using System.Linq;
using System.Windows;

namespace pr_23._106_tiagnirenko_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void GenerateAndSortButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = int.Parse(NTextBox.Text);
                int minRange = int.Parse(MinRangeTextBox.Text);
                int maxRange = int.Parse(MaxRangeTextBox.Text);

                if (n <= 0)
                {
                    throw new ArgumentException("Размер массива должен быть больше 0.");
                }
                if (minRange >= maxRange)
                {
                    throw new ArgumentException("Минимальное значение диапазона должно быть меньше максимального.");
                }

                Random random = new Random();
                int[] array = Enumerable.Repeat(0, n).Select(x => random.Next(minRange, maxRange + 1)).ToArray();

                SortArray(array);

                ResultTextBox.Text = string.Join(", ", array);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void SortArray(int[] array)
        {
            Array.Sort(array, (a, b) => (a % 2) - (b % 2));
        }
    }
}
