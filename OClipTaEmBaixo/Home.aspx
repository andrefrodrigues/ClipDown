<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OClipTaEmBaixo.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script> $(document).ready(function () {
     setInterval(function () {
         $.ajax({
             url: "Home.aspx/GetStatus",
             type: "POST",
             dataType: "json",
             contentType: "application/json; charset=utf-8",
             async: true,
             success: function (obj) {
                 $("#placeHolder").text(obj.d.Item1);
             }
         });


     }, 1000);
        })</script>
    <title>O Clip está em baixo?</title>
</head>
<body>

    <div class="jumbotron">
        <h2>O CLIP está em baixo?</h2>
    </div>
        <div class="container">

            <label id="placeHolder" />

    </div>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" EnablePageMethods="true"/>


    </form>
</body>
</html>
