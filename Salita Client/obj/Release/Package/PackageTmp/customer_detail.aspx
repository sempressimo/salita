<%@ Page Title="AutoGermana BMW / Detalles de cliente" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="True" CodeBehind="customer_detail.aspx.cs" Inherits="Salita_Client.customer_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<div class="container">

    <fieldset class="formcontainer whiteclear whiteborder shadow">

        <legend class="blackclear whitetext">Detalles de Cliente</legend>

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-info" />
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>

        <div class="form-group">
            <label>Nombre Completo</label>
            <asp:TextBox ID="txtFullName" runat="server" placeholder="Nombre" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="checkbox"><label><asp:CheckBox ID="cbIsActive" runat="server" /><label>Activo</label></label></div>
        <div class="form-group">
            <label>Teléfono</label>    
            <asp:TextBox ID="txtPhone" runat="server" placeholder="Phone" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Email</label>
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Dirección</label>
            <asp:TextBox ID="txtAddress" runat="server" placeholder="Direccion" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Zip Code</label>
            <asp:TextBox ID="txtZipCode" runat="server" AutoPostBack="True" OnTextChanged="txtZipCode_TextChanged" placeholder="Zip Code" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Pueblo</label>
            <asp:TextBox ID="txtTown" runat="server" placeholder="Pueblo" CssClass="form-control"></asp:TextBox>
        </div>
            <div class="buttonpanel">
                <asp:LinkButton ID="cmdOK" runat="server" CssClass="btn mybutton blue rounded shadow" OnClick="cmdOK_Click"><asp:Image runat="server" ImageUrl="~/images/check.png" /></asp:LinkButton>
                <asp:LinkButton ID="cmdCancel" runat="server" CssClass="btn mybutton black rounded shadow" OnClick="cmdCancel_Click"><asp:Image runat="server" ImageUrl="~/images/return.png" /></asp:LinkButton>
            </div>
    </fieldset>
</div>
         
</asp:Content>
