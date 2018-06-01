<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ValidationError.aspx.cs" Inherits="Boilerplate.WebFormsUI.ValidationError" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        <span class="glyphicon glyphicon-exclamation-sign"></span>
        Validation Error
    </h1>
    <div class="alert alert-warning errorHolder">
        <h2>
            <span class="glyphicon glyphicon-info-sign"></span>
            <%=ErrorMessage %>
        </h2>
        <p>
            Please <a href="javascript:history.back()">go back</a> to the previous page and try again.
        </p>
    </div>
</asp:Content>