<%@ Page Language="C#" MasterPageFile="~/SilverTixHome.master" AutoEventWireup="true"
    CodeFile="Testing.aspx.cs" Inherits="_Testing" Title="Testing Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <script type="text/javascript" src="http://code.jquery.com/jquery-1.5.2.js"></script>

    <script type="text/javascript">
        
        $('li').hover(function(){
            $(this).fadeOut(100);
            $(this).fadeIn(500);
        });
        
        $(".fade").hover(
            function(){
                $(this).append($("<span> ***</span>"));
            },
            function(){
                $(this).find("span:last").remove();
            }
        );
    });
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <table>
        <tr>
            <td>
                <a href="http://jquery.com/">jQuery</a>
                <br />
                <br />
                <span>Boo</span>
                <ul>
                    <li>Milk</li>
                    <li>Bread</li>
                    <li class="fade">Chips</li>
                    <li class="fade">Socks</li>
                </ul>
            </td>
        </tr>
    </table>
  
</asp:Content>
