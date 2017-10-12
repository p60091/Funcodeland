// Decompiled with JetBrains decompiler
// Type: abo.Accounting.InvoiceSearch
// Assembly: abo.Accounting, Version=1.0.6383.18206, Culture=neutral, PublicKeyToken=null
// MVID: B4900280-8D49-4329-ACD3-E4C3020A0B4E
// Assembly location: C:\Users\aspentest\Downloads\b4_aspen_dll\abo.Accounting.dll

using abo.Security;
using abo.Web;
using System;
using System.Data.SqlTypes;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace abo.Accounting
{
  public class InvoiceSearch : Page
  {
    protected DropDownList SearchBy;
    protected Button btnSearch;
    protected Xml xmlInvoiceSearch;
    protected SiteStyle SiteStyle;
    protected Javascript Javascript;
    protected MenuBar MenuBar;
    protected NavBar NavBar;
    protected TabBar TaBar;
    protected TextBox SearchString;
    protected TextBox DisplaySize;
    protected TextBox RecordStart;
    protected TextBox SortBy;
    protected TabBar TabBar;
    protected Footer Footer;
    protected InvoiceObject theInvoiceSearch;

    private void ExecuteMethod(string theMethod)
    {
      if (((Page) this).Server.HtmlEncode(((Page) this).Request.Form["InvoiceID"]) == null)
        return;
      for (int index = 0; index < ((Page) this).Request.Form.GetValues("InvoiceID").Length; ++index)
      {
        this.theInvoiceSearch.InvoiceID = new SqlInt32(Convert.ToInt32(((Page) this).Request.Form.GetValues("InvoiceID")[index]));
        switch (theMethod)
        {
          case "Delete":
            this.theInvoiceSearch.Delete();
            break;
        }
      }
      ResponseExtended.SafeRedirect(((Page) this).Response, this.get_ReferringPage());
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
        ((ListControl) this.SearchBy).SelectedValue = ((Page) this).Server.HtmlEncode(this.theInvoiceSearch.SearchBy);
      ((TextBox) this.SearchString).Text = this.theInvoiceSearch.SearchString;
      ((Xml) this.xmlInvoiceSearch).TransformArgumentList = this.get_XsltArgumentSearch();
      if (((Page) this).IsPostBack || this.theInvoiceSearch.SearchString != null)
        ((Xml) this.xmlInvoiceSearch).DocumentContent = this.theInvoiceSearch.Search().GetXml();
      ((Xml) this.xmlInvoiceSearch).TransformSource = "InvoiceList.xslt";
    }

    protected virtual void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      // ISSUE: explicit non-virtual call
      __nonvirtual (((Page) this).OnInit(e));
    }

    private void InitializeComponent()
    {
      ((Control) this).Load += new EventHandler(this.Page_Load);
    }

    public InvoiceSearch()
    {
      base.\u002Ector();
    }
  }
}
