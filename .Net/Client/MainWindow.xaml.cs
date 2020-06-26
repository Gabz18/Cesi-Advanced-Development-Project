using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Client
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Collection<EncryptedFile> encryptedFiles;

        public MainWindow()
        {
            this.encryptedFiles = new Collection<EncryptedFile>();
            InitializeComponent();
        }


        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            ListView encryptedFilesView = new ListView();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                EncryptedFile encryptedFile = new EncryptedFile(openFileDialog.SafeFileName, File.ReadAllText(openFileDialog.FileName));
                encryptedFilesView.Items.Add(encryptedFile.name);
                this.encryptedFiles.Add(encryptedFile);
                FilesPanel.Children.Add(encryptedFilesView);
            }

        }
        private void decryptFileButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.encryptedFiles.Count == 0)
            {
                MessageBox.Show("On ne peut pas décrypter si il n'y a aucun fichier à traiter !");
            } else
            {
                ProgressBar.Visibility = Visibility.Visible;
            }
        }
    }
}
