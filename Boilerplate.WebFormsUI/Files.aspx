<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Files.aspx.cs" Inherits="Boilerplate.WebFormsUI.Files" %>
<%@ Import Namespace="System.IO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Aspx File Upload</h3>
    <div class="row">
        <div class="col-xs-6 col-md-4">
            <asp:FileUpload runat="server" CssClass="form-control" ID="fileUpload" />
        </div>
        <div class="col-xs-6 col-md-2">
            <asp:LinkButton runat="server" ID="fileUploadBtn" CssClass="btn btn-sm btn-block btn-success" OnClick="FileUploadClick">
                Upload
                <span class="glyphicon glyphicon-upload"></span>
            </asp:LinkButton>
        </div>
    </div>
    <h3>Files</h3>
    <table class="table table-bordered table-striped">
        <tbody>
            <asp:Repeater runat="server" ID="filesRepeater">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#((FileInfo)Container.DataItem).FullName %>
                        </td>
                        <td>
                            (file download)
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>