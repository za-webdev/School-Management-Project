<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentPage.aspx.cs" Inherits="ProjectSchool.StudentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css"/>
    
    </head>
<body>
    <form id="form1" runat="server">
   <div class="jumbotron jumbotron-fluid">
            <div class="container">
                <h1 class="display-4">WelCome Student 
                    <a href="../Index/Index.aspx"><img alt="goback" style="margin-left:90%" height="75" width="75" src="../Images/go-back-button.png" /></a></h1>
            </div>
        </div >
        <asp:Label ID="StudentCodeLable" runat="server"></asp:Label>
       <div class="mx-auto" style="width: 300px;">
           <h3>Student Information</h3>
           <asp:GridView ID="myGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="FirstName" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" >
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="GPA" HeaderText="GPA" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
           <br />
           <h3>Add a description about your self:</h3>
           <br />
        <asp:TextBox ID="DescriptionBox" class ="form-control" runat="server"></asp:TextBox>
           <br />
        <asp:Button style="margin-left:60px" ID="SubmitBtn" class="btn btn-primary" runat="server" OnClick="SubmitBtn_Click" Text="Submit" />
           <br />
           <br />
       </div>
        <h3 style="margin-left:330px">Your Schedule:</h3>
         <asp:GridView style="margin-left:330px" ID="courseGrid" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" >
               <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                <asp:BoundField DataField="Attendence" HeaderText="Attendence" />
                <asp:BoundField DataField="Quiz" HeaderText="Quiz" />
                <asp:BoundField DataField="HomeWork" HeaderText="Home Work" />
                <asp:BoundField DataField="Research" HeaderText="Research" />
                <asp:BoundField DataField="LabPractice" HeaderText="Lab Practice" />
                <asp:BoundField DataField="FinalExam" HeaderText="Final Exam" />
                
            </Columns>
               <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
               <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
               <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
               <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
               <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
               <SortedAscendingCellStyle BackColor="#F4F4FD" />
               <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
               <SortedDescendingCellStyle BackColor="#D8D8F0" />
               <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
           <br />
        
    </form>
    </body>
</html>
