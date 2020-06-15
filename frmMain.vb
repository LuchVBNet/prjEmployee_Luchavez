Public Class frmMain
    Private strZero As String = "0.00"
    Private Sub cmdProcessIt_Click(sender As Object, e As EventArgs) Handles cmdProcessIt.Click
        'declarations
        Dim decMon1, decMon2, decTue1, decTue2, decWed1, decWed2, decThu1, decThu2, decFri1, decFri2, decSat1, decSat2, decSun1, decSun2, decRate, decRegTotal, decRegAmount, decRegOverTotal, decRestTotal, decOverTotal, decOverAmount, decNetPay As Decimal
        'get data from from
        Decimal.TryParse(txtMonday1.Text, decMon1)
        Decimal.TryParse(txtMonday2.Text, decMon2)
        Decimal.TryParse(txtTuesday1.Text, decTue1)
        Decimal.TryParse(txtTuesday2.Text, decTue2)
        Decimal.TryParse(txtWednesday1.Text, decWed1)
        Decimal.TryParse(txtWednesday2.Text, decWed2)
        Decimal.TryParse(txtThursday1.Text, decThu1)
        Decimal.TryParse(txtThursday2.Text, decThu2)
        Decimal.TryParse(txtFriday1.Text, decFri1)
        Decimal.TryParse(txtFriday2.Text, decFri2)
        Decimal.TryParse(txtSaturday1.Text, decSat1)
        Decimal.TryParse(txtSaturday2.Text, decSat2)
        Decimal.TryParse(txtSunday1.Text, decSun1)
        Decimal.TryParse(txtSunday2.Text, decSun2)
        Decimal.TryParse(txtHourlySalary.Text, decRate)
        'computations for hours
        decRegTotal = GetRegHours(decMon1) + GetRegHours(decMon2) + GetRegHours(decTue1) + GetRegHours(decTue2) + GetRegHours(decWed1) + GetRegHours(decWed2) + GetRegHours(decThu1) + GetRegHours(decThu2) + GetRegHours(decFri1) + GetRegHours(decFri2)
        decRegOverTotal = GetOverHours(decMon1) + GetOverHours(decMon2) + GetOverHours(decTue1) + GetOverHours(decTue2) + GetOverHours(decWed1) + GetOverHours(decWed2) + GetOverHours(decThu1) + GetOverHours(decThu2) + GetOverHours(decFri1) + GetOverHours(decFri2)
        decRestTotal = GetRestRegHours(decSat1) + GetRestRegHours(decSat2) + GetRestRegHours(decSun1) + GetRestRegHours(decSun2)
        decOverTotal = decRegOverTotal + decRestTotal
        'computations for amounts
        decRegAmount = decRegTotal * decRate
        decOverAmount = (decRestTotal * 1.3D + decRegOverTotal * 1.25D) * decRate
        decNetPay = decRegAmount + decOverAmount
        'display
        txtRegularHours.Text = decRegTotal.ToString("N2")
        txtRegularAmount.Text = decRegAmount.ToString("N2")
        txtOvertimeHours.Text = decOverTotal.ToString("N2")
        txtOvertimeAmount.Text = decOverAmount.ToString("N2")
        txtNetPay.Text = decNetPay.ToString("N2")
    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        txtEmployeeName.Clear()
        txtEmployeeName.Focus()
        'set to 0.00
        txtHourlySalary.Text = strZero
        txtMonday1.Text = strZero
        txtMonday2.Text = strZero
        txtTuesday1.Text = strZero
        txtTuesday2.Text = strZero
        txtWednesday1.Text = strZero
        txtWednesday2.Text = strZero
        txtThursday1.Text = strZero
        txtThursday2.Text = strZero
        txtFriday1.Text = strZero
        txtFriday2.Text = strZero
        txtSaturday1.Text = strZero
        txtSaturday2.Text = strZero
        txtSunday1.Text = strZero
        txtSunday2.Text = strZero
        txtRegularHours.Text = strZero
        txtRegularAmount.Text = strZero
        txtOvertimeHours.Text = strZero
        txtOvertimeAmount.Text = strZero
        txtNetPay.Text = strZero
    End Sub

    Private Function GetRegHours(decHours As Decimal) As Decimal
        GetRegHours = If(decHours / 8 >= 1, 8, decHours)
    End Function

    Private Function GetOverHours(decHours As Decimal) As Decimal
        GetOverHours = If(decHours / 8 >= 1, decHours - 8, 0)
    End Function

    Private Function GetRestRegHours(decHours As Decimal) As Decimal
        GetRestRegHours = If(decHours / 8 >= 1, 8, decHours)
    End Function

End Class
