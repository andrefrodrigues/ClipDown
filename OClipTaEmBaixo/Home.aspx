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
                 if (obj.d.Item1 == "OK") {
                     $("#placeHolder").text("O CLIP está a funcionar neste momento!");
                     $("#placeHolder").addClass("label");
                     $("#placeHolder").addClass("label-success");
                 }
             }
         });


     }, 1000);
        })</script>
    <title>O Clip está em baixo?</title>
</head>
<body>

    <div id="aboutModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
               <h2>O que é este site?</h2> 
                </div>
                <div class="modal-body">

                </div>
            <div class="modal-footer">

            </div>
          </div>
        </div>
    </div>


    <div class="container">
    <div class="jumbotron">
        <h2>O CLIP está em baixo?</h2>
    </div>
        <div class="container">
        <input type="button" class="btn btn-primary" value="O que é isto?" data-toggle="modal" data-target="#aboutModal"/>

            <h3><label id="placeHolder" /></h3>
    </div>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" EnablePageMethods="true"/>    
    </form>
        </div>
</body>
</html>
