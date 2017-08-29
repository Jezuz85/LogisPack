
Imports System.Text

Public Class Cifrar

    Public Shared Function cifrarCadena(mensaje As String) As String
        Dim result As String = String.Empty
        Dim encrypted As Byte() = Encoding.Unicode.GetBytes(mensaje)
        result = Convert.ToBase64String(encrypted)
        Return result

    End Function


    Public Shared Function descifrarCadena(mensaje As String) As String
        Dim result As String = String.Empty
        Dim decrypted As Byte() = Convert.FromBase64String(mensaje)
        result = Encoding.Unicode.GetString(decrypted)
        Return result

    End Function



End Class
