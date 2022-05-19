<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="Prroject_Web_App.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="container p-3">
        <fieldset>
            <legend>Settings</legend>
            <div class="mb-3">
                <asp:Label ID="lblTheme" CssClass="form-label" runat="server" Text="Theme:"></asp:Label>
                    <asp:DropDownList AutoPostBack="true" ID="ddlTheme" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlTheme_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="0">- select -</asp:ListItem>
                        <asp:ListItem Value="WhiteTheme">White</asp:ListItem>
                        <asp:ListItem Value="DarkTheme">Dark</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label ID="LabelLang" CssClass="form-label" meta:resourcekey="LabelLang" runat="server" Text="Language:"></asp:Label>
                    <asp:DropDownList AutoPostBack="true" ID="DropDownListLang" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlLang_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="0">- select -</asp:ListItem>
                        <asp:ListItem Value="hr">Croatian</asp:ListItem>
                        <asp:ListItem Value="en">English</asp:ListItem>
                </asp:DropDownList>
            </div>
        </fieldset>
    </div>

</asp:Content>
