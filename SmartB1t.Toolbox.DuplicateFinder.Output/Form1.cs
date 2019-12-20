using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartB1t.Toolbox.DuplicateFinder;

namespace SmartB1t.Toolbox.DuplicateFinder.Output
{
    public partial class Form1 : Form
    {
        private DuplicateFinder DuplicateFinder { get; set; }
        
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            DuplicateFinder = new DuplicateFinder("D:\\");
            DuplicateFinder.ProgressReporter.ProgressChanged += SearchProgressChanged;
            //await Task.Run(() => DuplicateFinder.FindDuplicates());
            await DuplicateFinder.FindDuplicatesAsync();
        }

        private void SearchProgressChanged(object sender, DuplicationSearchProgressReport e)
        {
            _ = Invoke((MethodInvoker)delegate
            {
                progressBar1.Style = e.CurrentOperation == DuplicateSearchStatus.StartingSearch || e.CurrentOperation == DuplicateSearchStatus.MappingDirectories
                    ? ProgressBarStyle.Marquee
                    : ProgressBarStyle.Continuous;
                Text = $"{e.Percentage}% - Duplications founded: {DuplicateFinder.DuplicatedFiles.Count} - Current operation: { e.CurrentOperation.ToString()}";
                progressBar1.Value = Convert.ToInt32(Math.Round(e.Percentage));
                label1.Text = $"{e.Percentage} % - {e.CurrentDirectory}";
                if (e.CurrentOperation == DuplicateSearchStatus.StartingSearch)
                {
                    textBox1.Text += e.Details;
                }
                if (e.CurrentOperation == DuplicateSearchStatus.Error)
                {
                    textBox1.Text += $"\r\n{e.Details}";
                }
                if (e.CurrentOperation == DuplicateSearchStatus.SearchFinished)
                {
                    var reportString = new StringBuilder();
                    _ = reportString.AppendLine(e.Details);
                    _ = reportString.AppendLine($"Duplicates founded: {DuplicateFinder.DuplicatedFiles.Count}");
                    foreach (var duplicate in DuplicateFinder.DuplicatedFiles)
                    {
                        _ = reportString.AppendLine("-------------------------");
                        _ = reportString.AppendLine(duplicate.FileName);
                        _ = reportString.AppendLine($"File size: {duplicate.AverageFileSize}");
                        _ = reportString.AppendLine($"Times repeated: {duplicate.TimesRepeated}");
                        _ = reportString.AppendLine($"Files:");
                        foreach (var file in duplicate.Files)
                        {
                            _ = reportString.AppendLine($"{file.FullName}");
                        }
                    }
                    textBox1.Text += $"\r\n{reportString.ToString()}";
                }
            });
        }
    }
}
