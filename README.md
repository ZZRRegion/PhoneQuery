# 手机归属地查询
本应用是使用了[http://m.ip138.com/mobile.asp](http://m.ip138.com/mobile.asp)
网站提供的查询手机归属地，只是将获取到html部分使用HtmlAgilityPack进行解析，找出有关归属地描述的部分，给与显示。主要代码如下
```C#
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
```
我的[github](https://github.com/ZZRRegion/PhoneQuery)