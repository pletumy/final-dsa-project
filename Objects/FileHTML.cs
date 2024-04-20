using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;
using System.Formats.Tar;
using System.Security.Policy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using do_an_dsa.Objects;

namespace do_an_dsa
{
    public class FileHTML
    {
    //upload file => Cảnh báo file không đúng, đúng thì hiện nội dung của file (Queue => Kiểm tra tính hợp lệ).
        //Ở class nào ? FileHTML hay DSFileHTML =? DSFileHTML => Hàm check
        //Chỉnh sửa file
        //Lưu file lại vị trí
        //Trích xuất liên kết từ file HTML (Queue => Tìm kiếm và trích xuất)
        //Upload file
        public string url { get; set; }
        public string tenFile { get; set; }
        public string noiDung { get; set; }
        public FileHTML(string url)
        {
            this.url = url;
            tenFile = LayTenFile(url);
            noiDung = LayNoiDungFile(url);
        }

        public string LayTenFile(string url)
        {
            string tenFile = Path.GetFileName(url);
            return tenFile;
        }

        public string LayNoiDungFile(string url)
        {
            string noiDung = File.ReadAllText(url);
            noiDung = noiDung.Replace("<!DOCTYPE html>", "");
            noiDung = noiDung.Replace("\n", "");
            return noiDung;
        }
        //Upload File
        public string taiFileHTML()
        {
            string htmlContent = File.ReadAllText(url);
            return htmlContent;
        }

        //kiemTraNoiDungFile
        public bool KiemTraNoiDung(string html)
        {
            MyQueue tagMo = new MyQueue();
            MyQueue tagDong = new MyQueue();
            Regex tagRegex = new Regex("<[^>]+>");
            MatchCollection tagMatches = tagRegex.Matches(html);

            foreach (Match tagMatch in tagMatches)
            {
                string tagName = tagMatch.Value.Trim('<', '>');
                if (tagName.StartsWith("/")) {
                    tagName = tagName.Substring(1);
                    tagDong.Enqueue(tagName);
                }
                else { 
                    tagMo.Enqueue(tagName);
                }
            }

            while (tagMo.Count() > 0 && tagDong.Count() > 0)
            {
                string tag1 = tagMo.Dequeue().data.ToString();
                string tag2 = tagDong.Dequeue().data.ToString();
                if (tag1.Equals(tag2))
                {
                    return false;
                }
            }
                //true: html đúng ; false: html sai
                return tagMo.Count() == 0 && tagDong.Count() == 0;
        }

        //inNoiDungDung
        public string inNoiDungDung(string html)
        {
            string contentWithoutTags = Regex.Replace(html, "<[^>]+>", "").Trim();
            return contentWithoutTags;
        }


    }
}
