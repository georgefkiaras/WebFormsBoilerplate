<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Files.aspx.cs" Inherits="Boilerplate.WebFormsUI.Files" %>

<%@ Import Namespace="System.IO" %>
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
                </div>
            </div>
        </div>
    </div>
    <!--End Modal-->
    <h1>Files</h1>
    <p>
        Demonstration of the basic nuts-and-bolts of getting the file up via web forms or jquery + webAPI.  This method on it's own is inherently insecure and 
        would only be used in an authenticated context.
    </p>
    <p>
        Uploaded files can be accessed directly in this case.  In most cases however, an uploaded file would be accessed by a database ID and stored on a non-public
        folder on the web server for security.  Additional restrictions on file types would also be in a place.
    </p>
    <h3>jQuery + WebAPI File Upload</h3>
    <div class="row">
        <div class="col-xs-6 col-md-4">
            <input type='file' id='jQueryFile' class='form-control fileUploader' />
        </div>
        <div class="col-xs-6 col-md-2">
            <span class="label label-info">Auto-Upload <span class="glyphicon glyphicon-upload"></span></span>
        </div>
    </div>


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
    <h3>File List</h3>
    <table class="table table-bordered table-striped">
        <tbody>
            <asp:Repeater runat="server" ID="filesRepeater">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#((FileInfo)Container.DataItem).Name %>
                        </td>
                        <td>
                            <a href="../UserFiles/<%#  ((FileInfo)Container.DataItem).Name %>" class="btn btn-warning btn-sm">Download
                                <span class="glyphicon glyphicon-download"></span>
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
