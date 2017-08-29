Imports System.Drawing
Imports System.Web.UI.WebControls


Public Class ControlesDinamicos

    Public Shared Sub CrearLiteral(etiqueta As String, _panel As Panel)
        Dim miLiteral As New Literal()
        miLiteral.Text = etiqueta
        _panel.Controls.Add(miLiteral)

    End Sub

    Public Shared Sub CrearRequiredFieldValidator(_miControl As String, _panel As Panel, _ValidationGroup As String)
        Dim miRequiredFieldValidator As RequiredFieldValidator
        miRequiredFieldValidator = New RequiredFieldValidator()
        miRequiredFieldValidator.ErrorMessage = "<p>Campo Obligatorio!</p>"
        miRequiredFieldValidator.SetFocusOnError = True
        miRequiredFieldValidator.Display = ValidatorDisplay.Dynamic
        miRequiredFieldValidator.ForeColor = ColorTranslator.FromHtml("#B50128")
        miRequiredFieldValidator.Font.Size = 10
        miRequiredFieldValidator.Font.Bold = True
        miRequiredFieldValidator.ControlToValidate = _miControl
        miRequiredFieldValidator.ValidationGroup = _ValidationGroup
        _panel.Controls.Add(miRequiredFieldValidator)

    End Sub

    Public Shared Sub CrearTextbox(ByVal id As String, _panel As Panel, _TextBoxMode As TextBoxMode, Optional ByVal _TextType As String = "text")
        Dim miTextBox As TextBox
        miTextBox = New TextBox()
        miTextBox.ID = id
        miTextBox.CssClass = "form-control"
        miTextBox.TextMode = _TextBoxMode
        If _TextBoxMode = TextBoxMode.MultiLine Then
            miTextBox.Rows = 3

        End If
        miTextBox.Attributes.Add("type", _TextType)
        _panel.Controls.Add(miTextBox)

    End Sub

    Public Shared Function CrearDropDownList(id As String, _panel As Panel, _DropDownList As DropDownList) As DropDownList

        _DropDownList.ID = id
        _DropDownList.CssClass = "form-control"

        _panel.Controls.Add(_DropDownList)

        Return _DropDownList
    End Function



End Class
