
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub LinkLoan_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles LinkLoan.Click
        Me.Response.Redirect("~/Loan.aspx")
    End Sub

    Protected Sub LinkBook_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles LinkBook.Click
        Me.Response.Redirect("~/Book.aspx")
    End Sub

    Protected Sub LinkEmp_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles LinkEmp.Click
        Me.Response.Redirect("~/Emp.aspx")
    End Sub

End Class