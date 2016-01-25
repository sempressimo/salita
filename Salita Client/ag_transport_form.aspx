<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ag_transport_form.aspx.cs" Inherits="Salita_Client.ag_transport_form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger mysummary"/>
    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>
    
    <div class="container-fluid" style="background-color: white;">
        <h1>Hoja de Transportación</h1>

        <asp:ListView ID="ListView1" runat="server" DataSourceID="EntityDataSource1"></asp:ListView>

        <asp:EntityDataSource ID="EntityDataSource1" runat="server">
        </asp:EntityDataSource>

        <hr/>
        <div style="text-align: right;">
            <span style="color: gray;">Last updated: 3:00PM</span>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
    <script type="text/javascript">
    function setValue(val)
    {
        document.getElementById('myRecordId').value = val;

        $('#ContentPlaceHolder1_txtEditFullName').val($('#td-fullname-' + val).find('a').html().trim());
        $('#ContentPlaceHolder1_txtEditPhone').val($('#td-phone-' + val).find('a').html().trim());
        

    }
    </script>
</asp:Content>
