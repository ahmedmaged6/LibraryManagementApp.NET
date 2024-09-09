<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="LibraryProject.usersignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
      <div class="row">
         <div class="col-md-8 mx-auto">
            
            <div class="card">
               <div class="card-body">
                  
                  <div class="row">
                     <div class="col">
                        <center><img width=100px src="imgs/generaluser.png"/></center>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col">
                        <center><h4>Member Sign Up</h4></center>
                     </div>
                  </div>
                  
                  
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col-md-6">
                        <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full Name"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Date of Birth</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>

                  </div>

                  <div class="row">  

                     <div class="col-md-6">
                        <label>Contact Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Contact Number"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Email</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                        </div>
                     </div>

                  </div>


                  <div class="row">

                     <div class="col-md-4">
                        <label>State</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                              <asp:ListItem Text="Select" Value="select" />
                              <asp:ListItem Text="Egypt" Value="Egypt" />
                              <asp:ListItem Text="Saudia Arabia" Value="Saudia Arabia" />
                              <asp:ListItem Text="Canada" Value="Canada" />
                              <asp:ListItem Text="Dubai" Value="Dubai" />
                           </asp:DropDownList>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>City</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="City" ></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Zip Code</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Zip Code" ></asp:TextBox>
                        </div>
                     </div>

                  </div>


                  <div class="row">
                     <div class="col">
                        <label>Full Address</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Full Address" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                  <%--UserId and Password textboxs--%>
                  <div class="row">
                     <div class="col-md-6">
                        <label>User Id</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox8" runat="server" placeholder="User Id"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Passsword</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="Passsword" TextMode="Password"></asp:TextBox>
                        </div>
                     </div>
                  </div>


                  <%--SignUp button--%>
                  <div class="row">
                     <div class="col">
                        <div class="form-group">
                           <br>
                           <center><asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click" /></center>                          
                           <br>
                        </div>
                     </div>
                  </div>




                     </div>
                  </div>
               </div>
            </div>

            <center><a href="homepage.aspx">Back to Home</a><br><br></center>
         </div>


</asp:Content>
