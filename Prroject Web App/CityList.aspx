<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CityList.aspx.cs" Inherits="Prroject_Web_App.CityList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:Repeater runat="server" ID="rptrCity">
        <HeaderTemplate>
            <ul>
                
               
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <%#Eval(nameof(projectLibrary.Models.Generic.Name))%> id: <%# Eval(nameof(projectLibrary.Models.Generic.Id)) %>
                </li>
        </ItemTemplate>
        <FooterTemplate>
            
            </ul>
        </FooterTemplate>

    </asp:Repeater>
</asp:Content>
