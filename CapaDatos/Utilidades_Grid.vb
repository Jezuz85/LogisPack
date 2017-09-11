
Imports System.Web.UI.WebControls

Public Class Utilidades_Grid

    ''' <summary>
    ''' Metodo para obtener el id de la fila de un Gridview
    ''' </summary>
    Public Shared Function Get_IdRow(ByRef GridView1 As GridView, e As GridViewCommandEventArgs, IdControl As String) As String

        Dim RowIndex As Integer = Convert.ToInt32((e.CommandArgument))
        Dim gvrow As GridViewRow = GridView1.Rows(RowIndex)
        Return TryCast(gvrow.FindControl(IdControl), Label).Text

    End Function

    Public Shared Function Get_IdRow_Editing(ByRef GridView1 As GridView, e As GridViewEditEventArgs, IdControl As String) As String

        Dim RowIndex As Integer = Convert.ToInt32((e.NewEditIndex))
        Dim gvrow As GridViewRow = GridView1.Rows(RowIndex)
        Return TryCast(gvrow.FindControl(IdControl), Label).Text

    End Function

    Public Shared Function Get_IdRow_Deleting(ByRef GridView1 As GridView, e As GridViewDeletedEventArgs, IdControl As String) As String

        Dim RowIndex As Integer = Convert.ToInt32((e.AffectedRows))
        Dim gvrow As GridViewRow = GridView1.Rows(RowIndex)
        Return TryCast(gvrow.FindControl(IdControl), Label).Text

    End Function

End Class
