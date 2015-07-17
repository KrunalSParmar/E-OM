using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//ER References
using OnlinExpenseManager.Models;
using System.Web.ModelBinding;


//identity package references
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace OnlinExpenseManager
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Default UserStore constructor uses the default connection string named: DefaultConnection
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            var email = new IdentityUser() { UserName = txtEmail.Text };
            email.PhoneNumber = txtPhone.Text;
            email.Email = txtEmail.Text;

            IdentityResult result = manager.Create(email, txtPassword.Text);

            if (result.Succeeded)
            {
                lblStatus.Text = string.Format("User {0} was created successfully!", email.UserName);
                lblStatus.CssClass = "label label-success";
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = manager.CreateIdentity(email, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);

                using (ExpMgmtEntities db = new ExpMgmtEntities())
                    {
                        User u = new User();
                        Account a = new Account();
                        u.FName = txtFName.Text;
                        u.LName = txtLName.Text;
                        u.Email = txtEmail.Text;
                        u.Phone = txtPhone.Text;
                        a.CreditBalance = Convert.ToDouble(txtCredit.Text);
                        a.DebitBalance = Convert.ToDouble(txtDebit.Text);
                        
                        //Add user and account to database
                        db.Users.Add(u);
                        db.Accounts.Add(a);

                        //run the update or insert
                        db.SaveChanges();
                    }
                 //redirect to the updated students page
                 Response.Redirect("home.aspx");
            }
            else
            {
                lblStatus.Text = result.Errors.FirstOrDefault();
                lblStatus.CssClass = "label label-danger";
            }
        }
    }
}