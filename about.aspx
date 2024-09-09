<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="LibraryProject.about" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f5f5f5;
            color: #333;
        }
        header {
            background-color: #762b00;
            color: #fff;
            padding: 20px 0;
            text-align: center;
        }
        .container {
            max-width: 800px;
            margin: 20px auto;
            padding: 0 20px;
        }
        h1, h2 {
            text-align: center;
        }
        p {
            line-height: 1.6;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <header>
        <h1>About Our E-Library System</h1>
    </header>
    <div class="container">
        <h2>Our Mission</h2>
        <p>At our E-Library system, our mission is to provide access to a vast collection of digital resources to enhance learning, research, and personal development.</p>

        <h2>What We Offer</h2>
        <p>We offer a diverse range of digital content including eBooks, audiobooks, academic journals, research papers, and more. Our platform is designed to cater to the needs of students, educators, researchers, and enthusiasts alike.</p>

        <h2>Features</h2>
        <ul>
            <li>Extensive collection of digital resources</li>
            <li>User-friendly interface for easy navigation</li>
            <li>Advanced search functionality for efficient discovery</li>
            <li>Personalized recommendations based on user preferences</li>
            <li>Access to resources anytime, anywhere</li>
            <li>Flexible borrowing and lending options</li>
        </ul>

        <h2>Contact Us</h2>
        <p>If you have any questions, suggestions, or feedback, feel free to reach out to us at <a href="mailto:info@elibrary.com">info@elibrary.com</a>.</p>
    </div>
</asp:Content>
