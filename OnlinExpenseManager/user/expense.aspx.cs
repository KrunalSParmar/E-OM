using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//ER References
using OnlinExpenseManager.Models;
using System.Web.ModelBinding;

namespace OnlinExpenseManager
{
    public partial class expense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = (string)(Session["Name"]);
        }

        protected void btnExpense_Click(object sender, EventArgs e)
        {
            //Retrive Session variable to get UserID
            Int32 UserName = (Int32)(Session["UserName"]);
            try
            {

                using (ExpMgmtEntities db = new ExpMgmtEntities())
                {
                    //use the Expense model to save the new record
                    Expense ex = new Expense();
                    Account ac = new Account();
                    User us = new User();

                    us = (from objU in db.Users
                          where objU.UserID == UserName
                          select objU).FirstOrDefault();

                    ex.ExpType = ddlExpense.SelectedValue;
                    ex.ExpAmount = Convert.ToDouble(txtAmount.Text);
                    ex.UserID = UserName;
                    ex.Date = Convert.ToDateTime(DateTime.Today);
                    ex.AccountType = ddlAccountType.SelectedValue;

                    //Reduce expense amount from equivalent User account
                    if (ddlAccountType.SelectedValue == "Credit")
                    {
                        ac = (from objA in db.Accounts
                              where objA.UserID == us.UserID
                              select objA).FirstOrDefault();

                        ac.CreditBalance = ac.CreditBalance - Convert.ToDouble(txtAmount.Text);
                    }
                    else
                    {
                        ac = (from objA in db.Accounts
                              where objA.UserID == us.UserID
                              select objA).FirstOrDefault();

                        ac.DebitBalance = ac.DebitBalance - Convert.ToDouble(txtAmount.Text);
                    }
                    //run the update or insert
                    db.Expenses.Add(ex);
                    db.SaveChanges();
                    //redirect to the updated students page
                    Response.Redirect("/user/expense.aspx");
                }
            }
            catch
            {
                Server.Transfer("errors.aspx");
            }
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