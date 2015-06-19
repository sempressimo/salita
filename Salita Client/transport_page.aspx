<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="transport_page.aspx.cs" Inherits="Salita_Client.transport_page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="jtron" class="container" style="background: none;">

        <h3>Transportes (Hoy)</h3>
        
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>

        <br/>
        
        <asp:ListView ID="lvTake" runat="server">
            <ItemTemplate>
                <div class="panel">
                    <div class="panel-body">
                        <label><%#Eval("FullName") %> (<%#Regex.Replace(Eval("Phone").ToString(), @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3") %>)</label><br/>
                        <%#Eval("Address_Line") %><br/>
                        <%#Eval("Town") %> PR, <%#Eval("ZipCode") %><br/>
                        <br/>
                        <asp:LinkButton ID="lbComplete" OnClick="lbComplete_Click" CommandArgument='<%#Eval("CustomerNeed_ID") %>' CssClass="btn btn-primary pull-left" runat="server">Entregado</asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="lbCancel" CommandArgument='<%#Eval("CustomerNeed_ID") %>' CssClass="btn btn-danger" runat="server">Cancelar</asp:LinkButton>
                    </div>
                </div>
            </ItemTemplate>
            <ItemSeparatorTemplate>
                <hr/>
            </ItemSeparatorTemplate>
            <EmptyDataTemplate>
                <div class="panel">
                    <div class="panel-body">
                        <p>No hay transportes pendientes para hoy.</p>
                    </div>
                </div>
            </EmptyDataTemplate>
        </asp:ListView>

    </div>
</asp:Content>