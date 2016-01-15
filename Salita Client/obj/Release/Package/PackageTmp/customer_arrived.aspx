<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="True" CodeBehind="customer_arrived.aspx.cs" Inherits="Salita_Client.customer_arrived" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    .rbl input[type="radio"]
    {
       margin-left: 24px;
       margin-right: 1px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">

    <fieldset class="formcontainer whiteclear whiteborder shadow">

    <legend class="blackclear whitetext">Recibir a <asp:Label ID="lblFullName" runat="server" style="text-transform:uppercase;"></asp:Label></legend>
 
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-info" />
    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>

        <div class="form-group">
            <label>Esperando por</label>
            <asp:DropDownList ID="cmbWaitingFor" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>

        <div class="form-group">
            <label>Estado de ánimo</label>
            <asp:DropDownList runat="server" CssClass="form-control" ID="cmbMood" >
                <asp:ListItem Value="G">Bueno</asp:ListItem>
                <asp:ListItem Value="N">Neutral</asp:ListItem>
                <asp:ListItem Value="B">Molesto</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label>PIN de Acceso</label>
            <input runat="server" type="text" class="form-control" id="txtPIN" placeholder="4 numbers..." maxlength="4">
        </div>

        <div class="panel panel-default">
            <div class="panel-body">
                <div class="table-responsive">
                    <asp:GridView ID="gvCustomerServices" Caption="Ultimas 8 atenciones" runat="server" CssClass="mygrid" EmptyDataText="No tiene servicios previos." AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="ServiceDescription" HeaderText="Servicio" />
                            <asp:BoundField DataField="RequestDateTime" HeaderText="Fecha" />
                            <asp:CheckBoxField DataField="WasFullfilled" HeaderText="Se entrego" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>

        <div class="buttonpanel">
            <asp:LinkButton ID="cmdSeatInRoom" runat="server" CssClass="btn mybutton blue rounded shadow whitetext" OnClick="cmdSeatInRoom_Click"><asp:Image runat="server" ImageUrl="~/images/check.png" /><span>Sentar en sala</span></asp:LinkButton>
            <asp:LinkButton ID="cmdCancel" runat="server" CssClass="btn mybutton black rounded shadow whitetext" OnClick="cmdCancel_Click"><asp:Image runat="server" ImageUrl="~/images/return.png" /><span>Volver</span></asp:LinkButton>
        </div>

    </fieldset>
</div>
</asp:Content>
