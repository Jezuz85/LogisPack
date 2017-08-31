
Imports System.Web
Imports System.Web.UI.WebControls

Public Class Utilidades_Fileupload

    Public Shared Function Subir_Archivos(ByRef _archivo As HttpPostedFile, ruta As String, nombre As String) As String

        Dim fileExtension As String = "." + _archivo.FileName.Substring(_archivo.FileName.LastIndexOf(".") + 1).ToLower()
        Dim rutaImagen As String = HttpContext.Current.Server.MapPath(ruta) & nombre & fileExtension
        _archivo.SaveAs(rutaImagen)

        Return ruta & nombre & fileExtension

    End Function


    Public Shared Function Subir_Archivo(ByRef _archivo As FileUpload, ruta As String, nombre As String) As String

        Dim fileExtension As String = "." + _archivo.FileName.Substring(_archivo.FileName.LastIndexOf(".") + 1).ToLower()
        Dim rutaImagen As String = HttpContext.Current.Server.MapPath(ruta) & nombre & fileExtension
        _archivo.SaveAs(rutaImagen)

        Return ruta & nombre & fileExtension

    End Function

End Class
