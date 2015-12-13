<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvLopHoc = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnUpdatedb = New System.Windows.Forms.Button()
        Me.cbChonThangSinh = New System.Windows.Forms.ComboBox()
        Me.cbChonXepLoai = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgvHocSinh = New System.Windows.Forms.DataGridView()
        CType(Me.dgvLopHoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvHocSinh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvLopHoc
        '
        Me.dgvLopHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLopHoc.Location = New System.Drawing.Point(14, 28)
        Me.dgvLopHoc.Name = "dgvLopHoc"
        Me.dgvLopHoc.Size = New System.Drawing.Size(942, 159)
        Me.dgvLopHoc.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvLopHoc)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(971, 204)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Danh sách lớp học"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnUpdatedb)
        Me.GroupBox2.Controls.Add(Me.cbChonThangSinh)
        Me.GroupBox2.Controls.Add(Me.cbChonXepLoai)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 232)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(971, 71)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Chọn lựa"
        '
        'btnUpdatedb
        '
        Me.btnUpdatedb.Location = New System.Drawing.Point(749, 16)
        Me.btnUpdatedb.Name = "btnUpdatedb"
        Me.btnUpdatedb.Size = New System.Drawing.Size(152, 43)
        Me.btnUpdatedb.TabIndex = 2
        Me.btnUpdatedb.Text = "Update database"
        Me.btnUpdatedb.UseVisualStyleBackColor = True
        '
        'cbChonThangSinh
        '
        Me.cbChonThangSinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbChonThangSinh.FormattingEnabled = True
        Me.cbChonThangSinh.Items.AddRange(New Object() {"Chọn tháng", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cbChonThangSinh.Location = New System.Drawing.Point(493, 30)
        Me.cbChonThangSinh.Name = "cbChonThangSinh"
        Me.cbChonThangSinh.Size = New System.Drawing.Size(121, 21)
        Me.cbChonThangSinh.TabIndex = 1
        '
        'cbChonXepLoai
        '
        Me.cbChonXepLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbChonXepLoai.FormattingEnabled = True
        Me.cbChonXepLoai.Items.AddRange(New Object() {"...................", "Xuat sac", "Gioi", "Kha gioi", "Kha", "TB kha", "TB", "TB yeu", "Yeu"})
        Me.cbChonXepLoai.Location = New System.Drawing.Point(177, 30)
        Me.cbChonXepLoai.Name = "cbChonXepLoai"
        Me.cbChonXepLoai.Size = New System.Drawing.Size(121, 21)
        Me.cbChonXepLoai.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(386, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Lọc theo tháng sinh"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(69, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Lọc theo xếp loại"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgvHocSinh)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 309)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(971, 311)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Danh sách học sinh"
        '
        'dgvHocSinh
        '
        Me.dgvHocSinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHocSinh.Location = New System.Drawing.Point(14, 22)
        Me.dgvHocSinh.Name = "dgvHocSinh"
        Me.dgvHocSinh.Size = New System.Drawing.Size(942, 276)
        Me.dgvHocSinh.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1005, 632)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.dgvLopHoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvHocSinh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvLopHoc As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvHocSinh As System.Windows.Forms.DataGridView
    Friend WithEvents cbChonXepLoai As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnUpdatedb As System.Windows.Forms.Button
    Friend WithEvents cbChonThangSinh As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
