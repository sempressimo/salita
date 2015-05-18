<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="service_complete.aspx.cs" Inherits="Salita_Client.service_complete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">

     <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-info" />
     <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>

     <fieldset class="formcontainer whiteclear whiteborder shadow">

     <legend class="blackclear whitetext">Servicio completado para: <asp:Label ID="lblFullName" runat="server" style="text-transform:uppercase;"></asp:Label></legend>

         <div class="form-group">
             <label>Servicio solicitado</label>
             <asp:TextBox ID="txtServiceDesc" runat="server" placeholder="Servicio" CssClass="form-control"></asp:TextBox>
         </div>

     <div class="buttonpanel">
        <asp:LinkButton ID="cmdOK" runat="server" CssClass="btn mybutton blue rounded shadow whitetext" OnClick="cmdOK_Click"><asp:Image runat="server" ImageUrl="~/images/check.png" /><span>Servicio fue realizado</span></asp:LinkButton>
        <asp:LinkButton ID="cmdCancel" runat="server" CssClass="btn mybutton black rounded shadow whitetext" OnClick="cmdCancel_Click" ><asp:Image runat="server" ImageUrl="~/images/return.png" /><span>Volver</span></asp:LinkButton>
     </div>

     </fieldset>
 </div>
</asp:Content>
