<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="transport_page.aspx.cs" Inherits="Salita_Client.transport_page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="jtron" class="container" style="background: none;">

        <h3>Transportes (Hoy)</h3>
        
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>

        <div class="well well-sm">
            <a id="li_llevar" runat="server" href="transport_page.aspx?m=llevar" style="margin-right: 12px;">Llevar <span class="badge">
                <asp:Label ID="lblTake" runat="server" Text="0"></asp:Label></span></a>&nbsp;<a id="li_recojer" runat="server" href="transport_page.aspx?m=recojer">Recojer <span class="badge"><asp:Label ID="lblPickUp" runat="server" Text="0"></asp:Label></span></a>
        </div>

        <asp:ListView ID="lvTake" runat="server">
            <ItemTemplate>
                <div class="panel">
                    <div class="panel-body">
                        <h3 class="pull-right"><%#Convert.ToDateTime(Eval("RequestDateTime")).ToShortTimeString()%></h3>
                        <label><%#Eval("FullName") %> (<%#Regex.Replace(Eval("Phone").ToString(), @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3") %>)</label><br/>
                        <%#Eval("Address_Line") %><br/>
                        <%#Eval("Town") %> PR, <%#Eval("ZipCode") %><br/>
                        <br/>
                        <asp:LinkButton ID="lbComplete" OnClick="lbComplete_Click" CommandArgument='<%#Eval("CustomerNeed_ID") %>' CssClass="btn btn-primary pull-left" runat="server">Entregado</asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="lbEdit" OnClick="lbEdit_Click" CommandArgument='<%#Eval("CustomerNeed_ID") %>' CssClass="btn btn-success pull-left" runat="server">Edit</asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="lbCancel" OnClick="lbCancel_Click" CommandArgument='<%#Eval("CustomerNeed_ID") %>' CssClass="btn btn-danger" runat="server">Cancel</asp:LinkButton>
                    </div>
                </div>
            </ItemTemplate>
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