
Imports System.Data
Imports Oracle.ManagedDataAccess.Client

Partial Class OutPutSetting
    Inherits System.Web.UI.Page

    ' ページ読み込み
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

                ' DBからスケジューラーのジョブのパラメータを取得
                Dim sql As String = "SELECT ENABLED, REPEAT_INTERVAL, START_DATE, END_DATE " &
                                      "FROM sys.dba_scheduler_jobs " &
                                     "WHERE JOB_NAME = 'OUTPUT_LOAN_JOB'"
                Dim Cmd As New OracleCommand(sql, Conn)
                Dim da As OracleDataAdapter = New OracleDataAdapter(Cmd)

                ' 取得したパラメータのデータをDataTableに格納
                Dim dt As New DataTable()
                da.Fill(dt)

                ' 有効無効設定をDataTableから取得して設定
                Dim enabled As String = dt.Rows(0).Item("ENABLED").ToString
                If enabled = "TRUE" Then
                    enbabled.Checked = True
                    disabled.Checked = False
                ElseIf enabled = "FALSE" Then
                    enbabled.Checked = False
                    disabled.Checked = True
                End If

                ' REPEAT_INTERVALをDataTableから取得
                Dim repeatStr As String = dt.Rows(0).Item("REPEAT_INTERVAL").ToString

                ' 繰り返し間隔を定義
                Dim freqStr As String

                ' 「;」がREPEAT_INTERVALに含まれているか
                If repeatStr.Contains(";") = True Then
                    Dim repeatArrayData As String() = repeatStr.Split(";"c) ' 「;」で区切りで分割して配列に格納
                    freqStr = repeatArrayData(0)

                    Dim hourStr As String = repeatArrayData(1).Substring(7)
                    HourList.SelectedValue = Integer.Parse(hourStr) ' 出力時間を設定
                    Dim minuteStr As String = repeatArrayData(2).Substring(9)
                    MinuteList.SelectedValue = Integer.Parse(minuteStr) ' 出力分を設定

                Else ' 含まれていなければrepeatStrをそのまま繰り返し間隔として設定
                    freqStr = repeatStr
                End If

                ' 繰り返し間隔を設定
                FreqList.SelectedValue = freqStr.Substring(5)

                ' 開始日をDataTableから取得して設定
                Dim setStartDate As Date = dt.Rows(0).Item("START_DATE")
                StartDate.SelectedDate = setStartDate ' 選択する日付を設定
                EndDate.VisibleDate = setStartDate ' 表示する日付を設定

                ' 終了日をDataTableから取得して設定
                Dim setEndDate As Date = dt.Rows(0).Item("END_DATE")
                EndDate.SelectedDate = setEndDate ' 選択する日付を設定
                EndDate.VisibleDate = setEndDate ' 表示する日付を設定

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

    ' 設定ボタンクリック
    Protected Sub Setting_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles Setting.Click
        ' 有効無効設定を取得
        Dim enbabledStr As String
        If enbabled.Checked = True Then
            enbabledStr = "ENABLE"
        Else
            enbabledStr = "DISABLE"
        End If

        ' 繰り返し間隔を取得
        Dim freqStr As String = FreqList.SelectedValue.ToString

        ' 繰り返し間隔で「日」か「月」を選んでいれば出力時刻を取得
        If freqStr = "MONTHLY" OrElse freqStr = "DAILY" Then
            Dim HourStr As String = HourList.SelectedValue.ToString
            Dim MinuteStr As String = MinuteList.SelectedValue.ToString
            freqStr = freqStr & ";BYHOUR=" & HourStr & ";BYMINUTE=" & MinuteStr & ";BYSECOND=0"
        End If

        ' 開始日を取得
        Dim startDateDate As Date = StartDate.SelectedDate
        ' フォーマット変更してString型にキャスト
        Dim startDateStr As String = startDateDate.ToString("yy-MM-dd")

        ' 終了日を取得
        Dim endDateDate As Date = EndDate.SelectedDate
        ' フォーマット変更してString型にキャスト
        Dim endDateStr As String = endDateDate.ToString("yy-MM-dd")

        ' DB接続情報をweb.configから取得
        Dim conStr As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        'オラクル接続オブジェクト
        Dim Conn As New OracleConnection(conStr)

        Try
            'オラクル接続オープン
            Conn.Open()

            ' スケジューラーのジョブのパラメータを更新
            Dim sql As String = "BEGIN " &
                                "DBMS_SCHEDULER.SET_ATTRIBUTE(" &
                                    "name      => 'OUTPUT_LOAN_JOB', " &
                                    "attribute => 'REPEAT_INTERVAL', " &
                                    "value     => 'FREQ=" & freqStr & "'); " &
                                "DBMS_SCHEDULER.SET_ATTRIBUTE(" &
                                    "name      => 'OUTPUT_LOAN_JOB', " &
                                    "attribute => 'START_DATE', " &
                                    "value     => to_date('" & startDateStr & "')); " &
                                "DBMS_SCHEDULER.SET_ATTRIBUTE(" &
                                    "name      => 'OUTPUT_LOAN_JOB', " &
                                    "attribute => 'END_DATE', " &
                                    "value     => to_date('" & endDateStr & "')); " &
                                "DBMS_SCHEDULER." & enbabledStr & "('sys.OUTPUT_LOAN_JOB'); " &
                                "END;"
            Dim Cmd As New OracleCommand(sql, Conn)
            Cmd.ExecuteReader()

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

        MsgBox("設定が完了しました", MsgBoxStyle.OkOnly, "完了")

    End Sub

End Class
