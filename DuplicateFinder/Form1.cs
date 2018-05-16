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
                await Task.Run(() => finder.StartSearchOfDuplicates());
                watch.Stop();
                pbOverallProgress.Value = 100;
                loadingScreen = new FrmLoading(watch.Elapsed, finder.ProcessedDirectoriesCount, finder.Duplicates.Count, finder.TotalSpaceInDuplicates, finder.TotalSpaceLostByDuplicates);
                loadingScreen.Show();
                await Task.Run(() => SearchDuplicates());
                stlbStatus.Text = $"Task finished in: {watch.Elapsed}. Found: {finder.Duplicates.Count} files with duplications. Total space lost by duplicates: {Toolkit.GetSizeString(finder.TotalSpaceInDuplicates)}.";
                #region ToMakeLogs
                //txtConsole.AppendText($"Task started at: {DateTime.Now}{Environment.NewLine}");
                //txtConsole.AppendText($"Task finished at: {DateTime.Now}{Environment.NewLine}Task time: {watch.Elapsed}{Environment.NewLine}");
                //txtConsole.AppendText($"-------------------------------------{Environment.NewLine}");
                //txtConsole.AppendText($"Founded: {finder.Duplicates.Count} files repeated at least 1 time.{Environment.NewLine}");
                //txtConsole.AppendText($"Total space in duplicates: {Toolkit.GetSizeString(finder.TotalSpaceInDuplicates)}{Environment.NewLine}");
                //txtConsole.AppendText($"Total space lost by duplicates: {Toolkit.GetSizeString(finder.TotalSpaceLostByDuplicates)}{Environment.NewLine}");
                //txtConsole.AppendText("-------------------------------------");
                //txtConsole.SuspendLayout();
                //foreach (var file in finder.Duplicates)
                //{
                //    txtConsole.AppendText($"-------------------------------------{ Environment.NewLine }File: { file.FileName } - Repeated: { file.TimesRepeated } times. - Average size: { Toolkit.GetSizeString(file.AverageFileSize) } - Total size in duplicates: { Toolkit.GetSizeString(file.TotalDuplicationSize) } { Environment.NewLine }{ string.Join(Environment.NewLine, file.Files.Select(f => f.FullName).ToArray()) } {Environment.NewLine}");
                //}
                //txtConsole.AppendText("-------------------------");
                //txtConsole.AppendText(Environment.NewLine);
                //txtConsole.AppendText($"Total space in duplicates: { Toolkit.GetSizeString(finder.TotalSpaceInDuplicates) }");
                //txtConsole.AppendText(Environment.NewLine);
                //txtConsole.AppendText($"Total space lost by duplicates: { Toolkit.GetSizeString(finder.TotalSpaceLostByDuplicates) }");
                //txtConsole.ResumeLayout(); 
                #endregion
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
                MessageBox.Show($"Ups! Something happend. This is the message: {ex.Message}");
                MessageBox.Show("Stopped by the user.");
                ResetUI();
                return;
            }
        }

<<<<<<< HEAD
        private void SearchDuplicates()
        {
            var filterResult = finder?.Duplicates.Where(d => d.FileName.ToLower().Contains(txtQuickSearch.Text.ToLower()));

            Invoke((MethodInvoker)delegate { dgvDuplicates.Rows.Clear(); });
            foreach (var duplicate in filterResult)
            {
                Invoke((MethodInvoker)delegate { AddDatagridRow(duplicate); loadingScreen.ReportProgress(dgvDuplicates.Rows.Count, false); });
            }
            Invoke((MethodInvoker)delegate { loadingScreen.ReportProgress(dgvDuplicates.Rows.Count, true); });
        }

        private void AddDatagridRow(DuplicatedFile duplicate)
        {
            Bitmap icon = null;
            try
            {
                icon = Icon.ExtractAssociatedIcon(duplicate.Files[0].FullName).ToBitmap();
            }
            catch (Exception)
            {
                // TODO - Log exception extracting icon.
            }
            int added = dgvDuplicates.Rows.Add(icon, duplicate.FileName, duplicate.TimesRepeated, Toolkit.GetSizeString(duplicate.AverageFileSize), Toolkit.GetSizeString(duplicate.TotalDuplicationSize));
            dgvDuplicates.Rows[added].Tag = duplicate;
        }

=======
>>>>>>> parent of f5cdf5d... Operational basic version
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
<<<<<<< HEAD
                    // TODO - Log errors.
=======
                    Invoke((MethodInvoker)delegate
                    {
                        txtConsole.Text = $"Error found: {e.AdditionalInformation}";
                    });
>>>>>>> parent of f5cdf5d... Operational basic version
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
