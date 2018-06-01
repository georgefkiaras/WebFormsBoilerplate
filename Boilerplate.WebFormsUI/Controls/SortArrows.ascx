<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SortArrows.ascx.cs" Inherits="Boilerplate.WebFormsUI.Controls.SortArrows" %>
<% if (CurrentSortInfo.SortColumn == SortColumn)
    { %>
<% if (CurrentSortInfo.descending)
    { %>
    <span class="label label-success pull-right">
        <span class="glyphicon glyphicon-chevron-up"></span>
    </span>

<% } %>
<% else
    { %>
    <span class="label label-success pull-right">
        <span class="glyphicon glyphicon-chevron-down"></span>
    </span>
<% } %>
<% } %>