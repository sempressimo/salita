<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ag_transport_form.aspx.cs" Inherits="Salita_Client.ag_transport_form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger mysummary"/>
    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator" Visible="false"></asp:CustomValidator>
    
    <input type="hidden" value="-1" name="myRecordId" id="myRecordId" />

    <!-- Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <h4 class="modal-title" id="myModalLabel">Editar Información</h4>
          </div>
              <div class="modal-body">
            
                <!-- Basic details form start here -->
                
                <div class="row">
                    <div class="col-lg-6">
                        <label>Nombre</label>
                        <input id="txtEditFullName" runat="server" type="text" placeholder="Full name" class="form-control" />
                    </div>
                    <div class="col-lg-6">
                        <label>Teléfono</label>
                        <input id="txtEditPhone" runat="server" type="tel" placeholder="(787) 999-9999" class="form-control" />
                    </div>
                </div>

                <div class="row">

                    <div class="col-lg-4">
                        <label>Acompañantes</label>
                        <input id="Text2" runat="server" type="number" placeholder="#" class="form-control" />
                    </div>

                    <div class="col-lg-4">
                        <label>Tag</label>
                        <input id="txtTag" runat="server" type="number" placeholder="#" class="form-control" />
                    </div>

                    <div class="col-lg-2">
                        <label>LL</label>
                        <br/><asp:CheckBox ID="cbLL" runat="server" class="form-control"/>
                    </div>
                    
                    <div class="col-lg-2">
                        <label>R</label>
                        <br/><asp:CheckBox ID="lbR" runat="server" class="form-control"/>
                    </div>
                  
                </div>

                <div class="row">

                    <div class="col-lg-12">
                        <label>Destino</label>
                        <input id="txtDestiny" type="text" runat="server" placeholder="Detalles..." class="form-control" />
                    </div>

                </div>
          
                <div class="row">
                
                    <div class="col-lg-4">
                        <label>H. Cita</label>
                        <input id="txtDateTime" type="time" runat="server" placeholder="9:99 AM" class="form-control" />
                    </div>
                
                    <div class="col-lg-4">
                        <label>H. Anotado</label>
                        <input id="txtSignedInTime" type="time" runat="server" placeholder="9:99 AM" class="form-control" />
                    </div>

                    <div class="col-lg-4">
                        <label>H. Atendido</label>
                        <input id="txtAtended" type="time" runat="server" placeholder="9:99 AM" class="form-control" />
                    </div>

                </div>

                <div class="row">
                
                    <div class="col-lg-6">
                        <label>Chofer</label>
                        <input id="txtDriver" type="text" runat="server" placeholder="Nombre..." class="form-control" />
                    </div>
                
                    <div class="col-lg-6">
                        <label>OK</label>
                        <br/><asp:CheckBox ID="cbOK" runat="server" />
                    </div>

                </div>

                <div class="row">

                    <div class="col-lg-4">
                        <label>H. Salida</label>
                        <input id="txtLeaveTime" type="time" runat="server" placeholder="9:99 AM" class="form-control" />
                    </div>
                
                    <div class="col-lg-4">
                        <label>H. Llegada</label>
                        <input id="txtArriveTime" type="time" runat="server" placeholder="9:99 AM" class="form-control" />
                    </div>

                    <div class="col-lg-4">
                        <label>&nbsp;</label>
                    </div>

                </div>

              </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
              <asp:Button ID="cmdSave" OnClick="cmdSave_Click" CssClass="btn btn-primary" runat="server" Text="Save changes" />
          </div>
        </div>
      </div>
    </div>
    
    <div class="container-fluid" style="background-color: white;">
        <h1>Hoja de Transportación</h1>

        <!-- Header details -->
        <div>

            &nbsp;
        </div>

        <table style="width: 100%; border: thin; border-color: silver;">
            <thead style="background-color: silver;">
                <tr>
                    <th>
                        Nombre
                    </th>
                    <th>
                        Teléfono
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
                        <td id='td-fullname-<%#Eval("Visit_ID")%>'>
                            <a href='#' style="text-decoration: none; color: black;" onclick="setValue(<%#Eval("Visit_ID")%>)" data-toggle="modal" data-target="#myModal"><%#Eval("FullName")%></a>
                        </td>
                        <td id='td-phone-<%#Eval("Visit_ID")%>'>
                            <a href='#' style="text-decoration: none; color: black;" onclick="setValue(<%#Eval("Visit_ID")%>)" data-toggle="modal" data-target="#myModal"><%#Eval("Phone")%></a>
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
    <script type="text/javascript">
        function setValue(val) {
            document.getElementById('myRecordId').value = val;

            $('#ContentPlaceHolder1_txtEditFullName').val($('#td-fullname-' + val).find('a').html().trim());
            $('#ContentPlaceHolder1_txtEditPhone').val($('#td-phone-' + val).find('a').html().trim());


        }
    </script>
</asp:Content>
