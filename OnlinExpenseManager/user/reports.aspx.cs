using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Add reference for PDF export
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

//ER Refrences
using OnlinExpenseManager.Models;
using System.Web.ModelBinding;

namespace OnlinExpenseManager
{
    public partial class reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = (string)(Session["Name"]);
            if (!IsPostBack)
            {
                this.getExps(null, null, ddlAccountType.SelectedValue);
            }
        }


        private void getExps(string startdate, string enddate, string acctype)
        {
            try
            {

                Int32 Uid = (Int32)(Session["UserName"]);
                using (ExpMgmtEntities db = new ExpMgmtEntities())
                {
                    Expense ex = new Expense();

                    if ((startdate != "") && (enddate != "") && (acctype != ""))
                    {
                        DateTime sd = Convert.ToDateTime(startdate);
                        DateTime ed = Convert.ToDateTime(enddate);
                        string at = ddlAccountType.SelectedValue;
                        var Exp = from e in db.Expenses
                                  where e.UserID == Uid && e.Date >= sd && e.Date <= ed && e.AccountType == at
                                  select new { e.ExpID, e.ExpType, e.Date, e.ExpAmount, e.AccountType };
                        if (Exp != null)
                        {
                            grdExpense.DataSource = Exp.ToList();
                            grdExpense.DataBind();
                        }
                        else
                        {
                            Response.Redirect("/user/expense.aspx");
                        }
                    }
                    else
                    {
                        var Exp = from e in db.Expenses
                                  where e.UserID == Uid
                                  select new { e.ExpID, e.ExpType, e.Date, e.ExpAmount, e.AccountType };
                        if (Exp != null)
                        {
                            grdExpense.DataSource = Exp.ToList();
                            grdExpense.DataBind();
                        }
                        else
                        {
                            Response.Redirect("/user/expense.aspx");
                        }
                    }
                }
            }
            catch
            {
                Server.Transfer("errors.aspx");
            }
        }


        protected void btnGo_Click(object sender, EventArgs e)
        {
            string startDate = txtStartDate.Text;
            string endDate = txtEndDate.Text;
            string acctype;
            if (ddlAccountType.SelectedValue == "All Expense")
            {
                acctype = "";
            }
            else
            {
                acctype = ddlAccountType.SelectedValue;
            }
            lblReportType.Text = "Date Report";

            getExps(startDate, endDate, acctype);
        }
        protected void grdExpense_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set the new page #
            grdExpense.PageIndex = e.NewPageIndex;
            string startDate = txtStartDate.Text;
            string endDate = txtEndDate.Text;
            string acctype;
            if (ddlAccountType.SelectedValue == "All Expense")
            {
                acctype = "";
            }
            else
            {
                acctype = ddlAccountType.SelectedValue;
            }
            lblReportType.Text = "Date Report";

            getExps(startDate, endDate, acctype);
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the page size
            grdExpense.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            string startDate = txtStartDate.Text;
            string endDate = txtEndDate.Text;
            string acctype;
            if (ddlAccountType.SelectedValue == "All Expense")
            {
                acctype = "";
            }
            else
            {
                acctype = ddlAccountType.SelectedValue;
            }
            lblReportType.Text = "Date Report";

            getExps(startDate, endDate, acctype);
        }

        protected void ddlAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ExportToPDF(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
            "attachment;filename=ExpenseAccountExport.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-word ";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grdExpense.AllowPaging = false;
            grdExpense.DataBind();
            grdExpense.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        private void Page_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();

            // Handle specific exception.
            if (exc is HttpUnhandledException)
            {
                ErrorMsgTextBox.Visible = true;
                ErrorMsgTextBox.Text = "An error occurred on this page. Please verify your " +
                "information to resolve the issue.";
            }
            // Clear the error from the server.
            Server.ClearError();
        }
    }
}