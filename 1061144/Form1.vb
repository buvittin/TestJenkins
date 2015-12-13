Public Class Form1
    'dataset dùng cho toàn chương trình
    Dim ds As DataSet
    'cờ nhận biết có cần generate datagridview khi load dữ liệu hay không
    Dim isGeneratedDGV As Boolean = False
    'đánh dấu row mới cho dgvLopHoc
    Dim idxNewRowLH As Integer = -1
    'lưu lại màu mặc định của cell
    Dim clOld As Color
    'màu selection của cell
    Dim clSl As Color = Color.FromArgb(255, 0, 100)

    Private Sub LoadData()
        If (Not ds Is Nothing) Then
            ds.Dispose()
        End If
        ds = DataProvider.GetData()
        'xử lý thêm column cần thiết cho table HocSinh
        XLTableHocSinh(ds.Tables("HocSinh"))
        'custom datagirdview
        If (Not isGeneratedDGV) Then
            GenerateDGVLH()
            GenerateDGVHS()
            isGeneratedDGV = True
        End If

        'thực hiện binding data
        Dim bsLH As BindingSource = New BindingSource(ds, "LopHoc")
        dgvLopHoc.DataSource = bsLH
        Dim bsHS As BindingSource = New BindingSource(bsLH, "LH_HS")

        dgvHocSinh.DataSource = bsHS
        cbChonXepLoai.SelectedIndex = 0
        cbChonThangSinh.SelectedIndex = 0
        'điện cột STT
        GenerateNoSTTHS()
        GenerateNoSTTLH()
    End Sub

    Private Sub XLTableHocSinh(ByVal dt As DataTable)
        If (dt.TableName <> "HocSinh") Then
            Return
        End If
        'tạo column điểm trung bình
        Dim dc As DataColumn
        dc = New DataColumn("DTB")
        'biểu thức tính điểm trung bình
        dc.Expression = "(DiemToan + DiemLy + DiemHoa + DiemVan) / 4"
        dt.Columns.Add(dc)
        'tạo column xếp loại
        dc = New DataColumn("XepLoai")
        'biểu thức tính giá trị cho cột
        dc.Expression = "IIF((DiemToan + DiemLy + DiemHoa + DiemVan) / 4 >= 9,'Xuat sac'," & "IIF((DiemToan + DiemLy + DiemHoa + DiemVan) / 4 >=8,'Gioi'," & "IIF((DiemToan + DiemLy + DiemHoa + DiemVan) / 4 >=7.5,'Kha Gioi'," & "IIF((DiemToan + DiemLy + DiemHoa + DiemVan) / 4 >=7,'Kha'," & "IIF((DiemToan + DiemLy + DiemHoa + DiemVan) / 4 >=6,'TB Kha'," & "IIF((DiemToan + DiemLy + DiemHoa + DiemVan) / 4 >=5,'TB'," & "IIF((DiemToan + DiemLy + DiemHoa + DiemVan) / 4 >=4,'TB Yeu','Yeu'" & ")))))))"
        dt.Columns.Add(dc)
    End Sub

    Private Sub GenerateDGVHS()
        dgvHocSinh.AutoGenerateColumns = False
        dgvHocSinh.RowHeadersVisible = False
        dgvHocSinh.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvHocSinh.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim col As DataGridViewColumn = Nothing
        col = New DataGridViewTextBoxColumn()
        CreateStyleColumn(col, "colSTT", "STT", True, Nothing, DataGridViewContentAlignment.MiddleCenter, DataGridViewAutoSizeColumnMode.ColumnHeader)
        dgvHocSinh.Columns.Add(col)
        col = New DataGridViewTextBoxColumn()
        CreateStyleColumn(col, "colHoTen", "Họ Tên", False, "TenHocSinh", DataGridViewContentAlignment.MiddleLeft)
        dgvHocSinh.Columns.Add(col)
        col = New DataGridViewTextBoxColumn()
        CreateStyleColumn(col, "colDienThoai", "Telephone", False, "DienThoai", DataGridViewContentAlignment.MiddleLeft)
        dgvHocSinh.Columns.Add(col)
        col = New DataGridViewTextBoxColumn()
        CreateStyleColumn(col, "colNgaySinh", "Ngày Sinh", False, "NgaySinh")
        dgvHocSinh.Columns.Add(col)
        col = New DataGridViewTextBoxColumn()
        CreateStyleColumn(col, "colDiemToan", "Điểm Toán", False, "DiemToan")
        dgvHocSinh.Columns.Add(col)
        col = New DataGridViewTextBoxColumn()
        CreateStyleColumn(col, "colDiemLy", "Điểm Lý", False, "DiemLy")
        dgvHocSinh.Columns.Add(col)
        col = New DataGridViewTextBoxColumn()
        CreateStyleColumn(col, "colDiemHoa", "Điểm Hóa", False, "DiemHoa")
        col = New DataGridViewTextBoxColumn()
        CreateStyleColumn(col, "colVan", "Điểm Văn", False, "DiemVan")
        dgvHocSinh.Columns.Add(col)
        col = New DataGridViewTextBoxColumn()
        CreateStyleColumn(col, "colDTB", "Điểm Trung Bình", False, "DTB")
        dgvHocSinh.Columns.Add(col)
        col = New DataGridViewTextBoxColumn()
        CreateStyleColumn(col, "colXL", "Xếp Loại", False, "XepLoai", DataGridViewContentAlignment.MiddleCenter, DataGridViewAutoSizeColumnMode.Fill)
        dgvHocSinh.Columns.Add(col)
    End Sub
    
    'cmt
    Private Sub GenerateDGVLH()
        dgvLopHoc.AutoGenerateColumns = False
        dgvLopHoc.RowHeadersVisible = False
        dgvLopHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvLopHoc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim col As DataGridViewColumn = Nothing
        col = New DataGridViewTextBoxColumn()
        CreateStyleColumn(col, "colSTT", "STT", True, Nothing, DataGridViewContentAlignment.MiddleCenter, DataGridViewAutoSizeColumnMode.ColumnHeader)
        dgvLopHoc.Columns.Add(col)
        col = New DataGridViewTextBoxColumn()
        CreateStyleColumn(col, "colTenLop", "Tên Lớp", False, "TenLop", DataGridViewContentAlignment.MiddleLeft)
        dgvLopHoc.Columns.Add(col)
        col = New DataGridViewTextBoxColumn()
        CreateStyleColumn(col, "colSSHT", "Sỉ Số Hiện Tại", False, "SiSoHienTai", DataGridViewContentAlignment.MiddleCenter, DataGridViewAutoSizeColumnMode.ColumnHeader)
        dgvLopHoc.Columns.Add(col)
        col = New DataGridViewTextBoxColumn()
        CreateStyleColumn(col, "colSSTD", "Sỉ Số Tối Đa", False, "SiSoToiDa", DataGridViewContentAlignment.MiddleCenter, DataGridViewAutoSizeColumnMode.ColumnHeader)
        dgvLopHoc.Columns.Add(col)
        col = New DataGridViewTextBoxColumn()
        CreateStyleColumn(col, "colGhiChu", "Ghi Chú", False, "GhiChu", DataGridViewContentAlignment.TopLeft, DataGridViewAutoSizeColumnMode.Fill)
        dgvLopHoc.Columns.Add(col)

    End Sub

    'xử lý lọc dữ liệu theo yêu cầu
    'chú ý ở đây đóng vai trò BindingSource tương đương dataView
    Private Sub XLLoc()
        Dim idxXL As Integer = cbChonXepLoai.SelectedIndex
        Dim idxTh As Integer = cbChonThangSinh.SelectedIndex
        Dim bsHS As BindingSource = dgvHocSinh.DataSource
        If (idxXL > 0) Then
            If (idxTh > 0) Then
                bsHS.Filter = locXL(idxXL) & " AND " & "Thang=" & idxTh
            Else
                bsHS.Filter = locXL(idxXL)
            End If
        Else
            If idxTh > 0 Then
                bsHS.Filter = "Thang=" & idxTh
            Else
                bsHS.Filter = locXL(idxXL)
            End If

        End If
    End Sub

    'hàm tạo style cho column với những thuộc tính thường dùng
    Private Sub CreateStyleColumn(ByVal col As DataGridViewColumn, ByVal name As String, ByVal hText As String, ByVal ro As Boolean, ByVal dPName As String, Optional ByVal alg As DataGridViewContentAlignment = DataGridViewContentAlignment.MiddleCenter, Optional ByVal aSM As DataGridViewAutoSizeColumnMode = DataGridViewAutoSizeColumnMode.DisplayedCells)
        col.Name = name
        col.HeaderText = hText
        col.ReadOnly = ro
        col.AutoSizeMode = aSM
        col.DefaultCellStyle.Alignment = alg
        col.DataPropertyName = dPName
        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub


    Private Sub btnUpdatedb_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdatedb.Click
        DataProvider.UpdateDataSet(ds)
        LoadData()
    End Sub


    Private Sub cbChonXepLoai_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbChonXepLoai.SelectedIndexChanged
        XLLoc()
    End Sub

    Private Sub GenerateNoSTTHS()
        Dim i As Integer = 1
        For Each e As DataGridViewRow In dgvHocSinh.Rows
            If (e.IsNewRow) Then
                Continue For
            End If
            e.Cells("colSTT").Value = i
            i += 1
        Next
    End Sub

    Private Sub GenerateNoSTTLH()
        Dim i As Integer = 1
        For Each e As DataGridViewRow In dgvLopHoc.Rows
            If (e.IsNewRow) Then
                Continue For
            End If
            e.Cells("colSTT").Value = i
            i += 1
        Next
    End Sub

    Private locXL() As String = {"", "XepLoai='Xuat sac'", "XepLoai='Gioi'", "XepLoai='Kha gioi'", "XepLoai='Kha'", "XepLoai='TB kha'", "XepLoai='TB'", "XepLoai='TB yeu'", "XepLoai='Yeu'"}

    Private Sub dgvLopHoc_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgvLopHoc.SelectionChanged
        GenerateNoSTTLH()
        If (idxNewRowLH = -2) Then
            idxNewRowLH = -1
            DataProvider.UpdateDataSet(ds)
            LoadData()
        End If
    End Sub

    Private Sub dgvLopHoc_Sorted(sender As System.Object, e As System.EventArgs) Handles dgvLopHoc.Sorted
        GenerateNoSTTLH()
    End Sub

    Private Sub dgvHocSinh_Sorted(sender As System.Object, e As System.EventArgs) Handles dgvHocSinh.Sorted
        GenerateNoSTTHS()
    End Sub

    Private Sub dgvLopHoc_CellBeginEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvLopHoc.CellBeginEdit
        Dim row As DataGridViewRow = dgvLopHoc.Rows(e.RowIndex)
        If (row.IsNewRow AndAlso row.Cells("colSTT").Value Is Nothing) Then
            row.Cells("colSTT").Value = e.RowIndex + 1
            'lưu lại chỉ số dòng mới
            idxNewRowLH = e.RowIndex
        End If
    End Sub

    Private Sub dgvHocSinh_CellBeginEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvHocSinh.CellBeginEdit
        Dim row As DataGridViewRow = dgvHocSinh.Rows(e.RowIndex)
        If (row.IsNewRow AndAlso row.Cells("colSTT").Value Is Nothing) Then
            row.Cells("colSTT").Value = e.RowIndex + 1
            'lưu lại chỉ số dòng mới
            idxNewRowLH = e.RowIndex
        End If
    End Sub


    Private Sub dgvLopHoc_UserDeletingRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvLopHoc.UserDeletingRow
        If (CType(dgvLopHoc.DataSource, BindingSource).Count > 0) Then
            MessageBox.Show("Không Thể Xóa")
            e.Cancel = True
        End If
    End Sub


    Private Sub dgvLopHoc_UserDeletedRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvLopHoc.UserDeletedRow
        GenerateNoSTTLH()
    End Sub

    Private Sub dgvHocSinh_UserDeletedRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvHocSinh.UserDeletedRow
        GenerateNoSTTHS()
    End Sub

    Private Sub dgvLopHoc_RowLeave(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLopHoc.RowLeave
        If (e.ColumnIndex = idxNewRowLH) Then
            idxNewRowLH = -2
        End If
    End Sub

    Private Sub dgvLopHoc_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLopHoc.CellEnter
        Dim cell As DataGridViewCell = dgvLopHoc.Rows(e.RowIndex).Cells(e.ColumnIndex)
        If (cell.ReadOnly) Then
            Return
        End If
        clOld = cell.Style.SelectionBackColor
        cell.Style.SelectionBackColor = clSl
    End Sub

    Private Sub dgvLopHoc_CellLeave(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLopHoc.CellLeave
        Dim cell As DataGridViewCell = dgvLopHoc.Rows(e.RowIndex).Cells(e.ColumnIndex)
        If (cell.ReadOnly) Then
            Return
        End If
        cell.Style.SelectionBackColor = clOld
    End Sub

    Private Sub dgvHocSinh_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHocSinh.CellEnter
        Dim cell As DataGridViewCell = dgvHocSinh.Rows(e.RowIndex).Cells(e.ColumnIndex)
        If (cell.ReadOnly) Then
            Return
        End If
        clOld = cell.Style.SelectionBackColor
        cell.Style.SelectionBackColor = clSl
    End Sub

    Private Sub dgvHocSinh_CellLeave(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHocSinh.CellLeave
        Dim cell As DataGridViewCell = dgvHocSinh.Rows(e.RowIndex).Cells(e.ColumnIndex)
        If (cell.ReadOnly) Then
            Return
        End If
        cell.Style.SelectionBackColor = clOld
    End Sub

    Private Sub cbChonThangSinh_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbChonThangSinh.SelectedIndexChanged
        XLLoc()
    End Sub
End Class

