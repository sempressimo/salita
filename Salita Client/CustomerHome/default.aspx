<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerHome/CustomerSite.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Salita_Client.CustomerHome._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<form id="form_default" runat="server">

    <div style="background-color: white !important" class="jumbotron">

        <h3>Bienvenido Fulano de Tal</h3>

        <div class="well well-sm">
            Vista / acceso rapido a su expediente, citas etc.
        </div>

        <div class="container">
            <!-- Example row of columns -->
            <div class="row">
                <div class="col-md-4">
                    <h3><span class="glyphicon glyphicon-time"></span>&nbsp;Mis Citas</h3>
                    En esta sección podrá solicitar una cita y/o ver sus citas coordinadas con la dietista.<br/><br/>
                    <p><a class="btn btn-default" href="#" role="button">Ir a mis citas &raquo;</a></p>
                </div>
                <div class="col-md-4">
                    <h3><span class="glyphicon glyphicon-apple"></span>&nbsp;Dietas</h3>
                    Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus.<br/><br/>
                    <p><a class="btn btn-default" href="#" role="button">Ver mis dietas &raquo;</a></p>
                </div>
                <div class="col-md-4">
                    <h3><span class="glyphicon glyphicon-envelope"></span>&nbsp;Mensajes</h3>
                    En esta sección podrá enviarle mensajes a la dietista, así como ver cualquier mensaje de parte de la dietista o del sistema.<br/><br/>
                    <p><a class="btn btn-default" href="#" role="button">Ver Mensajes &raquo;</a></p>
                </div>
            </div>
        </div>

    </div>

</form>

</asp:Content>
