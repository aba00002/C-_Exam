using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewCheckedOutBooks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showCheckedoutBooks();
        }
    }


    protected void btnRemove_Click(object sender, EventArgs e)
    {
        //Add your code here
        List<Book> checkedoutList = (List<Book>)Session["books"];
        
            foreach(ListItem s in lstCheckedOutBooks.Items)
            {
                if(s.Selected == true) 
                {
                //2c
                    Book checked2Delete = checkedoutList[lstCheckedOutBooks.SelectedIndex];
                    checkedoutList.Remove(checked2Delete);
                if (s.Value == checked2Delete.Id)
                {
                    DataAccessHelper.MakeBookAvailable(s.Value);
                }
            }
            
               
            
        }


        showCheckedoutBooks();
    }

    private void showCheckedoutBooks()
    {
        lstCheckedOutBooks.Items.Clear();

        //Add your code here
        List<Book> checkedoutList = (List<Book>)Session["books"];

        if(checkedoutList.Count == 0) { lblNumCheckouts.Text = checkedoutList.Count.ToString(); }

        foreach (Book book in checkedoutList)
        {
            lstCheckedOutBooks.Items.Add(new ListItem(book.Title, book.Id));
            lblNumCheckouts.Text = checkedoutList.Count.ToString();
        }
    }
}