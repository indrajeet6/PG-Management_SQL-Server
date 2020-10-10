<%@ Page Title="Add New Tenant"  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add_New_Tenant.aspx.cs" Inherits="PG_Management.Add_New_Tenant" %> 

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="table-responsive container">
        <div>
            <div style="float:left">
            <h4 style="text-align:center">Tenant Details</h4>
            <table>
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text="Tenant Name"></asp:Label></td>
                <td><asp:TextBox ID="txtTenantName" runat="server"></asp:TextBox></td>
                <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="txtTenantName" errormessage="Required Field!" ForeColor="Red" />--%>
            </tr>
            <tr>
                <td><asp:Label ID="Label2" runat="server" Text="Tenant Mobile Number"></asp:Label></td>
                <td><asp:TextBox ID="txtTenantMobile" runat="server"></asp:TextBox></td>
                <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" controltovalidate="txtTenantMobile" errormessage="Required Field!" />--%>
            </tr>
            <tr>
                <td><asp:Label ID="Label3" runat="server" Text="Tenant Occupation"></asp:Label></td>
                <td><asp:TextBox ID="txtTenantJob" runat="server"></asp:TextBox></td>
                <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator3" controltovalidate="txtTenantJob" errormessage="Required Field!" />--%>
            </tr>
            <tr>
                <td><asp:Label ID="Label4" runat="server" Text="Residence Address"></asp:Label></td>
                <td><asp:TextBox ID="txtTenantResidence" runat="server"></asp:TextBox></td>
                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator4" controltovalidate="txtTenantResidence" errormessage="Required Field!" />
            </tr>
            <tr>
                <td><asp:Label ID="Label5" runat="server" Text="Office Address"></asp:Label></td>
                <td><asp:TextBox ID="txtTenantOffice" runat="server"></asp:TextBox></td>
                <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator5" controltovalidate="txtTenantOffice" errormessage="Required Field!" />--%>
            </tr>
            <tr>
                <td><asp:Label ID="Label6" runat="server" Text="Permanent Address"></asp:Label></td>
                <td><asp:TextBox ID="txtTenantPermAddress" runat="server"></asp:TextBox></td>
                <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator6" controltovalidate="txtTenantPermAddress" errormessage="Required Field!" />--%>
            </tr>
        </table>
        </div>
        <div style="float:left">
           <h4 style="text-align:center"> Father's Details</h4>
            <table>
            <tr>
                <td><asp:Label ID="Label7" runat="server" Text="Father's Name"></asp:Label></td>
                <td><asp:TextBox ID="txtFatherName" runat="server"></asp:TextBox></td>
                <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator7" controltovalidate="txtFatherName" errormessage="Required Field!" />--%>
            </tr>
            <tr>
                <td><asp:Label ID="Label8" runat="server" Text="Father's Mobile Number"></asp:Label></td>
                <td><asp:TextBox ID="txtFatherMobile" runat="server"></asp:TextBox></td>
                <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator8" controltovalidate="txtFatherMobile" errormessage="Required Field!" />--%>
            </tr>
            <tr>
                <td><asp:Label ID="Label9" runat="server" Text="Father's Occupation"></asp:Label></td>
                <td><asp:TextBox ID="txtFatherJob" runat="server"></asp:TextBox></td>
                <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator9" controltovalidate="txtFatherJob" errormessage="Required Field!" />--%>
            </tr>
            <tr>
                <td><asp:Label ID="Label10" runat="server" Text="Residence Address"></asp:Label></td>
                <td><asp:TextBox ID="txtFatherResidence" runat="server"></asp:TextBox></td>
                <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator10" controltovalidate="txtFatherResidence" errormessage="Required Field!" />--%>
            </tr>
            <tr>
                <td><asp:Label ID="Label11" runat="server" Text="Office Address"></asp:Label></td>
                <td><asp:TextBox ID="txtFatherOffice" runat="server"></asp:TextBox></td>
                <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator11" controltovalidate="txtFatherOffice" errormessage="Required Field!" ForeColor="Red" />--%>
            </tr>
            <tr>
                <td><asp:Label ID="Label12" runat="server" Text="Permanent Address"></asp:Label></td>
                <td><asp:TextBox ID="txtFatherPermAddress" runat="server"></asp:TextBox></td>
                <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator12" controltovalidate="txtFatherPermAddress" errormessage="Required Field!" />--%>
            </tr>
        </table>
        </div>
        <div style="float:left">
            <h4 style="text-align:center">Local Guardian's Details</h4>
            <table>
            <tr>
                <td><asp:Label ID="Label13" runat="server" Text="Local Guardian's Name"></asp:Label></td>
                <td><asp:TextBox ID="txtLGName" runat="server"></asp:TextBox></td>
                <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator13" controltovalidate="txtLGName" errormessage="Required Field!" />--%>
            </tr>
            <tr>
                <td><asp:Label ID="Label14" runat="server" Text="Local Guardian's Mobile Number"></asp:Label></td>
                <td><asp:TextBox ID="txtLGMobile" runat="server"></asp:TextBox></td>
                <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator14" controltovalidate="txtLGMobile" errormessage="Required Field!" />--%>
            </tr>
            <tr>
                <td><asp:Label ID="Label15" runat="server" Text="Local Guardian's Occupation"></asp:Label></td>
                <td><asp:TextBox ID="txtLGJob" runat="server"></asp:TextBox></td>
                <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator15" controltovalidate="txtLGJob" errormessage="Required Field!" />--%>
            </tr>
            <tr>
                <td><asp:Label ID="Label16" runat="server" Text="Residence Address"></asp:Label></td>
                <td><asp:TextBox ID="txtLGResidence" runat="server"></asp:TextBox></td>
                <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator16" controltovalidate="txtLGResidence" errormessage="Required Field!" />--%>
            </tr>
            <tr>
                <td><asp:Label ID="Label17" runat="server" Text="Office Address"></asp:Label></td>
                <td><asp:TextBox ID="txtLGOffice" runat="server"></asp:TextBox></td>
                <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator17" controltovalidate="txtLGOffice" errormessage="Required Field!" />--%>
            </tr>
            <tr>
                <td><asp:Label ID="Label18" runat="server" Text="Permanent Address"></asp:Label></td>
                <td><asp:TextBox ID="txtLGPermAddress" runat="server"></asp:TextBox></td>
                <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator18" controltovalidate="txtLGPermAddress" errormessage="Required Field!" />--%>
            </tr>
        </table>
        </div>
        </div>
    </div>  
    <div style="text-align:center" >
        <asp:Label ID="Label20" Text="Rent Amount" runat="server"></asp:Label>
        <asp:TextBox ID="txtTenantRent"  runat="server"></asp:TextBox>
        <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator19" controltovalidate="txtTenantRent" errormessage="Required Field!" />--%>
        <asp:Button ID="Submit" Text="Add New Tenant Details" OnCommand="Add_New_Tenant_Details" runat="server" />
    </div>
</asp:Content>