Imports System.Web.UI

Public Class Modal


    Public Shared Sub MostrarMsjModal(msj As String, tipo As String, _page As Page)

        Dim sTitulo As String = "Información"
        Dim sCcsClase As String = "fa fa-check fa-2x text-info"
        Select Case tipo
            Case "ERR"
                sTitulo = "ERROR"
                sCcsClase = "fa fa-times fa-2x text-danger"
                    ' break;
            Case "ADV"
                sTitulo = "ADVERTENCIA"
                sCcsClase = "fa fa-exclamation-triangle fa-2x text-warning"
                    ' break;
            Case "EXI"
                sTitulo = "ÉXITO"
                sCcsClase = "fa fa-check fa-2x text-success"
                ' break;

        End Select

        ScriptManager.RegisterStartupScript(_page, GetType(Page), "MostrarMsjModal", "MostrarMsjModal('" & msj.Replace("'", "").Replace("" & vbCrLf & "", " ") & "','" & sTitulo & "','" & sCcsClase & "');", True)

    End Sub
    Public Shared Sub CerrarModal(nombreModal As String, nombreScript As String, _page As Page)
        ScriptManager.RegisterStartupScript(_page, GetType(Page), nombreScript, "$('#" & nombreModal & "').modal('hide');", True)
    End Sub
    Public Shared Sub AbrirModal(nombreModal As String, nombreScript As String, _page As Page)
        ScriptManager.RegisterStartupScript(_page, GetType(Page), nombreScript, "$('#" & nombreModal & "').modal('show');", True)
    End Sub


    Public Shared Sub ModalAddRegistroExito(_page As Page)
        MostrarMsjModal("Registro agregado con Éxito", "EXI", _page)

    End Sub
    Public Shared Sub ModalEditRegistroExito(_page As Page)
        MostrarMsjModal("Registro actualizado con Éxito", "EXI", _page)

    End Sub
    Public Shared Sub ModalAddRegistroFallo(_page As Page)
        MostrarMsjModal("Error al insertar el registro", "ERR", _page)

    End Sub
    Public Shared Sub ModalEditRegistroFallo(_page As Page)
        MostrarMsjModal("Error al actualizar el registro", "ERR", _page)

    End Sub
    Public Shared Sub ModalDeleteRegistroExito(_page As Page)
        MostrarMsjModal("Registro eliminado con Éxito", "EXI", _page)

    End Sub
    Public Shared Sub ModalDeleteRegistroFallo(_page As Page)
        MostrarMsjModal("Error al eliminar el registro", "ERR", _page)

    End Sub

    Public Shared Sub Validacion(_page As Page, bError As Boolean, tipo As String)
        If tipo = "Add" Then
            If bError = True Then
                ModalAddRegistroExito(_page)

            Else
                ModalAddRegistroFallo(_page)

            End If
        ElseIf tipo = "Edit" Then
            If bError = True Then
                ModalEditRegistroExito(_page)

            Else
                ModalEditRegistroFallo(_page)

            End If
        ElseIf tipo = "Delete" Then
            If bError = True Then
                ModalDeleteRegistroExito(_page)

            Else
                ModalDeleteRegistroFallo(_page)

            End If
        End If

    End Sub

End Class
