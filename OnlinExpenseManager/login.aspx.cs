using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//ER Referenses
using OnlinExpenseManager.Models;
using System.Web.ModelBinding;

//auth references
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace OnlinExpenseManager
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = userManager.Find(txtUsername.Text, txtPassword.Text);
            
            if (user != null)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);

                string em = txtUsername.Text;
                //store UserId in session variable from Users table using Email
                using (ExpMgmtEntities db = new ExpMgmtEntities())
                {
                     User u1 =(from objU in db.Users
                             where objU.Email == txtUsername.Text
                             select objU).FirstOrDefault();

                     Int32 uid = u1.UserID;
                     string name = " "+u1.FName +" "+ u1.LName;

                     Session["UserName"] = uid;
                     Session["Name"] = name;
                }
   
                Response.Redirect("/user/expense.aspx");
            }
            else
            {
                lblStatus.Text = "Invalid username or password.";
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
                Server.Transfer("errors.aspx");
            }
            // Clear the error from the server.
            Server.ClearError();
        }
    }


}