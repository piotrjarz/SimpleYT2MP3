using Microsoft.Win32;
using SimpleYT2MP3.CSPythonScripts;
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

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                try
                {
                    youtubeLink = YoutubeLinkInput.Text;
                    string downloadScriptPath = PythonScriptsPaths.Paths["Download"];
                    string output = PythonScripstRunner.RunScript(downloadScriptPath, youtubeLink, downloadDirectory);

                    MessageBox.Show(output);
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