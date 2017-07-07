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
using Xceed.Wpf.Toolkit;
using HideIt.Model;

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
            ComboBoxEncrypt.Items.Add("Bez szyfrowania");
            ComboBoxEncrypt.Items.Add("Szyfr Cezara");
            ComboBoxEncrypt.SelectedIndex = 0;
        }

        #region Buttons

        #region Buttons.BasePicture

        bool flagButtonBasePicture;

        private void ButtonBasePicture_MouseEnter(object sender, MouseEventArgs e)
        {
            setInfo("Kliknij by wczytać obraz, który będzie bazą do ukrycia wiadomości");
            flagButtonBasePicture = false;
        }

        private void ButtonBasePicture_MouseLeave(object sender, MouseEventArgs e)
        {
            if (flagButtonBasePicture == false)
                setInfo();

            flagButtonBasePicture = false;
        }

        private void ButtonBasePicture_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            flagButtonBasePicture = true;
        }

        private void ButtonBasePicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG images (*.jpg)|*.jpg";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                setPictureParam(openFileDialog.FileName);
            }
        }

        #endregion Buttons.BasePicture

        #region Buttons.FileMessage

        bool flagButtonFileMessage;

        private void ButtonFileMessage_MouseEnter(object sender, MouseEventArgs e)
        {
            setInfo("Kliknij by wczytać plik z wiadomością do ukrycia");
            flagButtonFileMessage = false;
        }

        private void ButtonFileMessage_MouseLeave(object sender, MouseEventArgs e)
        {
            if (flagButtonFileMessage == false)
                setInfo();

            flagButtonFileMessage = false;
        }

        private void ButtonFileMessage_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            flagButtonFileMessage = true;
        }

        private void ButtonFileMessage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Txt files (*.txt)|*.txt";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                setFileMessageInfo(openFileDialog.FileName);
            }
        }

        #endregion Buttons.FileMessage

        #region Buttons.Encrypt

        bool flagButtonEncrypt;

        private void ButtonEncrypt_MouseEnter(object sender, MouseEventArgs e)
        {
            setInfo("Kliknij by rozpocząć szyfrowanie");
            flagButtonEncrypt = false;
        }

        private void ButtonEncrypt_MouseLeave(object sender, MouseEventArgs e)
        {
            if(flagButtonEncrypt == false)
                setInfo();
        }

        private void ButtonEncrypt_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            flagButtonEncrypt = true;
        }

        private void ButtonEncrypt_Click(object sender, RoutedEventArgs e)
        {
            //TODO walidacja
            //TODO szyfrowanie wiadomosci jezeli zaznaczone
            //TODO ustalenie parametrow steganograficznych
            //TODO wpisanie informacji w obraz w osobnym watku
            //TODO dodanie procesu ukrywania do zakladni procesy
            //TODO Messageboxy albo Info 
            switch(ComboBoxEncrypt.SelectedItem.ToString())
            {
                case "Szyfr Cezara":
                    //MessageBox.Show("wybrano cezara");
                    EncryptDecrypt ed = new Caesar(5);
                    setInfo(ed.EncryptAlgorithm(TextBoxMessage.Text.ToString()));
                    
                    break;
                default:
                    //MessageBox.Show("Wybrano bez szyfrowania");
                    //bez szyfrowania
                    break;
            }
        }

        #endregion Buttons.Encrypt

        #region Buttons.Decryption

        bool flagButtonDecryption;

        private void ButtonDecryption_MouseEnter(object sender, MouseEventArgs e)
        {
            setInfo("Kliknij by rozpocząć deszyfrowanie");
            flagButtonDecryption = false;
        }

        private void ButtonDecryption_MouseLeave(object sender, MouseEventArgs e)
        {
            if(flagButtonDecryption == false)
                setInfo();
        }

        private void ButtonDecryption_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            flagButtonDecryption = true;
        }

        private void ButtonDecryption_Click(object sender, RoutedEventArgs e)
        {
            //TODO Deszyfrowanie wczytanego obrazu
            //TODO Dodanie do procesow
            //TODO i inne ale nie wiem co
        }

        #endregion Buttons.Decryption

        #endregion Buttons

        #region SetInformations
        private void setFileMessageInfo(string FileName)
        {
            try
            {
                FileInfo fi = new FileInfo(FileName);
                String s = File.ReadAllText(FileName);

                LabelFilePathMessage.Content = "Ścieżka pliku: " + FileName;
                LabelFileMessageParam.Content =
                    "Parametry tekstu:  " + Environment.NewLine +
                    "Ilość znaków:  " + s.Length + Environment.NewLine +
                    "Rozmiar:   " + (fi.Length / 1000.0 < 1 ? "<1" : (fi.Length / 1000.0).ToString()) + "Mb";

                if (s.Length > 1000)
                    TextBoxMessage.Text = "Tekst jest za długi do wyświetlenia, więcej niż 1000 znaków";
                else
                    TextBoxMessage.Text = s;
            }
            catch (Exception e)
            {
                setError(e.Message);
            }
        }

        private void setPictureParam(string FileName)
        {
            try
            {
                ImageBase.Source = new BitmapImage(new Uri(FileName));
                FileInfo fi = new FileInfo(FileName);

                var pix = ImageBase.Source.Width * ImageBase.Source.Height;
                FilePathBase.Content = "Ścieżka pliku: " + FileName;
                LabelImageParam.Content =
                    "Parametry obrazu:" + Environment.NewLine +
                    "Wysokość: " + ImageBase.Source.Height + Environment.NewLine +
                    "Szerokość: " + ImageBase.Source.Width + Environment.NewLine +
                    "Ilość pixeli: " + pix + Environment.NewLine +
                    "Rozmiar: " + (fi.Length / 1000.0 < 1 ? "<1" : (fi.Length / 1000.0).ToString()) + "Mb";
            }
            catch (Exception e)
            {
                setError(e.Message);
            }
        }

        private void setInfo(String info = "")
        {
            TextBoxInfo.Text = info;
        }

        private void setError(String errorMessage)
        {
            TextBoxInfo.Text = "Błąd: " + errorMessage;
        }

        #endregion SetInformations

        #region ComboBoxs

        #region ComboBoxs.Encrypt

        private void ComboBoxEncrypt_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ComboBoxEncrypt_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void ComboBoxEncrypt_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void ComboBoxEncrypt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InitGridEncryptParamForComboBox();
        }
        #endregion ComboBoxs.Encrypt

        #endregion ComboBoxs

        #region Inits

        #region Inits.GridEncryptParamForComboBox

        public bool InitGridEncryptParamForComboBox()
        {
            try
            {
                switch (ComboBoxEncrypt.SelectedItem.ToString())
                {
                    case "Szyfr Cezara":
                        InitCaesar();
                        break;
                    default:
                        //MessageBox.Show("Wybrano bez szyfrowania");
                        GridEncryptParamForComboBox.Children.Clear();
                        Label l = new Label();
                        l.Content = "Nie wybrano żadnego trybu szyfrowania";
                        GridEncryptParamForComboBox.Children.Add(l);

                        //bez szyfrowania
                        break;
                }

                return true;
            }
            catch(Exception e)
            {
                setError(e.Message);
                return false; //something going wrong
            }
            
        }



        #endregion Inits.GridEncryptParamForComboBox

        #region Inits.InitCaesar

        private bool InitCaesar()
        {
            try
            {
                GridEncryptParamForComboBox.Children.Clear();

                #region mainGrid

                Grid mainGrid = new Grid();

                ColumnDefinition cd1 = new ColumnDefinition();
                ColumnDefinition cd2 = new ColumnDefinition();
                ColumnDefinition cd3 = new ColumnDefinition();
                cd1.Width = new GridLength(200, GridUnitType.Pixel);
                cd2.Width = new GridLength(200, GridUnitType.Pixel);
                cd3.Width = new GridLength(300, GridUnitType.Star);

                RowDefinition rd1 = new RowDefinition();
                RowDefinition rd2 = new RowDefinition();
                rd1.Height = new GridLength(50, GridUnitType.Pixel);
                rd2.Height = new GridLength(500, GridUnitType.Star);

                mainGrid.ColumnDefinitions.Add(cd1);
                mainGrid.ColumnDefinitions.Add(cd2);

                mainGrid.RowDefinitions.Add(rd1);
                mainGrid.RowDefinitions.Add(rd2);

                #endregion mainGrid

                #region Items

                #region Items.labelKeyValueCaesar

                Label labelKeyValueCaesar = new Label();
                labelKeyValueCaesar.Content = "Wartość klucza: ";
                labelKeyValueCaesar.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                labelKeyValueCaesar.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right;
                labelKeyValueCaesar.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                Grid.SetRow(labelKeyValueCaesar, 0);
                Grid.SetColumn(labelKeyValueCaesar, 0);
                mainGrid.Children.Add(labelKeyValueCaesar);

                #endregion Items.labelKeyValueCaesar

                #region Items.updownKeyValueCaesar

                IntegerUpDown updownKeyValueCaesar = new IntegerUpDown();
                updownKeyValueCaesar.Margin = new Thickness(5);
                updownKeyValueCaesar.Text = "5";
                updownKeyValueCaesar.FormatString = "N0";
                updownKeyValueCaesar.Watermark = "Enter Integer";
                updownKeyValueCaesar.Maximum = 500;
                updownKeyValueCaesar.Minimum = -500;
                updownKeyValueCaesar.MouseEnter += updownKeyValueCaesar_MouseEnter;
                updownKeyValueCaesar.MouseLeave += updownKeyValueCaesar_MouseLeave;
                updownKeyValueCaesar.MouseRightButtonUp += updownKeyValueCaesar_MouseRightButtonUp;
                Grid.SetRow(updownKeyValueCaesar, 0);
                Grid.SetColumn(updownKeyValueCaesar, 1);
                mainGrid.Children.Add(updownKeyValueCaesar);

                #endregion Items.updownKeyValueCaesar

                #endregion Items

                GridEncryptParamForComboBox.Children.Add(mainGrid);

                return true;
            }
            catch(Exception ex)
            {
                setError(ex.Message);
                return false;
            }
        }



        #endregion Inits.InitCaesar

        #endregion Inits

        #region IntegerUpDown

        bool flagupdownKeyValueCaesar;

        private void updownKeyValueCaesar_MouseEnter(object sender, MouseEventArgs e)
        {
            setInfo("Kliknij by edytować wartość klucza dla szyfrowania");
            flagupdownKeyValueCaesar = false;
        }

        void updownKeyValueCaesar_MouseLeave(object sender, MouseEventArgs e)
        {
            if (flagupdownKeyValueCaesar == false)
                setInfo();
        }

        void updownKeyValueCaesar_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            flagupdownKeyValueCaesar = true;
        }

        #endregion IntegerUpDown
    }
}