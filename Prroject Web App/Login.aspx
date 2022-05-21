<%@ Page Title="" Language="C#" MasterPageFile="/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Prroject_Web_App.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
        
    <div class="row">
        <div class="col-md-6">
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>

<table id="table" class="table">
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
         <asp:LinkButton ID="LinkButton1" CommandArgument="<%#Eval(nameof(projectLibrary.Models.Apartman.Id)) %>" OnClick="LinkButton1_Click" runat="server">
             Edit
             </asp:LinkButton>
           </td>
        
        
      
        
    </tr>

            </ItemTemplate>
            <FooterTemplate>
                </tbody>
</table>
</FooterTemplate>
  

  
        </asp:Repeater>

        </div>
        <div class="col-md-6">
        <asp:GridView ID="GridView1" AutoGenerateColumns="false" CssClass="tbl" runat="server">
            <Columns>
<asp:BoundField HeaderText/>

            </Columns>

        </asp:GridView>
        
            </div>
</div>
        
       
    </div>
    <div class="m-3 mt-5">
        <div class="m-3">
        <p style="font-size:5rem; font-weight:bold">fefe:</p></div>
        <div class="m-3">
    <asp:TextBox  class="form-control" ID="exampleInputEmail1" runat="server"></asp:TextBox></div>
      </div>





    
    <script>
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
