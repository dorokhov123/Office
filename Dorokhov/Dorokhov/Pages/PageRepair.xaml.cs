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

namespace Dorokhov.Pages
{
    /// <summary>
    /// Interaction logic for PageRepair.xaml
    /// </summary>
    public partial class PageRepair : Page
    {
        public PageRepair()
        {
            InitializeComponent();
        }

        private void CBFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
        public void Update()
        {
            var list = AppData.Context.Repairs.ToList();
            if (!TBoxSearch.Text.Equals(""))
                list = list.Where(p => p.Employee.FullName.ToLower().Contains(TBoxSearch.Text.ToLower()) ||
                     p.Equipment.Info.ToLower().Contains(TBoxSearch.Text.ToLower()) ||
                     p.Employee.RoomOfEmployee.ToLower().Contains(TBoxSearch.Text.ToLower()) ||
                      p.Cost.ToString().ToLower().Contains(TBoxSearch.Text.ToLower()) ||
                     p.Reason.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            if (CBFilter.SelectedIndex != 0)
                list = list.Where(p => p.Employee == CBFilter.SelectedItem as Entities.Employee).ToList();
            DGEmployers.ItemsSource = list;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var employees = AppData.Context.Employees.Where(p=>p.IdPost == 1).ToList();
            var employee = new Entities.Employee
            {
                Surname = "All"
            };
            employees.Insert(0, employee);
            CBFilter.ItemsSource = employees;
            CBFilter.SelectedIndex = 0;
            Update();
        }
    }
}
