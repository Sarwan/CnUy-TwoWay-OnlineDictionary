<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Main.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .keywordUy {
        font-size:18pt;
        color:blueviolet;
        }
           .keywordCn {
        font-size:18pt;
        color:blueviolet;
        direction:ltr;
        text-align:left;
        }

        .TranslationUy {
        padding-right:20px;
        font-size:14pt;
        color:green;
        }
        .TranslationCn {
        padding-right:20px;
        font-size:14pt;
        color:green;
        direction:ltr;
        text-align:left;
        }

        .TermCat {
        font-size:11pt;
        color:black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="direction:rtl; text-decoration:none;">
<asp:Panel ID="pnlDefault" runat="server">
    <asp:Literal ID="ltrlResult" runat="server"></asp:Literal>
    <%--<h4 class="keyword">كومپيۇتېر</h4>
    <p class="Translation">
        <span>Computer</span><br />
        <span>电脑</span>
    </p>
    
     <h4 class="keyword">سىڭدۈرمە سىستېما</h4>
    <p class="Translation">
        <span>embedded system</span><br />
        <span>嵌入式系统</span>
    </p>--%>
    
</asp:Panel>
    </div>

</asp:Content>
<asp:Content ID="ContentLeft" ContentPlaceHolderID="ContentPlaceHolderLeft" runat="server">
    <nav class="block">
    
      <h3>مۇناسىۋەتلىك سۆزلەر</h3>
     <asp:Literal ID="ltrlRelatedWords" runat="server"></asp:Literal>
    </nav>
</asp:Content>

