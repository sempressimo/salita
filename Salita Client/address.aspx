<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="address.aspx.cs" Inherits="Salita_Client.address" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

     <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-info" />
     <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>

     <fieldset class="formcontainer whiteclear whiteborder shadow">

     <legend class="blackclear whitetext">Transportación para: <asp:Label ID="lblFullName" runat="server" style="text-transform:uppercase;"></asp:Label></legend>

         <div class="form-group">
             <asp:RadioButtonList ID="rblWhereTo" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                 <asp:ListItem Selected="True">Hacia dirección</asp:ListItem>
                 <asp:ListItem>Hacia el dealer</asp:ListItem>
             </asp:RadioButtonList>
         </div>
         <div class="form-group">
             <label>Dirección</label>
             <asp:TextBox ID="txtSendTo" runat="server" placeholder="Direccion a transportar" CssClass="form-control"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSendTo" ErrorMessage="La dirección es requerida." ForeColor="#FF9900">* Requerido</asp:RequiredFieldValidator>
         </div>
         <div class="form-group">
            <label>Zip Code</label>
            <asp:TextBox ID="txtZipCode" runat="server" AutoPostBack="True" OnTextChanged="txtZipCode_TextChanged" placeholder="Zip Code" CssClass="form-control"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtZipCode" ErrorMessage="El zipcode es requerido." ForeColor="#FF9900">* Requerido</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>Pueblo</label>
            <asp:TextBox ID="txtTown" runat="server" placeholder="Pueblo" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTown" ErrorMessage="El pueblo es requerido." ForeColor="#FF9900">* Requerido</asp:RequiredFieldValidator>
        </div>
         <div class="buttonpanel">
             <asp:LinkButton ID="cmdOK" runat="server" CssClass="btn mybutton blue rounded shadow whitetext" OnClick="cmdOK_Click"><asp:Image runat="server" ImageUrl="~/images/check.png" /><span>Someter</span></asp:LinkButton>
             <asp:LinkButton ID="cmdCancel" runat="server" CssClass="btn mybutton black rounded shadow whitetext" OnClick="cmdCancel_Click" ><asp:Image runat="server" ImageUrl="~/images/return.png" /><span>Volver</span></asp:LinkButton>
         </div>

     </fieldset>
 </div>
</asp:Content>
