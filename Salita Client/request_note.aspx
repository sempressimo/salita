<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="request_note.aspx.cs" Inherits="Salita_Client.request_note" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

     <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-info" />
     <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>

     <fieldset class="formcontainer whiteclear whiteborder shadow">

         <legend class="blackclear whitetext">Servicio solicitado por: <asp:Label ID="lblFullName" runat="server" style="text-transform:uppercase;"></asp:Label></legend>

             <div class="form-group">
                 <label>
                    <asp:Image ID="imageIcon" runat="server" ImageUrl="~/images/pop_cafe.png" />
                    <asp:Label ID="lblServiceRequested" runat="server" Text="Label"></asp:Label>
                 </label>
                 <asp:TextBox ID="txtServiceNote" runat="server" placeholder="Nota..." CssClass="form-control"></asp:TextBox>
             </div>

         <div class="buttonpanel">
            <asp:LinkButton ID="cmdOK" runat="server" CssClass="btn mybutton blue rounded shadow whitetext" OnClick="cmdOK_Click"><asp:Image runat="server" ImageUrl="~/images/check.png" /><span>Confirmar Solicitud</span></asp:LinkButton>
            <asp:LinkButton ID="cmdCancel" runat="server" CssClass="btn mybutton black rounded shadow whitetext" OnClick="cmdCancel_Click" ><asp:Image runat="server" ImageUrl="~/images/return.png" /><span>Volver</span></asp:LinkButton>
         </div>

     </fieldset>

</div>

</asp:Content>
