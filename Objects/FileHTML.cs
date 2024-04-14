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
        public bool KiemTraNoiDung(string html)
        {
            MyQueue CheckingTags = new MyQueue();
            MyQueue ValidTags = new MyQueue();
            MyQueue InvalidTags = new MyQueue();

            Regex tagRegex = new Regex("<[^>]+>");

            MatchCollection tagMatches = tagRegex.Matches(html);

            foreach (Match tagMatch in tagMatches)
            {
                CheckingTags.Enqueue(tagMatch.Value);
            }

            while (CheckingTags.Count() > 0)
            {
                string tag = CheckingTags.Dequeue().ToString();

                if (tag.StartsWith("<"))
                {
                    string tagName = tag.Trim('<', '>');
                    //tag mở
                    if (!tagName.StartsWith("/"))
                    {
                        ValidTags.Enqueue(tagName);
                    }
                    //tag đóng
                    else
                    {
                        tagName = tagName.Substring(1);

                        if (ValidTags.Count() > 0 && ValidTags.Peek().ToString().Equals(tagName))
                        {
                            ValidTags.Dequeue();
                        }
                        else
                        {
                            InvalidTags.Enqueue(tag);
                        }
                    }
                }
            }
            //true: html đúng ; false: html sai
            return InvalidTags.Count() == 0 && ValidTags.Count() == 0;
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

            while (invalidTags.Count() > 0)
            {
                string invalidTag = (string)invalidTags.Dequeue().data;
                processedHTML = processedHTML.Replace(invalidTag, $"<span style=\"color:red;\">{invalidTag}</span>");
            }

            return processedHTML;
        }

    }
}
