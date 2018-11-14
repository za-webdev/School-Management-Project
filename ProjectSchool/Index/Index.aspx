<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ProjectSchool.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <style type="text/css">
        .newStyle1 {
            color: #BD2130;
        }
        #ErrorLbl{
            color:red;
        }
    </style>
</head>
<body style="background-color: #FFFFFF">
    <form id="form1" runat="server" >
        <div class="jumbotron jumbotron-fluid">
  <div class="container">
    <h1 class="display-4">School Management</h1>
  </div>
</div>
        <div class="mx-auto" style="width: 200px;">
        <h2>Who are you?</h2>
            <asp:DropDownList class="dropdown" ID="DropDownList" runat="server" AutoPostBack="True">
            <asp:ListItem Selected="True">Select</asp:ListItem>
            <asp:ListItem>Admin</asp:ListItem>
            <asp:ListItem>Student</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="StudentCodeBox" runat="server" Visible="False" class="form-control"></asp:TextBox>
        <asp:Button ID="SubmitBtn" class="btn btn-primary" runat="server" OnClick="SubmitBtn_Click" Text="Submit" Visible="False" />
        <p>
            <asp:Label ID="StudentCode" runat="server" Text="Enter your student code" Visible="False"></asp:Label>
        </p>
            <asp:Label  ID="ErrorLbl" runat="server" Visible="False"></asp:Label>
        </div>
       
        
       
        
       
        
       
    </form>
</body>
</html>
