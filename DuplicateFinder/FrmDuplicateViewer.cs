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
    public partial class FrmDuplicateViewer : Form
    {
        public event EventHandler RequestingNextDuplicate = null;
        public event EventHandler RequestingPrevDuplicate = null;
        public event EventHandler<string> RemovedFile = null;
        public event EventHandler RequestingRemoveDuplication = null;

        DuplicatedFile duplicate;

        public FrmDuplicateViewer()
        {
            InitializeComponent();
        }

        public FrmDuplicateViewer(DuplicatedFile duplicate)
        {
            InitializeComponent();
            SetDuplicate(duplicate);
        }

        public void SetDuplicate(DuplicatedFile duplicate)
        {
            this.duplicate = duplicate;
            Bitmap icon = null;
            try
            {
                icon = Icon.ExtractAssociatedIcon(duplicate.Files[0].FullName).ToBitmap();
            }
            catch (Exception)
            {
            }
            pbxIcon.Image = icon;
            Text = $"Duplications of: {duplicate.FileName}";
            lbFilename.Text = duplicate.FileName;
            lbRepeatedTimes.Text = $"{duplicate.TimesRepeated} time{(duplicate.TimesRepeated > 1 ? "s" : "")}";
            lbFileSize.Text = $"{Toolkit.GetSizeString(duplicate.AverageFileSize)}";
            lbTotalSize.Text = $"{Toolkit.GetSizeString(duplicate.TotalDuplicationSize)}";
            lbSpaceLost.Text = $"{Toolkit.GetSizeString(duplicate.SpaceLostByDuplication)}";
            dgvDuplicatedFiles.Rows.Clear();
            foreach (var file in duplicate.Files)
            {
                int added = dgvDuplicatedFiles.Rows.Add(file.FullName, "Open...", "Open directory...", "Delete");
                dgvDuplicatedFiles.Rows[added].Tag = file;                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            RequestingNextDuplicate?.Invoke(this, new EventArgs());
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            RequestingPrevDuplicate?.Invoke(this, new EventArgs());
        }

        private void dgvDuplicatedFiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                FileInfo file = (dgvDuplicatedFiles.Rows[e.RowIndex].Tag as FileInfo);
                switch (e.ColumnIndex)
                {
                    case 2:
                        Process.Start($"{Environment.SystemDirectory}\\explorer.exe", $"{file.Directory.FullName}");
                        break;
                    case 1:
                        Process.Start(file.FullName);
                        break;
                    case 3:
                        if (MessageBox.Show($"Do you want to delete '{file.FullName}'?", "Delete file", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            file.Delete();
                            duplicate.Files.Remove(file);
                            dgvDuplicatedFiles.Rows.RemoveAt(e.RowIndex);
                            if (duplicate.Files.Count <= 1)
                            {
                                RequestingRemoveDuplication?.Invoke(this, new EventArgs());
                            }
                            else
                            {
                                SetDuplicate(duplicate);
                                RemovedFile?.Invoke(this, file.FullName);
                            }
                        }
                        break;
                    default:
                        break;
                } 
            }
        }
    }
}
