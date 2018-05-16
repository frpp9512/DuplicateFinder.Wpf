using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuplicateFinder
{
    public partial class FrmLoading : Form
    {
        int totalDuplications;

        public FrmLoading(TimeSpan taskTime, int processedDirs, int foundedDuplications, long totalsize, long spaceLost)
        {
            InitializeComponent();
            totalDuplications = foundedDuplications;
            lbTaskTime.Text = $"Task time: {taskTime}";
            lbProcessedDirs.Text = $"Processed: {processedDirs} directorires";
            lbFoundedDuplications.Text = $"Founded with duplications: {foundedDuplications}";
            lbTotalSize.Text = $"Total size of the files: {Toolkit.GetSizeString(totalsize)}";
            lbLostSpace.Text = $"Total space lost by duplications: {Toolkit.GetSizeString(spaceLost)}";
            btnOK.Enabled = false;
            Height = 279;
        }

        public void ReportProgress(int duplicationsShowed, bool finished)
        {
            if (progressBar1.Style == ProgressBarStyle.Marquee)
            {
                progressBar1.Style = ProgressBarStyle.Blocks;
            }
            progressBar1.Value = duplicationsShowed * 100 / totalDuplications;
            LbProgress.Text = $"{progressBar1.Value} %";
            if (finished)
            {
                btnOK.Enabled = true;
                Height = 321;
                LbProgress.Text = $"100 %";
                btnOK.Focus();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}