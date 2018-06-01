<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Stops.aspx.cs" Inherits="Boilerplate.WebFormsUI.Stops" %>

<%@ Import Namespace="Boilerplate.Data.Models.Dto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Stops (<%=StopsCount %>)</h1>
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
                <th>
                    Longitude
                </th>
                <th>
                    Latitude
                </th>
                <th colspan="2"></th>
            </tr>
            <tr>
                <th>
                    <asp:TextBox runat="server" ID="idFilter" CssClass="form-control input-sm" placeholder="Filter by Id" AutoPostBack="true" OnTextChanged="Filter_Change"></asp:TextBox>
                </th>
                <th>
                    <asp:TextBox runat="server" ID="nameFilter" CssClass="form-control input-sm" placeholder="Filter by Name" AutoPostBack="true" OnTextChanged="Filter_Change"></asp:TextBox>
                </th>
                <th>
                    &nbsp;
                </th>
                <th>
                    &nbsp;
                </th>
                <td class="text-center">
                    <asp:LinkButton runat="server" CssClass="btn btn-success btn-sm" OnClick="Filter_Change">
                        <span class="glyphicon glyphicon-search"></span>
                    </asp:LinkButton>
                </td>
                <td class="text-center">
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
                        <td colspan="2"></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>




    <div class="spacer"></div>
    <div class="row">
        <div class="col-xs-4 text-right">
            <asp:LinkButton runat="server" CssClass="btn btn-sm btn-success" OnClick="PrevPage_Click">
                <span class="glyphicon glyphicon-arrow-left"></span>
            </asp:LinkButton>
        </div>
        <div class="col-xs-4 text-center">
            <asp:Repeater runat="server" ID="pageNumbersRepeater">
                <ItemTemplate>
                    <asp:LinkButton runat="server" OnClick="PageNum_Click" CommandArgument="<%# ((int)Container.DataItem) %>">
                        <%#FormatPageNumberBtn(Container.DataItem) %>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="col-xs-4 text-left">
            <asp:LinkButton runat="server" CssClass="btn btn-sm btn-success" OnClick="NextPage_Click">
                <span class="glyphicon glyphicon-arrow-right"></span>
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
