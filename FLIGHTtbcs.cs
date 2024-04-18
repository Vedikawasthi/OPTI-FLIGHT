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
using static System.Windows.Forms.AxHost;
using System.Security.Cryptography;
//using System.Data.SqlClient;
namespace OPTI_FLIGHT
{
    public partial class FLIGHTtbcs : Form
    {
        public FLIGHTtbcs()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vedika\OneDrive\Documents\AirlineDb.mdf;Integrated Security=True;Connect Timeout=30");


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            FcodeTb.Text = "";
            SeatNum.Text = "";
        }

      

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (FcodeTb.Text == "" || Fsrc.Text == "" || FDest.Text == "" || FDate.Text == "" || SeatNum.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into FlightTbl values('" + FcodeTb.Text + "','" + Fsrc.SelectedItem.ToString() + "','" + FDest.SelectedItem.ToString() + "','" + SeatNum.Text + "','"+FDate.Value.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger Data recorded successfully");
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void FLIGHTtbcs_Load(object sender, EventArgs e)
        {

        }

        private void FLIGHTtbcs_Load_1(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            /*  ViewFlights viewflt = new ViewFlight();
              viewflt.Show();
              this.hide();*/

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FcodeTb.Text = "";
            SeatNum.Text = "";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            viewflight viewflt = new viewflight();  
            viewflt.Show();
            this.Hide();
        }
    }
}
