using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

        private void ButtonEncrypt_MouseEnter(object sender, MouseEventArgs e)
        {
            setInfo("Kliknij by rozpocząć szyfrowanie");
        }

        private void ButtonEncrypt_MouseLeave(object sender, MouseEventArgs e)
        {
            setInfo("");
        }

        private void ButtonDecryption_MouseEnter(object sender, MouseEventArgs e)
        {
            setInfo("Kliknij by rozpocząć deszyfrowanie");
        }

        private void ButtonDecryption_MouseLeave(object sender, MouseEventArgs e)
        {
            setInfo("");
        }

        private void ButtonBasePicture_MouseEnter(object sender, MouseEventArgs e)
        {
            setInfo("Kliknij by wczytać obraz, który będzie bazą do ukrycia wiadomości");
        }

        private void ButtonBasePicture_MouseLeave(object sender, MouseEventArgs e)
        {
            setInfo("");
        }

        private void ButtonBasePicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG images (*.jpg)|*.jpg";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {  
                ImageBase.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                setPictureParam(openFileDialog.FileName);
            }
        }

        private void setPictureParam(string FileName)
        {
            try
            {
                FileInfo fi = new FileInfo(FileName);

                var pix = ImageBase.Source.Width * ImageBase.Source.Height;
                FilePathBase.Content = "Ścieżka pliku: " + FileName;
                LabelImageParam.Content = 
                    "Parametry obrazu: " + Environment.NewLine +
                    "Wysokość: " + ImageBase.Source.Height + Environment.NewLine +
                    "Szerokość: " + ImageBase.Source.Width + Environment.NewLine +
                    "Ilość pixeli: " + pix + Environment.NewLine +
                    "Rozmiar: " + fi.Length / 1000 + "Mb";
            }
            catch(Exception e)
            {
                setInfo("Błąd: " + e.Message);
            }
        }

        private void ButtonFileMessage_MouseEnter(object sender, MouseEventArgs e)
        {
            setInfo("Kliknij by wczytać plik z wiadomością do ukrycia");
        }

        private void ButtonFileMessage_MouseLeave(object sender, MouseEventArgs e)
        {
            setInfo("");
        }

        private void ButtonFileMessage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Txt images (*.txt)|*.txt";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                //TODO przechowywanie wiadomosci bo jak za dluga to moze lepiej nie wypisywać
                //TODO Funkjca do ustawiania labela dla wiadomości
            }
        }

        private void setInfo(String info)
        {
            TextBlockInfo.Text = info;
        }
    }
}
