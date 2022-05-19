<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Prroject_Web_App.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <form class="container p-5" method="post" action="Default.aspx">
  <div class="m-3">
    <asp:Label for="exampleInputEmail1" class="form-label" ID="Label1" runat="server">Username</asp:Label>
    <asp:TextBox  class="form-control" ID="exampleInputEmail1" runat="server"></asp:TextBox>
      </div>
        <div class="m-1">
      <asp:RequiredFieldValidator ControlToValidate="exampleInputEmail1" ID="RequiredFieldValidator1" runat="server" CssClass="alert alert-danger" ErrorMessage="Please enter username"></asp:RequiredFieldValidator>
 
          </div>
  <div class="m-3">
      <asp:Label for="exampleInputPassword1" class="form-label" ID="Label2" runat="server">Password</asp:Label>
    <asp:TextBox TextMode="Password" type="password" class="form-control" ID="exampleInputPassword1" runat="server"></asp:TextBox>
       
  </div>
        <div class="m-1">
        <asp:RequiredFieldValidator ControlToValidate="exampleInputPassword1" ID="RequiredFieldValidator3" runat="server" CssClass="alert alert-danger" ErrorMessage="Please enter password"></asp:RequiredFieldValidator>

          </div>
 <div class="m-3">
  <asp:Button type="submit" class="ml-3 btn btn-primary"  ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
     <div class="m-3">
  <asp:Literal id="lit1" runat="server" />
        </div>
        </div>
</form>
</asp:Content>
