using Microsoft.Win32;
using SimpleYT2MP3.CSPythonScripts;
using SimpleYT2MP3.CSPythonScripts.Interfaces;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleYT2MP3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string youtubeLink = String.Empty;
        private string downloadDirectory = String.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                try
                {
                    DownloadButton.IsEnabled = false;
                    StatusLabel.Content = "Downloading...";

                    youtubeLink = YoutubeLinkInput.Text;

                    if (youtubeLink == String.Empty)
                    {
                        MessageBox.Show("Please type in the link!");
                        return;
                    }

                    

                    IScriptPathProvider pathProvider = new DictionaryScriptPathsProvider();
                    string downloadScriptPath = pathProvider.GetScriptPath("Download");


                    IScriptRunner scriptRunner = new PythonScriptsRunner();


                    string output = await Task.Run(() =>
                    {
                        return scriptRunner.Run(downloadScriptPath, youtubeLink, downloadDirectory);
                    });

                    StatusLabel.Content = output;

                    DownloadButton.IsEnabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd: {ex}");
                }
            }
        }

        private void SetDirectoryLabel(string directory)
        {
            if (IsLoaded)
            {
                DirectoryLabel.Content = directory;
            }
        }

        private void SetDownloadDirectory(string directory)
        {
            downloadDirectory = directory;
        }

        private void DirectorySelectorButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                try
                {
                    OpenFolderDialog dialog = new OpenFolderDialog();
                    dialog.ShowDialog();

                    string folderName = dialog.FolderName;
                    if (folderName != null)
                    {
                        SetDownloadDirectory(folderName);
                        SetDirectoryLabel(folderName);
                    }
                    else
                    {
                        SetDownloadDirectory(String.Empty);
                        SetDirectoryLabel("Directory not selected!");
                    }
                }
                catch (Exception ex)
                {
                    {
                        MessageBox.Show($"Error: {ex}");
                    }

                }
            }
        }
    }
}