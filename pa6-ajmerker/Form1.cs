using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms; 

namespace pa6_ajmerker
{
    public partial class frmCWID : Form //CWID FORM 
    {
        public frmCWID()
        {
            InitializeComponent();
        }

        //close button
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        //redirects to main page
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            FrmMain m1 = new FrmMain(txtCWID.Text); 
            if(m1.ShowDialog() == DialogResult.OK)
            {
                m1.ShowDialog(); 
            }
            else
            {
                this.Close(); 
            }
        }

        //logo methods 
        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            int A = rand.Next(0, 255);
            int R = rand.Next(0, 255);
            int G = rand.Next(0, 255);
            int B = rand.Next(0, 255);
            label1.ForeColor = Color.FromArgb(A, R, G, B); Random Rand = new Random();
            label1.ForeColor = Color.FromArgb(A, R, G, B);
            timer1.Start(); 
        }

        private void frmCWID_Load(object sender, EventArgs e)
        {
            timer1.Start(); 
        }
    }
}
