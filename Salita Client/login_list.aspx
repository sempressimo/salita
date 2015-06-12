<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login_list.aspx.cs" Inherits="Salita_Client.login_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <fieldset class="formcontainer">
        <legend class="black whitetext shadow">Cuentas de Usuario</legend>

                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>

                <div class="row">
                    <div class="col-md-6">
                        <div class="form-inline">
                                <div class="form-group">
                                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Buscar por nombre..."></asp:TextBox>
                                </div>
                                <asp:LinkButton ID="lbSearch" runat="server" OnClick="lbSearch_Click" CssClass="btn btn-default mybutton rounded shadow blue bold">
                                    <asp:Image runat="server" ImageUrl="~/images/search.png" />
                                </asp:LinkButton>
                        </div>
                    </div>

                    <div class="col-md-2 col-md-offset-4">
                        <div class="form-inline">
                            <asp:LinkButton ID="lbAddCustomer" runat="server" OnClick="lbAddCustomer_Click" CssClass="mybutton btn-block green bold whitetext rounded shadow">
                                <asp:Image runat="server" ImageUrl="~/images/plus.png" />
                                <span>Nueva Cuenta</span>
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
        

                <asp:GridView ID="gvRecords" CssClass="mygrid" DataKeyNames="Username" runat="server" EmptyDataText="No hay clientes bajo esos criterios." AutoGenerateColumns="False" OnRowCommand="gvCustomers_RowCommand" OnRowDeleting="gvCustomers_RowDeleting">
                    <Columns>
                        <asp:ButtonField CommandName="Update" ButtonType="Image" ImageUrl="~/images/pencil.png" HeaderStyle-Width="10px" />
                        <asp:ButtonField CommandName="Delete" ButtonType="Image" ImageUrl="~/images/delete2.png" HeaderStyle-Width="10px" />
                        <asp:BoundField DataField="Username" HeaderText="Nombre de Usuario" />
                        <asp:BoundField DataField="Role" HeaderText="Rol" />
                    </Columns>
                </asp:GridView>
        </fieldset>

</asp:Content>
