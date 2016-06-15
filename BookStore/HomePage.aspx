<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="BookStore.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.10.2.min.js"></script>

   
</head>
<body>
    <form id="form1" runat="server" style="background-color:#BCD4EC" >
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add New" />
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" OnClientClick="return ConfirmYesNo();" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <br />
        <br />
    </div>
        <asp:Image ID="Image1" runat="server" Height="102px" Width="197px" />
        <asp:Panel ID="Panel1" runat="server" Height="553px">
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:Table ID="myTable" runat="server" style="cursor: pointer;" Width="100%" BackColor='#BCD4EC'> 
    <asp:TableRow  ID="trow" runat="Server">
        <asp:TableCell visible="false" runat="Server">ID</asp:TableCell>
        <asp:TableCell runat="Server">Image</asp:TableCell>
        <asp:TableCell runat="Server">BookName</asp:TableCell>
        <asp:TableCell runat="Server">Author</asp:TableCell>
        <asp:TableCell runat="Server" >Price</asp:TableCell>
        </asp:TableRow>


       
   
</asp:Table>  
             <script>

               
function myFunction() {
    alert("Hit");
}

var tbl = document.getElementById("myTable");
var cid = 0;
document.getElementById('btnDelete').style.visibility = 'hidden';
if (tbl != null) {
    for (var i = 0; i < tbl.rows.length; i++) {
        for (var j = 0; j < tbl.rows[i].cells.length; j++) {
            tbl.rows[i].cells[j].onclick = function () { getval(this); };
          //  debugger;
             cid = i
            ;
        }
    }
}





function getval(cel) {
  //  alert(cel.innerHTML);
    var table = document.getElementById('myTable');
    for (var i = 0; i < table.rows.length; i++) {
        table.rows[i].onclick = function high() {
            if (!this.hilite) {
               // debugger;
                var ronindex = tbl.rows[this.rowIndex].cells[2].innerHTML;
                document.getElementById('<%=HiddenField1.ClientID%>').value = this.rowIndex;
             //   alert(ronindex);

                unhighlight();
                
                this.origColor = '#FF0000' ;//this.style.backgroundColor;
                this.style.backgroundColor = '#FF0000'; //'#BCD4EC';
                this.hilite = true;
            }
            else {
                this.style.backgroundColor = '#BCD4EC';
                this.hilite = false;
            }
        }



    }

 
   // debugger;
   // var cid = tbl.rows[i].cells[0].innerHTML;
  //  alert(tbl.rows[cid].cells[1].innerHTML);
    document.getElementById('btnDelete').style.visibility = 'visible';
   // tbl.rows[i].cells[j].style.backgroundColor = '#BCD4EC';
    document.getElementById('btnDelete').style.backgroundColor = '#BCD4EC';




   

}

                 function ConfirmYesNo() {
              
                     if (confirm("Are you sure?") == true) {
                         return true;
                     }
                     else {
                         document.getElementById('Label1').innerHTML = '';
                         alert("You have Cancelled the Operation.");
                         return false;
                     }
                 }


function unhighlight() {
    //debugger;
    var table = document.getElementById('myTable');
    for (var i = 0; i < table.rows.length; i++) {
        var row = table.rows[i];
        row.style.backgroundColor = '#BCD4EC';
        row.hilite = false;
    }
}
      //  debugger;
      

        </script>

        </asp:Panel>
    </form>
</body>
</html>
