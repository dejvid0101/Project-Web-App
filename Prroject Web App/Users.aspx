<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Prroject_Web_App.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:Repeater runat="server" ID="rptrOwner">
        <HeaderTemplate>
            <ul>
                
               
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                Id: <%#Eval(nameof(projectLibrary.Models.Generic.Id))%>, email: <%# Eval(nameof(projectLibrary.Models.Generic.Name)) %>
                </li>
        </ItemTemplate>
        <FooterTemplate>
            
            </ul>
        </FooterTemplate>

    </asp:Repeater>

</asp:Content>
