
Imports System.Web.UI.WebControls

Public Class Utilidades_Grid

    Public Shared Function Get_IdRow(ByRef GridView1 As GridView, e As GridViewCommandEventArgs, IdControl As String) As String

        Dim RowIndex As Integer = Convert.ToInt32((e.CommandArgument))
        Dim gvrow As GridViewRow = GridView1.Rows(RowIndex)
        Return TryCast(gvrow.FindControl(IdControl), Label).Text

    End Function

End Class
