using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//ER Refrences
using OnlinExpenseManager.Models;
using System.Web.ModelBinding;

namespace OnlinExpenseManager
{
    public partial class reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getExps(null, null, ddlAccountType.SelectedValue);
        }


        private void getExps(string startdate, string enddate, string acctype)
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

        protected void ddlAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
    }
}