using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Wpf_Independent_work_3
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)//изменение стиля шрифта
        {
            string fontName = ((sender as ComboBox).SelectedItem as string);
            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)//изменение размера шрифта
        {
            if (textBox != null)
            {
                double fontSize = Convert.ToDouble(((sender as ComboBox).SelectedItem));
                textBox.FontSize = fontSize;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)//изменение толщины шрифта
        {
            if (textBox.FontWeight==FontWeights.Normal)
            {
                textBox.FontWeight = FontWeights.Bold;
            }
            else
            {
                textBox.FontWeight = FontWeights.Normal;
            }
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)//изменение наклона
        {
            if (textBox.FontStyle == FontStyles.Normal)
            {
                textBox.FontStyle = FontStyles.Italic;
            }
            else
            {
                textBox.FontStyle = FontStyles.Normal;
            }
        }

        private void ToggleButton_Click_1(object sender, RoutedEventArgs e)//подчеркивание 
        {
            if(textBox.TextDecorations.Count==0)
            {
                textBox.TextDecorations.Add(TextDecorations.Underline);
            }
            else
            {
                textBox.TextDecorations.Remove(TextDecorations.Underline[0]);
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)//изменение цвета текста
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Black;
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Red;
            }
        }

        private void OpenExecuted(object sender, RoutedEventArgs e)//открытие файла
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";//Задаем фильтр с расширениями файлов 
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveExecuted(object sender, RoutedEventArgs e)//сохранение файла
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void ExitExecuted(object sender, RoutedEventArgs e)//закрытие программы
        {
            Application.Current.Shutdown();
        }

        private void themes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            Uri theme = new Uri(themes.SelectedIndex == 0 ? "Light.xaml" : "Dark.xaml",UriKind.Relative);//создаем экземпляр класса Uri для привязки словарей ресурсов. 
                                                                                                         //В конструкторе, через тернарный опероатор определяем какой из словарей подключить, в зависимости от выбранного значения в ComboBox с темами.
                                                                                                         //указываем тип пути к файлу "относительный".
            ResourceDictionary themeDict = Application.LoadComponent(theme) as ResourceDictionary;//подключаем выбраный файл
            Application.Current.Resources.MergedDictionaries.Add(themeDict);//загружаем полученный ресурс в коллекцию ресурсов
        }
    }
}
