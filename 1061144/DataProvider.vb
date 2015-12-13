Imports System.Data.OleDb
Public Class DataProvider
    Shared da As OleDbDataAdapter
    Shared conStr As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Data.mdb"
    Public Shared Function GetTable(ByVal sql As String) As DataTable
        Dim dt As New DataTable
        If (da Is Nothing) Then
            da = New OleDbDataAdapter(sql, conStr)
        Else
            da.SelectCommand.CommandText = sql
        End If
        da.Fill(dt)
        Return dt
    End Function

    Public Shared Function GetDataSet(ByVal sql As String, ByVal dsNameTable() As String) As DataSet
        Dim ds As New DataSet
        Dim dsStr() As String
        If (sql.Contains(";")) Then
            dsStr = sql.Split(New String(0) {";"}, StringSplitOptions.RemoveEmptyEntries)
        Else
            ReDim dsStr(0)
        End If
        Dim dt As DataTable
        Dim idx As Integer = 0
        For Each e As String In dsStr
            If (da Is Nothing) Then
                da = New OleDbDataAdapter(e, conStr)
            Else
                da.SelectCommand.CommandText = e
            End If
            If (idx < dsNameTable.Length) Then
                dt = New DataTable(dsNameTable(idx))
            Else
                dt = New DataTable
            End If
            da.Fill(dt)
            ds.Tables.Add(dt)
            idx += 1
        Next
        Return ds
    End Function

    Public Shared Function GetData() As DataSet
        Dim ds As DataSet
        Dim sql As String = "SELECT MaHocSinh,TenHocSinh,DienThoai,NgaySinh,DiemToan,DiemLy," & "DiemHoa,DiemVan,MaLop,month(NgaySinh) as Thang FROM HocSinh;" & "SELECT * FROM LopHoc"
        Dim dsName() As String = New String() {"HocSinh", "LopHoc"}
        ds = DataProvider.GetDataSet(sql, dsName)
        Dim dr As DataRelation
        dr = New DataRelation("LH_HS", ds.Tables("LopHoc").Columns("MaLopHoc"), ds.Tables("HocSinh").Columns("MaLop"))
        ds.Relations.Add(dr)
        Return ds
    End Function

    Public Shared Function UpdateTable(ByVal dt As DataTable, ByVal tbName As String) As Integer
        If (da Is Nothing) Then
            Return 0
        End If
        da.SelectCommand.CommandText = "SELECT * FROM " & tbName
        Dim cmbBuilder As New OleDbCommandBuilder(da)
        cmbBuilder.ConflictOption = ConflictOption.CompareRowVersion
        Return da.Update(dt)
    End Function

    Public Shared Function UpdateDataSet(ByVal ds As DataSet) As Integer
        If (da Is Nothing) Then
            Return 0
        End If
        Dim toReturn As Integer = 0
        toReturn += UpdateTable(ds.Tables("LopHoc"), "LopHoc")
        toReturn += UpdateTable(ds.Tables("HocSinh"), "HocSinh")
        Return toReturn
    End Function
End Class
