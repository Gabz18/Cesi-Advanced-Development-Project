﻿using Microsoft.Win32;
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
                encryptedFilesView.Width = 200;
                this.encryptedFiles.Add(encryptedFile);
                ChosenFilesPanel.Children.Add(encryptedFilesView);
            }

        }
        private void decryptFileButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.encryptedFiles.Count == 0)
            {
                MessageBox.Show("On ne peut pas décrypter si il n'y a aucun fichier à traiter !");
            } else
            {
                decryptFileButton.IsEnabled = false;
                ProgressBar.Visibility = Visibility.Visible;

                //Partie simulation de travail 
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += worker_doWork;
                worker.RunWorkerCompleted += worker_RunWorkerCompleted;
                worker.RunWorkerAsync(10000);
                //Fin de cette partie
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBar.Visibility = Visibility.Hidden;
            foreach (EncryptedFile file in encryptedFiles)
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

                decryptedFilesView.Items.Add(file.name);
                stack.Children.Add(decryptedFilesView);
                stack.Children.Add(downloadButton);
                DecryptedFilesPanel.Children.Add(stack);
                btnOpenFile.Visibility = Visibility.Collapsed;

            }
        }

        private void worker_doWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(5000);
        }


        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            var receivedFile = ((Button)sender).Tag;
            EncryptedFile file = (EncryptedFile)receivedFile;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, file.content);
        }
    }
}
