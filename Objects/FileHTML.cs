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
        MyQueue tagMo = new MyQueue();
        MyQueue tagDong = new MyQueue();
        public bool KiemTraNoiDung(string html)
        {
            /*tạo 2 match collection -> sort -> enqueue vào opening tags và closing tags
             * số lượng opening tags = closing tags
             * nội dung opening tags equals closing tags
             * */
            Regex tagRegex = new Regex("<[^>]+>");
            MatchCollection tagMatches = tagRegex.Matches(html);

            List<string> openTags = new List<string>();
            List<string> closeTags = new List<string>();

            foreach (Match match in tagMatches)
            {
                string tag = match.Value.Trim('<', '>');
                if (tag.StartsWith("/"))
                {
                    closeTags.Add(tag);
                }
                else
                {
                    openTags.Add(tag);
                }
            }

            openTags.Sort();
            closeTags.Sort();

            foreach (string tag in openTags)
            {
                tagMo.Enqueue(tag);
            }

            foreach (string tag in closeTags)
            {
                tagDong.Enqueue(tag);
            }

            //tagDong != tagMo => false

            if (tagDong.Count() != tagMo.Count())
            {
                return false;
            }
            else {
                //checkNoiDungTag
                while (tagMo.Count() > 0 && tagDong.Count() > 0)
                {
                    string tag1 = tagMo.Peek().data.ToString();
                    string tag2 = tagDong.Peek().data.ToString().Substring(1);
                    if (tag1.Equals(tag2))
                    {
                        tagMo.Dequeue();
                        tagDong.Dequeue();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            //true: html đúng ; false: html sai
            return true;
        }

        //inNoiDungDung
        public string inNoiDungDung(string html)
        {
            string contentWithoutTags = Regex.Replace(html, @"<[^>]+>", match =>
            {
                string tagName = Regex.Match(match.Value, @"<(\w+)").Groups[1].Value;
                if (tagName.ToLower() != "script" && tagName.ToLower() != "style")
                {
                    return $"{match.Groups[1].Value}\n";
                }
                else
                {
                    return "";
                }
            }).Trim();
            return contentWithoutTags;
        }
    }
}
