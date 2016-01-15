<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ag_transport_form.aspx.cs" Inherits="Salita_Client.ag_transport_form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger mysummary"/>
    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>
    <div class="container-fluid" style="background-color: white;">
        <h1>Hoja de Transportación</h1>
        <table style="width: 100%; border: thin; border-color: silver;">
            <thead style="background-color: silver;">
                <tr>
                    <th>
                        Nombre
                    </th>
                    <th>
                        A#
                    </th>
                    <th>
                        LL
                    </th>
                    <th>
                        R
                    </th>
                    <th>
                        Telefono
                    </th>
                    <th>
                        Tag
                    </th>
                    <th>
                        Asesor
                    </th>
                    <th>
                        Destino
                    </th>
                    <th>
                        H. Cita
                    </th>
                    <th>
                        H. Anotado
                    </th>
                    <th>
                        H. Atentido
                    </th>
                    <th>
                        OK
                    </th>
                    <th>
                        H. Salida
                    </th>
                    <th>
                        Chofer
                    </th>
                    <th>
                        H. Llegada
                    </th>
                    <th>
                        S#
                    </th>
                </tr>
            </thead>
            <tbody>
            <asp:ListView ID="ListView1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("FullName")%>
                        </td>
                        <td>
                            <input id="txtAGCompanions" type="number" value='<%#Eval("AG_Companions")%>'></input>
                        </td>
                        <td>
                            <%#Eval("AG_LL")%>
                        </td>
                        <td>
                            <%#Eval("AG_RR")%>
                        </td>
                        <td>
                            <input id="txtPhone" type="number" value='<%#Eval("Phone")%>'></input>
                        </td>
                        <td>
                            <%#Eval("AG_Tag")%>
                        </td>
                        <td>
                            <%#Eval("AG_Advisor")%>
                        </td>
                        <td>
                            <%#Eval("AG_DriveTo")%>
                        </td>
                        <td>
                            <%#Eval("AG_AppointmentTime")%>
                        </td>
                        <td>
                            <%#Eval("AG_RegisteredTime")%>
                        </td>
                        <td>
                            <%#Eval("AG_AttendedTime")%>
                        </td>
                        <td>
                            <%#Eval("AG_OK")%>
                        </td>
                        <td>
                            <%#Eval("AG_ExitTime")%>
                        </td>
                        <td>
                            <%#Eval("AG_DriverName")%>
                        </td>
                        <td>
                            <%#Eval("AG_ArrivalTime")%>
                        </td>
                        <td>
                            <%#Eval("Seat_X")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            </tbody>
        </table>
        <hr/>
        <div style="text-align: right;">
            <span style="color: gray;">Last updated: 3:00PM</span>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
