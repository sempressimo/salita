<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ag_transport_form.aspx.cs" Inherits="Salita_Client.ag_transport_form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger mysummary"/>
    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>
    
    <!-- Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <h4 class="modal-title" id="myModalLabel">Basic Details</h4>
          </div>
              <div class="modal-body">
            
                  <!-- Basic details form start here -->
                  <div class="row">
                    <div class="col-lg-6">
                        Nombre completo:
                    </div>
                    <div class="col-lg-6">
                        <input id="txtEditFullName" placeholder="Full name" class="form-control" />
                    </div>
                  </div>

                <div class="row">
                    <div class="col-lg-6">
                        Teléfono:
                    </div>
                    <div class="col-lg-6">
                        <input id="txtEditPhone" placeholder="(787) 999-9999" class="form-control" />
                    </div>
                  </div>
          
              </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary">Save changes</button>
          </div>
        </div>
      </div>
    </div>
    
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
                        Teléfono
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
                            <a href='#' data-toggle="modal" data-target="#myModal"><%#Eval("FullName")%></a>
                        </td>
                        <td>
                            <%#Eval("AG_Companions")%>
                        </td>
                        <td>
                            <%#Eval("AG_LL")%>
                        </td>
                        <td>
                            <%#Eval("AG_RR")%>
                        </td>
                        <td>
                            <%#Eval("Phone")%>
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
