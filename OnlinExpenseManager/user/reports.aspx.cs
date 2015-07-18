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
            
            

                getExps(null,null);
            
        }

     
        private void getExps(string startdate,string enddate)
        {
            
            Int32 Uid = (Int32)(Session["UserName"]);
            using(ExpMgmtEntities db = new ExpMgmtEntities())
            {
                Expense ex = new Expense();
                
                if(startdate != null && enddate != null){
                   DateTime sd= Convert.ToDateTime(startdate);
                   DateTime ed = Convert.ToDateTime(enddate);
                 var Exp = from e in db.Expenses
                          where e.UserID == Uid && e.Date == sd && e.Date == ed                        
                          select new {e.ExpID,e.ExpType,e.ExpAmount,e.Date};
                 if (Exp != null)
                 {
                     GridExpense.DataSource = Exp.ToList();
                     GridExpense.DataBind();
                 }
                 else
                 {
                     Response.Redirect("/user/expense.aspx");
                 }
                }else{
                    var Exp = from e in db.Expenses
                              where e.UserID == Uid               
                           select new { e.ExpID, e.ExpType, e.ExpAmount, e.Date };
                    if (Exp != null)
                    {
                        GridExpense.DataSource = Exp.ToList();
                        GridExpense.DataBind();
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
            string startDate = txtfromdate.Text;
            string endDate = txtenddate.Text;

            getExps(startDate,endDate);
        }
    }
}