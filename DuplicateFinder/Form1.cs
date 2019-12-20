using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuplicateFinder
{
    public partial class Form1 : Form
    {
        private DuplicateFinder finder;
        private FrmLoading loadingScreen;
        private FrmDuplicateViewer duplicateViewer;

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
            var fbd = new FolderBrowserDialog();
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
                var watch = new Stopwatch();
                watch.Start();

                await Task.Run(() => finder.StartSearchOfDuplicatesAsync());
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
                _ = MessageBox.Show($"Ups! Something happend. This is the message: {ex.Message}", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetUI();
                return;
            }
        }

        private void SearchDuplicates()
        {
            if (txtQuickSearch.Text.Length > 3 || txtQuickSearch.Text.Length == 0)
            {
                var filterResult = finder?.Duplicates.Where(d => d.FileName.ToLower().Contains(txtQuickSearch.Text.ToLower()));
                filterResult = filterResult.OrderByDescending(d => d.AverageFileSize);
                _ = Invoke((MethodInvoker)delegate { dgvDuplicates.Rows.Clear(); });
                foreach (var duplicate in filterResult)
                {
                    _ = Invoke((MethodInvoker)delegate { AddDatagridRow(duplicate); loadingScreen.ReportProgress(dgvDuplicates.Rows.Count, false); });
                }
                _ = Invoke((MethodInvoker)delegate { loadingScreen.ReportProgress(dgvDuplicates.Rows.Count, true); });
            }
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
            var added = dgvDuplicates.Rows.Add(icon, duplicate.FileName, duplicate.TimesRepeated, Toolkit.GetSizeString(duplicate.AverageFileSize), Toolkit.GetSizeString(duplicate.TotalDuplicationSize));
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
                    _ = Invoke((MethodInvoker)delegate
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
            if (e.RowIndex >= 0 && dgvDuplicates.Rows.Count > 0)
            {
                var df = dgvDuplicates.Rows[e.RowIndex].Tag as DuplicatedFile;
                if (duplicateViewer == null)
                { InitializeViewer(); }
                else
                { if (duplicateViewer.IsDisposed) { InitializeViewer(); } }
                duplicateViewer.SetDuplicate(df);
                duplicateViewer.Show();
                duplicateViewer.BringToFront();
            }
        }

        private void InitializeViewer()
        {
            duplicateViewer = new FrmDuplicateViewer();
            duplicateViewer.RequestingNextDuplicate += Frm_RequestingNextDuplicate;
            duplicateViewer.RequestingPrevDuplicate += Frm_RequestingPrevDuplicate;
            duplicateViewer.RequestingRemoveDuplication += DuplicateViewer_RequestingRemoveDuplication;
            duplicateViewer.RemovedFile += DuplicateViewer_RemovedFile;
        }

        private void DuplicateViewer_RemovedFile(object sender, string e)
        {
            if (dgvDuplicates.SelectedRows.Count > 0)
            {
                var selectedIndex = dgvDuplicates.SelectedRows[0].Index;
                var df = dgvDuplicates.Rows[selectedIndex].Tag as DuplicatedFile;
                _ = df.Files.Remove(df.Files.FirstOrDefault(d => d.FullName == e));
                dgvDuplicates.Rows[selectedIndex].Cells[2].Value = df.TimesRepeated;
                dgvDuplicates.Rows[selectedIndex].Cells[3].Value = Toolkit.GetSizeString(df.AverageFileSize);
                dgvDuplicates.Rows[selectedIndex].Cells[4].Value = Toolkit.GetSizeString(df.SpaceLostByDuplication);
            }
        }

        private void DuplicateViewer_RequestingRemoveDuplication(object sender, EventArgs e)
        {
            if (dgvDuplicates.SelectedRows.Count > 0)
            {
                var selectedIndex = dgvDuplicates.SelectedRows[0].Index;
                var df = dgvDuplicates.Rows[selectedIndex].Tag as DuplicatedFile;
                if (df.Files.Count <= 1)
                {
                    duplicateViewer.SendToBack();
                    _ = MessageBox.Show($"The file: '{df.FileName}' is no more duplicated so is no more in this list.{Environment.NewLine}{(df.Files.Count == 1 ? $"The final path is: '{df.Files[0].FullName}'" : "")}", "Duplication removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ = finder.Duplicates.Remove(df);
                    ShowNextDuplication();
                    dgvDuplicates.Rows.RemoveAt(selectedIndex);
                    duplicateViewer.BringToFront();
                }
            }
        }

        private void Frm_RequestingPrevDuplicate(object sender, EventArgs e)
        {
            ShowPrevDuplication();
        }

        private void ShowPrevDuplication()
        {
            if (dgvDuplicates.SelectedRows.Count > 0)
            {
                var new_selection = dgvDuplicates.SelectedRows[0].Index - 1 >= 0 ? dgvDuplicates.SelectedRows[0].Index - 1 : 0;
                SelectRow(new_selection);
                var df = dgvDuplicates.Rows[new_selection].Tag as DuplicatedFile;
                duplicateViewer.SetDuplicate(df);
            }
        }

        private void Frm_RequestingNextDuplicate(object sender, EventArgs e)
        {
            ShowNextDuplication();
        }

        private void ShowNextDuplication()
        {
            if (dgvDuplicates.SelectedRows.Count >= 0)
            {
                var new_selection = dgvDuplicates.SelectedRows[0].Index + 1 < dgvDuplicates.Rows.Count ? dgvDuplicates.SelectedRows[0].Index + 1 : 0;
                SelectRow(new_selection);
                var df = dgvDuplicates.Rows[new_selection].Tag as DuplicatedFile;
                duplicateViewer.SetDuplicate(df);
            }
        }

        private void SelectRow(int index)
        {
            if (index >= 0)
            {
                dgvDuplicates.ClearSelection();
                dgvDuplicates.Rows[index].Selected = true;
                if (!dgvDuplicates.Rows[index].Displayed)
                {
                    dgvDuplicates.FirstDisplayedScrollingRowIndex = (index - 5 >= 0 ? index - 5 : index);
                }
            }
        }

        private void txtQuickSearch_TextChanged(object sender, EventArgs e)
        {
            SearchDuplicates();
        }
    }

    public static class Extensions
    {
        public static int ContarLetras(this string palabra)
        {
            return palabra.Length;
        }
    }
}