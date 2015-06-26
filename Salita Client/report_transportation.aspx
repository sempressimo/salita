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
        
        <fieldset class="formcontainer">
        <legend class="black whitetext shadow">Reporte de Transportación</legend>

                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>

                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-3">
                            <asp:RadioButtonList ID="RadioButtonList1" CssClass="rbl" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CellPadding="0" CellSpacing="10" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                <asp:ListItem Selected="True">Pendientes para Hoy</asp:ListItem>
                                <asp:ListItem>Buscar por fecha</asp:ListItem>
                            </asp:RadioButtonList>
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
                                <asp:LinkButton ID="lbSearch" runat="server" OnClick="lbSearch_Click" CssClass="mybutton rounded shadow blue bold"> <asp:Image runat="server" ImageUrl="~/images/search.png" />
                                Buscar</asp:LinkButton>
                                <br/>
                        </div>
                    </div>
                </div>
        
                <div class="panel panel-default">
                    <div class="panel-body">
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
        </fieldset>
</asp:Content>
