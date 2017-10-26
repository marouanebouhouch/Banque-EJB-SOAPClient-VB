Public Class Form1
    Public Class Form1
        Dim proxy As New ServiceReference1.BanqueServiceClient()
        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            loadDataView()
        End Sub

        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
            If IsNumeric(TextBox1.Text.Trim()) Then
                proxy.addCompte(Convert.ToDecimal(TextBox1.Text.Trim()))
                TextBox1.Text = ""
                loadDataView()
            End If
        End Sub

        Private Sub loadDataView()
            Dim comptes() As Object
            Dim dt As DataTable
            Dim columnCode As DataColumn
            Dim columnCreationDate As DataColumn
            Dim columnSolde As DataColumn
            Dim dr As DataRow
            columnCode = New DataColumn("Code")
            columnCreationDate = New DataColumn("Creation date")
            columnSolde = New DataColumn("Solde")
            dt = New DataTable
            dt.Columns.Add(columnCode)
            dt.Columns.Add(columnSolde)
            dt.Columns.Add(columnCreationDate)
            comptes = proxy.listComptes()
            For i As Integer = 0 To comptes.Length - 1
                dr = dt.NewRow
                dr.Item("Code") = comptes(i).code
                dr.Item("Creation date") = comptes(i).date_creation
                dr.Item("Solde") = comptes(i).solde
                dt.Rows.Add(dr)
            Next
            DataGridView1.DataSource = dt
        End Sub

    End Class

End Class
