using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookStore : System.Web.UI.Page
{
    public static int MaxNumOfCheckOut { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {


        List<Book> checkedoutList  = null;
        if (Session["books"] == null)
        {
            checkedoutList = new List<Book>();
            Session["books"] = checkedoutList;
        }
        else
        { checkedoutList = (List<Book>)Session["books"]; }


        if (!IsPostBack)
        {
            //get all available books.
            List<Book> availableBooks = DataAccessHelper.GetAvailableBooks();

            //Add your code here
            lblMaxCheckout.Text = MaxNumOfCheckOut.ToString();
            foreach (Book book in availableBooks)
            {
                drpBookSelection.Items.Add(new ListItem(book.Title, book.Id));
            }
        }
    }
    protected void drpBookSelection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpBookSelection.SelectedValue != "-1")
        {
            //Add your code here
            List<Book> availableBooks = DataAccessHelper.GetAvailableBooks();
            Book selectedBook = availableBooks[drpBookSelection.SelectedIndex - 1];
            lblDescription.Visible = true;
            lblDescription.Text = selectedBook.Description;
        }
        else
        {
            //Add your code here
            lblDescription.Visible = false;
        }
    }

    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        //Add your code here
        List<Book> availableBooks = DataAccessHelper.GetAvailableBooks();
        Book selectedBook = availableBooks[drpBookSelection.SelectedIndex - 1];
        List<Book> checkedOut = new List<Book>();
        List<Book> checkedoutList = (List<Book>)Session["books"];
        checkedOut.Add(selectedBook);
        checkedoutList.AddRange(checkedOut);


        int maxBooks = 0;
        
            //g.The dropdown list displays its initial text “Select a Book …” to allow the user to select and checkout more books.
            if (drpBookSelection.Items.Count > 1)
            {
                for (int i = drpBookSelection.Items.Count - 1; i > 0; i--)
                {
                    drpBookSelection.Items.RemoveAt(i);
                }
            }
            //drop down with removed checkedout


            foreach (Book book in checkedOut)
            {
                DataAccessHelper.MakeBookUnavailable(book.Id);
                lblDescription.Text = "";
                maxBooks = MaxNumOfCheckOut - checkedoutList.Count;
                lblConfirmation.Text = "You just checked out: " + book.Title + "<br />" + "You can check out " + maxBooks + " more book(s).";
            }

            foreach (Book book in availableBooks)
            {
                drpBookSelection.Items.Add(new ListItem(book.Title, book.Id));
            }

        

        
        
            //h. If the user has reached the maximum number of books allowed
            if (maxBooks <= 0)
            {
                lblConfirmation.Text = "You have reached the maximum number of books allowed.";
            }
        
    }
}