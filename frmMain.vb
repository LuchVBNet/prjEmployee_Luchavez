Public Class frmMain
    'class-level declarations
    Private Const decRegHours As Decimal = 8
    Private decMon1, decMon2, decTue1, decTue2, decWed1, decWed2, decThu1, decThu2, decFri1, decFri2, decSat1, decSat2, decSun1, decSun2, decRate, decRegTotal, decRegAmount, decOverTotal, decOverAmount, decNetPay As Decimal

    Private Sub press_Enter(sender As Object, e As KeyPressEventArgs) Handles txtWednesday2.KeyPress, txtWednesday1.KeyPress, txtTuesday2.KeyPress, txtTuesday1.KeyPress, txtThursday2.KeyPress, txtThursday1.KeyPress, txtSunday2.KeyPress, txtSunday1.KeyPress, txtSaturday2.KeyPress, txtSaturday1.KeyPress, txtMonday2.KeyPress, txtMonday1.KeyPress, txtHourlySalary.KeyPress, txtFriday2.KeyPress, txtFriday1.KeyPress, txtEmployeeName.KeyPress
        If (e.KeyChar = ChrW(Keys.Enter)) Then
            cmdProcessIt.PerformClick()
        End If
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetInputs()
        FormatInputsOutputs()
    End Sub

    Private Sub cmdProcessIt_Click(sender As Object, e As EventArgs) Handles cmdProcessIt.Click
        'declarations
        Dim decRegOverTotal, decRestTotal As Decimal
        'get data from form
        GetInputs()
        'computations for hours
        decRegTotal = GetRegHours(decMon1) + GetRegHours(decMon2) + GetRegHours(decTue1) + GetRegHours(decTue2) + GetRegHours(decWed1) + GetRegHours(decWed2) + GetRegHours(decThu1) + GetRegHours(decThu2) + GetRegHours(decFri1) + GetRegHours(decFri2)
        decRegOverTotal = GetOverHours(decMon1) + GetOverHours(decMon2) + GetOverHours(decTue1) + GetOverHours(decTue2) + GetOverHours(decWed1) + GetOverHours(decWed2) + GetOverHours(decThu1) + GetOverHours(decThu2) + GetOverHours(decFri1) + GetOverHours(decFri2)
        decRestTotal = GetRegHours(decSat1) + GetRegHours(decSat2) + GetRegHours(decSun1) + GetRegHours(decSun2)
        decOverTotal = decRegOverTotal + decRestTotal
        'computations for amounts
        decRegAmount = decRegTotal * decRate
        decOverAmount = (decRestTotal * 1.3D + decRegOverTotal * 1.25D) * decRate
        decNetPay = decRegAmount + decOverAmount
        'display
        FormatInputsOutputs()
    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        txtEmployeeName.Clear()
        txtEmployeeName.Focus()
        'set to 0.00
        GetInputs()
        FormatInputsOutputs()
    End Sub

    Private Sub GetInputs()
        Decimal.TryParse(txtHourlySalary.Text, decRate)
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
        'Clean Inputs
        CleanInputs()
    End Sub

    Private Sub CleanInputs()
        RemoveExcessiveHours(decMon1)
        RemoveExcessiveHours(decMon2)
        RemoveExcessiveHours(decTue1)
        RemoveExcessiveHours(decTue2)
        RemoveExcessiveHours(decWed1)
        RemoveExcessiveHours(decWed2)
        RemoveExcessiveHours(decThu1)
        RemoveExcessiveHours(decThu2)
        RemoveExcessiveHours(decFri1)
        RemoveExcessiveHours(decFri2)
        RemoveExcessiveHours(decSat1)
        RemoveExcessiveHours(decSat2)
        RemoveExcessiveHours(decSun1)
        RemoveExcessiveHours(decSun2)
    End Sub

    Private Sub RemoveExcessiveHours(ByRef decHours As Decimal)
        decHours = If(decHours > 24, 24, decHours)
    End Sub

    Private Sub FormatInputsOutputs()
        'Inputs
        txtHourlySalary.Text = decRate.ToString("N2")
        txtMonday1.Text = decMon1.ToString("N2")
        txtMonday2.Text = decMon2.ToString("N2")
        txtTuesday1.Text = decTue1.ToString("N2")
        txtTuesday2.Text = decTue2.ToString("N2")
        txtWednesday1.Text = decWed1.ToString("N2")
        txtWednesday2.Text = decWed2.ToString("N2")
        txtThursday1.Text = decThu1.ToString("N2")
        txtThursday2.Text = decThu2.ToString("N2")
        txtFriday1.Text = decFri1.ToString("N2")
        txtFriday2.Text = decFri2.ToString("N2")
        txtSaturday1.Text = decSat1.ToString("N2")
        txtSaturday2.Text = decSat2.ToString("N2")
        txtSunday1.Text = decSun1.ToString("N2")
        txtSunday2.Text = decSun2.ToString("N2")
        'Outputs
        txtRegularHours.Text = decRegTotal.ToString("N2")
        txtRegularAmount.Text = decRegAmount.ToString("N2")
        txtOvertimeHours.Text = decOverTotal.ToString("N2")
        txtOvertimeAmount.Text = decOverAmount.ToString("N2")
        txtNetPay.Text = decNetPay.ToString("N2")
    End Sub

    Private Function GetRegHours(decHours As Decimal) As Decimal
        GetRegHours = If(decHours / decRegHours > 1, decRegHours, decHours)
    End Function

    Private Function GetOverHours(decHours As Decimal) As Decimal
        GetOverHours = If(decHours / decRegHours > 1, decHours - decRegHours, 0)
    End Function
End Class
