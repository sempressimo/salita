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
                                <div class="form-group">
                                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Buscar por nombre de cliente..."></asp:TextBox>
                                </div>
                                <asp:LinkButton ID="lbSearch" runat="server" OnClick="lbSearch_Click" CssClass="mybutton rounded shadow blue bold">
                                    <asp:Image runat="server" ImageUrl="~/images/search.png" />
                                </asp:LinkButton>
                        </div>
                    </div>

                </div>
        
                <asp:GridView ID="gvRecords" CssClass="mygrid" DataKeyNames="Customer_ID" runat="server" EmptyDataText="No pedidos de transportación para la fecha." AutoGenerateColumns="False">
                    <Columns>
                        <asp:ButtonField Text="Llego" CommandName="Arrived" ButtonType="Image" ImageUrl="~/images/check.png" HeaderStyle-Width="10px" />
                        <asp:ButtonField Text="Edit" CommandName="Edit" ButtonType="Image" ImageUrl="~/images/pencil.png"  HeaderStyle-Width="10px" />
                        <asp:ButtonField CommandName="Delete" ButtonType="Image" ImageUrl="~/images/delete2.png" HeaderStyle-Width="10px" />
                        <asp:TemplateField ControlStyle-Width="10%"></asp:TemplateField>
                        <asp:BoundField DataField="FullName" HeaderText="Nombre" />
                        <asp:BoundField DataField="Phone" HeaderText="Telefono" />
                        <asp:ButtonField DataTextField="Town" HeaderText="Pueblo" Text="Button" />
                    </Columns>
                </asp:GridView>
        </fieldset>
</asp:Content>
