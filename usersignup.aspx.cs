using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace LibraryProject
{
    public partial class usersignup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CheckMemberExists())
            {
                Response.Write("<script>alert('Member Already Exists with this Member ID, please try a different ID.');</script>");
            }
            else
            {
                SignUpNewMember();
                Response.Redirect("homepage.aspx");
            }
        }

        private bool CheckMemberExists()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM member_master_tbl WHERE member_id = @member_id", con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@member_id", TextBox8.Text.Trim());
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Response.Write("<script>alert('Error occurred while checking member existence.');</script>");
                return false;
            }
        }

        private void SignUpNewMember()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl (full_name, dob, contact_no, email, state, city, pincode, full_address, member_id, password, account_status) VALUES (@full_name, @dob, @contact_no, @email, @state, @city, @pincode, @full_address, @member_id, @password, @account_status)", con))
                    {
                        String password = TextBox9.Text.Trim();


                        // 
                        con.Open();
                        cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                        cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                        cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                        cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                        cmd.Parameters.AddWithValue("@member_id", TextBox8.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
                        cmd.Parameters.AddWithValue("@account_status", "pending");
                        cmd.ExecuteNonQuery();
                        Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login.');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error occurred while signing up.');</script>");
            }
        }
    }
}
