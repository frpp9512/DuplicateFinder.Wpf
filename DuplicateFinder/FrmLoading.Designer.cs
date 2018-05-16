namespace DuplicateFinder
{
    partial class FrmLoading
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTaskTime = new System.Windows.Forms.Label();
            this.lbProcessedDirs = new System.Windows.Forms.Label();
            this.lbFoundedDuplications = new System.Windows.Forms.Label();
            this.lbTotalSize = new System.Windows.Forms.Label();
            this.lbLostSpace = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.LbProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 100F);
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 177);
            this.label1.TabIndex = 0;
            this.label1.Text = ":)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 24F);
            this.label2.Location = new System.Drawing.Point(160, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 45);
            this.label2.TabIndex = 1;
            this.label2.Text = "Task finished!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.label3.Location = new System.Drawing.Point(164, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(365, 63);
            this.label3.TabIndex = 1;
            this.label3.Text = "The search is complete and now we are getting ready\r\neverything so you can check " +
    "the results properly.\r\nMeanwhile you can check this statics from the task:";
            // 
            // lbTaskTime
            // 
            this.lbTaskTime.AutoSize = true;
            this.lbTaskTime.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lbTaskTime.Location = new System.Drawing.Point(164, 139);
            this.lbTaskTime.Name = "lbTaskTime";
            this.lbTaskTime.Size = new System.Drawing.Size(169, 21);
            this.lbTaskTime.TabIndex = 1;
            this.lbTaskTime.Text = "Task time: 00:00:00.0000";
            // 
            // lbProcessedDirs
            // 
            this.lbProcessedDirs.AutoSize = true;
            this.lbProcessedDirs.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lbProcessedDirs.Location = new System.Drawing.Point(164, 164);
            this.lbProcessedDirs.Name = "lbProcessedDirs";
            this.lbProcessedDirs.Size = new System.Drawing.Size(165, 21);
            this.lbProcessedDirs.TabIndex = 1;
            this.lbProcessedDirs.Text = "Processed: 0 directories";
            // 
            // lbFoundedDuplications
            // 
            this.lbFoundedDuplications.AutoSize = true;
            this.lbFoundedDuplications.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lbFoundedDuplications.Location = new System.Drawing.Point(164, 189);
            this.lbFoundedDuplications.Name = "lbFoundedDuplications";
            this.lbFoundedDuplications.Size = new System.Drawing.Size(217, 21);
            this.lbFoundedDuplications.TabIndex = 1;
            this.lbFoundedDuplications.Text = "Found: 0 files with duplications.";
            // 
            // lbTotalSize
            // 
            this.lbTotalSize.AutoSize = true;
            this.lbTotalSize.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lbTotalSize.Location = new System.Drawing.Point(164, 214);
            this.lbTotalSize.Name = "lbTotalSize";
            this.lbTotalSize.Size = new System.Drawing.Size(194, 21);
            this.lbTotalSize.TabIndex = 1;
            this.lbTotalSize.Text = "Total size of the files: 0 bytes";
            // 
            // lbLostSpace
            // 
            this.lbLostSpace.AutoSize = true;
            this.lbLostSpace.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lbLostSpace.Location = new System.Drawing.Point(164, 239);
            this.lbLostSpace.Name = "lbLostSpace";
            this.lbLostSpace.Size = new System.Drawing.Size(294, 21);
            this.lbLostSpace.TabIndex = 1;
            this.lbLostSpace.Text = "Total space lost by the duplications: 0 bytes";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(33, 237);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(58, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(390, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "OK, we are ready now. Click \'OK\' to see the results.";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnOK.FlatAppearance.BorderSize = 2;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(454, 280);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 28);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // LbProgress
            // 
            this.LbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LbProgress.AutoSize = true;
            this.LbProgress.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.LbProgress.ForeColor = System.Drawing.Color.Green;
            this.LbProgress.Location = new System.Drawing.Point(30, 220);
            this.LbProgress.Name = "LbProgress";
            this.LbProgress.Size = new System.Drawing.Size(54, 13);
            this.LbProgress.TabIndex = 5;
            this.LbProgress.Text = "Progress:";
            // 
            // FrmLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 321);
            this.Controls.Add(this.LbProgress);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbLostSpace);
            this.Controls.Add(this.lbTotalSize);
            this.Controls.Add(this.lbFoundedDuplications);
            this.Controls.Add(this.lbProcessedDirs);
            this.Controls.Add(this.lbTaskTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLoading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLoading";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbTaskTime;
        private System.Windows.Forms.Label lbProcessedDirs;
        private System.Windows.Forms.Label lbFoundedDuplications;
        private System.Windows.Forms.Label lbTotalSize;
        private System.Windows.Forms.Label lbLostSpace;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label LbProgress;
    }
}