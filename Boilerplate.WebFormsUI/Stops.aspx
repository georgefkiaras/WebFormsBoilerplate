﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Stops.aspx.cs" Inherits="Boilerplate.WebFormsUI.Stops" %>

<%@ Import Namespace="Boilerplate.Data.Models.Dto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Modal -->
    <div class="modal fade" id="messageModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="messageModalHeader">Sample Modal</h4>
                </div>
                <div class="modal-body" id="messageModalBody">
                    <p>
                        This shows how to open a modal with jquery and bootstrap.
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" data-dismiss="modal">
                        Ok
                        <span class="glyphicon glyphicon-ok"></span>
                    </button>
                    <button type="button" class="btn btn-warning" id="pageReloadButton" data-dismiss="modal">
                        Reload Page Example
                        <span class="glyphicon glyphicon-repeat"></span>
                    </button>
                </div>
            </div>
        </div>
    </div>
    <!--End Modal-->

    <!-- Modal -->
    <div class="modal fade" id="stationModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="modalStationNameTitle"></h4>
                </div>
                <div class="modal-body">
                    <table class="table table-bordered table-striped">
                        <tr>
                            <th>Id:
                            </th>
                            <td id="stationModalId"></td>
                        </tr>
                        <tr>
                            <th>Longitude
                            </th>
                            <td id="stationModalLat"></td>
                        </tr>
                        <tr>
                            <th>Latitude
                            </th>
                            <td id="stationModalLon"></td>
                        </tr>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" data-dismiss="modal">
                        Ok
                        <span class="glyphicon glyphicon-ok"></span>
                    </button>
                </div>
            </div>
        </div>
    </div>
    <!--End Modal-->

    <!-- Modal -->
    <div class="modal fade" id="postModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Post Data Modal</h4>
                </div>
                <div class="modal-body">
                    <p>
                        This modal sends a text value to the server, and refreshes this page to see the sent message.  Enter an empty value to clear the message.
                    </p> 
                    <input type="text" id="messageBox" placeholder="Enter message." class="form-control" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" id="exceptionButton">
                        Simulate exception
                        <span class="glyphicon glyphicon-arrow-right"></span>
                    </button>
                    <button type="button" class="btn btn-warning" id="validationErrorButton">
                        Simulate validation error
                        <span class="glyphicon glyphicon-arrow-right"></span>
                    </button>
                    <button type="button" class="btn btn-success" id="submitMessage">
                        Submit
                        <span class="glyphicon glyphicon-arrow-right"></span>
                    </button>
                </div>
            </div>
        </div>
    </div>
    <!--End Modal-->

    <!-- Modal -->
    <div class="modal fade" id="errorModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">An Error has Occurred</h4>
                </div>
                <div class="modal-body" id="errorModalMessageBody">
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Ok</button>
                </div>
            </div>
        </div>
    </div>
    <!--End Modal-->

    <h1>Stops (<%=StopsCount %>)</h1>
    <span class="btn btn-success btn-sm" id="modalOpenButton">SimpleModal Demo</span>
    <span class="btn btn-success btn-sm" id="postOpenButton">Send Data to Server via Modal Demo</span>
    <div class="spacer"></div>
    <%if (LastMessage.Length > 0)
        { %>
    <h2>
        <span class="label label-success">
            <%=LastMessage %> @ <%=LastMessageDate.ToString() %>
        </span>
    </h2>

    <%} %>
    <table class="table table-bordered table-striped">
        <thead>
            <tr>
                <th>
                    <asp:LinkButton runat="server" OnClick="sortColumn_click" CommandArgument="Id">
                        Id
                        <Controls:SortArrows runat="server" CurrentSortInfo="<%#CurrentSortInfo%>" SortColumn="Id" />
                    </asp:LinkButton>
                </th>
                <th>
                    <asp:LinkButton runat="server" OnClick="sortColumn_click" CommandArgument="Name">
                        Name
                        <Controls:SortArrows runat="server" CurrentSortInfo="<%#CurrentSortInfo%>" SortColumn="Name" />
                    </asp:LinkButton>
                </th>
                <th>Longitude
                </th>
                <th>Latitude
                </th>
                <th></th>
            </tr>
            <tr>
                <th>
                    <asp:TextBox runat="server" ID="idFilter" CssClass="form-control input-sm" placeholder="Filter by Id" AutoPostBack="true" OnTextChanged="Filter_Change"></asp:TextBox>
                </th>
                <th>
                    <asp:TextBox runat="server" ID="nameFilter" CssClass="form-control input-sm" placeholder="Filter by Name" AutoPostBack="true" OnTextChanged="Filter_Change"></asp:TextBox>
                </th>
                <th>&nbsp;
                </th>
                <th>&nbsp;
                </th>
                <td class="text-center">
                    <asp:LinkButton runat="server" CssClass="btn btn-success btn-sm" OnClick="Filter_Change">
                        <span class="glyphicon glyphicon-search"></span>
                    </asp:LinkButton>
                    <asp:LinkButton runat="server" CssClass="btn btn-warning btn-sm" OnClick="Filter_Clear">
                        <span class="glyphicon glyphicon-ban-circle"></span>
                    </asp:LinkButton>
                </td>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="stopsRepeater">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#((StopDto)Container.DataItem).Id %>
                        </td>
                        <td>
                            <%#((StopDto)Container.DataItem).Name %>
                        </td>
                        <td>
                            <%#((StopDto)Container.DataItem).Longitude %>
                        </td>
                        <td>
                            <%#((StopDto)Container.DataItem).Latitude %>
                        </td>
                        <td class="text-center">
                            <%#FormatDetailButton(Container.DataItem) %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>




     <!--Pagination-->
    <div class="spacer"></div>
    <div class="row">
        <div class="col-xs-5 text-right">
            <asp:LinkButton runat="server" CssClass="btn btn-sm btn-success" OnClick="PageNum_Click" CommandArgument="1">
                <span class="glyphicon glyphicon-fast-backward"></span> First
            </asp:LinkButton>
            <asp:LinkButton runat="server" CssClass="btn btn-sm btn-success" OnClick="PrevPage_Click">
                <span class="glyphicon glyphicon-step-backward"></span> Previous
            </asp:LinkButton>
        </div>
        <div class="col-xs-2 text-center">
            <span class="badge">Page
            <%=CurrentPageInfo.CurrentPage %> /
                <%=CurrentPageInfo.TotalPages %>
            </span>
        </div>

        <div class="col-xs-5 text-left">
            <asp:LinkButton runat="server" CssClass="btn btn-sm btn-success" OnClick="NextPage_Click">
                Next <span class="glyphicon glyphicon-step-forward"></span>
            </asp:LinkButton>
            <asp:LinkButton runat="server" CssClass="btn btn-sm btn-success" OnClick="PageNum_Click" CommandArgument="<%#CurrentPageInfo.TotalPages %>">
                Last <span class="glyphicon glyphicon-fast-forward"></span>
            </asp:LinkButton>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-xs-12 text-center">
            <asp:Repeater runat="server" ID="recordsPerPageRepeater">
                <ItemTemplate>
                    <asp:LinkButton runat="server" OnClick="RecordsNum_Click" CommandArgument="<%# ((int)Container.DataItem) %>">
                        <%#FormatRecordsPerPage(Container.DataItem) %>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12 text-center">
            Records per page
        </div>
    </div>
</asp:Content>
