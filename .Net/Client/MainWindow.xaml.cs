using Client.ServiceReference1;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IdentityModel.Tokens;
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
        private Collection<DecryptedFile> decryptedFiles;
        private bool tokenValidity;


        public MainWindow()
        {
            this.encryptedFiles = new Collection<EncryptedFile>();
            this.decryptedFiles = new Collection<DecryptedFile>();
            tokenValidity = true;
            InitializeComponent();
        }


        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            ListView encryptedFilesView = new ListView();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                EncryptedFile encryptedFile = new EncryptedFile(openFileDialog.SafeFileName, File.ReadAllText(openFileDialog.FileName));
                this.encryptedFiles.Add(encryptedFile);
                encryptedFilesView.Items.Add(encryptedFile.name);
                encryptedFilesView.Width = 200;
                ChosenFilesPanel.Children.Add(encryptedFilesView);
            }

        }

        private void decryptFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.encryptedFiles.Count == 0)
            {
                MessageBox.Show("On ne peut pas décrypter si il n'y a aucun fichier à traiter !");
            }
            else
            {

                //decryptFileButton.IsEnabled = false;

                //myResetButton.IsEnabled = false;
                //btnOpenFile.IsEnabled = false;
                //decryptFileButton.IsEnabled = false;
                ProgressBar.Visibility = Visibility.Visible;


                ////Partie simulation de travail 
                BackgroundWorker worker = new BackgroundWorker();
                
                worker.DoWork += worker_doWork;
                //worker.RunWorkerCompleted += worker_RunWorkerCompleted;
                worker.RunWorkerAsync();

                if(tokenValidity == false)
                {
                    LoginWindow loginWindow = new LoginWindow();
                    App.Current.MainWindow = loginWindow;
                    this.Close();
                    loginWindow.Show();
                }
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBar.Visibility = Visibility.Hidden;
            foreach (DecryptedFile file in decryptedFiles)
            {
                StackPanel stack = new StackPanel();
                stack.Orientation = Orientation.Horizontal;
                Button downloadButton = new Button();
                downloadButton.Content = "Download";
                downloadButton.Click += btnSaveFile_Click;
                downloadButton.Tag = file;
                ListView decryptedFilesView = new ListView();
                decryptedFilesView.Width = 200;

                Thickness m = decryptedFilesView.Margin;
                m.Right = 10;
                decryptedFilesView.Margin = m;

                decryptedFilesView.Items.Add(file.Name);
                stack.Children.Add(decryptedFilesView);
                stack.Children.Add(downloadButton);
                DecryptedFilesPanel.Children.Add(stack);
                myResetButton.IsEnabled = true;
            }
        }

        private void worker_doWork(object sender, DoWorkEventArgs e)
        {
            Collection<EncryptedFile> myCollection = new Collection<EncryptedFile>();
            
            foreach(EncryptedFile encryptedFile in encryptedFiles)
            {
                myCollection.Add(encryptedFile);
            }
            encryptedFiles.Clear();

            foreach(EncryptedFile file in myCollection)
            {
                if(!Sender.Instance.sendEncryptedDocument(new object[] { file.name, file.content }))
                {
                    tokenValidity = false;
                }
            }
        }


        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            var receivedFile = ((Button)sender).Tag;
            DecryptedFile file = (DecryptedFile)receivedFile;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, file.Content);
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            this.encryptedFiles.Clear();
            this.decryptedFiles.Clear();
            DecryptedFilesPanel.Children.Clear();
            ChosenFilesPanel.Children.Clear();
            btnOpenFile.IsEnabled = true;
            decryptFileButton.IsEnabled = true;
        }
    }
}
