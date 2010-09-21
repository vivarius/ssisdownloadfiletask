namespace SSISDownloadFileTask100
{
    partial class frmEditProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditProperties));
            this.cmbHttpConnectionManager = new System.Windows.Forms.ComboBox();
            this.lbHTTPConnection = new System.Windows.Forms.Label();
            this.lbFileToDownload = new System.Windows.Forms.Label();
            this.txSourceFile = new System.Windows.Forms.TextBox();
            this.lbTargetDownloadFile = new System.Windows.Forms.Label();
            this.txDestinationFile = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btExpressionSource = new System.Windows.Forms.Button();
            this.btExpressionDestination = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbHttpConnectionManager
            // 
            this.cmbHttpConnectionManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHttpConnectionManager.FormattingEnabled = true;
            this.cmbHttpConnectionManager.Location = new System.Drawing.Point(157, 16);
            this.cmbHttpConnectionManager.Name = "cmbHttpConnectionManager";
            this.cmbHttpConnectionManager.Size = new System.Drawing.Size(300, 21);
            this.cmbHttpConnectionManager.TabIndex = 0;
            // 
            // lbHTTPConnection
            // 
            this.lbHTTPConnection.AutoSize = true;
            this.lbHTTPConnection.Location = new System.Drawing.Point(13, 19);
            this.lbHTTPConnection.Name = "lbHTTPConnection";
            this.lbHTTPConnection.Size = new System.Drawing.Size(138, 13);
            this.lbHTTPConnection.TabIndex = 1;
            this.lbHTTPConnection.Text = "HTTP Connection Manager";
            // 
            // lbFileToDownload
            // 
            this.lbFileToDownload.AutoSize = true;
            this.lbFileToDownload.Location = new System.Drawing.Point(13, 51);
            this.lbFileToDownload.Name = "lbFileToDownload";
            this.lbFileToDownload.Size = new System.Drawing.Size(86, 13);
            this.lbFileToDownload.TabIndex = 2;
            this.lbFileToDownload.Text = "File to Download";
            // 
            // txSourceFile
            // 
            this.txSourceFile.Location = new System.Drawing.Point(157, 48);
            this.txSourceFile.Name = "txSourceFile";
            this.txSourceFile.Size = new System.Drawing.Size(300, 20);
            this.txSourceFile.TabIndex = 3;
            // 
            // lbTargetDownloadFile
            // 
            this.lbTargetDownloadFile.AutoSize = true;
            this.lbTargetDownloadFile.Location = new System.Drawing.Point(13, 82);
            this.lbTargetDownloadFile.Name = "lbTargetDownloadFile";
            this.lbTargetDownloadFile.Size = new System.Drawing.Size(108, 13);
            this.lbTargetDownloadFile.TabIndex = 4;
            this.lbTargetDownloadFile.Text = "Target Download File";
            // 
            // txDestinationFile
            // 
            this.txDestinationFile.Location = new System.Drawing.Point(157, 79);
            this.txDestinationFile.Name = "txDestinationFile";
            this.txDestinationFile.Size = new System.Drawing.Size(300, 20);
            this.txDestinationFile.TabIndex = 5;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(173, 123);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 36);
            this.btSave.TabIndex = 6;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(254, 123);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 36);
            this.btCancel.TabIndex = 7;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btExpressionSource
            // 
            this.btExpressionSource.Location = new System.Drawing.Point(465, 47);
            this.btExpressionSource.Name = "btExpressionSource";
            this.btExpressionSource.Size = new System.Drawing.Size(29, 23);
            this.btExpressionSource.TabIndex = 8;
            this.btExpressionSource.Text = "...";
            this.btExpressionSource.UseVisualStyleBackColor = true;
            this.btExpressionSource.Click += new System.EventHandler(this.btExpressionSource_Click);
            // 
            // btExpressionDestination
            // 
            this.btExpressionDestination.Location = new System.Drawing.Point(465, 78);
            this.btExpressionDestination.Name = "btExpressionDestination";
            this.btExpressionDestination.Size = new System.Drawing.Size(29, 23);
            this.btExpressionDestination.TabIndex = 9;
            this.btExpressionDestination.Text = "...";
            this.btExpressionDestination.UseVisualStyleBackColor = true;
            this.btExpressionDestination.Click += new System.EventHandler(this.btExpressionDestination_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(307, 165);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(217, 13);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "http//ssisdownloadfiletask.codeplex.com";
            // 
            // frmEditProperties
            // 
            this.AcceptButton = this.btSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(522, 183);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btExpressionDestination);
            this.Controls.Add(this.btExpressionSource);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.txDestinationFile);
            this.Controls.Add(this.lbTargetDownloadFile);
            this.Controls.Add(this.txSourceFile);
            this.Controls.Add(this.lbFileToDownload);
            this.Controls.Add(this.lbHTTPConnection);
            this.Controls.Add(this.cmbHttpConnectionManager);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditProperties";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit task properties";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbHttpConnectionManager;
        private System.Windows.Forms.Label lbHTTPConnection;
        private System.Windows.Forms.Label lbFileToDownload;
        private System.Windows.Forms.TextBox txSourceFile;
        private System.Windows.Forms.Label lbTargetDownloadFile;
        private System.Windows.Forms.TextBox txDestinationFile;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btExpressionSource;
        private System.Windows.Forms.Button btExpressionDestination;
        private System.Windows.Forms.TextBox textBox1;
    }
}