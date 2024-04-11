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
            return noiDung;
        }
        //Upload File
        public string taiFileHTML()
        {
            string htmlContent = File.ReadAllText(url);
            return htmlContent;
        }

        //kiemTraNoiDungFile
        public bool kiemTraNoiDung(string html) {
            MyQueue tagQueue = new MyQueue();
            MyQueue invalidTags = new MyQueue();

            // Sử dụng biểu thức chính quy để tìm các tag trong chuỗi HTML
            Regex tagRegex = new Regex("<[^>]+>");

            MatchCollection tagMatches = tagRegex.Matches(html);

            foreach (Match tagMatch in tagMatches)
            {
                string tag = tagMatch.Value;
                string tagName = tag.Trim('<', '>');

                if (tagName.StartsWith("/"))
                {
                   tagName = tagName.Substring(1); 
                   if (tagQueue.Count > 0 && (string)tagQueue.Peek() == tagName)
                    {
                        tagQueue.Dequeue();
                    }
                    else
                    {
                        invalidTags.Enqueue(tag);
                    }
                }
                else
                {
                    tagQueue.Enqueue(tagName);
                }
            }

            if (tagQueue.Count == 0 && invalidTags.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //inNoiDungDung
        public string inNoiDungDung(string html)
        {
            string contentWithoutTags = Regex.Replace(html, "<[^>]+>", "");
            return contentWithoutTags;
        }

        //Sai
        public string inNoiDungSai(string html)
        {
            MyQueue invalidTags = new MyQueue();

            Regex tagRegex = new Regex("<[^>]+>");
            MatchCollection tagMatches = tagRegex.Matches(html);

            foreach (Match tagMatch in tagMatches)
            {
                string tag = tagMatch.Value;
                invalidTags.Enqueue(tag);
            }

            string processedHTML = html;

            while (invalidTags.Count > 0)
            {
                string invalidTag = (string)invalidTags.Dequeue();
                processedHTML = processedHTML.Replace(invalidTag, $"<span style=\"color:red;\">{invalidTag}</span>");
            }

            return processedHTML;
        }

    }
}
