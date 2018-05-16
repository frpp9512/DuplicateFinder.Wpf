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
        FrmLoading loadingScreen;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnBrowseDirectory_Click(object sender, EventArgs e)
        {
            BrowseDirectory();
        }

        private void BrowseDirectory()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
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
                #region ToLog
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
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something happend. This is the message: {ex.Message}");
                ResetUI();
                return;
            }
        }

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
                // TODO - Log the error extracting icon.
            }
            int added = dgvDuplicates.Rows.Add(icon, duplicate.FileName, duplicate.TimesRepeated, Toolkit.GetSizeString(duplicate.AverageFileSize), Toolkit.GetSizeString(duplicate.TotalDuplicationSize));
            dgvDuplicates.Rows[added].Tag = duplicate;
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
                    LbAction.Text = $"Progress: {e.Percentage} % - Processed: {finder.ProcessedDirectoriesCount}/{finder.DirectoriesCount} directories.";
                    stlbStatus.Text = $"Processing: {e.CurrentDirectory}";
                    break;
                case DuplicateSearchOperation.ErrorFound:
                    Invoke((MethodInvoker)delegate
                    {
                        // TODO - Log this error.
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BrowseDirectory();
        }

        private void dgvDuplicates_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && dgvDuplicates.Rows.Count > 0)
            {
                DuplicatedFile df = dgvDuplicates.Rows[e.RowIndex].Tag as DuplicatedFile;
                Process.Start(df.Files[0].FullName);
            }
        }
    }
}