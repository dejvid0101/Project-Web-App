<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="Prroject_Web_App.Tags" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:Repeater runat="server" ID="rptr2">
        <HeaderTemplate>
            <ul>
                
               
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <%#Eval(nameof(projectLibrary.Models.Tag.Name))%> (<%# Eval(nameof(projectLibrary.Models.Tag.NoOfApartments)) %>)
                </li>
        </ItemTemplate>
        <FooterTemplate>
            
            </ul>
        </FooterTemplate>

    </asp:Repeater>
</asp:Content>
