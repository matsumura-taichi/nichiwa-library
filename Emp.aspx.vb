
Imports Oracle.ManagedDataAccess.Client

Partial Class Emp
    Inherits System.Web.UI.Page

    Private Sub Page_Load(sender As Object, e As EventArgs) _
 Handles Me.Load

        If IsPostBack = False Then

            ' DB接続情報をweb.configから取得
            Dim conStr As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
            'オラクル接続オブジェクト
            Dim Conn As New OracleConnection(conStr)

            Try
                'オラクル接続オープン
                Conn.Open()

                ' SQL発行して結果を取得
                Dim sql As String = "SELECT * FROM EMP ORDER BY EMP_NO"
                Dim Cmd As New OracleCommand(sql, Conn)
                Dim dr As OracleDataReader = Cmd.ExecuteReader()

                ' 結果をDataSourceに設定してバインド
                Grid_Emps.DataSource = dr
                Grid_Emps.DataBind()

                'オラクル接続クローズ
                Conn.Close()
            Catch exora As OracleException
                'オラクルエラー
                MsgBox(exora.Number & ":" & exora.Message)
            Catch ex As Exception
                'PGエラー
                MsgBox(ex.Message)
            Finally
                Conn.Dispose()
            End Try
        End If

    End Sub

End Class
