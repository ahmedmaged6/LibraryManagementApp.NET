<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="LibraryProject.homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
   <section>
      <img src="imgs/home-bg.jpg" class="img-fluid"/>
   </section>

   <section>
      <div class="container">

         <div class="row">
            <div class="col-12">
               <center><h2>Our Features</h2><p><b>Our 3 Primary Features -</b></p></center>
            </div>
         </div>

         <div class="row">
            <div class="col-md-4">
               <center>
                   <img width="150px" src="imgs/digital-inventory.png"/>
                    <h4>Digital Book Inventory</h4>
               </center>
            </div>
            <div class="col-md-4">
               <center>
                  <img width="150px" src="imgs/search-online.png"/>
                  <h4>Search Books</h4>
               </center>
            </div>
            <div class="col-md-4">
               <center>
                  <img width="150px" src="imgs/defaulters-list.png"/>
                  <h4>Warning List</h4>
               </center>
            </div>
         </div>
          
          <br><br>
      </div>
   </section>


   <section>
      <img src="imgs/in-homepage-banner.jpg" class="img-fluid"/>
   </section>

   <section>
      <div class="container">

         <div class="row">
            <div class="col-12">
               <center>
                  <h2>Our Process</h2>
                  <p><b>We have a Simple 3 Steps</b></p>
               </center>
            </div>
         </div>
         
          
          <div class="row">

              <div class="col-md-4">
                  <center>
                      <img width="150px" src="imgs/sign-up.png" />
                      <h4>Sign Up</h4>
                  </center>
              </div>


              <div class="col-md-4">
                  <center>
                      <img width="150px" src="imgs/search-online.png" />
                      <h4>Search Books</h4>
                  </center>
              </div>


              <div class="col-md-4">
                  <center>
                      <img width="150px" src="imgs/library.png" />
                      <h4>Visit Us</h4>
                  </center>
              </div>
          </div>
          <br /><br />
      </div>
   </section>

</asp:Content>
