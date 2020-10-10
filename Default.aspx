<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PG_Management._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>PG Management System</h1>
    </div>
    <div class="table-responsive">
        <asp:gridview id="GridView1" runat="server" autogeneratecolumns="true" CssClass="table table-striped table-bordered table-hover table-condensed" >
        </asp:gridview>
    </div>
    

</asp:Content>
