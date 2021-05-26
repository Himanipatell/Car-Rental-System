<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CarRentalSystem.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    <style>
        .btn:hover{
            background-color:gray;
            color:white;
        }
        btn{
            background-color:transparent;
            color:black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                
                <asp:Button ID="Button1" runat="server" Text="Search for Cabs" CssClass="btn col-5 mt-4 border-1" style="border-color:gray"  OnClick="Button1_Click"/>
                <asp:Label runat="server" ID="Label1" CssClass="form-control mt-4 bg-transparent" Text=""></asp:Label>
            </div>
        </div>
    </form>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet">
</body>
</html>
