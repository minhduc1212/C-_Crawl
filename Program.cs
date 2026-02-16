using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Text;

HttpClient client = new HttpClient();
string url = "https://www.doctruyenvoz.com/2014/09/7-ngay-lam-gia-su.html";
try
{
    HttpResponseMessage response =  await client.GetAsync(url);
    response.EnsureSuccessStatusCode();

    string responseContent = await response.Content.ReadAsStringAsync();
    
    var htmlDoc = new HtmlDocument();
    htmlDoc.LoadHtml(responseContent);

    var divContent = htmlDoc.DocumentNode.SelectNodes("//div[@class='post-body-inner']");

    
    
    string content =  divContent[0].InnerText;
    
    string filePath = "content.txt";
    File.WriteAllText(filePath, content);   
}
catch (HttpRequestException e)
{
    Console.WriteLine(e.Message);
}