using Microsoft.Win32;
using SimpleYT2MP3.AppLogic;
using SimpleYT2MP3.AppLogic.Interfaces;
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
                    youtubeLink = YoutubeLinkInput.Text;

                    IDownloadStatusProvider statusProvider = new DownloadStatusContentProvider();
                    IScriptRunner scriptRunner = new PythonScriptsRunner();
                    IScriptPathProvider pathProvider = new DictionaryScriptPathsProvider();
                    
                    IDownloadService downloadService = new DownloadService(statusProvider, pathProvider, scriptRunner);


                    string downloadScriptPath = pathProvider.GetScriptPath("Download");
                    string downloadStatus = statusProvider.GetDownloadStatus("Download");
                    
                    SetStatusLabelContent(downloadStatus);
                    
                    DisableButtons();

                    if (youtubeLink == String.Empty)
                    {
                        MessageBox.Show("Please type in the link!");

                        downloadStatus = statusProvider.GetDownloadStatus("Error");
                        SetStatusLabelContent(downloadStatus);

                        EnableButtons();
                        return;
                    }

                    string output = await downloadService.RunDownloadAsync(youtubeLink, downloadDirectory);

                    SetStatusLabelContent(output);


                    EnableButtons();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd: {ex}");
                }
            }
        }

        private void SetStatusLabelContent(string content)
        {
            StatusLabel.Content = content;
        }

        private void DisableButtons()
        {
            if (IsLoaded)
            {
                DownloadButton.IsEnabled = false;
                DirectorySelectorButton.IsEnabled = false;
            }
        }

        private void EnableButtons()
        {
            if (IsLoaded)
            {
                DownloadButton.IsEnabled = true;
                DirectorySelectorButton.IsEnabled = true;
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