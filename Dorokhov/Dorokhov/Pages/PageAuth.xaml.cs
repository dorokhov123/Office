using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for PageAuth.xaml
    /// </summary>
    public partial class PageAuth : Page
    {
        string _capchaText = "";
        public PageAuth()
        {
            InitializeComponent();
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TBoxLogin.Text == "" ||
                    PasswordBoxPass.Password == "")
                {
                    MessageBox.Show("All field are required",
                        Properties.Resources.MessageError, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (_capchaText != TextBoxCapcha.Text)
                {
                    MessageBox.Show(Properties.Resources.MessageCapcha, Properties.Resources.MessageError, MessageBoxButton.OK, MessageBoxImage.Error);
                    ImageCapcha.Source = Drawing(Convert.ToInt32(ImageCapcha.Width), Convert.ToInt32(ImageCapcha.Height));
                    TextBoxCapcha.Text = "";
                    return;
                }

                var currentUser = AppData.Context.Users.ToList()
                    .FirstOrDefault(p => p.Login.Equals(TBoxLogin.Text) && p.Password.Equals(PasswordBoxPass.Password));
                if (currentUser != null)
                {
                    AppData.MainFrame.Navigate(new PageMenu());
                }
                else
                {
                    MessageBox.Show(Properties.Resources.MessageUser, Properties.Resources.MessageError, MessageBoxButton.OK, MessageBoxImage.Error);
                    ImageCapcha.Source = Drawing(Convert.ToInt32(ImageCapcha.Width), Convert.ToInt32(ImageCapcha.Height));
                    TextBoxCapcha.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Error", Properties.Resources.MessageError, MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        private DrawingImage Drawing(int width, int height)
        {
            _capchaText = "";
            Random random = new Random();
            char c ='0';
            for (int i = 0; i < 6; i++)
            {
                switch (random.Next(1,4))
                { 
                    case 1:
                        c = (char)random.Next(48, 58);
                        break;
                    case 2:
                        c = (char)random.Next(65, 91);
                        break;
                    case 3:
                        c = (char)random.Next(97, 123);
                        break;
                    default:
                        break;
                }
                _capchaText += c;
            }
            byte[] bytes = new byte[width * height * 100];
            random.NextBytes(bytes);
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                drawingContext.DrawImage(BitmapSource.Create(width, height, 300, 300, PixelFormats.Rgb48, null, bytes, width * 30), new Rect(0, 0, width, height));
                int v = ((height / 4) + (width / 4));
#pragma warning disable CS0618 // Type or member is obsolete
                drawingContext.DrawText(new FormattedText(_capchaText, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), v / 2, Brushes.Black), new Point(width / 7, height / 7));
#pragma warning restore CS0618 // Type or member is obsolete
            }
            return new DrawingImage(drawingVisual.Drawing);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ImageCapcha.Source = Drawing(Convert.ToInt32(ImageCapcha.Width), Convert.ToInt32(ImageCapcha.Height));
            TextBoxCapcha.Text = "";
        }

        private void ImageCapcha_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImageCapcha.Source = Drawing(Convert.ToInt32(ImageCapcha.Width), Convert.ToInt32(ImageCapcha.Height));
        }
    }
}
