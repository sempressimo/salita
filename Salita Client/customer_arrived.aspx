<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="True" CodeBehind="customer_arrived.aspx.cs" Inherits="Salita_Client.customer_arrived" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">

    <fieldset class="formcontainer whiteclear whiteborder shadow">

        <legend class="blackclear whitetext">Recibir a <asp:Label ID="lblFullName" runat="server" style="text-transform:uppercase;"></asp:Label></legend>

    
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-info" />
    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>

         <h3>Esperando por</h3>

         <div class="form-group">
             <asp:RadioButtonList ID="rblWaitingFor" runat="server" RepeatDirection="Vertical" AutoPostBack="True">
                 <asp:ListItem Selected="True">Servicio</asp:ListItem>
                 <asp:ListItem>Gerente</asp:ListItem>
             </asp:RadioButtonList>
         </div>

        <fieldset>
            <legend>Ultimas atenciones</legend>
            <asp:GridView ID="gvCustomerServices" runat="server" CssClass="mygrid" EmptyDataText="No tiene servicios previos."></asp:GridView>
        </fieldset>

        <div class="buttonpanel">
            <asp:LinkButton ID="cmdSeatInRoom" runat="server" CssClass="btn mybutton blue rounded shadow whitetext" OnClick="cmdSeatInRoom_Click"><asp:Image runat="server" ImageUrl="~/images/check.png" /><span>Sentar en sala</span></asp:LinkButton>
            <asp:LinkButton ID="cmdCancel" runat="server" CssClass="btn mybutton black rounded shadow whitetext" OnClick="cmdCancel_Click"><asp:Image runat="server" ImageUrl="~/images/return.png" /><span>Volver</span></asp:LinkButton>
        </div>

    </fieldset>
</div>
</asp:Content>
