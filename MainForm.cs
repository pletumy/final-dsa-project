

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

            //set up luôn có 1 file
            FileHTML demo = new FileHTML(@"C:\Users\ADMIN\Downloads\EMPTY.html");
            dsFileHTML.enqueueDS(demo);

            for (int i = 0; i < dsFileHTML.demDS(); i++)
            {
                FileHTML file = (FileHTML)dsFileHTML.layChiSo(i);

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
                    dsFileHTML.enqueueDS(newFile);
                    UpdateListView();
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

            for (int i = 0; i < dsFileHTML.demDS(); i++)
            {
                FileHTML file = (FileHTML)dsFileHTML.layChiSo(i);

                ListViewItem item = new ListViewItem(file.tenFile);

                item.SubItems.Add(file.url);

                lvFile1.Items.Add(item);
            }
        }

        private void lvFile1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void btnHienThi_Click(object sender, EventArgs e)
        {
            if (lvFile1.SelectedItems.Count > 0)
            {
                string selectedItem = lvFile1.SelectedItems[0].Text;

                FileHTML selectedFile = null;

                int queueSize = dsFileHTML.demDS();
                for (int i = 0; i < queueSize; i++)
                {
                    FileHTML file = (FileHTML)dsFileHTML.layChiSo(i);

                    if (file.tenFile.Equals(selectedItem))
                    {
                        selectedFile = file;
                        break;
                    }

                    dsFileHTML.enqueueDS(file);
                }

                if (selectedFile != null)
                {
                    string html = selectedFile.noiDung;
                    bool isValid = selectedFile.kiemTraNoiDung(html);

                    if (isValid)
                    {
                        txt_xuLyFile.Text = selectedFile.inNoiDungDung(html);
                    }
                    else txt_xuLyFile.Text = selectedFile.inNoiDungSai(html);
                }
            }
        }
    }
}