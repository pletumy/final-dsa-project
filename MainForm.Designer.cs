namespace do_an_dsa
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            lblPhanMem = new Label();
            btnUpload = new Button();
            btnSave = new Button();
            btnEdit = new Button();
            grbActions = new GroupBox();
            btnthoat = new Button();
            grbHTML = new GroupBox();
            txt_xuLyFile = new TextBox();
            grbActions.SuspendLayout();
            grbHTML.SuspendLayout();
            SuspendLayout();
            // 
            // lblPhanMem
            // 
            lblPhanMem.AutoSize = true;
            lblPhanMem.BackColor = Color.Transparent;
            lblPhanMem.Font = new Font("Arial", 28.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblPhanMem.ForeColor = Color.FromArgb(234, 191, 139);
            lblPhanMem.Location = new Point(23, 19);
            lblPhanMem.Margin = new Padding(5, 0, 5, 0);
            lblPhanMem.Name = "lblPhanMem";
            lblPhanMem.Size = new Size(566, 55);
            lblPhanMem.TabIndex = 2;
            lblPhanMem.Text = "BỘ ĐỌC TÀI LIỆU HTML";
            // 
            // btnUpload
            // 
            btnUpload.ForeColor = Color.FromArgb(40, 40, 40);
            btnUpload.Location = new Point(35, 42);
            btnUpload.Margin = new Padding(4);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(281, 43);
            btnUpload.TabIndex = 0;
            btnUpload.Text = "Tải tệp lên";
            btnUpload.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.ForeColor = Color.FromArgb(40, 40, 40);
            btnSave.Location = new Point(697, 42);
            btnSave.Margin = new Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(281, 43);
            btnSave.TabIndex = 2;
            btnSave.Text = "Lưu tệp";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Visible = false;
            // 
            // btnEdit
            // 
            btnEdit.ForeColor = Color.FromArgb(40, 40, 40);
            btnEdit.Location = new Point(367, 42);
            btnEdit.Margin = new Padding(4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(281, 43);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Chỉnh sửa tệp";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Visible = false;
            // 
            // grbActions
            // 
            grbActions.BackColor = Color.Transparent;
            grbActions.Controls.Add(btnUpload);
            grbActions.Controls.Add(btnEdit);
            grbActions.Controls.Add(btnSave);
            grbActions.ForeColor = Color.FromArgb(163, 252, 255);
            grbActions.Location = new Point(141, 604);
            grbActions.Margin = new Padding(4);
            grbActions.Name = "grbActions";
            grbActions.Padding = new Padding(4);
            grbActions.Size = new Size(1009, 118);
            grbActions.TabIndex = 7;
            grbActions.TabStop = false;
            grbActions.Text = "Thao tác";
            // 
            // btnthoat
            // 
            btnthoat.BackColor = Color.WhiteSmoke;
            btnthoat.DialogResult = DialogResult.Cancel;
            btnthoat.FlatAppearance.BorderColor = Color.White;
            btnthoat.FlatAppearance.BorderSize = 0;
            btnthoat.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnthoat.FlatAppearance.MouseOverBackColor = Color.DimGray;
            btnthoat.FlatStyle = FlatStyle.Popup;
            btnthoat.ForeColor = Color.DimGray;
            btnthoat.Location = new Point(1376, 785);
            btnthoat.Margin = new Padding(4);
            btnthoat.Name = "btnthoat";
            btnthoat.Size = new Size(133, 34);
            btnthoat.TabIndex = 8;
            btnthoat.Text = "Thoát";
            btnthoat.UseVisualStyleBackColor = false;
            // 
            // grbHTML
            // 
            grbHTML.BackColor = Color.Transparent;
            grbHTML.Controls.Add(txt_xuLyFile);
            grbHTML.ForeColor = Color.FromArgb(234, 191, 139);
            grbHTML.Location = new Point(270, 88);
            grbHTML.Name = "grbHTML";
            grbHTML.Size = new Size(719, 499);
            grbHTML.TabIndex = 3;
            grbHTML.TabStop = false;
            grbHTML.Text = "FILE HTML";
            // 
            // txt_xuLyFile
            // 
            txt_xuLyFile.Location = new Point(6, 48);
            txt_xuLyFile.Multiline = true;
            txt_xuLyFile.Name = "txt_xuLyFile";
            txt_xuLyFile.ScrollBars = ScrollBars.Both;
            txt_xuLyFile.Size = new Size(707, 445);
            txt_xuLyFile.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 60, 60);
            CancelButton = btnthoat;
            ClientSize = new Size(1262, 735);
            Controls.Add(grbHTML);
            Controls.Add(btnthoat);
            Controls.Add(grbActions);
            Controls.Add(lblPhanMem);
            Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = Color.Black;
            Margin = new Padding(5);
            MaximumSize = new Size(1920, 1080);
            MinimumSize = new Size(1280, 720);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            grbActions.ResumeLayout(false);
            grbHTML.ResumeLayout(false);
            grbHTML.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblPhanMem;
        private Button btnUpload;
        private GroupBox grbActions;
        private Button btnthoat;
        private GroupBox grbHTML;
        public Button btnSave;
        public Button btnEdit;
        private TextBox txt_xuLyFile;
    }
}