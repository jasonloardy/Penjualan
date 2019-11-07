<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormJenis
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormJenis))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbkdjenis = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbnamajenis = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.btnbatal = New System.Windows.Forms.Button()
        Me.btnhapus = New System.Windows.Forms.Button()
        Me.btnedit = New System.Windows.Forms.Button()
        Me.btntambah = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbkdjenis)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tbnamajenis)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(610, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "INFORMASI JENIS BARANG"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(81, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Kode Jenis :"
        '
        'tbkdjenis
        '
        Me.tbkdjenis.Enabled = False
        Me.tbkdjenis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbkdjenis.Location = New System.Drawing.Point(173, 28)
        Me.tbkdjenis.Name = "tbkdjenis"
        Me.tbkdjenis.Size = New System.Drawing.Size(179, 22)
        Me.tbkdjenis.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(81, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nama Jenis :"
        '
        'tbnamajenis
        '
        Me.tbnamajenis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnamajenis.Location = New System.Drawing.Point(173, 56)
        Me.tbnamajenis.MaxLength = 32
        Me.tbnamajenis.Name = "tbnamajenis"
        Me.tbnamajenis.Size = New System.Drawing.Size(351, 22)
        Me.tbnamajenis.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgv)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 199)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(610, 350)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DAFTAR JENIS BARANG"
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.Location = New System.Drawing.Point(6, 19)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(598, 325)
        Me.dgv.TabIndex = 0
        '
        'btnbatal
        '
        Me.btnbatal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnbatal.Image = CType(resources.GetObject("btnbatal.Image"), System.Drawing.Image)
        Me.btnbatal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnbatal.Location = New System.Drawing.Point(542, 118)
        Me.btnbatal.Name = "btnbatal"
        Me.btnbatal.Size = New System.Drawing.Size(80, 75)
        Me.btnbatal.TabIndex = 18
        Me.btnbatal.Text = "Batal"
        Me.btnbatal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnbatal.UseVisualStyleBackColor = True
        '
        'btnhapus
        '
        Me.btnhapus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnhapus.Image = CType(resources.GetObject("btnhapus.Image"), System.Drawing.Image)
        Me.btnhapus.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnhapus.Location = New System.Drawing.Point(456, 118)
        Me.btnhapus.Name = "btnhapus"
        Me.btnhapus.Size = New System.Drawing.Size(80, 75)
        Me.btnhapus.TabIndex = 17
        Me.btnhapus.Text = "Hapus"
        Me.btnhapus.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnhapus.UseVisualStyleBackColor = True
        '
        'btnedit
        '
        Me.btnedit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnedit.Image = CType(resources.GetObject("btnedit.Image"), System.Drawing.Image)
        Me.btnedit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnedit.Location = New System.Drawing.Point(370, 118)
        Me.btnedit.Name = "btnedit"
        Me.btnedit.Size = New System.Drawing.Size(80, 75)
        Me.btnedit.TabIndex = 16
        Me.btnedit.Text = "Edit"
        Me.btnedit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnedit.UseVisualStyleBackColor = True
        '
        'btntambah
        '
        Me.btntambah.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntambah.Image = CType(resources.GetObject("btntambah.Image"), System.Drawing.Image)
        Me.btntambah.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btntambah.Location = New System.Drawing.Point(284, 118)
        Me.btntambah.Name = "btntambah"
        Me.btntambah.Size = New System.Drawing.Size(80, 75)
        Me.btntambah.TabIndex = 15
        Me.btntambah.Text = "Tambah"
        Me.btntambah.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btntambah.UseVisualStyleBackColor = True
        '
        'FormJenis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 561)
        Me.Controls.Add(Me.btnbatal)
        Me.Controls.Add(Me.btnhapus)
        Me.Controls.Add(Me.btnedit)
        Me.Controls.Add(Me.btntambah)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FormJenis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Data Jenis Barang"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnbatal As System.Windows.Forms.Button
    Friend WithEvents btnhapus As System.Windows.Forms.Button
    Friend WithEvents btnedit As System.Windows.Forms.Button
    Friend WithEvents btntambah As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbnamajenis As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbkdjenis As System.Windows.Forms.TextBox
End Class
