using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using HtmlAgilityPack;

namespace PhoneQuery
{
    public partial class FrmMain : Form
    {
        private string cloudUrl => "http://m.ip138.com/mobile.asp?mobile={0}";
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();
            string url = string.Format(this.cloudUrl, this.txtPhone.Text);
            HttpClient httpClient = new HttpClient();
            string content = httpClient.GetStringAsync(url).Result;
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(content);
            HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode(".//table[@class='table']");
            string text = htmlNode.InnerText;
            text = text.Replace("\t", "");
            string[] lst = text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for(int i = 1; i < lst.Length; i++)
            {
                this.richTextBox1.AppendText(lst[i]);
                this.richTextBox1.AppendText(Environment.NewLine);
            }
        }
    }
}
