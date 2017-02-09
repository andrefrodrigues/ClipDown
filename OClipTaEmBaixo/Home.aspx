<!-- 
     This file is part of O CLIP esta em baixo.

    O CLIP esta em baixo is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    O CLIP esta em baixo is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Foobar.  If not, see <http://www.gnu.org/licenses/>.
    -->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OClipTaEmBaixo.Home" %>
 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" type="image/x-icon" href="/favicon.ico" />
        <script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/Site.css" rel="stylesheet" />
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
               
        <br/>
            <h3><label id="placeHolder" /></h3>
         <input type="button" class="btn btn-primary btn-xs" value="O que é isto?" data-toggle="modal" data-target="#aboutModal"/>
    </div>
        <div class="container">

            <div class="form-group">
            <label for="lastOnline">Última vez online:</label>
            <label id="lastOnline"/>
            </div>
            <div class="form-group">
            <label for="lasOffline">Última vez offline:</label>
            <label id="lastOffline" />
               </div>
    </div>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" EnablePageMethods="true"/>    
    </form>
        </div>
</body>
</html>
