using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace KMA.ProgrammingInCSharp2023.Lab1BirthdayApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region Fields
        private DateTime _birthDate;
        private string _age;
        private string _westernSign;
        private string _chineseSign;
        #endregion

        #region Properties
        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }

        public string Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        public string WesternSign
        {
            get => _westernSign;
            set
            {
                _westernSign = value;
                OnPropertyChanged(nameof(WesternSign));
            }
        }

        public string ChineseSign
        {
            get => _chineseSign;
            set
            {
                _chineseSign = value;
                OnPropertyChanged(nameof(ChineseSign));
            }
        }
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        #region Button Clicks
        private void GetAge_Click(object sender, RoutedEventArgs e)
        {
            BirthDate = (DateTime)datePicker.SelectedDate;
            AnalizeDate analizeDate = new AnalizeDate(BirthDate);
            int age = analizeDate.GetAge();
            if (!analizeDate.IsValidAge())
            {
                MessageBox.Show("Invalid date of birth!");
            }
            else if (analizeDate.IsBirthday())
            {
                Age = $"You are {age} today! \nHappy Birthday! \nBe happy! \nGlory to Ukraine!";
            }
            else
            {
                Age = $"You are {age} y.o.";
            }
            WesternSign = "";
            ChineseSign ="";
        }

        private void GetSign_Click(object sender, RoutedEventArgs e)
        {
            BirthDate = (DateTime)datePicker.SelectedDate;
            AnalizeDate analizeDate = new AnalizeDate(BirthDate);
            if (!analizeDate.IsValidAge())
            {
                MessageBox.Show("Invalid date of birth!");
            }
            else
            {
                string westernSign = analizeDate.GetWesternSign();
                string chineseSign = analizeDate.GetChineseSign();
                WesternSign = $"Your Western Sign: {westernSign}";
                ChineseSign = $"Your Chinese Sign: {chineseSign}";
            }
           
            Age = "";
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
