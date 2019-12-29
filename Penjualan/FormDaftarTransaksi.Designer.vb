<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDaftarTransaksi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDaftarTransaksi))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tbpage = New System.Windows.Forms.TextBox()
        Me.lbltotpage = New System.Windows.Forms.Label()
        Me.btnlast = New System.Windows.Forms.Button()
        Me.btnnext = New System.Windows.Forms.Button()
        Me.btnprev = New System.Windows.Forms.Button()
        Me.btnfirst = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbcari = New System.Windows.Forms.TextBox()
        Me.dgvtrx = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvbarang = New System.Windows.Forms.DataGridView()
        Me.btncetak = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvtrx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvbarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.tbpage)
        Me.GroupBox1.Controls.Add(Me.lbltotpage)
        Me.GroupBox1.Controls.Add(Me.btnlast)
        Me.GroupBox1.Controls.Add(Me.btnnext)
        Me.GroupBox1.Controls.Add(Me.btnprev)
        Me.GroupBox1.Controls.Add(Me.btnfirst)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbcari)
        Me.GroupBox1.Controls.Add(Me.dgvtrx)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(504, 537)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Daftar Transaksi"
        '
        'tbpage
        '
        Me.tbpage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbpage.Location = New System.Drawing.Point(334, 50)
        Me.tbpage.Name = "tbpage"
        Me.tbpage.Size = New System.Drawing.Size(40, 22)
        Me.tbpage.TabIndex = 26
        '
        'lbltotpage
        '
        Me.lbltotpage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltotpage.AutoSize = True
        Me.lbltotpage.Location = New System.Drawing.Point(380, 53)
        Me.lbltotpage.Name = "lbltotpage"
        Me.lbltotpage.Size = New System.Drawing.Size(36, 16)
        Me.lbltotpage.TabIndex = 25
        Me.lbltotpage.Text = "/ 999"
        '
        'btnlast
        '
        Me.btnlast.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnlast.Location = New System.Drawing.Point(463, 49)
        Me.btnlast.Name = "btnlast"
        Me.btnlast.Size = New System.Drawing.Size(35, 23)
        Me.btnlast.TabIndex = 24
        Me.btnlast.Text = ">|"
        Me.btnlast.UseVisualStyleBackColor = True
        '
        'btnnext
        '
        Me.btnnext.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnnext.Location = New System.Drawing.Point(422, 49)
        Me.btnnext.Name = "btnnext"
        Me.btnnext.Size = New System.Drawing.Size(35, 23)
        Me.btnnext.TabIndex = 23
        Me.btnnext.Text = ">"
        Me.btnnext.UseVisualStyleBackColor = True
        '
        'btnprev
        '
        Me.btnprev.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnprev.Location = New System.Drawing.Point(293, 49)
        Me.btnprev.Name = "btnprev"
        Me.btnprev.Size = New System.Drawing.Size(35, 23)
        Me.btnprev.TabIndex = 22
        Me.btnprev.Text = "<"
        Me.btnprev.UseVisualStyleBackColor = True
        '
        'btnfirst
        '
        Me.btnfirst.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnfirst.Location = New System.Drawing.Point(252, 49)
        Me.btnfirst.Name = "btnfirst"
        Me.btnfirst.Size = New System.Drawing.Size(35, 23)
        Me.btnfirst.TabIndex = 21
        Me.btnfirst.Text = "|<"
        Me.btnfirst.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Cari Kd. TRX / Nama :"
        '
        'tbcari
        '
        Me.tbcari.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbcari.Location = New System.Drawing.Point(149, 21)
        Me.tbcari.Name = "tbcari"
        Me.tbcari.Size = New System.Drawing.Size(349, 22)
        Me.tbcari.TabIndex = 4
        '
        'dgvtrx
        '
        Me.dgvtrx.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvtrx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvtrx.Location = New System.Drawing.Point(6, 78)
        Me.dgvtrx.Name = "dgvtrx"
        Me.dgvtrx.Size = New System.Drawing.Size(492, 453)
        Me.dgvtrx.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dgvbarang)
        Me.GroupBox2.Location = New System.Drawing.Point(522, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(650, 456)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Daftar Barang"
        '
        'dgvbarang
        '
        Me.dgvbarang.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvbarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvbarang.Enabled = False
        Me.dgvbarang.Location = New System.Drawing.Point(6, 21)
        Me.dgvbarang.Name = "dgvbarang"
        Me.dgvbarang.Size = New System.Drawing.Size(638, 429)
        Me.dgvbarang.TabIndex = 1
        '
        'btncetak
        '
        Me.btncetak.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btncetak.Image = CType(resources.GetObject("btncetak.Image"), System.Drawing.Image)
        Me.btncetak.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btncetak.Location = New System.Drawing.Point(1097, 474)
        Me.btncetak.Name = "btncetak"
        Me.btncetak.Size = New System.Drawing.Size(75, 75)
        Me.btncetak.TabIndex = 6
        Me.btncetak.Text = "Cetak"
        Me.btncetak.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btncetak.UseVisualStyleBackColor = True
        '
        'FormDaftarTransaksi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 561)
        Me.Controls.Add(Me.btncetak)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormDaftarTransaksi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormDaftarPenjualan"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvtrx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvbarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvtrx As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvbarang As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbcari As System.Windows.Forms.TextBox
    Friend WithEvents btncetak As System.Windows.Forms.Button
    Friend WithEvents tbpage As System.Windows.Forms.TextBox
    Friend WithEvents lbltotpage As System.Windows.Forms.Label
    Friend WithEvents btnlast As System.Windows.Forms.Button
    Friend WithEvents btnnext As System.Windows.Forms.Button
    Friend WithEvents btnprev As System.Windows.Forms.Button
    Friend WithEvents btnfirst As System.Windows.Forms.Button
End Class
