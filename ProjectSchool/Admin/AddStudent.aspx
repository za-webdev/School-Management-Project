<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="ProjectSchool.Admin.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" <%--integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous"--%>/>
    <style>
        #ErrorLbl{
            color:red;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
              <div class="jumbotron jumbotron-fluid">
  <div class="container">
    <h1 class="display-4">Add A Sttudent</h1>
  </div>
</div>
    <div style="height: 243px; width: 277px; margin-left: 478px; margin-top: 139px">
  
        <asp:Label ID="FisrtName" runat="server" Text="First Name:"></asp:Label>
        &nbsp;<span >*</span><asp:TextBox CssClass="form-control" ID="FName" runat="server"></asp:TextBox>
       
        <asp:Label ID="LastName" runat="server" Text="Last Name:"></asp:Label>
        &nbsp;<span>*</span><asp:TextBox CssClass="form-control" ID="Lname" runat="server"></asp:TextBox>
        <br />
        
        <asp:Label ID="StudentCode" runat="server" Text="Student Code:"></asp:Label>
        &nbsp;<span>*</span>
        <asp:TextBox CssClass="form-control" ID="SCode" runat="server"></asp:TextBox>
        <br />
        
        <asp:Button CssClass="btn btn-primary" ID="SubmitBtn" runat="server" OnClick="SubmitBtn_Click" Text="Submit" />


        <asp:Label ID="ErrorLbl" runat="server" Visible="False"></asp:Label>
    </div>
              
    </form>
</body>
</html>
