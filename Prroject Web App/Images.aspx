<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Images.aspx.cs" Inherits="Prroject_Web_App.Images" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
     <div class="row m-3">
        <div class="col-lg-6 ">
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>

                    <table id="tblApt" class="displ">
                        <thead class="thead-dark">
                            <tr>
                                <th scope="col">Oznaka apartmana</th>
                                <th scope="col">Name</th>
                                <th scope="col">Address</th>
                                <th scope="col">Price</th>
                                <th scope="col">Broj soba</th>
                                <th scope="col">Broj osoba</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>

                    <tr>
                        <th scope="row"><%#Eval(nameof(projectLibrary.Models.Apartman.Id)) %></th>
                        <td><%#Eval(nameof(projectLibrary.Models.Apartman.Name)) %></td>
                        <td><%#Eval(nameof(projectLibrary.Models.Apartman.Address)) %></td>
                        <td><%#Eval(nameof(projectLibrary.Models.Apartman.Price)) %>/night</td>
                        <td><%#Eval(nameof(projectLibrary.Models.Apartman.TotalRooms)) %></td>
                        <td><%#Eval(nameof(projectLibrary.Models.Apartman.MaxAdults)) %></td>
                        <td>
                            <asp:LinkButton OnClick="LinkButton1_Click" CommandArgument="<%#Eval(nameof(projectLibrary.Models.Apartman.Id)) %>" class="btn btn-primary" ID="LinkEditApt" runat="server">Edit</asp:LinkButton>

                        </td>




                    </tr>

                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
</table>
                </FooterTemplate>



            </asp:Repeater>

             <fieldset class="border p-4">
                <legend class="w-auto">Add image</legend>
                 <br />
                 <asp:Label ID="LabelAptName" runat="server" Text=""></asp:Label>
                 <br />
                 <asp:FileUpload id="FileUpload1"                 
           runat="server">
       </asp:FileUpload>

                 <asp:Button id="UploadButton" 
           Text="Upload file"
                     OnClick="UploadButton_Click"
           runat="server">
       </asp:Button> 
                 <br />
                 <asp:Label ID="UploadStatusLabel" runat="server" Text="ff"></asp:Label>
                 </fieldset>

        </div>
        <div class="col-lg-6">
            <fieldset class="border p-4">
                <legend class="w-auto">Image editor</legend>
               <asp:Repeater ID="RepeaterImg" runat="server">
                <HeaderTemplate>

                    <table id="tblApt" class="displ">
                        <thead class="thead-dark">
                            <tr>
                                <th scope="col">Images</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>

                    <tr>
                        <th scope="row"><%#Eval(nameof(projectLibrary.Models.Apartman.Id)) %></th>
                        <td>
                            <%#Eval(nameof(projectLibrary.Models.Generic.Name)) %>
                            <asp:LinkButton OnClick="LinkButton1_Click" CommandArgument="<%#Eval(nameof(projectLibrary.Models.Apartman.Id)) %>"
                                class="btn btn-primary" ID="LinkEditApt" runat="server">Edit</asp:LinkButton>
                        </td>
                            

                    </tr>


                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
</table>
                </FooterTemplate>



            </asp:Repeater>
            </fieldset>


        </div>
    </div>
    <script>$(document).ready(function () {
            console.log("fefe");
            $('table.displ').dataTable({ /* ... */ });


        });</script>
</asp:Content>
