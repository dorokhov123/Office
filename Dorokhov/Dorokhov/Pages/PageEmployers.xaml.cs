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
        List<Entities.Room> _rooms = AppData.Context.Rooms.ToList();
        public PageEmployers()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var room = new Entities.Room
            {
                NumberOfRoom = "-1",
                NameOfRoom = "All"
            };
            _rooms.Insert(0, room);
            CBFilter.ItemsSource = _rooms;
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
    }
}
