

using do_an_dsa.Objects;
using System.CodeDom.Compiler;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace do_an_dsa
{
    public partial class MainForm : Form
    {
        DSFileHTML dsFileHTML = new DSFileHTML();
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            for (int i = 0; i < dsFileHTML.demDS(); i++)
            {
                FileHTML file = (FileHTML)dsFileHTML.layNode(i).data;

                ListViewItem item = new ListViewItem(file.tenFile);

                //item.SubItems.Add(file.url);

                lvFile1.Items.Add(item);
            }
        }

        private void btnLink_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fileThayDoi = txt_xuLyFile.Text.Replace("<!DOCTYPE html>", "").Replace(" ", "").Replace("\n", "").Replace("\r", "");
            
            if (lvFile1.SelectedItems.Count > 0)
            {
                string selectedItem = lvFile1.SelectedItems[0].Text;

                FileHTML selectedFile = null;

                int queueSize = dsFileHTML.demDS();


                for (int i = 0; i < queueSize; i++)
                {
                    FileHTML file = (FileHTML)dsFileHTML.layNode(i).data;

                    if (file.tenFile.Equals(selectedItem))
                    {
                        selectedFile = file;
                        break;
                    }

                    dsFileHTML.enqueueDS(file);
                }

                if (selectedFile != null)
                {
                    bool isValid = selectedFile.KiemTraNoiDung(fileThayDoi);
                    if (isValid)
                    {
                        using (StreamWriter writer = new StreamWriter(selectedFile.url))
                        {
                            writer.Write(txt_xuLyFile.Text);
                        }
                        MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Kiểm tra lại nội dung hoặc cú pháp HTML!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
        }

        private void txt_xuLyFile_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "HTML Files (*.html;*.htm)|*.html;*.htm";
            openFileDialog.Title = "Chọn file HTML";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog.FileName;
                if (IsHtmlFile(selectedFile))
                {
                    FileHTML newFile = new FileHTML(selectedFile);
                    bool isFileAlreadySelected = false;
                    foreach (ListViewItem item in lvFile1.Items)
                    {
                        if (item.Text == newFile.tenFile)
                        {
                            isFileAlreadySelected = true;
                            break;
                        }
                    }
                    if (isFileAlreadySelected)
                    {
                        MessageBox.Show("File này đã được chọn trước đó. Vui lòng chọn file khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        //FileHTML newFile = new FileHTML(selectedFile);
                        dsFileHTML.enqueueDS(newFile);
                        UpdateListView();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một file HTML!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        //check
        private bool IsHtmlFile(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            return (extension.Equals(".html", StringComparison.OrdinalIgnoreCase) ||
                    extension.Equals(".htm", StringComparison.OrdinalIgnoreCase));
        }
        private void UpdateListView()
        {
            lvFile1.Items.Clear();
            int index = dsFileHTML.demDS();
            for (int i = 0; i < index; i++)
            {
                FileHTML file = (FileHTML)dsFileHTML.layNode(i).data;
                ListViewItem item = new ListViewItem(file.tenFile);
                lvFile1.Items.Add(item);
            }
        }

        private void lvFile1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            txt_xuLyFile.Enabled = false;
            if (lvFile1.SelectedItems.Count > 0)
            {
                string selectedItem = lvFile1.SelectedItems[0].Text;

                FileHTML selectedFile = null;

                int queueSize = dsFileHTML.demDS();


                for (int i = 0; i < queueSize; i++)
                {
                    FileHTML file = (FileHTML)dsFileHTML.layNode(i).data;

                    if (file.tenFile.Equals(selectedItem))
                    {
                        selectedFile = file;
                        break;
                    }

                    dsFileHTML.enqueueDS(file);
                }

                if (selectedFile != null)
                {
                    string html = selectedFile.LayNoiDungFile(selectedFile.url);
                    bool isValid = selectedFile.KiemTraNoiDung(html);

                    if (isValid)
                    {
                        txt_xuLyFile.Text = selectedFile.inNoiDungDung(html);
                    }
                    else
                    {
                        txt_xuLyFile.Text = "Cú pháp HTML trong File không chính xác!";
                       
                    }
                }
            }
        }

        private void Xóa_Click(object sender, EventArgs e)
        {
            if (lvFile1.SelectedItems.Count > 0)
            {
                string selectedItem = lvFile1.SelectedItems[0].Text;
                int index = dsFileHTML.demDS();
                
                for (int i = 0; i < index; i++)
                {
                    FileHTML file = dsFileHTML.dequeueDS(); 
                    if (!file.tenFile.Equals(selectedItem))
                    {
                        dsFileHTML.enqueueDS(file);
                    }
                }
                UpdateListView();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một file HTML!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txt_xuLyFile.Enabled = true;
            if (lvFile1.SelectedItems.Count > 0)
            {
                string selectedItem = lvFile1.SelectedItems[0].Text;
                FileHTML selectedFile = null;
                int queueSize = dsFileHTML.demDS();

                for (int i = 0; i < queueSize; i++)
                {
                    FileHTML file = (FileHTML)dsFileHTML.layNode(i).data;

                    if (file.tenFile.Equals(selectedItem))
                    {
                        selectedFile = file;
                        break;
                    }

                    dsFileHTML.enqueueDS(file);
                }
                //hiển thị file gốc, chưa chỉnh sửa
                if (selectedFile != null)
                {
                    string htmlContent;
                    using (StreamReader reader = new StreamReader(selectedFile.url))
                    {
                        htmlContent = reader.ReadToEnd();
                    }
                    txt_xuLyFile.Text = htmlContent;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một file HTML!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}