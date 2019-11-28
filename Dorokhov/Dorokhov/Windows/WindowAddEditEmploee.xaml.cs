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
using System.Windows.Shapes;

namespace Dorokhov.Windows
{
    /// <summary>
    /// Interaction logic for WindowAddEditEmploee.xaml
    /// </summary>
    public partial class WindowAddEditEmploee : Window
    {
        Entities.Employee _employee;
        public WindowAddEditEmploee()
        {
            InitializeComponent();
            Update();
            Title = "Добавление работника";
            BtnOk.Content = "Добавить";
        }

        public WindowAddEditEmploee(Entities.Employee employee)
        {
            InitializeComponent();
            Update();
            Title = "Изменение работника";
            BtnOk.Content = "Изменить";
            _employee = employee;
            TBoxName.Text = employee.Name;
            TBoxSurname.Text = employee.Surname;
            TBoxPatronymic.Text = employee.Patronymic;
            CBoxPost.SelectedItem = employee.Post;
            CBoxRoom.SelectedItem = employee.Room;
            MTBoxPhone.Text = employee.PhoneNumber;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            bool add = false;
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrWhiteSpace(TBoxName.Text))
                error.AppendLine("• Поле 'Имя' не заполнено!");
            if (string.IsNullOrWhiteSpace(TBoxSurname.Text))
                error.AppendLine("• Поле 'Фамилия' не заполнено!");
            if (string.IsNullOrWhiteSpace(TBoxPatronymic.Text))
                error.AppendLine("• Поле 'Отчество' не заполнено!");
            if (CBoxRoom.SelectedItem == null)
                error.AppendLine("• Кабинет не выбран!");
            if (!MTBoxPhone.MaskCompleted)
                error.AppendLine("• Поле 'Телефон' не заполнено или заполнено не полностью!");
            if (CBoxPost.SelectedItem == null)
                error.AppendLine("• Должность не выбрана!");
            if (!error.ToString().Equals(""))
            {
                MessageBox.Show("Невозможно по следующим причинам!\n\n" + error.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (_employee == null)
                add = true;
            _employee = new Entities.Employee()
            {
                Name = TBoxName.Text,
                Surname = TBoxSurname.Text,
                Patronymic = TBoxPatronymic.Text,
                PhoneNumber = MTBoxPhone.Text,
                Room = CBoxRoom.SelectedItem as Entities.Room,
                Post = CBoxPost.SelectedItem as Entities.Post
            };
            if (add)
                AppData.Context.Employees.Add(_employee);
            AppData.Context.SaveChanges();
            DialogResult = true;
        }

        private void Update()
        {
            var rooms = AppData.Context.Rooms.ToList();
            var posts = AppData.Context.Posts.ToList();
            var room = new Entities.Room()
            {
                NumberOfRoom = "Добавить новый кабинет"
            };
            var post = new Entities.Post()
            {
                NameOfPost = "Добавить новую должность"
            };
            rooms.Insert(0, room);
            posts.Insert(0, post);
            CBoxPost.ItemsSource = posts;
            CBoxRoom.ItemsSource = rooms;
        }

        private void CBoxRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBoxRoom.SelectedIndex == 0)
            {
                if (CBoxRoom.Text.Equals(""))
                {
                    MessageBox.Show("Не может быть пустым", "Ошибка!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    CBoxRoom.SelectedItem = null;
                    return;
                }
                if (AppData.Context.Rooms.Where(p => p.NumberOfRoom == CBoxRoom.Text).ToList().Count != 0)
                {
                    MessageBox.Show("Уже существует!", "Ошибка!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    CBoxRoom.SelectedItem = AppData.Context.Rooms.Where(p => p.NumberOfRoom == CBoxRoom.Text).ToList().FirstOrDefault();
                    return;
                }
                Entities.Room room = new Entities.Room()
                {
                    NumberOfRoom = CBoxRoom.Text
                };
                AppData.Context.Rooms.Add(room);
                AppData.Context.SaveChanges();
                Update();
                CBoxRoom.SelectedItem = room;
            }
        }

        private void CBoxPost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBoxPost.SelectedIndex == 0)
            {
                if (CBoxPost.Text.Equals(""))
                {
                    MessageBox.Show("Не может быть пустым","Ошибка!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    CBoxPost.SelectedItem = null;
                    return;
                }
                if (AppData.Context.Posts.Where(p => p.NameOfPost == CBoxPost.Text).ToList().Count != 0)
                {
                    MessageBox.Show("Уже существует!", "Ошибка!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    CBoxPost.SelectedItem = AppData.Context.Posts.Where(p => p.NameOfPost == CBoxPost.Text).ToList().FirstOrDefault();
                    return;
                }
                Entities.Post post = new Entities.Post()
                {
                    NameOfPost = CBoxPost.Text
                };
                AppData.Context.Posts.Add(post);
                AppData.Context.SaveChanges();
                Update();
                CBoxPost.SelectedItem = post;
            }
        }
    }
}
