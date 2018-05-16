namespace DuplicateFinder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.TxtFolderPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDuplicates = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pbOverallProgress = new System.Windows.Forms.ProgressBar();
            this.LbAction = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stlbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtQuickSearch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.clIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.clFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTimesRepeated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clAverageFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTotalSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuplicates)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 24F);
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Duplicate finder";
            // 
            // TxtFolderPath
            // 
            this.TxtFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFolderPath.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.TxtFolderPath.Location = new System.Drawing.Point(20, 112);
            this.TxtFolderPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtFolderPath.Name = "TxtFolderPath";
            this.TxtFolderPath.Size = new System.Drawing.Size(447, 22);
            this.TxtFolderPath.TabIndex = 1;
            this.TxtFolderPath.Text = "D:\\New folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 16F);
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(15, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Search directory";
            // 
            // dgvDuplicates
            // 
            this.dgvDuplicates.AllowUserToAddRows = false;
            this.dgvDuplicates.AllowUserToDeleteRows = false;
            this.dgvDuplicates.AllowUserToResizeRows = false;
            this.dgvDuplicates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDuplicates.BackgroundColor = System.Drawing.Color.White;
            this.dgvDuplicates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDuplicates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clIcon,
            this.clFileName,
            this.clTimesRepeated,
            this.clAverageFileSize,
            this.clTotalSize});
            this.dgvDuplicates.GridColor = System.Drawing.Color.White;
            this.dgvDuplicates.Location = new System.Drawing.Point(20, 295);
            this.dgvDuplicates.MultiSelect = false;
            this.dgvDuplicates.Name = "dgvDuplicates";
            this.dgvDuplicates.ReadOnly = true;
            this.dgvDuplicates.RowHeadersVisible = false;
            this.dgvDuplicates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDuplicates.Size = new System.Drawing.Size(565, 147);
            this.dgvDuplicates.TabIndex = 4;
            this.dgvDuplicates.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDuplicates_CellDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 16F);
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(15, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "Files founded";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Light", 16F);
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(15, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "Task progress";
            // 
            // pbOverallProgress
            // 
            this.pbOverallProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbOverallProgress.Location = new System.Drawing.Point(20, 194);
            this.pbOverallProgress.Name = "pbOverallProgress";
            this.pbOverallProgress.Size = new System.Drawing.Size(486, 28);
            this.pbOverallProgress.TabIndex = 5;
            // 
            // LbAction
            // 
            this.LbAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LbAction.AutoSize = true;
            this.LbAction.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.LbAction.ForeColor = System.Drawing.Color.Green;
            this.LbAction.Location = new System.Drawing.Point(17, 227);
            this.LbAction.Name = "LbAction";
            this.LbAction.Size = new System.Drawing.Size(54, 13);
            this.LbAction.TabIndex = 0;
            this.LbAction.Text = "Progress:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(473, 89);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = "&Start search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnStop.FlatAppearance.BorderSize = 2;
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(512, 194);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(73, 28);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "St&op";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Bold);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stlbStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 445);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(599, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stlbStatus
            // 
            this.stlbStatus.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.stlbStatus.Name = "stlbStatus";
            this.stlbStatus.Size = new System.Drawing.Size(156, 17);
            this.stlbStatus.Text = "Welcome to Duplicate Finder";
            // 
            // txtQuickSearch
            // 
            this.txtQuickSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuickSearch.Location = new System.Drawing.Point(434, 267);
            this.txtQuickSearch.Name = "txtQuickSearch";
            this.txtQuickSearch.Size = new System.Drawing.Size(151, 22);
            this.txtQuickSearch.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label5.Location = new System.Drawing.Point(353, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Quick search:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.linkLabel1.LinkColor = System.Drawing.Color.Green;
            this.linkLabel1.Location = new System.Drawing.Point(413, 89);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(54, 13);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Browse...";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // clIcon
            // 
            this.clIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clIcon.DataPropertyName = "Icon";
            this.clIcon.HeaderText = "";
            this.clIcon.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.clIcon.Name = "clIcon";
            this.clIcon.ReadOnly = true;
            this.clIcon.Width = 5;
            // 
            // clFileName
            // 
            this.clFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clFileName.DataPropertyName = "FileName";
            this.clFileName.HeaderText = "File name";
            this.clFileName.Name = "clFileName";
            this.clFileName.ReadOnly = true;
            // 
            // clTimesRepeated
            // 
            this.clTimesRepeated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clTimesRepeated.DataPropertyName = "TimesRepeated";
            this.clTimesRepeated.HeaderText = "Times Repeated";
            this.clTimesRepeated.Name = "clTimesRepeated";
            this.clTimesRepeated.ReadOnly = true;
            this.clTimesRepeated.Width = 90;
            // 
            // clAverageFileSize
            // 
            this.clAverageFileSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clAverageFileSize.DataPropertyName = "AverageFileSize";
            this.clAverageFileSize.HeaderText = "Average Size";
            this.clAverageFileSize.Name = "clAverageFileSize";
            this.clAverageFileSize.ReadOnly = true;
            this.clAverageFileSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clAverageFileSize.Width = 90;
            // 
            // clTotalSize
            // 
            this.clTotalSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clTotalSize.DataPropertyName = "TotalDuplicationSize";
            this.clTotalSize.HeaderText = "Total";
            this.clTotalSize.Name = "clTotalSize";
            this.clTotalSize.ReadOnly = true;
            this.clTotalSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clTotalSize.Width = 90;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 467);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.txtQuickSearch);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pbOverallProgress);
            this.Controls.Add(this.dgvDuplicates);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtFolderPath);
            this.Controls.Add(this.LbAction);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuplicates)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtFolderPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDuplicates;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar pbOverallProgress;
        private System.Windows.Forms.Label LbAction;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stlbStatus;
        private System.Windows.Forms.TextBox txtQuickSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.DataGridViewImageColumn clIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTimesRepeated;
        private System.Windows.Forms.DataGridViewTextBoxColumn clAverageFileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTotalSize;
    }
}