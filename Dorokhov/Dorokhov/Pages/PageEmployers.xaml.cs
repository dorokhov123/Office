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
    /// Interaction logic for PageEmployers.xaml
    /// </summary>
    public partial class PageEmployers : Page
    {
        public PageEmployers()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<Entities.Room> rooms = AppData.Context.Rooms.ToList();
            var room = new Entities.Room
            {
                NumberOfRoom = "All"
            };
            rooms.Insert(0, room);
            CBFilter.ItemsSource = rooms;
            CBFilter.SelectedIndex = 0;
            Update();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void CBFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        public void Update()
        {
            var list = AppData.Context.Employees.ToList();
            if (!TBoxSearch.Text.Equals(""))
               list = list.Where(p => p.Name.ToLower().Contains(TBoxSearch.Text.ToLower()) ||
                    p.Surname.ToLower().Contains(TBoxSearch.Text.ToLower()) ||
                    p.Patronymic.ToLower().Contains(TBoxSearch.Text.ToLower()) ||
                    p.PhoneNumber.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            if (CBFilter.SelectedIndex != 0)
               list = list.Where(p => p.Room == CBFilter.SelectedItem as Entities.Room).ToList();
            DGEmployers.ItemsSource = list;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Windows.WindowAddEditEmploee(DGEmployers.SelectedItem as Entities.Employee);
            window.ShowDialog();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить?", "Удалить?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AppData.Context.Employees.Remove(DGEmployers.SelectedItem as Entities.Employee);
                AppData.Context.SaveChanges();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Windows.WindowAddEditEmploee();
            window.ShowDialog();
        }
    }
}
