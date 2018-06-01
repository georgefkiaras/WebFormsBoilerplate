<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Stops.aspx.cs" Inherits="Boilerplate.WebFormsUI.Stops" %>

<%@ Import Namespace="Boilerplate.Data.Models.Dto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Stops (<%=StopsCount %>)</h1>
    <table class="table table-bordered table-striped">
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
