Public Class frmMain

    Private Const TAX As Double = 0.05
    Private Shared subTotal As Double = 0,
        salesTax As Double = 0,
        shipping As Double = 6.5,
        total As Double = 0

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        subTotal += Val(txtPrice.Text)
        salesTax = subTotal * TAX
        If subTotal >= 100 Then shipping = 0
        total = subTotal + salesTax + shipping

        txtSubtotal.Text = Currency(subTotal)
        txtTax.Text = Currency(salesTax)
        txtShipping.Text = Currency(shipping)
        txtTotal.Text = Currency(total)
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub txtPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or Asc(e.KeyChar) = 8 Or e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrice_Enter(sender As Object, e As EventArgs) Handles txtPrice.Enter, txtPrice.Click
        txtPrice.SelectAll()
    End Sub

    Private Function Currency(expression As Double) As String
        Return Format(expression, "$#,##0.00")
    End Function

End Class
