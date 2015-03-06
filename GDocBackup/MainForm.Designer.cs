
namespace GDocBackup
{
    partial class MainForm
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
            this.BtnExec = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadAllagainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.configToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.debugModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.techSupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.techDocListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGV = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Export = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLocalData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lbllastBackup = new System.Windows.Forms.Label();
            this.trvFolders = new System.Windows.Forms.TreeView();
            this.lblerror = new System.Windows.Forms.Label();
            this.lblCompleteBackup = new System.Windows.Forms.Label();
            this.lblCopied = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnExec
            // 
            this.BtnExec.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnExec.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExec.ForeColor = System.Drawing.Color.Black;
            this.BtnExec.Location = new System.Drawing.Point(528, 310);
            this.BtnExec.Name = "BtnExec";
            this.BtnExec.Size = new System.Drawing.Size(93, 34);
            this.BtnExec.TabIndex = 0;
            this.BtnExec.Text = "&Save";
            this.BtnExec.UseVisualStyleBackColor = true;
            this.BtnExec.Click += new System.EventHandler(this.BtnExec_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(0, 286);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(802, 18);
            this.progressBar1.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(817, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem,
            this.downloadAllagainToolStripMenuItem,
            this.toolStripSeparator1,
            this.configToolStripMenuItem1,
            this.logsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.toolStripSeparator2,
            this.debugModeToolStripMenuItem,
            this.techSupportToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.configToolStripMenuItem.Text = "&Action";
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.downloadToolStripMenuItem.Text = "Download (only modified docs)";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // downloadAllagainToolStripMenuItem
            // 
            this.downloadAllagainToolStripMenuItem.Name = "downloadAllagainToolStripMenuItem";
            this.downloadAllagainToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.downloadAllagainToolStripMenuItem.Text = "Download (all docs)";
            this.downloadAllagainToolStripMenuItem.Click += new System.EventHandler(this.downloadAllagainToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(238, 6);
            // 
            // configToolStripMenuItem1
            // 
            this.configToolStripMenuItem1.Name = "configToolStripMenuItem1";
            this.configToolStripMenuItem1.Size = new System.Drawing.Size(241, 22);
            this.configToolStripMenuItem1.Text = "Config";
            this.configToolStripMenuItem1.Click += new System.EventHandler(this.configToolStripMenuItem1_Click);
            // 
            // logsToolStripMenuItem
            // 
            this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            this.logsToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.logsToolStripMenuItem.Text = "View Logs";
            this.logsToolStripMenuItem.Click += new System.EventHandler(this.logsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(238, 6);
            // 
            // debugModeToolStripMenuItem
            // 
            this.debugModeToolStripMenuItem.Name = "debugModeToolStripMenuItem";
            this.debugModeToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.debugModeToolStripMenuItem.Text = "Debug mode";
            this.debugModeToolStripMenuItem.Click += new System.EventHandler(this.debugModeToolStripMenuItem_Click);
            // 
            // techSupportToolStripMenuItem
            // 
            this.techSupportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.techDocListToolStripMenuItem});
            this.techSupportToolStripMenuItem.Name = "techSupportToolStripMenuItem";
            this.techSupportToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.techSupportToolStripMenuItem.Text = "Tech support";
            // 
            // techDocListToolStripMenuItem
            // 
            this.techDocListToolStripMenuItem.Name = "techDocListToolStripMenuItem";
            this.techDocListToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.techDocListToolStripMenuItem.Text = "Doc list";
            this.techDocListToolStripMenuItem.Click += new System.EventHandler(this.techDocListToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(238, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // dataGV
            // 
            this.dataGV.AllowUserToAddRows = false;
            this.dataGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnType,
            this.Export,
            this.ColumnAction,
            this.ColumnLocalData});
            this.dataGV.Location = new System.Drawing.Point(134, 91);
            this.dataGV.Name = "dataGV";
            this.dataGV.ReadOnly = true;
            this.dataGV.Size = new System.Drawing.Size(668, 189);
            this.dataGV.TabIndex = 5;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Width = 150;
            // 
            // ColumnType
            // 
            this.ColumnType.HeaderText = "Type";
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.ReadOnly = true;
            this.ColumnType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Export
            // 
            this.Export.HeaderText = "Export";
            this.Export.Name = "Export";
            this.Export.ReadOnly = true;
            this.Export.Width = 50;
            // 
            // ColumnAction
            // 
            this.ColumnAction.HeaderText = "Action";
            this.ColumnAction.Name = "ColumnAction";
            this.ColumnAction.ReadOnly = true;
            this.ColumnAction.Width = 50;
            // 
            // ColumnLocalData
            // 
            this.ColumnLocalData.HeaderText = "Data";
            this.ColumnLocalData.Name = "ColumnLocalData";
            this.ColumnLocalData.ReadOnly = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnCancel.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.ForeColor = System.Drawing.Color.Black;
            this.BtnCancel.Location = new System.Drawing.Point(623, 310);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(93, 34);
            this.BtnCancel.TabIndex = 6;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Google Account:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(276, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Last Backup:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(276, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Copied:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(545, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Errors:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(545, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Completed:";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccount.Location = new System.Drawing.Point(104, 28);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(0, 15);
            this.lblAccount.TabIndex = 12;
            // 
            // lbllastBackup
            // 
            this.lbllastBackup.AutoSize = true;
            this.lbllastBackup.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllastBackup.Location = new System.Drawing.Point(364, 28);
            this.lbllastBackup.Name = "lbllastBackup";
            this.lbllastBackup.Size = new System.Drawing.Size(0, 15);
            this.lbllastBackup.TabIndex = 13;
            // 
            // trvFolders
            // 
            this.trvFolders.Location = new System.Drawing.Point(0, 91);
            this.trvFolders.Name = "trvFolders";
            this.trvFolders.Size = new System.Drawing.Size(128, 189);
            this.trvFolders.TabIndex = 14;
            // 
            // lblerror
            // 
            this.lblerror.AutoSize = true;
            this.lblerror.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblerror.Location = new System.Drawing.Point(620, 44);
            this.lblerror.Name = "lblerror";
            this.lblerror.Size = new System.Drawing.Size(0, 15);
            this.lblerror.TabIndex = 15;
            // 
            // lblCompleteBackup
            // 
            this.lblCompleteBackup.AutoSize = true;
            this.lblCompleteBackup.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompleteBackup.Location = new System.Drawing.Point(620, 28);
            this.lblCompleteBackup.Name = "lblCompleteBackup";
            this.lblCompleteBackup.Size = new System.Drawing.Size(0, 15);
            this.lblCompleteBackup.TabIndex = 16;
            // 
            // lblCopied
            // 
            this.lblCopied.AutoSize = true;
            this.lblCopied.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopied.Location = new System.Drawing.Point(358, 44);
            this.lblCopied.Name = "lblCopied";
            this.lblCopied.Size = new System.Drawing.Size(0, 15);
            this.lblCopied.TabIndex = 17;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(817, 362);
            this.Controls.Add(this.lblCopied);
            this.Controls.Add(this.lblCompleteBackup);
            this.Controls.Add(this.lblerror);
            this.Controls.Add(this.trvFolders);
            this.Controls.Add(this.lbllastBackup);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.dataGV);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.BtnExec);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(400, 210);
            this.Name = "MainForm";
            this.Text = "GDocBackup";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnExec;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGV;
        private System.Windows.Forms.ToolStripMenuItem logsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadAllagainToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem debugModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Export;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLocalData;
        private System.Windows.Forms.ToolStripMenuItem techSupportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem techDocListToolStripMenuItem;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lbllastBackup;
        internal System.Windows.Forms.TreeView trvFolders;
        private System.Windows.Forms.Label lblerror;
        private System.Windows.Forms.Label lblCompleteBackup;
        private System.Windows.Forms.Label lblCopied;
    }
}

