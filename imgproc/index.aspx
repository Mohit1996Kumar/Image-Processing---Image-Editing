<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="imgproc.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #myimg {
            height: 17px;
            width: 11px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
          <asp:FileUpload id="FileUploadControl" runat="server" />
        <asp:Button runat="server" id="UploadButton" text="Upload" onclick="UploadButton_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        <asp:Image ID="Image1" runat="server" />
        <br />
          <br />
        <br />
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:CheckBox ID="CheckBox1" runat="server" Text="Grayscale" />
          <asp:CheckBox ID="CheckBox2" runat="server" Text="Resize" />
        <br />
        <br />
        <img id="myimg" alt="" src="" runat="server"/>
          <br />
          <br />
          <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Apply Filter" Width="112px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="Button2" runat="server" Text="Download Image" Width="119px" />
          <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
    </div>
    </form>
</body>
</html>
