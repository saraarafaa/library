using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LibrarySystem
{
    public partial class Form1 : Form
    {
        // For border movment 
        int move;
        int movx;
        int movy;

        //sql connection
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e) => Environment.Exit(1);

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            movx = e.X;
            movy = e.Y;

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movx, MousePosition.Y - movy);
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            con.ConnectionString =(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Source\Repos\library\LibrarySystem\DBOOK1.mdf;Integrated Security=True");
            var sql = "SELECT id as BOOK_ID,TITLE,AUTHOR,PRICE,CATEGORY FROM BOOKS";
            da = new SqlDataAdapter(sql, con);
            int v = da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
