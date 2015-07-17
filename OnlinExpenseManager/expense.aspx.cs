using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlinExpenseManager
{
    public partial class expense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            welcomUser.Text = "Welcome" + Session["Email"];
        }

        protected void btnExpense_Click(object sender, EventArgs e)
        {
            
        }
    }
}