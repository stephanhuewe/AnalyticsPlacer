namespace Huestel.Tools.AnalyticsPlacer.App
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
            this.txtGACode = new System.Windows.Forms.TextBox();
            this.btnReplace = new System.Windows.Forms.Button();
            this.sourceDirectoryDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.targetDirectoryDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.lblProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtGACode
            // 
            this.txtGACode.Location = new System.Drawing.Point(19, 27);
            this.txtGACode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtGACode.Multiline = true;
            this.txtGACode.Name = "txtGACode";
            this.txtGACode.Size = new System.Drawing.Size(348, 237);
            this.txtGACode.TabIndex = 0;
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(387, 27);
            this.btnReplace.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(167, 41);
            this.btnReplace.TabIndex = 1;
            this.btnReplace.Text = "Place Google Analytics Code in files";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // sourceDirectoryDialog
            // 
            this.sourceDirectoryDialog.Description = "Select source directory";
            // 
            // targetDirectoryDialog
            // 
            this.targetDirectoryDialog.Description = "Select target directory";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(384, 84);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 13);
            this.lblProgress.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 275);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.txtGACode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Google Analytics Placer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGACode;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.FolderBrowserDialog sourceDirectoryDialog;
        private System.Windows.Forms.FolderBrowserDialog targetDirectoryDialog;
        private System.Windows.Forms.Label lblProgress;
    }
}

