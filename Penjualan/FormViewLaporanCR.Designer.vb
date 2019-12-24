<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormViewLaporanCR
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CRViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.rbtahunan = New System.Windows.Forms.RadioButton()
        Me.rbbulanan = New System.Windows.Forms.RadioButton()
        Me.rbharian = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbbarangdibeli = New System.Windows.Forms.RadioButton()
        Me.rbbarangterjual = New System.Windows.Forms.RadioButton()
        Me.rbpenjualanantar = New System.Windows.Forms.RadioButton()
        Me.rbpenjualanlangsung = New System.Windows.Forms.RadioButton()
        Me.rbpenjualan = New System.Windows.Forms.RadioButton()
        Me.rbpembelian = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.CRViewer)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 137)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1258, 411)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'CRViewer
        '
        Me.CRViewer.ActiveViewIndex = -1
        Me.CRViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRViewer.Location = New System.Drawing.Point(4, 19)
        Me.CRViewer.Name = "CRViewer"
        Me.CRViewer.ShowCloseButton = False
        Me.CRViewer.ShowLogo = False
        Me.CRViewer.Size = New System.Drawing.Size(1250, 388)
        Me.CRViewer.TabIndex = 1
        Me.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtp2)
        Me.GroupBox2.Controls.Add(Me.ComboBox3)
        Me.GroupBox2.Controls.Add(Me.ComboBox2)
        Me.GroupBox2.Controls.Add(Me.ComboBox1)
        Me.GroupBox2.Controls.Add(Me.dtp1)
        Me.GroupBox2.Controls.Add(Me.rbtahunan)
        Me.GroupBox2.Controls.Add(Me.rbbulanan)
        Me.GroupBox2.Controls.Add(Me.rbharian)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(330, 116)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Periode"
        '
        'dtp2
        '
        Me.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp2.Location = New System.Drawing.Point(213, 24)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(110, 22)
        Me.dtp2.TabIndex = 9
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(97, 82)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(73, 24)
        Me.ComboBox3.TabIndex = 8
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(176, 52)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(147, 24)
        Me.ComboBox2.TabIndex = 7
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(97, 52)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(73, 24)
        Me.ComboBox1.TabIndex = 6
        '
        'dtp1
        '
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp1.Location = New System.Drawing.Point(97, 24)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(110, 22)
        Me.dtp1.TabIndex = 5
        '
        'rbtahunan
        '
        Me.rbtahunan.AutoSize = True
        Me.rbtahunan.Location = New System.Drawing.Point(7, 84)
        Me.rbtahunan.Name = "rbtahunan"
        Me.rbtahunan.Size = New System.Drawing.Size(79, 20)
        Me.rbtahunan.TabIndex = 3
        Me.rbtahunan.Text = "Tahunan"
        Me.rbtahunan.UseVisualStyleBackColor = True
        '
        'rbbulanan
        '
        Me.rbbulanan.AutoSize = True
        Me.rbbulanan.Location = New System.Drawing.Point(7, 54)
        Me.rbbulanan.Name = "rbbulanan"
        Me.rbbulanan.Size = New System.Drawing.Size(75, 20)
        Me.rbbulanan.TabIndex = 2
        Me.rbbulanan.Text = "Bulanan"
        Me.rbbulanan.UseVisualStyleBackColor = True
        '
        'rbharian
        '
        Me.rbharian.AutoSize = True
        Me.rbharian.Checked = True
        Me.rbharian.Location = New System.Drawing.Point(7, 24)
        Me.rbharian.Name = "rbharian"
        Me.rbharian.Size = New System.Drawing.Size(66, 20)
        Me.rbharian.TabIndex = 0
        Me.rbharian.TabStop = True
        Me.rbharian.Text = "Harian"
        Me.rbharian.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbbarangdibeli)
        Me.GroupBox3.Controls.Add(Me.rbbarangterjual)
        Me.GroupBox3.Controls.Add(Me.rbpenjualanantar)
        Me.GroupBox3.Controls.Add(Me.rbpenjualanlangsung)
        Me.GroupBox3.Controls.Add(Me.rbpenjualan)
        Me.GroupBox3.Controls.Add(Me.rbpembelian)
        Me.GroupBox3.Location = New System.Drawing.Point(351, 13)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(354, 116)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Jenis"
        '
        'rbbarangdibeli
        '
        Me.rbbarangdibeli.AutoSize = True
        Me.rbbarangdibeli.Location = New System.Drawing.Point(185, 82)
        Me.rbbarangdibeli.Name = "rbbarangdibeli"
        Me.rbbarangdibeli.Size = New System.Drawing.Size(154, 20)
        Me.rbbarangdibeli.TabIndex = 5
        Me.rbbarangdibeli.Text = "Jumlah Barang Dibeli"
        Me.rbbarangdibeli.UseVisualStyleBackColor = True
        '
        'rbbarangterjual
        '
        Me.rbbarangterjual.AutoSize = True
        Me.rbbarangterjual.Location = New System.Drawing.Point(185, 52)
        Me.rbbarangterjual.Name = "rbbarangterjual"
        Me.rbbarangterjual.Size = New System.Drawing.Size(161, 20)
        Me.rbbarangterjual.TabIndex = 4
        Me.rbbarangterjual.Text = "Jumlah Barang Terjual"
        Me.rbbarangterjual.UseVisualStyleBackColor = True
        '
        'rbpenjualanantar
        '
        Me.rbpenjualanantar.AutoSize = True
        Me.rbpenjualanantar.Location = New System.Drawing.Point(185, 24)
        Me.rbpenjualanantar.Name = "rbpenjualanantar"
        Me.rbpenjualanantar.Size = New System.Drawing.Size(120, 20)
        Me.rbpenjualanantar.TabIndex = 3
        Me.rbpenjualanantar.Text = "Penjualan Antar"
        Me.rbpenjualanantar.UseVisualStyleBackColor = True
        '
        'rbpenjualanlangsung
        '
        Me.rbpenjualanlangsung.AutoSize = True
        Me.rbpenjualanlangsung.Location = New System.Drawing.Point(7, 82)
        Me.rbpenjualanlangsung.Name = "rbpenjualanlangsung"
        Me.rbpenjualanlangsung.Size = New System.Drawing.Size(148, 20)
        Me.rbpenjualanlangsung.TabIndex = 2
        Me.rbpenjualanlangsung.Text = "Penjualan Langsung"
        Me.rbpenjualanlangsung.UseVisualStyleBackColor = True
        '
        'rbpenjualan
        '
        Me.rbpenjualan.AutoSize = True
        Me.rbpenjualan.Location = New System.Drawing.Point(7, 52)
        Me.rbpenjualan.Name = "rbpenjualan"
        Me.rbpenjualan.Size = New System.Drawing.Size(132, 20)
        Me.rbpenjualan.TabIndex = 1
        Me.rbpenjualan.Text = "Semua Penjualan"
        Me.rbpenjualan.UseVisualStyleBackColor = True
        '
        'rbpembelian
        '
        Me.rbpembelian.AutoSize = True
        Me.rbpembelian.Location = New System.Drawing.Point(7, 24)
        Me.rbpembelian.Name = "rbpembelian"
        Me.rbpembelian.Size = New System.Drawing.Size(137, 20)
        Me.rbpembelian.TabIndex = 0
        Me.rbpembelian.Text = "Semua Pembelian"
        Me.rbpembelian.UseVisualStyleBackColor = True
        '
        'FormViewLaporanCR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 561)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormViewLaporanCR"
        Me.Text = "FormViewLaporanCR"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbtahunan As System.Windows.Forms.RadioButton
    Friend WithEvents rbbulanan As System.Windows.Forms.RadioButton
    Friend WithEvents rbharian As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbpenjualanantar As System.Windows.Forms.RadioButton
    Friend WithEvents rbpenjualanlangsung As System.Windows.Forms.RadioButton
    Friend WithEvents rbpenjualan As System.Windows.Forms.RadioButton
    Friend WithEvents rbpembelian As System.Windows.Forms.RadioButton
    Friend WithEvents CRViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents rbbarangdibeli As System.Windows.Forms.RadioButton
    Friend WithEvents rbbarangterjual As System.Windows.Forms.RadioButton
End Class
