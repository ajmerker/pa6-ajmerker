using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pa6_ajmerker
{
    public partial class FrmMain : Form //Main form 
    {
        string cwid;
        List<Book> myBooks; 

        //methods for getting and displaying the book list 
        public FrmMain(string tempCwid)
        {
            this.cwid = tempCwid; 
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage; 
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            loadList(); 
        }

        private void loadList()
        {
            myBooks = BookFile.GetAllBooks(cwid);
            lstBooks.DataSource = myBooks;
        }

        private void lstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;
            txtTitleData.Text = myBook.title; 
            txtAuhorData.Text = myBook.author;
            txtGenreData.Text = myBook.genre;
            txtIsbnData.Text = myBook.isbn; 
            txtCopiesData.Text = myBook.copies.ToString();
            txtLengthData.Text = myBook.length.ToString();

            try
            {
                pbCover.Load(myBook.cover); 
            }
            catch
            {

            }
        }

        //close button
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Renting
        private void btnRent_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            myBook.copies--;
            BookFile.SaveBook(myBook, cwid, "edit");
            loadList(); 
        }

        //Returning 
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            myBook.copies++;
            BookFile.SaveBook(myBook, cwid, "edit");
            loadList();
        }

        //Deleting 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this book?", "Delete", MessageBoxButtons.YesNo);
            
            if (dialogResult == DialogResult.Yes)
            {
                BookFile.DeleteBook(myBook, cwid);
                loadList(); 
            }
        }

        //Editing
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;
            frmEdit e1 = new frmEdit(myBook, "edit", cwid);
            if (e1.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                loadList(); 
            }
        }

        //New Book 
        private void btnNew_Click(object sender, EventArgs e)
        {
            Book myBook = new Book();
            frmEdit e1 = new frmEdit(myBook, "new", cwid);
            if (e1.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                loadList();
            }
        }

        //Goes back to log in 
        private void btnLog_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCWID f1 = new frmCWID();
            f1.ShowDialog(); 
        }
    }
}
