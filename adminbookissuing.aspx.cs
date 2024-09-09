using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace LibraryProject
{
    public partial class adminbookissuing : System.Web.UI.Page
    {
        private readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (CheckIfBookAndMemberExist())
            {
                if (CheckIfIssueEntryExist())
                {
                    Response.Write("<script>alert('This Member already has this book');</script>");
                }
                else
                {
                    IssueBook();
                }
            }
            else
            {
                Response.Write("<script>alert('Wrong Book ID or Member ID');</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (CheckIfBookAndMemberExist())
            {
                if (CheckIfIssueEntryExist())
                {
                    ReturnBook();
                }
                else
                {
                    Response.Write("<script>alert('This Entry does not exist');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Wrong Book ID or Member ID');</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GetNames();
        }

        private void ReturnBook()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM book_issue_tbl WHERE book_id=@book_id AND member_id=@member_id", con);
                    cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock = current_stock + 1 WHERE book_id=@book_id", con);
                        cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                        cmd.ExecuteNonQuery();
                        Response.Write("<script>alert('Book Returned Successfully');</script>");
                        GridView1.DataBind();
                    }
                    else
                    {
                        Response.Write("<script>alert('Error - Invalid details');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void IssueBook()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl(member_id, member_name, book_id, book_name, issue_date, due_date) VALUES(@member_id, @member_name, @book_id, @book_name, @issue_date, @due_date)", con);
                    cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@member_name", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock = current_stock - 1 WHERE book_id=@book_id", con);
                    cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Book Issued Successfully');</script>");
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private bool CheckIfBookAndMemberExist()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM book_master_tbl WHERE book_id=@book_id AND current_stock > 0; SELECT COUNT(*) FROM member_master_tbl WHERE member_id=@member_id", con);
                    cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
                    int bookCount = (int)cmd.ExecuteScalar();

                    if (bookCount > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

            return false;
        }

        private bool CheckIfIssueEntryExist()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM book_issue_tbl WHERE member_id=@member_id AND book_id=@book_id", con);
                    cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                    int issueCount = (int)cmd.ExecuteScalar();

                    if (issueCount > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

            return false;
        }

        private void GetNames()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT book_name FROM book_master_tbl WHERE book_id=@book_id; SELECT full_name FROM member_master_tbl WHERE member_id=@member_id", con);
                    cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        TextBox4.Text = reader["book_name"].ToString();
                        reader.NextResult();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            TextBox3.Text = reader["full_name"].ToString();
                        }
                        else
                        {
                            Response.Write("<script>alert('Wrong User ID');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Wrong Book ID');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt;
                    if (DateTime.TryParse(e.Row.Cells[5].Text, out dt))
                    {
                        if (DateTime.Today > dt)
                        {
                            e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


    }
}
