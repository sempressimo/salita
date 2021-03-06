﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="address.aspx.cs" Inherits="Salita_Client.address" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    .rbl input[type="radio"]
    {
       margin-left: 0px;
       margin-right: 8px;
       padding-right: 8px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

     <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-info" />
     <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>

     <fieldset class="formcontainer whiteclear whiteborder shadow">

     <legend class="blackclear whitetext">Transportación para: <asp:Label ID="lblFullName" runat="server" style="text-transform:uppercase;"></asp:Label></legend>

        <div class="form-group">
            <label>Llevar o recojer</label>
            <asp:DropDownList runat="server" CssClass="form-control" ID="cmbWhereTo" AutoPostBack="true" OnSelectedIndexChanged="cmbWhereTo_SelectedIndexChanged" >
                <asp:ListItem Value="0">Llevar a destino</asp:ListItem>
                <asp:ListItem Value="1">Recojer y traer al taller</asp:ListItem>
            </asp:DropDownList>
        </div>
         <div class="form-group">
             <asp:CheckBox ID="cbUseRegisteredAddress" runat="server" AutoPostBack="True" OnCheckedChanged="cbUseRegisteredAddress_CheckedChanged" Text="Usar dirección del hogar" />
         </div>
         <div class="form-group">
             <label>Dirección</label>
             <asp:TextBox ID="txtSendTo" runat="server" placeholder="Direccion a transportar" CssClass="form-control"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSendTo" ErrorMessage="La dirección es requerida." ForeColor="#FF9900">* Requerido</asp:RequiredFieldValidator>
         </div>
         <div class="form-group">
            <label>Zip Code (Opcional)</label>
            <asp:TextBox ID="txtZipCode" runat="server" AutoPostBack="True" OnTextChanged="txtZipCode_TextChanged" placeholder="Zip Code" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Pueblo</label>
            <asp:TextBox ID="txtTown" runat="server" placeholder="Pueblo" CssClass="form-control"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTown" ErrorMessage="El pueblo es requerido." ForeColor="#FF9900">* Requerido</asp:RequiredFieldValidator>
        </div>
        <div id="div_RoundTrip" runat="server" class="form-group">
                <asp:CheckBox ID="cbRoundTrip" runat="server" OnCheckedChanged="cbRoundTrip_CheckedChanged" Text="Necesita que lo busquen también" AutoPostBack="True" />

                <div id="divPickupTime" class="form-group" runat="server" visible="false">
                    <div class="form-group">
                        <label>Hora</label>
                        <asp:DropDownList ID="cmbTime" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>

         </div>
         <div class="buttonpanel">
             <asp:LinkButton ID="cmdOK" runat="server" CssClass="btn mybutton blue rounded shadow whitetext" OnClick="cmdOK_Click"><asp:Image runat="server" ImageUrl="~/images/check.png" /><span>Someter</span></asp:LinkButton>
             <asp:LinkButton ID="cmdCancel" runat="server" CausesValidation="false" CssClass="btn mybutton black rounded shadow whitetext" OnClick="cmdCancel_Click" ><asp:Image runat="server" ImageUrl="~/images/return.png" /><span>Volver</span></asp:LinkButton>
         </div>

     </fieldset>
 </div>
</asp:Content>
