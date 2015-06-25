<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="cancel_transportation.aspx.cs" Inherits="Salita_Client.cancel_transportation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="jtron" class="container" style="background: none;">

    <h3>Cancelar Transportación</h3>
        
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>

    <div class="panel">
        <div class="panel-body">
            <p>
                ¿Esta seguro que desea cancelar la transportación?
            </p>
            <label>
                <asp:Label ID="lblCustomerName" runat="server" Text="Label"></asp:Label> (<asp:Label ID="lblPhone" runat="server" Text="Label"></asp:Label>)</label><br/>
                <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label><br/>
                <asp:Label ID="lblTown" runat="server" Text="Label"></asp:Label>&nbsp;<asp:Label ID="lblCountry" runat="server" Text="PR"></asp:Label>, <asp:Label ID="lblZipCode" runat="server" Text="Label"></asp:Label><br/>
            <br/>
            <asp:LinkButton ID="lbComplete" OnClick="lbComplete_Click" CommandArgument='<%#Eval("CustomerNeed_ID") %>' CssClass="btn btn-danger pull-left" runat="server">Cancelar</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="lbCancel" OnClick="lbCancel_Click" CommandArgument='<%#Eval("CustomerNeed_ID") %>' CssClass="btn btn-default" runat="server">Regresar</asp:LinkButton>
        </div>
    </div>

</div>

</asp:Content>
