<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Alert.ascx.vb" Inherits="LogisPack.Alert" %>

<asp:PlaceHolder ID="AlertExito" runat="server" Visible="false">
    <div class="alert alert-success">
        <asp:Label ID="lbAlertMsjExito" runat="server" Text="Label"></asp:Label>
    </div>

</asp:PlaceHolder>

<asp:PlaceHolder ID="AlertFalla" runat="server" Visible="false">
    <div class="alert alert-danger">
        <asp:Label ID="lbAlertMsjFalla" runat="server" Text="Label"></asp:Label>
    </div>
</asp:PlaceHolder>
