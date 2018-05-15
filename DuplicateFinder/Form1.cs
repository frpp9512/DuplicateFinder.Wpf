using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuplicateFinder
{
    public partial class Form1 : Form
    {
        DuplicateFinder finder;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnBrowseDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                TxtFolderPath.Text = fbd.SelectedPath;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            finder = new DuplicateFinder { SelectedDirectory = new DirectoryInfo(TxtFolderPath.Text) };
            finder.Progress.ProgressChanged += Progress_ProgressChanged1;
            
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                txtConsole.AppendText($"Task started at: {DateTime.Now}{Environment.NewLine}");
                await Task.Run(() => finder.StartSearchOfDuplicates());
                watch.Stop();
                pbOverallProgress.Value = 100;
                txtConsole.AppendText($"Task finished at: {DateTime.Now}{Environment.NewLine}Task time: {watch.Elapsed}{Environment.NewLine}");
                txtConsole.AppendText($"-------------------------------------{Environment.NewLine}");
                txtConsole.AppendText($"Founded: {finder.Duplicates.Count} files repeated at least 1 time.{Environment.NewLine}");
                txtConsole.AppendText($"Total space in duplicates: {GetSizeString(finder.TotalSpaceInDuplicates)}{Environment.NewLine}");
                txtConsole.AppendText($"Total space lost by duplicates: {GetSizeString(finder.TotalSpaceLostByDuplicates)}{Environment.NewLine}");
                txtConsole.AppendText("-------------------------------------");
                txtConsole.SuspendLayout();
                foreach (var file in finder.Duplicates)
                {
                    txtConsole.AppendText($"-------------------------------------{ Environment.NewLine }File: { file.FileName } - Repeated: { file.TimesRepeated } times. - Average size: { GetSizeString(file.AverageFileSize) } - Total size in duplicates: { GetSizeString(file.TotalDuplicationSize) } { Environment.NewLine }{ string.Join(Environment.NewLine, file.Files.Select(f => f.FullName).ToArray()) } {Environment.NewLine}");
                }
                txtConsole.AppendText("-------------------------");
                txtConsole.AppendText(Environment.NewLine);
                txtConsole.AppendText($"Total space in duplicates: { GetSizeString(finder.TotalSpaceInDuplicates) }");
                txtConsole.AppendText(Environment.NewLine);
                txtConsole.AppendText($"Total space lost by duplicates: { GetSizeString(finder.TotalSpaceLostByDuplicates) }");
                txtConsole.ResumeLayout();
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Stopped by the user.");
                ResetUI();
                return;
            }
        }

        private void ResetUI()
        {
            pbOverallProgress.Value = 0;
            pbOverallProgress.Style = ProgressBarStyle.Blocks;
            LbAction.Text = "Progress:";
            stlbStatus.Text = "Welcome to Duplicate Finder";
        }

        private void Progress_ProgressChanged1(object sender, DuplicateSearchProgress e)
        {
            switch (e.Operation)
            {
                case DuplicateSearchOperation.DetectingDirectories:
                    pbOverallProgress.Style = ProgressBarStyle.Marquee;
                    LbAction.Text = "Detecting directories...";
                    stlbStatus.Text = "Starting task...";
                    break;
                case DuplicateSearchOperation.SearchingDuplicates:
                    pbOverallProgress.Style = ProgressBarStyle.Blocks;
                    pbOverallProgress.Value = e.Percentage;
                    LbAction.Text = $"Progress: {e.Percentage} % - Processed: {finder.ProcessedDirectoriesCount}/{finder.DirectoriesCount}";
                    stlbStatus.Text = $"Processing: {e.CurrentDirectory}";
                    break;
                case DuplicateSearchOperation.ErrorFound:
                    Invoke((MethodInvoker)delegate
                    {
                        txtConsole.Text = $"Error found: {e.AdditionalInformation}";
                    });
                    break;
                default:
                    break;
            }            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            finder?.CancelAll();
        }

        string GetSizeString(long size)
        {
            string[] mu = { "Bytes", "KB", "MB", "GB", "TB" };
            int iterations = 0;
            decimal convertedSize = size;
            while (convertedSize > 1024)
            {
                convertedSize /= 1024;
                iterations++;
            }
            return $"{decimal.Round(convertedSize, 2, MidpointRounding.AwayFromZero)} {(iterations < mu.Length ? mu[iterations] : "NONE")}";
        }
    }
}
