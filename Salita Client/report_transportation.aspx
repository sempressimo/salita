<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="report_transportation.aspx.cs" Inherits="Salita_Client.report_transportation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <fieldset class="formcontainer">
        <legend class="black whitetext shadow">Reporte de Transportación</legend>

                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>

                <div class="row">
                    
                    <div class="col-md-5">
                        <div class="form-inline">
                            <asp:RadioButtonList ID="RadioButtonList1" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CellPadding="0" CellSpacing="10" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                <asp:ListItem Selected="True">Pendientes para hoy</asp:ListItem>
                                <asp:ListItem>Historicos</asp:ListItem>
                            </asp:RadioButtonList> 
                        </div>
                    </div>
                        <div class="form-inline">
                                <div class="form-group">
                                    <input id="txtFrom" runat="server" class="datepicker" data-date-format="mm/dd/yyyy" placeholder="Desde" />
                                    <input id="txtTo" runat="server" class="datepicker" data-date-format="mm/dd/yyyy" placeholder="Hasta" />
                                </div>
                                <asp:LinkButton ID="lbSearch" runat="server" OnClick="lbSearch_Click" CssClass="mybutton rounded shadow blue bold"> <asp:Image runat="server" ImageUrl="~/images/search.png" />
                                </asp:LinkButton>
                        </div>
                    </div>

                </div>
        
                <asp:GridView ID="gvRecords" CssClass="mygrid" DataKeyNames="CustomerNeed_ID" runat="server" EmptyDataText="No pedidos de transportación para la fecha." AutoGenerateColumns="False" OnRowCommand="gvRecords_RowCommand">
                    <Columns>

                        <asp:TemplateField ControlStyle-Width="10%"></asp:TemplateField>
                        <asp:BoundField DataField="FullName" HeaderText="Nombre" />
                        <asp:BoundField DataField="Phone" HeaderText="Telefono" />
                        <asp:BoundField DataField="Address_Line" HeaderText="Dirección" />
                        <asp:BoundField DataField="Town" HeaderText="Pueblo" />
                        <asp:BoundField DataField="ZipCode" HeaderText="ZipCode" />
                        <asp:ButtonField DataTextField="WasFullfilled" HeaderText="Completado" />
                    </Columns>
                </asp:GridView>
        </fieldset>
</asp:Content>
