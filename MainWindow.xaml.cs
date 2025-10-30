/*
===========================================
Program: Car Inventory Manager (COSC2100)
File: MainWindow.xaml.cs
Author: Ayomide Emmanuel
Date: October 2025
Description:
    Contains the event-handling and logic for the Car Inventory WPF application.
    Handles input validation, creation and modification of Car objects,
    populates the Year ComboBox dynamically, updates the ListView display,
    and manages button events for Enter, Reset, and Exit.
===========================================
*/





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

namespace Assignment_2_Classes_And_Exceptions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Car> cars = new List<Car>();

        public MainWindow()
        {
            InitializeComponent();
            LoadYears();
            lvCars.SelectionChanged += LvCars_SelectionChanged;
        }

        // ==============================
        // Load the last 50 years dynamically
        // ==============================
        private void LoadYears()
        {
            int currentYear = DateTime.Now.Year;
            for (int year = currentYear; year >= currentYear - 49; year--)
            {
                Year.Items.Add(year);
            }
        }

        // ==============================
        // Enter button – Add or Update car
        // ==============================
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            lblOutput.Content = ""; // clear previous message

            if (!ValidateInput(out string make, out string model, out int year, out decimal price, out bool isNew))
                return;

            if (lvCars.SelectedIndex == -1)
            {
                // Add new car
                Car newCar = new Car(make, model, year, price, isNew);
                cars.Add(newCar);
                lblOutput.Content = $"✅ Added: {newCar}";
            }
            else
            {
                // Modify existing car
                Car selectedCar = cars[lvCars.SelectedIndex];
                selectedCar.Make = make;
                selectedCar.Model = model;
                selectedCar.Year = year;
                selectedCar.Price = price;
                selectedCar.IsNew = isNew;

                lblOutput.Content = $"✏️ Updated: {selectedCar}";
            }

            RefreshCarList();
            ResetForm();
        }

        // ==============================
        // Validate input fields
        // ==============================
        private bool ValidateInput(out string make, out string model, out int year, out decimal price, out bool isNew)
        {
            make = "";
            model = "";
            year = 0;
            price = 0;
            isNew = checkIsNew.IsChecked == true;

            if (Make.SelectedItem == null)
            {
                lblOutput.Content = "⚠️ Please select a car make.";
                return false;
            }
            make = ((ComboBoxItem)Make.SelectedItem).Content.ToString();

            if (string.IsNullOrWhiteSpace(Model.Text))
            {
                lblOutput.Content = "⚠️ Please enter a model name.";
                return false;
            }
            model = Model.Text.Trim();

            if (Year.SelectedItem == null)
            {
                lblOutput.Content = "⚠️ Please select a year.";
                return false;
            }
            year = Convert.ToInt32(Year.SelectedItem);

            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                lblOutput.Content = "⚠️ Price must be numeric.";
                return false;
            }

            return true;
        }

        // ==============================
        // Refresh ListView
        // ==============================
        private void RefreshCarList()
        {
            lvCars.Items.Clear();
            foreach (Car c in cars)
            {
                lvCars.Items.Add(c);
            }
        }

        // ==============================
        // Reset form
        // ==============================
        private void ResetForm()
        {
            Make.SelectedIndex = -1;
            Model.Clear();
            Year.SelectedIndex = -1;
            txtPrice.Clear();
            checkIsNew.IsChecked = false;
            lvCars.SelectedIndex = -1;
        }

        // ==============================
        // Reset button
        // ==============================
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetForm();
            lblOutput.Content = "Form reset.";
        }

        // ==============================
        // Exit button
        // ==============================
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // ==============================
        // When selecting a car from list
        // ==============================
        private void LvCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvCars.SelectedIndex == -1) return;

            Car selectedCar = cars[lvCars.SelectedIndex];
            Make.Text = selectedCar.Make;
            Model.Text = selectedCar.Model;
            Year.Text = selectedCar.Year.ToString();
            txtPrice.Text = selectedCar.Price.ToString("0.00");
            checkIsNew.IsChecked = selectedCar.IsNew;
        }
    }
}
