<%@ Page Title="Face Shape Guide" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="FaceGuide.aspx.cs" Inherits="faceShape" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Face Shape Guide
    </h2>
    <table> <!-- style="border:1px solid black;" --> 
        <tr >
            <td><img src="Images/Face Shapes/rectangularFace.png" width="150" height="150" alt="" /></td>
            <td><p><font face="Comic Sans MS, Verdana" size="9" color="#78bae5">
Rectangular
</font></p><br /><span class="boldBlack">Facial Description:</span> You have a broad forehead, strong jaw line, and a square chin. <br />
                   <span class="boldBlack">Recommmended:</span> Round, oval, butterfly or cat shaped frames. These will highlight your best features, such as your broad cheekbones and strong jaw line.
            </td>
        </tr>
        <tr>
            <td><br /><img src="Images/Face Shapes/roundFace.png" width="150" height="150" alt="" /></td>
            <td><p><font face="Comic Sans MS, Verdana" size="9" color="#78bae5">
Round
</font></p><span class="boldBlack">Facial Description:</span> Full cheeks, and a rounder chin. <br />
                  <span class="boldBlack">Recommmended:</span> Angular frames such as rectangular or triangular in shape. This will give your face the appearance that it is longer and narrower.
            </td>
        </tr>
        <tr>
            <td><br /><img src="Images/Face Shapes/diamondFace.png" width="150" height="150" alt="" /></td>
            <td><p><font face="Comic Sans MS, Verdana" size="9" color="#78bae5">
Diamond
</font></p><span class="boldBlack">Facial Description:</span> Narrow at the eye line and jaw line, as well as a small forehead and chin, but more pronounced cheekbones. <br />
                   <span class="boldBlack">Recommmended:</span> Oval frames to create a balanced look, or upswept styles such as the cat eye, and also rimless styles that gives emphasis on the cheekbones.
            </td>
        </tr>
        <tr>
            <td><br /><img src="Images/Face Shapes/triangularFace.png" width="150" height="150" alt="" /></td>
            <td><p><font face="Comic Sans MS, Verdana" size="9" color="#78bae5">
Triangular
</font></p><span class="boldBlack">Facial Description:</span> You have a prominent jaw line which narrows at the cheekbone and temples. <br />
                   <span class="boldBlack">Recommmended:</span> Semi-rimless, heavily accented or top-heavy styles. This will emphasize the upper portion of your face.
            </td>
        </tr>
        <tr>
            <td><br /><img src="Images/Face Shapes/ovalFace.png" width="150" height="150" alt="" /></td>
            <td><p><font face="Comic Sans MS, Verdana" size="9" color="#78bae5">
Oval
</font></p><span class="boldBlack">Facial Description:</span> Your chin is a little narrower than your forehead and your cheekbones are high. <br />
                    <span class="boldBlack">Recommmended:</span> Anything will look good on your face, from rectangular shapes which add angles to soft curves, to oval frames to maintain balance.
            </td>
        </tr>
    </table><br /><br />
</asp:Content>
