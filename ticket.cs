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
namespace OPTI_FLIGHT
{
    public partial class ticket : Form
    {
        public ticket()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vedika\OneDrive\Documents\AirlineDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void fillPassenger()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select PassId from PassengerTbl",Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable(); 
            dt.Load(rdr);
            PIdCb.ValueMember = "PassId";
            PIdCb.DataSource = dt;
            Con.Close();
        }
        private void fillFlightCode()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select Fcode from FlightTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Fcode", typeof(string));
            dt.Load(rdr);
            FCode.ValueMember = "Fcode";
            FCode.DataSource = dt;
            Con.Close();
        }
            private void ticket_Load(object sender, EventArgs e)
        {
            fillPassenger();   
            fillFlightCode();   
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        string pname, ppass, pnat;

        private void button1_Click(object sender, EventArgs e)
        {
            if (TId.Text == "" || PNameCb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into TicketTble values(" + TId.Text + ",'" + FCode.SelectedValue.ToString() + "','" + PIdCb.SelectedValue.ToString() + "','" + PNameCb.Text + "','" + PpassTb.Text + "','" +PNatTb.Text+ "','" + PAmtTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ticket Booked!!");
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void fetchPassenger()
        {
            Con.Open();
            String query = "Select * from PassengerTbl where PassId = " + PIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                pname = dr["PassName"].ToString();
                ppass = dr["Passport"].ToString();
                pnat = dr["PassNat"].ToString();
                PNameCb.Text = pname;
                PpassTb.Text = ppass;
                PNatTb.Text = pnat;
            }
            Con.Close();
        }
        private void PIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchPassenger();
        }
    }
}
