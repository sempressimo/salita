<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login_detail.aspx.cs" Inherits="Salita_Client.login_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

    <fieldset class="formcontainer whiteclear whiteborder shadow">

        <legend class="blackclear whitetext">Detalles de la Cuenta</legend>

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-info" />
        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>
  
        <div class="form-group">
            <label>Usuario</label>
            <asp:TextBox ID="txtUsername" runat="server" placeholder="Nombre" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="El nombre de usuario es requerido." ForeColor="#FF9900">Requerido.</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>Rol</label>    
            <asp:DropDownList ID="cmbRole" runat="server" CssClass="form-control">
                <asp:ListItem Value="A">Admin</asp:ListItem>
                <asp:ListItem Value="D">Driver</asp:ListItem>
                <asp:ListItem Value="U">User</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cmbRole" ErrorMessage="El rol es requerido." ForeColor="#FF9900">Requerido.</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>Password</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="6 letras min..." CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword" ErrorMessage="El password es requerido." ForeColor="#FF9900">Requerido.</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>Confirmar Password</label>
            <asp:TextBox ID="txtValidatePassword" runat="server" TextMode="Password" placeholder="Otra vez..." CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtValidatePassword" ErrorMessage="El verificar el password es requerido." ForeColor="#FF9900">Requerido.</asp:RequiredFieldValidator>
        </div>
        <div class="buttonpanel">
            <asp:LinkButton ID="cmdOK" runat="server" CssClass="btn mybutton blue rounded shadow bold whitetext" OnClick="cmdOK_Click"><asp:Image runat="server" ImageUrl="~/images/check.png" /><span>Guardar datos</span></asp:LinkButton>
            <asp:LinkButton ID="cmdCancel" runat="server" CssClass="btn mybutton black rounded shadow bold whitetext" CausesValidation="false" OnClick="cmdCancel_Click"><asp:Image runat="server" ImageUrl="~/images/return.png" /><span>Regresar</span></asp:LinkButton>
        </div>
</fieldset>
</div>
</asp:Content>