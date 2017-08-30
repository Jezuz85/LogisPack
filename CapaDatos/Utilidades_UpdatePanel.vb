Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class Utilidades_UpdatePanel

    Public Shared Sub LimpiarControles(_UpdatePanel As UpdatePanel)

        For Each _control As Control In _UpdatePanel.ContentTemplateContainer.Controls

            If _control IsNot Nothing Then
                If _control.GetType() Is GetType(TextBox) Then
                    CType(_control, TextBox).Text = Nothing
                ElseIf _control.GetType() Is GetType(DropDownList) Then
                    CType(_control, DropDownList).SelectedValue = ""
                ElseIf _control.GetType() Is GetType(CheckBox) Then
                    CType(_control, CheckBox).Checked = False
                ElseIf _control.GetType() Is GetType(ListBox) Then
                    CType(_control, ListBox).Items.Clear()
                ElseIf _control.GetType() Is GetType(RadioButton) Then
                    CType(_control, RadioButton).Checked = False
                End If
            End If

        Next

    End Sub


End Class
