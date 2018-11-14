<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSchedule.aspx.cs" Inherits="ProjectSchool.Admin.AddSchedule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css"/>
    
    <style type="text/css">
        .ListBox
        {
            color:darkblue;
            background-color:lightblue;
            font-family:Courier New;
            font-size:large;
            font-style:italic;
            width:30%;
            }
        </style>

</head>
<body>
    <form id="form1" runat="server">
        <h1 style="margin-left:10%">Create Schedule For
            <asp:Label ID="StudentNameLabel" runat="server"></asp:Label>
            <a href="AdminPage.aspx">
            <img alt="home" height="65" width="150" style="margin-left:85%" src="../Images/home_button.png" /></a></h1>
        <div style="margin-left:30%">
        
        <p>
            <asp:ListBox Class="ListBox"  ID="ListBoxSubjects" runat="server" DataSourceID="SqlDataSource1" DataTextField="CourseName" DataValueField="Id" SelectionMode="Multiple"></asp:ListBox>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StudentDataBaseConnection %>" SelectCommand="SELECT [Id], [CourseName] FROM [Subject]"></asp:SqlDataSource>
        </p>
        <asp:Button class="btn btn-primary btn-lg" style="margin-left:5%" ID="AddBtn" runat="server" OnClick="AddBtn_Click" Text="Add Subjects" />
            <br />
            <br />
        </div>
        <br />

        <asp:GridView ID="StudentGrid" runat="server" AutoGenerateColumns="False" OnRowCommand="StudentGrid_RowCommand" DataKeyNames="CourseId,CourseName" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" style="margin-left:25%">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="CourseId" HeaderText="Course Id" Visible="False" />
                <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                <asp:BoundField DataField="Attendence" HeaderText="Attendence" />
                <asp:BoundField DataField="quiz" HeaderText="Quiz" />
                <asp:BoundField DataField="HomeWork" HeaderText="Home Work" />
                <asp:BoundField DataField="Research" HeaderText="Research" />
                <asp:BoundField DataField="LabPractice" HeaderText="Lab Practice" />
                <asp:BoundField DataField="FinalExam" HeaderText="Final Exam" />
                <asp:BoundField DataField="Total" HeaderText="Total" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="score" runat="server" CommandName="score" CommandArgument="score" Text="Score Subject" class="btn btn-secondary" />
                    </ItemTemplate>
                </asp:TemplateField>
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
            <br />
             <asp:Button style="margin-left:30%" class="btn btn-success" ID="GPABtn" runat="server" OnClick="Cal_GPA" Text="Calculate GPA" />
            <br />
            <br />
            <asp:Label style="margin-left:45%; font-size:25px " ID="GPALbl" runat="server" Visible="False" BackColor="White" ForeColor="#000099"></asp:Label>
            <br />
        <asp:Label style="margin-left:30%; font-size:25px" ID="SubjectLbl" runat="server"></asp:Label>
             <br />
             <br />
         <div runat="server" id="scorediv" visible="false" class="mx-auto" style="width: 200px;">
             
             <asp:Label  ID="AttendenceLbl" runat="server" Text="Attendence:"></asp:Label>
             <asp:TextBox CssClass="form-control" ID="Attendence" runat="server" TextMode="Number">0</asp:TextBox>
             
             <asp:Label ID="QuizLbl" runat="server" Text="Quiz:"></asp:Label>
             <asp:TextBox CssClass="form-control" ID="quiz" runat="server">0</asp:TextBox>
             <br />
             
             <asp:Label ID="HWLbl" runat="server" Text="Home Work:"></asp:Label>
             <asp:TextBox CssClass="form-control" ID="HomeWork" runat="server" TextMode="Number">0</asp:TextBox>
             <br />
             
             <asp:Label ID="ResearchLbl" runat="server" Text="Research:"></asp:Label>
             <asp:TextBox CssClass="form-control" ID="Reasearch" runat="server" TextMode="Number">0</asp:TextBox>
             <br />
             
             <asp:Label ID="LabLbl" runat="server" Text="Lab Practive:"></asp:Label>
             <asp:TextBox CssClass="form-control" ID="LabPractice" runat="server" TextMode="Number">0</asp:TextBox>
             <br />
            
             <asp:Label ID="ExamLbl" runat="server" Text="Final Exam:"></asp:Label>
             <asp:TextBox CssClass="form-control" ID="FinalExam" runat="server" TextMode="Number">0</asp:TextBox>
    
             <br />
             <br />
             <asp:Button class="btn btn-primary btn-lg" ID="Button1" runat="server" OnClick="Submit_Score" Text="Submit Score" />
        </div>
        <p>
            &nbsp;</p>
    </form>
  
</body>
</html>
