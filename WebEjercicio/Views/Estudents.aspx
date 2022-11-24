<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estudents.aspx.cs" Inherits="WebEjercicio.Views.Estudents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<%--    <style type="text/css">
        ·
    </style>--%>

    <div id="mainContainer" class="container">
        <div class="shadowBox" style="margin:30px">
            <div class="page-container">
                <div class="container">
                    <asp:UpdatePanel runat="server" ID="updatePanel">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-4">
                                    <label>Estudiante: </label>
                                    <asp:DropDownList runat="server" ID="ddlEstudiante" OnSelectedIndexChanged="ddlEstudiante_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label>Periodo: </label>
                                    <asp:DropDownList runat="server" ID="ddlPeriodo" OnSelectedIndexChanged="ddlPeriodo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label>Materia: </label>
                                    <asp:DropDownList runat="server" ID="ddlMateria"></asp:DropDownList>
                                </div>
                            </div>
                    <div class="row">
                        <asp:Button runat="server" ID="btnConsultar" Text="Consultar" OnClick="btnConsultar_Click" AutoPostBack="true"/>
                        <asp:Button runat="server" ID="btnAgregar" Text="Agregar" OnClick="btnAgregar_Click" AutoPostBack="true"/>
                    </div>
                    <asp:Panel runat="server" ID="UNota" Visible="false">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <div class="form-horizontal">
                                    <div class="row">
                                        <asp:Label runat="server" ID="lblNota" Text="Nota: "></asp:Label>
                                        <asp:TextBox runat="server" ID="txtNota"></asp:TextBox>
                                        <asp:LinkButton runat="server" ID="lnkSave" CssClass="glyphicon glyphicon-save" OnClick="lnkSave_Click"></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                            
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView runat="server" ID="gvNotas" HorizontalAlign="Center" AutoGenerateColumns="false" RowStyle-Font-Size="11px" HeaderStyle-Font-Size="Small" AllowPaging="true"
                                width="100%" DataKeyNames="IdMatCursoEst,Nota" CssClass="table table-striped table-bordered table-hover table-condensed" OnRowCommand="gvNotas_RowCommand"
                                EmptyDataText="No hay registros para mostrar"
                                >
                                <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" PageButtonCount="10" Position="Bottom" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Opciones" ShowHeader="false" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkEditar" CssClass="glyphicon glyphicon-edit" CommandArgument="<%# Container.DataItemIndex  %>" CommandName="Editar" ToolTip="Editar Nota"></asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="lnkEliminar" CssClass="glyphicon glyphicon-remove" CommandArgument="<%# Container.DataItemIndex  %>" CommandName="Eliminar" ToolTip="Eliminar Nota"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle width="20px"/>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre Estudiante"/>
                                    <asp:BoundField DataField="NombreMateria" HeaderText="Asignatura"/>
                                    <asp:BoundField DataField="Curso" HeaderText="Periodo"/>
                                    <asp:BoundField DataField="Nota" HeaderText="Nota"/>
                                </Columns>
                            </asp:GridView>
                        </div>

                    </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>
       
    </div>

    <!-- Mensaje Validacion modal comienza aquí-->

    <div id="EditarNota" class="modal fade" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-sm">
            <asp:UpdatePanel ID="upeditar" runat="server">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header alert-info">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblTituloEditar" runat="server" Text="Editar Nota"></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <asp:TextBox runat="server" ID="txtUpNota"></asp:TextBox>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="lnkActualizar" runat="server" CssClass="btn btn-primary" OnClick="lnkActualizar_Click">
                                                 Aceptar <span aria-hidden="true"></span>    
                            </asp:LinkButton>
                            <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="lnkActualizar" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
