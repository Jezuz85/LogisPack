
Public Class Comandos

    Public Sub Comandos()

    End Sub

    Public Function Arbol_Almacen_Nivel0() As String
        Return "SELECT Count(id_almacen), id_cliente ID , 'Cliente:' + cast(id_cliente as varchar)  Name FROM Almacen Group By id_cliente"
    End Function

    Public Function Arbol_Almacen_Nivel1() As String
        Return "SELECT (codigo +' '+ nombre) Name, id_almacen ID FROM Almacen WHERE id_cliente = "
    End Function

    Public Function Arbol_Almacen_Nivel2() As String
        Return "SELECT 'Articulo: '+nombre Name, id_articulo ID FROM Articulo WHERE id_almacen ="
    End Function

End Class
