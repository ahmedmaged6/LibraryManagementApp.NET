<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="terms.aspx.cs" Inherits="LibraryProject.terms" %>
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
        <h1>Terms of Service</h1>
    </header>
    <div class="container">
        <p>Welcome to the E-Library! Please read these terms and conditions carefully before using our service.</p>

        <h2>1. Acceptance of Terms</h2>
        <p>By accessing or using the E-Library service, you agree to be bound by these terms of service, all applicable laws, and regulations, and agree that you are responsible for compliance with any applicable local laws. If you do not agree with any of these terms, you are prohibited from using or accessing this site.</p>

        <h2>2. Use License</h2>
        <p>Permission is granted to temporarily download one copy of the materials (information or software) on E-Library's website for personal, non-commercial transitory viewing only. This is the grant of a license, not a transfer of title, and under this license, you may not:</p>
        <ul>
            <li>Modify or copy the materials;</li>
            <li>Use the materials for any commercial purpose, or for any public display (commercial or non-commercial);</li>
            <li>Attempt to decompile or reverse engineer any software contained on E-Library's website;</li>
            <li>Remove any copyright or other proprietary notations from the materials; or</li>
            <li>Transfer the materials to another person or "mirror" the materials on any other server.</li>
        </ul>

        <h2>3. Disclaimer</h2>
        <p>The materials on E-Library's website are provided on an 'as is' basis. E-Library makes no warranties, expressed or implied, and hereby disclaims and negates all other warranties including, without limitation, implied warranties or conditions of merchantability, fitness for a particular purpose, or non-infringement of intellectual property or other violation of rights.</p>

        <h2>4. Limitations</h2>
        <p>In no event shall E-Library or its suppliers be liable for any damages (including, without limitation, damages for loss of data or profit, or due to business interruption) arising out of the use or inability to use the materials on E-Library's website, even if E-Library or a E-Library authorized representative has been notified orally or in writing of the possibility of such damage.</p>

        <h2>5. Governing Law</h2>
        <p>These terms and conditions are governed by and construed in accordance with the laws of [Your Country/State] and you irrevocably submit to the exclusive jurisdiction of the courts in that State or location.</p>

        <h2>6. Changes to Terms</h2>
        <p>E-Library may revise these terms of service for its website at any time without notice. By using this website you are agreeing to be bound by the then current version of these terms of service.</p>

        <h2>Contact Us</h2>
        <p>If you have any questions about these terms, please contact us at <a href="mailto:info@elibrary.com">info@elibrary.com</a>.</p>
    </div>
</asp:Content>
