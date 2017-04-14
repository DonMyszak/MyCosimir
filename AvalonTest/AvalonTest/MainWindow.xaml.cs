using System;
using System.Collections.Generic;
using System.IO;
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

namespace AvalonTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static RoutedCommand MyCommand = new RoutedCommand();

        string filename = "";
        bool saved = false;

        public MainWindow()
        {
            InitializeComponent();
            MyCommand.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control));
        }

        private void MyCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            menuSave(sender, e);
        }
        
        private void menuExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void menuSaveAs(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".text"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                filename = dlg.FileName;
                string fileText = textBoxEditor.Text;

                File.WriteAllText(filename, fileText);

                saved = true;
            }


        }

        private void menuSave(object sender, RoutedEventArgs e)
        {
            if (!saved)
            {
                menuSaveAs(sender, e);
            }

            else if (saved)
            {
                //zapisz do pliku
                string fileText = textBoxEditor.Text;
                File.WriteAllText(filename, fileText);

                saved = true;
            }
        }

        private void menuOpen(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".text"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                filename = dlg.FileName;
                string fileText = File.ReadAllText(filename);

                textBoxEditor.Text = fileText;

            }

            
        }

        private void menuRun(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("run script");
        }


    }
}
