Imports MySql.Data.MySqlClient

Module vbconnection


    ' Database ki details yahan set karein
    Public connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    Public cn As New MySqlConnection(connectionString)
    Public cmd As New MySqlCommand
    Public dr As MySqlDataReader

    ' Yeh woh function hai jo aapke frmLogin ke Load par call ho raha hai
    Public Sub dbconn()
        Try
            If cn.State = ConnectionState.Closed Then
                cn.Open()
                ' Connection check karne ke liye console ya message box use kar sakte hain
                Console.WriteLine("Database Connected Successfully")
            End If
        Catch ex As Exception
            MsgBox("Connection Error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            cn.Close()
        End Try
    End Sub
End Module




