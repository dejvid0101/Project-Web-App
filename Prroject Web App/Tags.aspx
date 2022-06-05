<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="Prroject_Web_App.Tags" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="row">
        <div class="col-lg-6">
            
    <asp:Repeater runat="server" OnItemDataBound="rptr2_ItemDataBound" ID="rptr2">
        <HeaderTemplate>
            <ul>
                
               
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                
                 <asp:Label ID="fefe" runat="server" Visible="false" 
                    Text="<%# Eval(nameof(projectLibrary.Models.Tag.NoOfApartments))
                        %>"></asp:Label>

                <%#Eval(nameof(projectLibrary.Models.Tag.Name))%>
                (<%# Eval(nameof(projectLibrary.Models.Tag.NoOfApartments)) %>)
               

                <asp:LinkButton ID="btnDeleteTag" OnClientClick="return confirm('Are you sure?')"
                    CommandArgument="<%#Eval(nameof(projectLibrary.Models.Tag.Name))%>" 
                    OnClick="btnDeleteTag_Click" style="text-decoration:underline" Text=" - delete" 
                    runat="server"></asp:LinkButton>

                
                
                </li>
           
        </ItemTemplate>
        <FooterTemplate>
            
            </ul>
        </FooterTemplate>

    </asp:Repeater>
            </div>
        <div class="col-lg-6">
            <fieldset class="border p-4">
                <legend class="w-auto">Add tags</legend><br />
            <asp:Label ID="Label6" runat="server" Text="Tag:"></asp:Label>
                    <asp:TextBox class="form-control" ID="TextBoxTag" runat="server"></asp:TextBox>
                    <asp:Label ID="LabelOwner" runat="server" Text="Tag type ID:"></asp:Label>
                    <div class="row">
                        <div class="col-10">
                            <asp:TextBox class="form-control" ID="TextBoxTypeID" runat="server"></asp:TextBox>
                        </div>
                        
        </div>
                
            <asp:LinkButton ID="btnAddTag" OnClick="btnAddTag_Click" CssClass="btn btn-warning mt-3" 
                CommandArgument="<%#Eval(nameof(projectLibrary.Models.Tag.Name))%>" 
                Text="Add" runat="server"></asp:LinkButton>
                
             <asp:Repeater runat="server" ID="rptrTagType">
        <HeaderTemplate>
            <ul class="mt-3">
                
               
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                
                <%#Eval(nameof(projectLibrary.Models.Generic.Name))%>, id: <%# Eval(nameof(projectLibrary.Models.Generic.Id)) %>
                </li>
        </ItemTemplate>
        <FooterTemplate>
            
            </ul>
        </FooterTemplate>

    </asp:Repeater>
                </fieldset>
            </div>
                </div>

</asp:Content>
