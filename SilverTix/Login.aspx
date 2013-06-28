<%@ Page Language="C#" MasterPageFile="~/SilverTixHome.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Login" Title="Login or Register" %>

<asp:Content ID="cphHeadRegister" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="cphMainRegister" ContentPlaceHolderID="cphMain" Runat="Server">
<div class="locationWrapper">
    <div class="loginContent">
        <h1>
            Login
        </h1>
        <table>
            <tr>
                <td align="right">
                    <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" MaxLength="20" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUserName"
                        Display="Dynamic" ErrorMessage="Username is required." ValidationGroup="vgLogin"
                        Font-Size="14px">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" MaxLength="20" TextMode="Password" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                        Display="Dynamic" ErrorMessage="Password is required." ValidationGroup="vgLogin"
                        Font-Size="14px">*</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvInvalidLogin" runat="server" Display="None" ErrorMessage="Invalid username or password."
                        ValidationGroup="vgLogin"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td />
                <td>
                    <asp:CheckBox ID="ckRememberMe" runat="server" Text="Remember Me?" />
                </td>
            </tr>
            <tr>
                <td />
                <td>
                    <asp:HyperLink ID="hlForgotPassword" runat="server" NavigateUrl="~/ForgottenPassword.aspx"
                        CssClass="noTextDec">Forgotten Password?</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right;">
                    <asp:Button ID="btnLogin" runat="server" Text="Sign in"
                        ValidationGroup="vgLogin" OnClick="btnLogin_Click" />
                </td>
            </tr>
        </table>
        
    </div>
    <div class="loginContent" style="border-left: 1px solid #a24000;">
        <div style="margin-left: 30px;">
            <h1>
                Register
            </h1>
            <asp:CreateUserWizard ID="cuwSignUp" runat="server" ContinueDestinationPageUrl="~/Home.aspx" LoginCreatedUser="false" 
                OnCreatedUser="cuwSignUp_CreatedUser">
                <WizardSteps>
                    <asp:CreateUserWizardStep runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User 
                                        Name:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                            ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                            ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                            ControlToValidate="Password" ErrorMessage="Password is required." 
                                            ToolTip="Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="ConfirmPasswordLabel" runat="server" 
                                            AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" 
                                            ControlToValidate="ConfirmPassword" 
                                            ErrorMessage="Confirm Password is required." 
                                            ToolTip="Confirm Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                                            ControlToValidate="Email" ErrorMessage="E-mail is required." 
                                            ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Security 
                                        Question:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" 
                                            ControlToValidate="Question" ErrorMessage="Security question is required." 
                                            ToolTip="Security question is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Security 
                                        Answer:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" 
                                            ControlToValidate="Answer" ErrorMessage="Security answer is required." 
                                            ToolTip="Security answer is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:CompareValidator ID="PasswordCompare" runat="server" 
                                            ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                            Display="Dynamic" 
                                            ErrorMessage="The Password and Confirmation Password must match." 
                                            ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color:Red;">
                                        <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:CreateUserWizardStep>
                    <asp:CompleteWizardStep runat="server" />
                </WizardSteps>
            </asp:CreateUserWizard>
        </div>
    </div>
</div>
</asp:Content>

