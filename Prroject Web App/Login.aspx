<%@ Page Title="" Language="C#" MasterPageFile="/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Prroject_Web_App.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
        
    <div class="row m-3" >
        <div class="col-lg-6 ">
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>

<table id="tblApt" class="display">
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

        </div>
        <div class="col-lg-6">
            <fieldset class="border p-4">
    <legend class="w-auto">Editor</legend>
        <div class="m-3">
            <asp:Label ID="Label2" runat="server" Text="Apt ID (leave empty if adding):"></asp:Label>
    <asp:TextBox  class="form-control" ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="Total rooms:"></asp:Label>
    <asp:TextBox  class="form-control" ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="Adults:"></asp:Label>
    <asp:TextBox  class="form-control" ID="TextBox3" runat="server"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" Text="Children:"></asp:Label>
    <asp:TextBox  class="form-control" ID="TextBox4" runat="server"></asp:TextBox>
            <asp:Label ID="Label6" runat="server" Text="Beach distance:"></asp:Label>
    <asp:TextBox  class="form-control" ID="TextBox5" runat="server"></asp:TextBox>
            <asp:Label ID="LabelOwner" runat="server" Text="Owner:"></asp:Label>
   <div class="row"><div class="col-10"><asp:TextBox  class="form-control" ID="TextBoxOwner" runat="server"></asp:TextBox>
            </div><div class="col-2"><button class="btn btn-primary">Owners</button></div></div>
            <asp:Label ID="LabelCity" runat="server" Text="City:"></asp:Label>
    <div class="row"><div class="col-10"><asp:TextBox  class="form-control" ID="TextBoxCity" runat="server"></asp:TextBox>
           </div><div class="col-2"> <button class="btn btn-primary">City list</button></div></div>
            <asp:Label ID="LabelAddress" runat="server" Text="Address:"></asp:Label>
    <asp:TextBox  class="form-control" ID="TextBoxAddress" runat="server"></asp:TextBox>
            <asp:Label ID="LabelAptName" runat="server" Text="Apt name:"></asp:Label>
    <asp:TextBox  class="form-control" ID="TextBoxAptName" runat="server"></asp:TextBox>
                
                <asp:Button OnClick="Button1_Click" CommandArgument="<%#Eval(TextBox1.Text) %>" ID="ButtonUpdate" runat="server" 
                    CssClass="btn btn-primary mt-3" Text="Update" />
            <asp:LinkButton OnClick="LinkButton2_Click" CommandArgument="<%#Eval(TextBox1.Text) %>" class="btn btn-danger mt-3" ID="LinkButton2" runat="server" Text="Delete"></asp:LinkButton></div>
               
      </fieldset>
        
            
            </div>
</div>
        
       
    <div class="m-3 ">
        <div class="m-3">
            
        <p style="font-size:2rem; font-weight:bold">Edit status:</p></div>
        
      </div>

    <div class="row m-3">
       
        <div class="col-lg-6">
        <asp:Repeater ID="Repeater2" runat="server">
            <HeaderTemplate>

<table id="tblStatus" class="display">
  <thead class="thead-dark"> 
    <tr>
      <th scope="col">Oznaka apartmana</th>
      <th scope="col">Name</th>
      <th scope="col">Status</th>
    </tr>
  </thead>
  <tbody>

            </HeaderTemplate>
            <ItemTemplate>

    <tr>
      <th scope="row"><%#Eval(nameof(projectLibrary.Models.Apartman.Id)) %></th>
      <td><%#Eval(nameof(projectLibrary.Models.Apartman.Name)) %></td>
      <td><%#Eval(nameof(projectLibrary.Models.Apartman.HelperStatus)) %></td>
      <td>
          <asp:LinkButton OnClick="LinkEditStatus_Click" CommandArgument="<%#Eval(nameof(projectLibrary.Models.Apartman.FrontendHelperNameID)) %>" class="btn btn-primary" ID="LinkEditStatus" runat="server">Edit</asp:LinkButton>
         
           </td>
        
        
      
        
    </tr>

            </ItemTemplate>
            <FooterTemplate>
                </tbody>
</table>
</FooterTemplate>
  

  
        </asp:Repeater>

        </div>
        <div class="col-lg-6">
            <fieldset class="border p-4">
    <legend class="w-auto">Editor</legend>
        <div class="m-3">
            <asp:Label ID="Label7" runat="server" Text="Ime apartmana: "></asp:Label>
            <asp:Label ID="LabelName" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label8" runat="server" Text="ID: "></asp:Label>
            <asp:Label ID="LabelID" runat="server" Text=""></asp:Label>

    <asp:DropDownList class="form-select" ID="ddlStatus" runat="server"> 
        <asp:ListItem Selected="True" Value="--odaberi status--"> --odaberi status-- </asp:ListItem>
        <asp:ListItem Selected="False" Value="Zauzeto"> Zauzeto </asp:ListItem>
        <asp:ListItem Selected="False" Value="Rezervirano"> Rezervirano </asp:ListItem>
        <asp:ListItem Selected="False" Value="Slobodno"> Slobodno </asp:ListItem>
        
    </asp:DropDownList>
                  </div>
                <asp:Button OnClick="BtnUpdateStatus_Click" CommandArgument="<%#Eval(TextBox1.Text) %>"
                    ID="BtnUpdateStatus" runat="server" 
                    CssClass="btn btn-primary mt-3" Text="Update" /></div>
      </fieldset>
            
            
          

    </div>
       

    
    <script>
        $(document).ready(function () {
            console.log("fefe");
            $('table.display').dataTable({ /* ... */ });


        });

        function toggle() {
            $('#exampleModal').modal(options)
        }
        function fifi() {

    var tables, sort, i, x, y, tableSort;
    tables = document.getElementById("table");
    sort = true;
    while (sort) {
        sort = false;
        tblrow = tables.rows;
        for (i = 1; i < (tblrow.length); i++) {
            tableSort = false;
            x = tblrow[i].getElementsByTagName("td")[0];
            y = tblrow[i + 1].getElementsByTagName("td")[0];
            if (x.innerHTML.toUpperCase() > y.innerHTML.toUpperCase()) {
                tableSort = true;
                break;
            }
        }
        if (tableSort) {
            tblrow[i].parentNode.insertBefore(tblrow[i + 1], tblrow[i]);
            sort = true;
        }
    }

    
        };

        
    </script>

    
</asp:Content>
