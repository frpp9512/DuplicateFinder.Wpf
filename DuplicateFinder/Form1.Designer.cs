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
            this.BtnBrowseDirectory = new System.Windows.Forms.Button();
            this.dgvDuplicates = new System.Windows.Forms.DataGridView();
            this.clFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTimesRepeated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pbOverallProgress = new System.Windows.Forms.ProgressBar();
            this.LbAction = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuplicates)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Duplicate finder";
            // 
            // TxtFolderPath
            // 
            this.TxtFolderPath.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.TxtFolderPath.Location = new System.Drawing.Point(17, 89);
            this.TxtFolderPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtFolderPath.Name = "TxtFolderPath";
            this.TxtFolderPath.Size = new System.Drawing.Size(282, 22);
            this.TxtFolderPath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label2.Location = new System.Drawing.Point(15, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccione el directorio:";
            // 
            // BtnBrowseDirectory
            // 
            this.BtnBrowseDirectory.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.BtnBrowseDirectory.FlatAppearance.BorderSize = 2;
            this.BtnBrowseDirectory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnBrowseDirectory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BtnBrowseDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBrowseDirectory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBrowseDirectory.Location = new System.Drawing.Point(303, 87);
            this.BtnBrowseDirectory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnBrowseDirectory.Name = "BtnBrowseDirectory";
            this.BtnBrowseDirectory.Size = new System.Drawing.Size(73, 26);
            this.BtnBrowseDirectory.TabIndex = 3;
            this.BtnBrowseDirectory.Text = "&Browse...";
            this.BtnBrowseDirectory.UseVisualStyleBackColor = true;
            this.BtnBrowseDirectory.Click += new System.EventHandler(this.BtnBrowseDirectory_Click);
            // 
            // dgvDuplicates
            // 
            this.dgvDuplicates.AllowUserToAddRows = false;
            this.dgvDuplicates.AllowUserToDeleteRows = false;
            this.dgvDuplicates.AllowUserToResizeRows = false;
            this.dgvDuplicates.BackgroundColor = System.Drawing.Color.White;
            this.dgvDuplicates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDuplicates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clFileName,
            this.clTimesRepeated});
            this.dgvDuplicates.GridColor = System.Drawing.Color.White;
            this.dgvDuplicates.Location = new System.Drawing.Point(17, 210);
            this.dgvDuplicates.Name = "dgvDuplicates";
            this.dgvDuplicates.ReadOnly = true;
            this.dgvDuplicates.RowHeadersVisible = false;
            this.dgvDuplicates.Size = new System.Drawing.Size(359, 150);
            this.dgvDuplicates.TabIndex = 4;
            // 
            // clFileName
            // 
            this.clFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clFileName.HeaderText = "File name";
            this.clFileName.Name = "clFileName";
            this.clFileName.ReadOnly = true;
            // 
            // clTimesRepeated
            // 
            this.clTimesRepeated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clTimesRepeated.HeaderText = "Times Repeated";
            this.clTimesRepeated.Name = "clTimesRepeated";
            this.clTimesRepeated.ReadOnly = true;
            this.clTimesRepeated.Width = 103;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 16F);
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(13, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "Files founded";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Light", 16F);
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(14, 366);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "Task progress";
            // 
            // pbOverallProgress
            // 
            this.pbOverallProgress.Location = new System.Drawing.Point(154, 366);
            this.pbOverallProgress.Name = "pbOverallProgress";
            this.pbOverallProgress.Size = new System.Drawing.Size(222, 30);
            this.pbOverallProgress.TabIndex = 5;
            // 
            // LbAction
            // 
            this.LbAction.AutoSize = true;
            this.LbAction.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.LbAction.ForeColor = System.Drawing.Color.Green;
            this.LbAction.Location = new System.Drawing.Point(149, 399);
            this.LbAction.Name = "LbAction";
            this.LbAction.Size = new System.Drawing.Size(54, 13);
            this.LbAction.TabIndex = 0;
            this.LbAction.Text = "Progress:";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(17, 117);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(359, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = "&Start search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStop
            // 
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnStop.FlatAppearance.BorderSize = 2;
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(303, 179);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(73, 26);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "St&op";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 422);
            this.Controls.Add(this.pbOverallProgress);
            this.Controls.Add(this.dgvDuplicates);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.BtnBrowseDirectory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtFolderPath);
            this.Controls.Add(this.LbAction);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuplicates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtFolderPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnBrowseDirectory;
        private System.Windows.Forms.DataGridView dgvDuplicates;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTimesRepeated;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar pbOverallProgress;
        private System.Windows.Forms.Label LbAction;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnStop;
    }
}

