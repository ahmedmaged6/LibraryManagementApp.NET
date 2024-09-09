using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Configuration;
using System.Web.UI;

namespace LibraryProject
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        private readonly string _connectionString = WebConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }



        //Add Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CheckIfBookExists())
            {
                Response.Write("<script>alert('Book Already Exists, try some other Book ID');</script>");
            }
            else
            {
                AddNewBook();
            }
        }

        private bool CheckIfBookExists()
        {
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    var query = "SELECT COUNT(*) FROM book_master_tbl WHERE book_id = @bookId OR book_name = @bookName";
                    using (var cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@bookId", TextBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@bookName", TextBox2.Text.Trim());
                        var count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}');</script>");
                return false;
            }
        }

        private void AddNewBook()
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    var fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    var filePath = "~/book_inventory/" + fileName;
                    FileUpload1.SaveAs(Server.MapPath(filePath));

                    using (var con = new SqlConnection(_connectionString))
                    {
                        con.Open();
                        var query = @"INSERT INTO book_master_tbl(book_id, book_name, genre, author_name, publisher_name, publish_date, language, edition, book_cost, no_of_pages, book_description, actual_stock, current_stock, book_img_link) 
                                    VALUES(@bookId, @bookName, @genre, @authorName, @publisherName, @publishDate, @language, @edition, @bookCost, @noOfPages, @bookDescription, @actualStock, @currentStock, @bookImgLink)";
                        using (var cmd = new SqlCommand(query, con))
                        {

                            cmd.Parameters.AddWithValue("@bookId", TextBox1.Text.Trim());
                            cmd.Parameters.AddWithValue("@bookName", TextBox2.Text.Trim());
                            cmd.Parameters.AddWithValue("@genre", DropDownList2.SelectedItem.Value);
                            cmd.Parameters.AddWithValue("@publisherName", TextBox8.Text.Trim());
                            cmd.Parameters.AddWithValue("@authorName", TextBox12.Text.Trim());
                            cmd.Parameters.AddWithValue("@publishDate", TextBox3.Text.Trim());
                            cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                            cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                            cmd.Parameters.AddWithValue("@bookCost", TextBox10.Text.Trim());
                            cmd.Parameters.AddWithValue("@noOfPages", TextBox11.Text.Trim());
                            cmd.Parameters.AddWithValue("@bookDescription", TextBox6.Text.Trim());
                            cmd.Parameters.AddWithValue("@actualStock", TextBox4.Text.Trim());
                            cmd.Parameters.AddWithValue("@currentStock", TextBox4.Text.Trim());
                            cmd.Parameters.AddWithValue("@bookImgLink", filePath);
                            cmd.ExecuteNonQuery();

                        }
                    }
                    Response.Write("<script>alert('Book added successfully.');</script>");
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Please select a file to upload.');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Book cannot be added due to an error.');</script>");
            }
        }


        //Go Button
        protected void Button2_Click(object sender, EventArgs e)
        {
            getBookByID();
        }

        void getBookByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(_connectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl WHERE book_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["book_name"].ToString();
                    TextBox3.Text = dt.Rows[0]["publish_date"].ToString();
                    TextBox9.Text = dt.Rows[0]["edition"].ToString();
                    TextBox10.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    TextBox11.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    TextBox4.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox5.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["book_description"].ToString();
                    TextBox7.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));

                    DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    TextBox8.Text = dt.Rows[0]["publisher_name"].ToString().Trim();
                    TextBox2.Text = dt.Rows[0]["author_name"].ToString().Trim();

                    DropDownList2.SelectedValue = dt.Rows[0]["genre"].ToString().Trim();

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }

            }
            catch (Exception ex)
            {

            }
        }



        //Delete Button
        protected void Button2_Click1(object sender, EventArgs e)
        {
            deleteBookByID();
        }
        void deleteBookByID()
        {
            if (CheckIfBookExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(_connectionString);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from book_master_tbl WHERE book_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book Deleted Successfully');</script>");

                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }
        }





    }
}
