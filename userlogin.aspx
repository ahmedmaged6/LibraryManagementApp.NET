﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="LibraryProject.userlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="container">

      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">

                  <div class="row">
                     <div class="col">
                        <center><img width=150px src="imgs/generaluser.png" /></center>
                     </div>

                  </div>

                  <div class="row">
                     <div class="col">
                        <center><h3>Member Login</h3></center>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  
                  <div class="row">
                     <div class="col">

                         Member ID
                        <%--email textbox--%>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Member ID"></asp:TextBox>
                        </div>
                        
                         
                         <label>Password</label>
                        <%--password textbox--%>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                            <br>
                        </div>

                        <%--Login Button--%>
                        <div class="form-group">
                           <center><asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" /></center>
                            <br>
                        </div>

                        <%--Sign Up Button--%>
                        <div class="form-group">
                          <center><a href="usersignup.aspx"><input class="btn btn-info btn-block btn-lg" id="Button2" type="button" value="Sign Up" /></a></center>
                        </div>

                     </div>
                  </div>

               </div>

            </div>
            <center>
                <a href="homepage.aspx">Back to Home</a>
                <br><br><br><br>
            </center>
         </div>
          <br><br>
      </div>
   </div>
</asp:Content>

