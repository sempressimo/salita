<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="transport_page_edit.aspx.cs" Inherits="Salita_Client.transport_page_edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="jtron" class="container" style="background: none;">

        <h3>Editar Transporte</h3>
        
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>

        <br/>

        <div class="container-fluid">
            <div class="row">

                <div class="panel">
                    <div class="panel-body">
    
                        <div id="div_alert" runat="server" class="alert alert-info alert-dismissible" role="alert">
                            <label id="lblFullName" runat="server">Cliente</label>
                        </div>

                        <div class="form-group">
                        <label>Acompañantes</label>
                        <asp:DropDownList ID="cmbCompanions" CssClass="form-control" runat="server">
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="form-group">
                        <label>Dirección</label> 
                        <input ID="txtAddressLine1" class="form-control" runat="server"/>
                        </div>

                        <div class="form-group">
                        <label>Zip Code</label>
                        <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtZipCode_TextChanged"></asp:TextBox>
                        </div>

                        <div class="form-group">
                        <label>Pueblo</label>
                        <input ID="txtTown" runat="server" class="form-control"/>
                        </div>

                        <div class="form-group">
                        <label>Hora</label>
                        <asp:DropDownList ID="cmbTime" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>

                        <br/>

                        <div class="form-group" style="direction: rtl;">
                            <asp:LinkButton ID="lbCancel" OnClick="lbCancel_Click" CssClass="btn btn-default" runat="server">Cancel</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="lbEdit" OnClick="lbEdit_Click" CssClass="btn btn-success" runat="server">Editar</asp:LinkButton>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
