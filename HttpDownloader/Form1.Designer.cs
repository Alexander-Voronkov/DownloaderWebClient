namespace HttpDownloader
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabControl = new System.Windows.Forms.TabControl();
            this.Downloading = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.History = new System.Windows.Forms.TabPage();
            this.Downloaded = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.DownloadBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TabControl.SuspendLayout();
            this.Downloading.SuspendLayout();
            this.History.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.Downloading);
            this.TabControl.Controls.Add(this.History);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(484, 307);
            this.TabControl.TabIndex = 0;
            // 
            // Downloading
            // 
            this.Downloading.Controls.Add(this.listView1);
            this.Downloading.Location = new System.Drawing.Point(4, 22);
            this.Downloading.Name = "Downloading";
            this.Downloading.Padding = new System.Windows.Forms.Padding(3);
            this.Downloading.Size = new System.Drawing.Size(476, 281);
            this.Downloading.TabIndex = 0;
            this.Downloading.Text = "Downloading";
            this.Downloading.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(464, 269);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // History
            // 
            this.History.Controls.Add(this.Downloaded);
            this.History.Location = new System.Drawing.Point(4, 22);
            this.History.Name = "History";
            this.History.Padding = new System.Windows.Forms.Padding(3);
            this.History.Size = new System.Drawing.Size(476, 281);
            this.History.TabIndex = 1;
            this.History.Text = "History";
            this.History.UseVisualStyleBackColor = true;
            // 
            // Downloaded
            // 
            this.Downloaded.FormattingEnabled = true;
            this.Downloaded.Location = new System.Drawing.Point(6, 6);
            this.Downloaded.Name = "Downloaded";
            this.Downloaded.Size = new System.Drawing.Size(464, 264);
            this.Downloaded.TabIndex = 0;
            this.Downloaded.DoubleClick += new System.EventHandler(this.Downloaded_DoubleClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(92, 344);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(400, 20);
            this.textBox1.TabIndex = 1;
            // 
            // DownloadBtn
            // 
            this.DownloadBtn.Location = new System.Drawing.Point(189, 385);
            this.DownloadBtn.Name = "DownloadBtn";
            this.DownloadBtn.Size = new System.Drawing.Size(106, 39);
            this.DownloadBtn.TabIndex = 2;
            this.DownloadBtn.Text = "Download";
            this.DownloadBtn.UseVisualStyleBackColor = true;
            this.DownloadBtn.Click += new System.EventHandler(this.DownloadBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Download link:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 436);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DownloadBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.TabControl);
            this.Name = "Form1";
            this.Text = "Downloader";
            this.TabControl.ResumeLayout(false);
            this.Downloading.ResumeLayout(false);
            this.History.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage Downloading;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TabPage History;
        private System.Windows.Forms.ListBox Downloaded;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button DownloadBtn;
        private System.Windows.Forms.Label label1;
    }
}

