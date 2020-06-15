﻿Public Class frmMain
    'class-level declarations
    Private Const decRegHours As Decimal = 8
    Private decMon1, decMon2, decTue1, decTue2, decWed1, decWed2, decThu1, decThu2, decFri1, decFri2, decSat1, decSat2, decSun1, decSun2, decRate, decRegTotal, decRegAmount, decOverTotal, decOverAmount, decNetPay As Decimal

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormatInputsOutputs()
    End Sub

    Private Sub cmdProcessIt_Click(sender As Object, e As EventArgs) Handles cmdProcessIt.Click
        'procedure-level declarations
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
        decRate = 0
        decMon1 = 0
        decMon2 = 0
        decTue1 = 0
        decTue2 = 0
        decWed1 = 0
        decWed2 = 0
        decThu1 = 0
        decThu2 = 0
        decFri1 = 0
        decFri2 = 0
        decSat1 = 0
        decSat2 = 0
        decSun1 = 0
        decSun2 = 0
        FormatInputs()
    End Sub

    Private Sub textbox_TextChanged(sender As Object, e As EventArgs) Handles txtWednesday2.TextChanged, txtWednesday1.TextChanged, txtTuesday2.TextChanged, txtTuesday1.TextChanged, txtThursday2.TextChanged, txtThursday1.TextChanged, txtSunday2.TextChanged, txtSunday1.TextChanged, txtSaturday2.TextChanged, txtSaturday1.TextChanged, txtMonday2.TextChanged, txtMonday1.TextChanged, txtHourlySalary.TextChanged, txtFriday2.TextChanged, txtFriday1.TextChanged
        decRegTotal = 0
        decRegAmount = 0
        decOverTotal = 0
        decOverAmount = 0
        decNetPay = 0
        FormatOutputs()
    End Sub

    Private Sub textbox_LostFocus(sender As Object, e As EventArgs) Handles txtWednesday2.Leave, txtWednesday1.Leave, txtTuesday2.Leave, txtTuesday1.Leave, txtThursday2.Leave, txtThursday1.Leave, txtSunday2.Leave, txtSunday1.Leave, txtSaturday2.Leave, txtSaturday1.Leave, txtMonday2.Leave, txtMonday1.Leave, txtHourlySalary.Leave, txtFriday2.Leave, txtFriday1.Leave
        GetInputs()
        FormatInputs()
    End Sub

    Private Sub press_Enter(sender As Object, e As KeyPressEventArgs) Handles txtWednesday2.KeyPress, txtWednesday1.KeyPress, txtTuesday2.KeyPress, txtTuesday1.KeyPress, txtThursday2.KeyPress, txtThursday1.KeyPress, txtSunday2.KeyPress, txtSunday1.KeyPress, txtSaturday2.KeyPress, txtSaturday1.KeyPress, txtMonday2.KeyPress, txtMonday1.KeyPress, txtHourlySalary.KeyPress, txtFriday2.KeyPress, txtFriday1.KeyPress, txtEmployeeName.KeyPress
        If (e.KeyChar = ChrW(Keys.Enter)) Then
            cmdProcessIt.PerformClick()
        End If
    End Sub

    Private Sub GetInputs()
        decRate = Decimal.Parse(txtHourlySalary.Text)
        decMon1 = RemoveExcessiveHours(Decimal.Parse(txtMonday1.Text))
        decMon2 = RemoveExcessiveHours(Decimal.Parse(txtMonday2.Text))
        decTue1 = RemoveExcessiveHours(Decimal.Parse(txtTuesday1.Text))
        decTue2 = RemoveExcessiveHours(Decimal.Parse(txtTuesday2.Text))
        decWed1 = RemoveExcessiveHours(Decimal.Parse(txtWednesday1.Text))
        decWed2 = RemoveExcessiveHours(Decimal.Parse(txtWednesday2.Text))
        decThu1 = RemoveExcessiveHours(Decimal.Parse(txtThursday1.Text))
        decThu2 = RemoveExcessiveHours(Decimal.Parse(txtThursday2.Text))
        decFri1 = RemoveExcessiveHours(Decimal.Parse(txtFriday1.Text))
        decFri2 = RemoveExcessiveHours(Decimal.Parse(txtFriday2.Text))
        decSat1 = RemoveExcessiveHours(Decimal.Parse(txtSaturday1.Text))
        decSat2 = RemoveExcessiveHours(Decimal.Parse(txtSaturday2.Text))
        decSun1 = RemoveExcessiveHours(Decimal.Parse(txtSunday1.Text))
        decSun2 = RemoveExcessiveHours(Decimal.Parse(txtSunday2.Text))
    End Sub

    Private Function RemoveExcessiveHours(decHours As Decimal) As Decimal
        Return If(decHours > 24, 24, decHours)
    End Function

    Private Sub FormatInputsOutputs()
        FormatInputs()
        FormatOutputs()
    End Sub

    Private Sub FormatInputs()
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
    End Sub
    Private Sub FormatOutputs()
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
