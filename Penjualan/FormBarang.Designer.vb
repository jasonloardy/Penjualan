<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBarang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBarang))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tbcari = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnsatuan = New System.Windows.Forms.Button()
        Me.btnjenis = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbstok = New System.Windows.Forms.TextBox()
        Me.cbsatuan = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbjenis = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbhargajual = New System.Windows.Forms.TextBox()
        Me.tbhargabeli = New System.Windows.Forms.TextBox()
        Me.tbnamabarang = New System.Windows.Forms.TextBox()
        Me.tbkdbarang = New System.Windows.Forms.TextBox()
        Me.btntambah = New System.Windows.Forms.Button()
        Me.btnedit = New System.Windows.Forms.Button()
        Me.btnhapus = New System.Windows.Forms.Button()
        Me.btnbatal = New System.Windows.Forms.Button()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbcari
        '
        Me.tbcari.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbcari.Location = New System.Drawing.Point(179, 26)
        Me.tbcari.Name = "tbcari"
        Me.tbcari.Size = New System.Drawing.Size(626, 22)
        Me.tbcari.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Cari Kode / Nama Barang :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgv)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tbcari)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(811, 537)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DAFTAR BARANG"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnsatuan)
        Me.GroupBox2.Controls.Add(Me.btnjenis)
        Me.GroupBox2.Controls.Add(Me.CheckBox1)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.tbstok)
        Me.GroupBox2.Controls.Add(Me.cbsatuan)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cbjenis)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.tbhargajual)
        Me.GroupBox2.Controls.Add(Me.tbhargabeli)
        Me.GroupBox2.Controls.Add(Me.tbnamabarang)
        Me.GroupBox2.Controls.Add(Me.tbkdbarang)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(839, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(433, 260)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "INFORMASI BARANG"
        '
        'btnsatuan
        '
        Me.btnsatuan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsatuan.Location = New System.Drawing.Point(276, 125)
        Me.btnsatuan.Name = "btnsatuan"
        Me.btnsatuan.Size = New System.Drawing.Size(75, 24)
        Me.btnsatuan.TabIndex = 27
        Me.btnsatuan.Text = "Atur"
        Me.btnsatuan.UseVisualStyleBackColor = True
        '
        'btnjenis
        '
        Me.btnjenis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnjenis.Location = New System.Drawing.Point(276, 92)
        Me.btnjenis.Name = "btnjenis"
        Me.btnjenis.Size = New System.Drawing.Size(75, 24)
        Me.btnjenis.TabIndex = 26
        Me.btnjenis.Text = "Atur"
        Me.btnjenis.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(279, 28)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(79, 20)
        Me.CheckBox1.TabIndex = 25
        Me.CheckBox1.Text = "Barcode"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 227)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 16)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Stok :"
        '
        'tbstok
        '
        Me.tbstok.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbstok.Location = New System.Drawing.Point(110, 224)
        Me.tbstok.Name = "tbstok"
        Me.tbstok.Size = New System.Drawing.Size(160, 22)
        Me.tbstok.TabIndex = 23
        '
        'cbsatuan
        '
        Me.cbsatuan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbsatuan.FormattingEnabled = True
        Me.cbsatuan.Location = New System.Drawing.Point(110, 125)
        Me.cbsatuan.Name = "cbsatuan"
        Me.cbsatuan.Size = New System.Drawing.Size(160, 24)
        Me.cbsatuan.TabIndex = 22
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 194)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 16)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Harga Jual :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 16)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Harga Beli :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Satuan :"
        '
        'cbjenis
        '
        Me.cbjenis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbjenis.FormattingEnabled = True
        Me.cbjenis.Location = New System.Drawing.Point(110, 92)
        Me.cbjenis.Name = "cbjenis"
        Me.cbjenis.Size = New System.Drawing.Size(160, 24)
        Me.cbjenis.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 16)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Jenis Barang :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 16)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Nama Barang :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Kode Barang :"
        '
        'tbhargajual
        '
        Me.tbhargajual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbhargajual.Location = New System.Drawing.Point(110, 191)
        Me.tbhargajual.Name = "tbhargajual"
        Me.tbhargajual.Size = New System.Drawing.Size(317, 22)
        Me.tbhargajual.TabIndex = 15
        '
        'tbhargabeli
        '
        Me.tbhargabeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbhargabeli.Location = New System.Drawing.Point(110, 158)
        Me.tbhargabeli.Name = "tbhargabeli"
        Me.tbhargabeli.Size = New System.Drawing.Size(317, 22)
        Me.tbhargabeli.TabIndex = 4
        '
        'tbnamabarang
        '
        Me.tbnamabarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnamabarang.Location = New System.Drawing.Point(110, 59)
        Me.tbnamabarang.Name = "tbnamabarang"
        Me.tbnamabarang.Size = New System.Drawing.Size(317, 22)
        Me.tbnamabarang.TabIndex = 1
        '
        'tbkdbarang
        '
        Me.tbkdbarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbkdbarang.Location = New System.Drawing.Point(110, 26)
        Me.tbkdbarang.Name = "tbkdbarang"
        Me.tbkdbarang.Size = New System.Drawing.Size(160, 22)
        Me.tbkdbarang.TabIndex = 0
        '
        'btntambah
        '
        Me.btntambah.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntambah.Image = CType(resources.GetObject("btntambah.Image"), System.Drawing.Image)
        Me.btntambah.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btntambah.Location = New System.Drawing.Point(934, 278)
        Me.btntambah.Name = "btntambah"
        Me.btntambah.Size = New System.Drawing.Size(80, 75)
        Me.btntambah.TabIndex = 11
        Me.btntambah.Text = "Tambah"
        Me.btntambah.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btntambah.UseVisualStyleBackColor = True
        '
        'btnedit
        '
        Me.btnedit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnedit.Image = CType(resources.GetObject("btnedit.Image"), System.Drawing.Image)
        Me.btnedit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnedit.Location = New System.Drawing.Point(1020, 278)
        Me.btnedit.Name = "btnedit"
        Me.btnedit.Size = New System.Drawing.Size(80, 75)
        Me.btnedit.TabIndex = 12
        Me.btnedit.Text = "Edit"
        Me.btnedit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnedit.UseVisualStyleBackColor = True
        '
        'btnhapus
        '
        Me.btnhapus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnhapus.Image = CType(resources.GetObject("btnhapus.Image"), System.Drawing.Image)
        Me.btnhapus.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnhapus.Location = New System.Drawing.Point(1106, 278)
        Me.btnhapus.Name = "btnhapus"
        Me.btnhapus.Size = New System.Drawing.Size(80, 75)
        Me.btnhapus.TabIndex = 13
        Me.btnhapus.Text = "Hapus"
        Me.btnhapus.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnhapus.UseVisualStyleBackColor = True
        '
        'btnbatal
        '
        Me.btnbatal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnbatal.Image = CType(resources.GetObject("btnbatal.Image"), System.Drawing.Image)
        Me.btnbatal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnbatal.Location = New System.Drawing.Point(1192, 278)
        Me.btnbatal.Name = "btnbatal"
        Me.btnbatal.Size = New System.Drawing.Size(80, 75)
        Me.btnbatal.TabIndex = 14
        Me.btnbatal.Text = "Batal"
        Me.btnbatal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnbatal.UseVisualStyleBackColor = True
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
        Me.dgv.Location = New System.Drawing.Point(9, 59)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(796, 472)
        Me.dgv.TabIndex = 3
        '
        'FormBarang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 561)
        Me.Controls.Add(Me.btnbatal)
        Me.Controls.Add(Me.btnhapus)
        Me.Controls.Add(Me.btnedit)
        Me.Controls.Add(Me.btntambah)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FormBarang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormBarang"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbcari As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btntambah As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbjenis As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbhargajual As System.Windows.Forms.TextBox
    Friend WithEvents tbhargabeli As System.Windows.Forms.TextBox
    Friend WithEvents tbnamabarang As System.Windows.Forms.TextBox
    Friend WithEvents tbkdbarang As System.Windows.Forms.TextBox
    Friend WithEvents btnedit As System.Windows.Forms.Button
    Friend WithEvents btnhapus As System.Windows.Forms.Button
    Friend WithEvents btnbatal As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbstok As System.Windows.Forms.TextBox
    Friend WithEvents cbsatuan As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents btnsatuan As System.Windows.Forms.Button
    Friend WithEvents btnjenis As System.Windows.Forms.Button
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
End Class
