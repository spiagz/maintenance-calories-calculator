using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public string Age
        {
            get { return AgeInput.Text; }
        }
        public string Gender
        {
            get 
            {
                string gender = "";

                if (Male.IsChecked == true || Female.IsChecked == true)
                {
                    gender = (Male.IsChecked == true) ? Male.Name : Female.Name;
                }

                return gender;
            }
        }

        public string Height
        {
            get { return HeightInput.Text; }
        }

        public string Weight
        {
            get { return WeightInput.Text; }
        }

        public string ActivityValue
        {
            get {
                string activity = ActivityInput.SelectedValue.ToString();
                return activity == "0" ? "" : activity;
             }
        }

        public string ActivityText
        {
            get
            {
                return ActivityInput.Text;
                
            }
        }
        public UserControl1()
        {
            InitializeComponent();
        }
        
        private string calcMaintenanceCalories()
        {
            if (String.IsNullOrEmpty(Age) ||
                String.IsNullOrEmpty(Gender) ||
                String.IsNullOrEmpty(Height) ||
                String.IsNullOrEmpty(Weight) ||
                String.IsNullOrEmpty(ActivityValue))
            {
                return "*error* missing fields";
            }
            else
            {
                int genderDiff = Gender == "Male" ? 5 : -161;
                double calories = (double.Parse(ActivityValue) * (10 * double.Parse(Weight) + 6.25 * double.Parse(Height) - 5 * double.Parse(Age) + genderDiff));
                return Math.Round(calories, 0).ToString();
            }
            
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("" +
                "Is this ok? \n " 
                + "Age: " + Age + "\n"
                + "Gender: " + Gender + "\n"
                + "Height: " + Weight + "\n"
                + "Weight: " + Height + "\n"
                + "Activity level: " + ActivityText + "\n", "Personal Data Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            { 
               
                string calories = calcMaintenanceCalories();
                MessageBox.Show("Your maintenance calories are: " + calories);
            }
        }
    }
}
