Public Class Form2
    ' DataTable を受け取るコンストラクタ
    Private dt As DataTable

    Public Sub New(data As DataTable)
        InitializeComponent()
        dt = data
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = dt ' DataGridView にデータをセット
    End Sub
End Class