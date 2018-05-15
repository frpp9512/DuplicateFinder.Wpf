using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            //List<string> a = new List<string>();
            //var b = a.Select(s => s == "aa");
            //MessageBox.Show("Test");
            //DirectoryInfo a = new DirectoryInfo(@"D:\New folder");
            //DirectoryInfo[] d = a.GetDirectories();
            //MessageBox.Show("Test");
        }

        public async void Test()
        {
            Task t = Task.Run(() => FileSearch());
        }

        public async Task FileSearch() { }

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
            finder = new DuplicateFinder();
            pbOverallProgress.Style = ProgressBarStyle.Marquee;
            LbAction.Text = "Detectando directorios...";
            int count = 0;
            try
            {
                count = await Task.Run(() => finder.StartGetDirectoriesCount(TxtFolderPath.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Detenido por el usuario");
            }
            finally
            {
                pbOverallProgress.Style = ProgressBarStyle.Blocks;
                LbAction.Text = "Progress:";
            }
            MessageBox.Show($"{count}");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            finder?.CancelAll();
        }
    }
}
