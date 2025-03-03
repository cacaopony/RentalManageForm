Imports MySql.Data.MySqlClient

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'データベースサーバの接続情報
        Const DB_Server As String = "127.0.0.1"
        Const DB_Port As String = "3306"
        Const DB_Name As String = "sakila"
        Const User_Id As String = "root"
        Const User_Pw As String = "mysql"
        Dim ConnectionString As String =
            "Server=" & DB_Server & ";" _
            & "Port=" & DB_Port & ";" _
            & "Database=" & DB_Name & ";" _
            & "User ID=" & User_Id & ";" _
            & "Password=" & User_Pw & ";"

        Dim Sql As String =
            "SELECT sakila.rental.rental_id, sakila.customer.first_name, sakila.customer.last_name, sakila.film.title, sakila.rental.rental_date, sakila.rental.return_date, sakila.customer.email " _
            & "FROM sakila.rental " _
            & "inner join sakila.customer " _
            & "ON sakila.rental.customer_id = sakila.customer.customer_id " _
            & "inner join sakila.inventory " _
            & "on sakila.rental.inventory_id = sakila.inventory.inventory_id " _
            & "inner join sakila.film ON sakila.inventory.film_id = sakila.film.film_id " _
            & "order by sakila.rental.rental_date asc;"
        Dim dt As New DataTable()

        Try
            Using Conn As MySqlConnection = New MySqlConnection(ConnectionString)
                Conn.Open()
                Using cmd As MySqlCommand = New MySqlCommand(Sql, Conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        dt.Load(reader) ' DataTable にデータを読み込む
                    End Using
                End Using
            End Using

            ' Form2 を開いてデータを渡す
            Dim newForm As New Form2(dt)
            newForm.Show()
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

End Class
