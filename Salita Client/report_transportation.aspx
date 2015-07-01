<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="report_transportation.aspx.cs" Inherits="Salita_Client.report_transportation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
.rbl input[type="radio"]
{
   margin-left: 10px;
   margin-right: 1px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="jtron" class="container" style="background-color: white;">

    <h3>Reporte de Transportación</h3>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger mysummary"/>
    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>

    <br/>

    <div class="row">
        <div class="col-lg-3">
            <asp:DropDownList ID="ddlReportType" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged">
                <asp:ListItem Value="0">Solo de Hoy</asp:ListItem>
                <asp:ListItem Value="1">Por Fechas</asp:ListItem>
            </asp:DropDownList>
            <br/>
        </div>
        <div class="col-lg-3">
            <input id="txtFrom" runat="server" class="form-control" disabled="disabled" data-date-format="mm/dd/yyyy" placeholder="Desde" />
            <br/>
        </div>
        <div class="col-lg-3">
            <input id="txtTo" runat="server" class="form-control" disabled="disabled" data-date-format="mm/dd/yyyy" placeholder="Hasta" />
            <br/>
        </div>
        <div class="col-lg-3">
                <asp:LinkButton ID="lbSearch" runat="server" OnClick="lbSearch_Click" CssClass="btn btn-primary"><span class="glyphicon glyphicon-search">&nbsp;</span>
                Buscar</asp:LinkButton>
                <br/>
        </div>
    </div>

    <div class="row">

        <div class="table-responsive">
            <asp:GridView ID="gvRecords" CssClass="mygrid" DataKeyNames="CustomerNeed_ID, Address_Line, Town, ZipCode" runat="server" EmptyDataText="No pedidos de transportación para la fecha." AutoGenerateColumns="False" OnRowCommand="gvRecords_RowCommand" OnRowDataBound="gvRecords_RowDataBound">
                <Columns>

                    <asp:TemplateField ControlStyle-Width="10%"></asp:TemplateField>
                    <asp:BoundField DataField="FullName" HeaderText="Nombre" />
                    <asp:BoundField DataField="Phone" HeaderText="Telefono" />
                    <asp:BoundField DataField="Address_Line" HeaderText="Dirección" />
                    <asp:BoundField DataField="Town" HeaderText="Pueblo" />
                    <asp:ButtonField CommandName="Maps" DataTextField="ZipCode" HeaderText="ZipCode" />
                    <asp:ButtonField CommandName="Close" DataTextField="WasFullfilled" HeaderText="Completado" />
                </Columns>
            </asp:GridView>
        </div>

        <div class="table-responsive">
            <asp:GridView ID="gvToDealder" CssClass="mygrid" DataKeyNames="CustomerNeed_ID, Address_Line, Town, ZipCode" runat="server" EmptyDataText="No pedidos de transportación para la fecha." AutoGenerateColumns="False" OnRowCommand="gvRecords_RowCommand" OnRowDataBound="gvRecords_RowDataBound">
                <Columns>

                    <asp:TemplateField ControlStyle-Width="10%"></asp:TemplateField>
                    <asp:BoundField DataField="FullName" HeaderText="Nombre" />
                    <asp:BoundField DataField="Phone" HeaderText="Telefono" />
                    <asp:BoundField DataField="Address_Line" HeaderText="Dirección" />
                    <asp:BoundField DataField="Town" HeaderText="Pueblo" />
                    <asp:ButtonField CommandName="Maps" DataTextField="ZipCode" HeaderText="ZipCode" />
                    <asp:ButtonField CommandName="Close" DataTextField="WasFullfilled" HeaderText="Completado" />
                </Columns>
            </asp:GridView>
        </div>

    </div>

</div>

</asp:Content>
