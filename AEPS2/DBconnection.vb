Imports System
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks



Public Class DBconnection
    Dim conn As New SqlConnection("Server=DESKTOP-2DT9OML;Database=HabibUniveristy;Integrated Security = true")
    Dim cmd As New SqlCommand

    Public Sub InsertQuery(ByVal query As String)
        conn.Open()
        cmd.CommandText = query
        cmd.Connection = conn
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub
    'System.Data.SqlClient.SqlException 'Unknown object type 'ElectionRecord2019' used in a CREATE, DROP, or ALTER statement.'

    Public Sub CreateQuery(ByVal query As String)
        'cmd = New SqlCommand(query, conn)
        conn.Open()
        cmd.CommandText = query
        cmd.Connection = conn
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub

    Public Function SelectQuery(ByVal query As String) As DataTable
        conn.Open()
        cmd.CommandText = query
        cmd.Connection = conn
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        conn.Close()
        Return dt
    End Function
End Class
