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
    public partial class accounts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Retrive Session variable to get UserID
            Int32 UserName = (Int32)(Session["UserName"]);
            lblWelcome.Text = (string)(Session["Name"]);

            using (ExpMgmtEntities db = new ExpMgmtEntities())
            {
                Account ac = new Account();
                User us = new User();

                us = (from objU in db.Users
                      where objU.UserID == UserName
                      select objU).FirstOrDefault();

                ac = (from objA in db.Accounts
                      where objA.UserID == us.UserID
                      select objA).FirstOrDefault();

                //show credit and debit balances
                lblCreditBalance.Text = lblCreditBalance.Text + Convert.ToString(ac.CreditBalance);
                lblDebitBalance.Text = lblDebitBalance.Text + Convert.ToString(ac.DebitBalance);
            }
        }

        protected void btnExpense_Click(object sender, EventArgs e)
        {
            using (ExpMgmtEntities db = new ExpMgmtEntities())
            {
                //Retrive Session variable to get UserID
                Int32 UserName = (Int32)(Session["UserName"]);

                //use the Expense model to save the new record
                Account ac = new Account();
                User us = new User();

                us = (from objU in db.Users
                      where objU.UserID == UserName
                      select objU).FirstOrDefault();

                //Reduce expense amount from equivalent User account
                if (ddlAccountType.SelectedValue == "Credit")
                {
                    ac = (from objA in db.Accounts
                          where objA.UserID == us.UserID
                          select objA).FirstOrDefault();

                    ac.CreditBalance = ac.CreditBalance + Convert.ToDouble(txtAmount.Text);
                }
                else
                {
                    ac = (from objA in db.Accounts
                          where objA.UserID == us.UserID
                          select objA).FirstOrDefault();

                    ac.DebitBalance = ac.DebitBalance + Convert.ToDouble(txtAmount.Text);
                }
                //run the update or insert
                db.SaveChanges();
                //redirect to the updated students page
                Response.Redirect("/user/accounts.aspx");
            }
        }
    }
}