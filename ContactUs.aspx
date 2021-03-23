<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="ContactUs1.ContactUs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/MyStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Contact Us Form</h1>
            <table>
                <tr>
                    <td>
                        <label>First Name</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input runat="server" id="inputFirstName" class="input" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Last Name</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input runat="server" id="inputLastName" class="input" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Email</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input runat="server" id="inputEmail" class="input" />
                        <label runat="server" id="lblInvalidEmail" visible="false" class="errorMsg">Invalid Email Address</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Message</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <textarea runat="server" id="taMessage" class="input message"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <button runat="server" id="btnSubmit">SUBMIT</button>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
