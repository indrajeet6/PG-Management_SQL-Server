<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PG_Management._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" >
        <h1>PG Management System</h1>
    </div>
    <div class="table-responsive" >
        <p></p>
        <asp:gridview HorizontalAlign="Justify" id="GridView1" runat="server" autogeneratecolumns="true" 
            CssClass="table table-striped table-bordered table-hover table-condensed"
            OnRowCommand="GridView1_RowCommand">
            <RowStyle HorizontalAlign="Center" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="Button" ButtonType="LinkButton" Text="Rent Paid" runat="server"  CommandName="Rent_Paid" CommandArgument='<%# Eval("ID") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:gridview>
    </div>
    <div>
        <asp:Label ID="Error_Msg" Font-Bold="true" Font-Size="XX-Large" runat="server"></asp:Label>
    </div>
   <%-- <div runat="server" id="AlertBox" class="alertBox" Visible="false">
        <div runat="server" id="AlertBoxMessage"></div>
        <button onclick="closeAlert.call(this, event)">Ok</button>
    </div>--%>
    

</asp:Content>
