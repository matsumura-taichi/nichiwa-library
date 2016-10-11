
Imports Oracle.ManagedDataAccess.Client

Partial Class Loan
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
                Dim sql As String = "SELECT L.LOAN_NO, B.BOOK_NAME, E.EMP_NAME, L.LENT_DATE, L.RETURN_DATE " &
                                      "FROM LOAN L " &
                                 "LEFT JOIN BOOKS B " &
                                        "ON L.BOOK_NO = B.BOOK_NO " &
                                 "LEFT JOIN EMP E " &
                                        "ON L.EMP_NO = E.EMP_NO " &
                                  "ORDER BY L.LOAN_NO"
                Dim Cmd As New OracleCommand(sql, Conn)
                Dim dr As OracleDataReader = Cmd.ExecuteReader()

                ' 結果をDataSourceに設定してバインド
                Grid_Loans.DataSource = dr
                Grid_Loans.DataBind()

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

    Protected Sub LinkLoanAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles LinkLoanAdd.Click
        Me.Response.Redirect("~/logs")
    End Sub

    Protected Sub LinkOutPutSetting_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles LinkOutPutSetting.Click
        Me.Response.Redirect("~/OutPutSetting.aspx")
    End Sub

End Class
