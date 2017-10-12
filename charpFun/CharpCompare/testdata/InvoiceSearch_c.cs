// Decompiled with JetBrains decompiler
// Type: abo.Accounting.InvoiceSearch
// Assembly: abo.Accounting, Version=1.0.6362.23227, Culture=neutral, PublicKeyToken=null
// MVID: AAF75D97-B708-4CE8-B7BD-297E8EAF260E
// Assembly location: C:\Users\aspentest\Downloads\comp_aspen_dll\abo.Accounting.dll

using abo.Security;
using abo.Web;
using System;
using System.Data.SqlTypes;
using System.Web.UI.WebControls;

namespace abo.Accounting
{
  public class InvoiceSearch : Page
  {
    protected abo.Web.DropDownList SearchBy;
    protected Button btnSearch;
    protected abo.Web.Xml xmlInvoiceSearch;
    protected SiteStyle SiteStyle;
    protected Javascript Javascript;
    protected MenuBar MenuBar;
    protected NavBar NavBar;
    protected TabBar TaBar;
    protected abo.Web.TextBox SearchString;
    protected abo.Web.TextBox DisplaySize;
    protected abo.Web.TextBox RecordStart;
    protected abo.Web.TextBox SortBy;
    protected TabBar TabBar;
    protected Footer Footer;
    protected InvoiceObject theInvoiceSearch;

    private void ExecuteMethod(string theMethod)
    {
      if (this.Server.HtmlEncode(this.Request.Form["InvoiceID"]) == null)
        return;
      for (int index = 0; index < this.Request.Form.GetValues("InvoiceID").Length; ++index)
      {
        this.theInvoiceSearch.InvoiceID = new SqlInt32(Convert.ToInt32(this.Request.Form.GetValues("InvoiceID")[index]));
        switch (theMethod)
        {
          case "Delete":
            this.theInvoiceSearch.Delete();
            break;
        }
      }
      this.Response.SafeRedirect(this.ReferringPage);
    }

    private void Page_Load(object sender, EventArgs e)
    {
      this.theInvoiceSearch = new InvoiceObject(this.get_connectionString());
      if (this.GetParameter("ExecuteMethod") != null)
        this.ExecuteMethod(this.GetParameter("ExecuteMethod"));
      this.theInvoiceSearch.SearchBy = this.GetParameter("SearchBy");
      this.theInvoiceSearch.SearchString = this.GetParameter("SearchString");
      this.theInvoiceSearch.SortBy = this.GetParameter("SortBy", this.GetParameter("SearchString"));
      if (this.theInvoiceSearch.SearchBy != null)
        this.SearchBy.SelectedValue = this.Server.HtmlEncode(this.theInvoiceSearch.SearchBy);
      this.SearchString.Text = this.theInvoiceSearch.SearchString;
      this.xmlInvoiceSearch.TransformArgumentList = this.get_XsltArgumentSearch();
      if (this.IsPostBack || this.theInvoiceSearch.SearchString != null)
        this.xmlInvoiceSearch.DocumentContent = this.theInvoiceSearch.Search().GetXml();
      this.xmlInvoiceSearch.TransformSource = "InvoiceList.xslt";
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent()
    {
      this.Load += new EventHandler(this.Page_Load);
    }
  }
}
