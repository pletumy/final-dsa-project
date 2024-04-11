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
            grbActions = new GroupBox();
            btnLink = new Button();
            btnSave = new Button();
            btnEdit = new Button();
            grbHTML = new GroupBox();
            txt_xuLyFile = new TextBox();
            groupBox1 = new GroupBox();
            lvFile1 = new ListView();
            Xóa = new Button();
            btnThem = new Button();
            btnHienThi = new Button();
            grbActions.SuspendLayout();
            grbHTML.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblPhanMem
            // 
            lblPhanMem.AutoSize = true;
            lblPhanMem.BackColor = Color.Transparent;
            lblPhanMem.Font = new Font("Arial", 28.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblPhanMem.ForeColor = Color.FromArgb(234, 191, 139);
            lblPhanMem.Location = new Point(23, 9);
            lblPhanMem.Margin = new Padding(5, 0, 5, 0);
            lblPhanMem.Name = "lblPhanMem";
            lblPhanMem.Size = new Size(566, 55);
            lblPhanMem.TabIndex = 2;
            lblPhanMem.Text = "BỘ ĐỌC TÀI LIỆU HTML";
            // 
            // grbActions
            // 
            grbActions.BackColor = Color.Transparent;
            grbActions.Controls.Add(btnLink);
            grbActions.Controls.Add(btnSave);
            grbActions.Controls.Add(btnEdit);
            grbActions.ForeColor = Color.FromArgb(163, 252, 255);
            grbActions.Location = new Point(32, 604);
            grbActions.Margin = new Padding(4);
            grbActions.Name = "grbActions";
            grbActions.Padding = new Padding(4);
            grbActions.Size = new Size(1208, 118);
            grbActions.TabIndex = 7;
            grbActions.TabStop = false;
            grbActions.Text = "THAO TÁC FILE";
            // 
            // btnLink
            // 
            btnLink.ForeColor = Color.FromArgb(40, 40, 40);
            btnLink.Location = new Point(790, 49);
            btnLink.Margin = new Padding(4);
            btnLink.Name = "btnLink";
            btnLink.Size = new Size(257, 43);
            btnLink.TabIndex = 3;
            btnLink.Text = "Trích xuất liên kết";
            btnLink.UseVisualStyleBackColor = true;
            btnLink.Click += btnLink_Click;
            // 
            // btnSave
            // 
            btnSave.ForeColor = Color.FromArgb(40, 40, 40);
            btnSave.Location = new Point(506, 49);
            btnSave.Margin = new Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(206, 43);
            btnSave.TabIndex = 2;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnEdit
            // 
            btnEdit.ForeColor = Color.FromArgb(40, 40, 40);
            btnEdit.Location = new Point(218, 49);
            btnEdit.Margin = new Padding(4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(206, 43);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Chỉnh sửa";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // grbHTML
            // 
            grbHTML.BackColor = Color.Transparent;
            grbHTML.Controls.Add(txt_xuLyFile);
            grbHTML.ForeColor = Color.FromArgb(234, 191, 139);
            grbHTML.Location = new Point(32, 77);
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
            txt_xuLyFile.TextChanged += txt_xuLyFile_TextChanged;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(btnHienThi);
            groupBox1.Controls.Add(lvFile1);
            groupBox1.Controls.Add(Xóa);
            groupBox1.Controls.Add(btnThem);
            groupBox1.ForeColor = Color.FromArgb(234, 191, 139);
            groupBox1.Location = new Point(822, 77);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(418, 499);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "DANH SÁCH FILE";
            // 
            // lvFile1
            // 
            // Set to details view.
            lvFile1.View = View.Details;
            // Add a column with width 20 and left alignment.
            lvFile1.Columns.Add("Tên file", 409, HorizontalAlignment.Left);
            lvFile1.FullRowSelect = true;
            lvFile1.Location = new Point(3, 30);
            lvFile1.Name = "lvFile1";
            lvFile1.Size = new Size(409, 393);
            lvFile1.TabIndex = 6;
            lvFile1.UseCompatibleStateImageBehavior = false;
            lvFile1.View = View.Details;
            lvFile1.SelectedIndexChanged += lvFile1_SelectedIndexChanged;
            // 
            // Xóa
            // 
            Xóa.ForeColor = Color.FromArgb(40, 40, 40);
            Xóa.Location = new Point(279, 443);
            Xóa.Margin = new Padding(4);
            Xóa.Name = "Xóa";
            Xóa.Size = new Size(115, 43);
            Xóa.TabIndex = 5;
            Xóa.Text = "Xóa";
            Xóa.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.ForeColor = Color.FromArgb(40, 40, 40);
            btnThem.Location = new Point(151, 443);
            btnThem.Margin = new Padding(4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(115, 43);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnHienThi
            // 
            btnHienThi.ForeColor = Color.FromArgb(40, 40, 40);
            btnHienThi.Location = new Point(19, 443);
            btnHienThi.Margin = new Padding(4);
            btnHienThi.Name = "btnHienThi";
            btnHienThi.Size = new Size(115, 43);
            btnHienThi.TabIndex = 7;
            btnHienThi.Text = "Hiển thị";
            btnHienThi.UseVisualStyleBackColor = true;
            btnHienThi.Click += btnHienThi_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(14F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 60, 60);
            ClientSize = new Size(1262, 753);
            Controls.Add(groupBox1);
            Controls.Add(grbHTML);
            Controls.Add(grbActions);
            Controls.Add(lblPhanMem);
            Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = Color.Black;
            Margin = new Padding(5);
            MaximumSize = new Size(1280, 800);
            MinimumSize = new Size(1280, 800);
            Name = "MainForm";
            Text = "MainForm";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            grbActions.ResumeLayout(false);
            grbHTML.ResumeLayout(false);
            grbHTML.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblPhanMem;
        private GroupBox grbActions;
        private GroupBox grbHTML;
        private TextBox txt_xuLyFile;
        private Button btnLink;
        private Button btnSave;
        private Button btnEdit;
        private GroupBox groupBox1;
        private Button Xóa;
        private Button btnThem;
        private ListView lvFile;
        private ListView lvFile1;
        private Button btnHienThi;
    }
}