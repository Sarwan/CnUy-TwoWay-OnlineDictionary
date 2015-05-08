using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["q"]))
            {
                string q = Request.QueryString["q"];
                //string l = Request.QueryString["l"];
                getWords(q);
                showRelatedWords(q);
            }
            //String str = "this is a test"; 
            //System.Diagnostics.Debug.WriteLine(str.CompareTo("zzz xxxx"),"compare");
        }
    }


    private void getWords(string strKeyword)
    {
        UyghurLanguageDetection uld = new UyghurLanguageDetection();
        dcDictDataContext dcDict = new dcDictDataContext();
        StringBuilder sb = new StringBuilder();
        if (uld.isUyghur(strKeyword))
        {
            var words = from uw in dcDict.TUyCns
                        where uw.WordUy == strKeyword
                        select uw;
            if (words.Count() <1)
            {
                showErrorMessage();
                return;
            }
            foreach (var wrd in words)
            {
                sb.Append("<h4 class=\"keywordUy\">").Append(wrd.WordUy.Trim()).Append("</h4>").AppendLine();
                sb.AppendLine("<p class=\"TranslationCn\">");
                    sb.Append("<span>").Append(wrd.WordCn.Trim()).Append("</span>").AppendLine();
                sb.AppendLine("</p>");
            }

           
        }
        else
        {
            var words = from cw in dcDict.TCnUys
                        where cw.WordCn== strKeyword
                        select cw;
            if (words.Count() < 1)
            {
                showErrorMessage();
                return;
            }
            foreach (var wrd in words)
            {
                sb.Append("<h4 class=\"keywordCn\">").Append(wrd.WordCn.Trim()).Append("<span class=\"TermCat\"> (").Append(wrd.WordPinyin.Trim()).Append(")</span>").Append("</h4>").AppendLine();
                sb.AppendLine("<p class=\"TranslationUy\">");
                sb.Append("<span>").Append(wrd.WordUy.Trim()).Append("</span>").AppendLine();
                sb.AppendLine("</p>");
            }

        }

        ltrlResult.Text = sb.ToString();
    }

    private void showRelatedWords(string strKeyword)
    {
        UyghurLanguageDetection uld = new UyghurLanguageDetection();
        dcDictDataContext dcDict = new dcDictDataContext();
        StringBuilder sb = new StringBuilder();
        if (uld.isUyghur(strKeyword))
        {
            var words = (from uw in dcDict.TUyCns
                        where uw.WordUy.StartsWith( strKeyword)
                        select uw).Take(11);
            if (words.Count() < 1)
            {
                showErrorMessage();
                return;
            }
            sb.Append("<ul>").AppendLine();
            foreach (var wrd in words)
            {
                if (wrd.WordUy.Trim() == strKeyword)
                {
                    continue;
                }
                sb.AppendLine("<li>");
                sb.Append("<a").Append(" href='home.aspx?q=").Append(wrd.WordUy.Trim()).Append("'>").Append(wrd.WordUy.Trim()).Append("</a").AppendLine();
                sb.AppendLine("</li>");
                
            }
            sb.Append("</ul>").AppendLine();

        }
        else
        {
            var words = (from cw in dcDict.TCnUys
                        where cw.WordCn.StartsWith(strKeyword)
                        select cw).Take(11);
            if (words.Count() < 1)
            {
                showErrorMessage();
                return;
            }
            sb.Append("<ul>").AppendLine();
            foreach (var wrd in words)
            {
                if (wrd.WordCn.Trim() == strKeyword)
                {
                    continue;
                }
                sb.AppendLine("<li>");
                sb.Append("<a").Append(" href='home.aspx?q=").Append(wrd.WordCn.Trim()).Append("'>").Append(wrd.WordCn.Trim()).Append("</a").AppendLine();
                sb.AppendLine("</li>");
            }
            sb.Append("</ul>").AppendLine();
        }

        ltrlRelatedWords.Text = sb.ToString();
    }

    private void showErrorMessage()
    {
        ltrlResult.Text = "ئىزدىگەن سۆز لۇغەتتىن تېپىلمىدى.";
    }
    



   

    
}