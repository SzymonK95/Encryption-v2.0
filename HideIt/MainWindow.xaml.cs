using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace HideIt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonEncrypt_MouseEnter(object sender, MouseEventArgs e)
        {
            textBlockInfo.Text = "Kliknij by rozpocząć szyfrowanie";
        }

        private void buttonEncrypt_MouseLeave(object sender, MouseEventArgs e)
        {
            textBlockInfo.Text = "";
        }

        private void buttonDecryption_MouseEnter(object sender, MouseEventArgs e)
        {
            textBlockInfo.Text = "Kliknij by rozpocząć deszyfrowanie";
        }

        private void buttonDecryption_MouseLeave(object sender, MouseEventArgs e)
        {
            textBlockInfo.Text = "";
        }

        private void ButtonBasePicture_MouseEnter(object sender, MouseEventArgs e)
        {
            textBlockInfo.Text = "Kliknij by wczytać obraz, który będzie bazą do ukrycia wiadomości";
        }

        private void ButtonBasePicture_MouseLeave(object sender, MouseEventArgs e)
        {
            textBlockInfo.Text = "";
        }

        private void ButtonBasePicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG images (*.jpg)|*.jpg";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                ImageBase.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
    }
}
