namespace DuplicateFinder
{
    partial class FrmDuplicateViewer
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
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            this.lbFilename = new System.Windows.Forms.Label();
            this.dgvDuplicatedFiles = new System.Windows.Forms.DataGridView();
            this.label = new System.Windows.Forms.Label();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lbRepeatedTimes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbFileSize = new System.Windows.Forms.Label();
            this.lbTotalSize = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbSpaceLost = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.clFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clOpenDirectory = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clOpenLink = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clDeleteLink = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuplicatedFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxIcon
            // 
            this.pbxIcon.Location = new System.Drawing.Point(10, 9);
            this.pbxIcon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(34, 34);
            this.pbxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxIcon.TabIndex = 0;
            this.pbxIcon.TabStop = false;
            // 
            // lbFilename
            // 
            this.lbFilename.AutoSize = true;
            this.lbFilename.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lbFilename.Location = new System.Drawing.Point(50, 15);
            this.lbFilename.Name = "lbFilename";
            this.lbFilename.Size = new System.Drawing.Size(73, 21);
            this.lbFilename.TabIndex = 1;
            this.lbFilename.Text = "File name";
            this.lbFilename.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvDuplicatedFiles
            // 
            this.dgvDuplicatedFiles.AllowUserToAddRows = false;
            this.dgvDuplicatedFiles.AllowUserToDeleteRows = false;
            this.dgvDuplicatedFiles.AllowUserToResizeRows = false;
            this.dgvDuplicatedFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDuplicatedFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDuplicatedFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clFilePath,
            this.clOpenDirectory,
            this.clOpenLink,
            this.clDeleteLink});
            this.dgvDuplicatedFiles.Location = new System.Drawing.Point(10, 108);
            this.dgvDuplicatedFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDuplicatedFiles.MultiSelect = false;
            this.dgvDuplicatedFiles.Name = "dgvDuplicatedFiles";
            this.dgvDuplicatedFiles.RowHeadersVisible = false;
            this.dgvDuplicatedFiles.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 8F);
            this.dgvDuplicatedFiles.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkGreen;
            this.dgvDuplicatedFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDuplicatedFiles.Size = new System.Drawing.Size(674, 95);
            this.dgvDuplicatedFiles.TabIndex = 2;
            this.dgvDuplicatedFiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDuplicatedFiles_CellClick);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI Light", 8F);
            this.label.Location = new System.Drawing.Point(12, 57);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(53, 13);
            this.label.TabIndex = 3;
            this.label.Text = "Repeated:";
            // 
            // btnPrev
            // 
            this.btnPrev.Font = new System.Drawing.Font("Segoe UI Light", 8F);
            this.btnPrev.Location = new System.Drawing.Point(550, 207);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(64, 21);
            this.btnPrev.TabIndex = 4;
            this.btnPrev.Text = "< &Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Segoe UI Light", 8F);
            this.btnNext.Location = new System.Drawing.Point(620, 207);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(64, 21);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "&Next >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lbRepeatedTimes
            // 
            this.lbRepeatedTimes.AutoSize = true;
            this.lbRepeatedTimes.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lbRepeatedTimes.Location = new System.Drawing.Point(11, 70);
            this.lbRepeatedTimes.Name = "lbRepeatedTimes";
            this.lbRepeatedTimes.Size = new System.Drawing.Size(57, 21);
            this.lbRepeatedTimes.TabIndex = 1;
            this.lbRepeatedTimes.Text = "0 times";
            this.lbRepeatedTimes.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 8F);
            this.label2.Location = new System.Drawing.Point(144, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "File size:";
            // 
            // lbFileSize
            // 
            this.lbFileSize.AutoSize = true;
            this.lbFileSize.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lbFileSize.Location = new System.Drawing.Point(143, 70);
            this.lbFileSize.Name = "lbFileSize";
            this.lbFileSize.Size = new System.Drawing.Size(57, 21);
            this.lbFileSize.TabIndex = 5;
            this.lbFileSize.Text = "0 bytes";
            // 
            // lbTotalSize
            // 
            this.lbTotalSize.AutoSize = true;
            this.lbTotalSize.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lbTotalSize.Location = new System.Drawing.Point(257, 70);
            this.lbTotalSize.Name = "lbTotalSize";
            this.lbTotalSize.Size = new System.Drawing.Size(57, 21);
            this.lbTotalSize.TabIndex = 5;
            this.lbTotalSize.Text = "0 bytes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Light", 8F);
            this.label5.Location = new System.Drawing.Point(258, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Total size of files:";
            // 
            // lbSpaceLost
            // 
            this.lbSpaceLost.AutoSize = true;
            this.lbSpaceLost.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lbSpaceLost.Location = new System.Drawing.Point(396, 70);
            this.lbSpaceLost.Name = "lbSpaceLost";
            this.lbSpaceLost.Size = new System.Drawing.Size(57, 21);
            this.lbSpaceLost.TabIndex = 5;
            this.lbSpaceLost.Text = "0 bytes";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Light", 8F);
            this.label7.Location = new System.Drawing.Point(397, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Spece lost by duplicates:";
            // 
            // clFilePath
            // 
            this.clFilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clFilePath.HeaderText = "Path";
            this.clFilePath.Name = "clFilePath";
            this.clFilePath.ReadOnly = true;
            // 
            // clOpenDirectory
            // 
            this.clOpenDirectory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clOpenDirectory.HeaderText = "";
            this.clOpenDirectory.Name = "clOpenDirectory";
            this.clOpenDirectory.ReadOnly = true;
            this.clOpenDirectory.Width = 5;
            // 
            // clOpenLink
            // 
            this.clOpenLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clOpenLink.HeaderText = "";
            this.clOpenLink.Name = "clOpenLink";
            this.clOpenLink.ReadOnly = true;
            this.clOpenLink.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clOpenLink.Width = 5;
            // 
            // clDeleteLink
            // 
            this.clDeleteLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDeleteLink.HeaderText = "";
            this.clDeleteLink.Name = "clDeleteLink";
            this.clDeleteLink.ReadOnly = true;
            this.clDeleteLink.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clDeleteLink.Width = 5;
            // 
            // FrmDuplicateViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 236);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbSpaceLost);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbTotalSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbFileSize);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.label);
            this.Controls.Add(this.dgvDuplicatedFiles);
            this.Controls.Add(this.lbRepeatedTimes);
            this.Controls.Add(this.lbFilename);
            this.Controls.Add(this.pbxIcon);
            this.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDuplicateViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duplicate Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuplicatedFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxIcon;
        private System.Windows.Forms.Label lbFilename;
        private System.Windows.Forms.DataGridView dgvDuplicatedFiles;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lbRepeatedTimes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbFileSize;
        private System.Windows.Forms.Label lbTotalSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbSpaceLost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFilePath;
        private System.Windows.Forms.DataGridViewButtonColumn clOpenDirectory;
        private System.Windows.Forms.DataGridViewButtonColumn clOpenLink;
        private System.Windows.Forms.DataGridViewButtonColumn clDeleteLink;
    }
}