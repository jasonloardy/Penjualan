<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUtama
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormUtama))
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DataMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataBarangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataPelangganToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataSupplierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransaksiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PembelianToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PenjualanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CariNotaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PembelianToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PenjualanToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PengaturanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblNamaToko = New System.Windows.Forms.Label()
        Me.lblDeskripsi = New System.Windows.Forms.Label()
        Me.lblAlamat = New System.Windows.Forms.Label()
        Me.lblTelp = New System.Windows.Forms.Label()
        Me.DataKecilToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JenisBarangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SatuanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(120, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 639)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(19, 0, 1, 0)
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(1284, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataMasterToolStripMenuItem, Me.TransaksiToolStripMenuItem, Me.LaporanToolStripMenuItem, Me.CariNotaToolStripMenuItem, Me.PengaturanToolStripMenuItem, Me.LogoutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1284, 25)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DataMasterToolStripMenuItem
        '
        Me.DataMasterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataBarangToolStripMenuItem, Me.DataKecilToolStripMenuItem, Me.DataPelangganToolStripMenuItem, Me.DataSupplierToolStripMenuItem, Me.DataUserToolStripMenuItem})
        Me.DataMasterToolStripMenuItem.Name = "DataMasterToolStripMenuItem"
        Me.DataMasterToolStripMenuItem.Size = New System.Drawing.Size(92, 21)
        Me.DataMasterToolStripMenuItem.Text = "Data Master"
        '
        'DataBarangToolStripMenuItem
        '
        Me.DataBarangToolStripMenuItem.Name = "DataBarangToolStripMenuItem"
        Me.DataBarangToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.DataBarangToolStripMenuItem.Text = "Data Barang"
        '
        'DataPelangganToolStripMenuItem
        '
        Me.DataPelangganToolStripMenuItem.Name = "DataPelangganToolStripMenuItem"
        Me.DataPelangganToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.DataPelangganToolStripMenuItem.Text = "Data Pelanggan"
        '
        'DataSupplierToolStripMenuItem
        '
        Me.DataSupplierToolStripMenuItem.Name = "DataSupplierToolStripMenuItem"
        Me.DataSupplierToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.DataSupplierToolStripMenuItem.Text = "Data Supplier"
        '
        'DataUserToolStripMenuItem
        '
        Me.DataUserToolStripMenuItem.Name = "DataUserToolStripMenuItem"
        Me.DataUserToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.DataUserToolStripMenuItem.Text = "Data User"
        '
        'TransaksiToolStripMenuItem
        '
        Me.TransaksiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PembelianToolStripMenuItem, Me.PenjualanToolStripMenuItem})
        Me.TransaksiToolStripMenuItem.Name = "TransaksiToolStripMenuItem"
        Me.TransaksiToolStripMenuItem.Size = New System.Drawing.Size(73, 21)
        Me.TransaksiToolStripMenuItem.Text = "Transaksi"
        '
        'PembelianToolStripMenuItem
        '
        Me.PembelianToolStripMenuItem.Name = "PembelianToolStripMenuItem"
        Me.PembelianToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.PembelianToolStripMenuItem.Text = "Pembelian"
        '
        'PenjualanToolStripMenuItem
        '
        Me.PenjualanToolStripMenuItem.Name = "PenjualanToolStripMenuItem"
        Me.PenjualanToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.PenjualanToolStripMenuItem.Text = "Penjualan"
        '
        'LaporanToolStripMenuItem
        '
        Me.LaporanToolStripMenuItem.Name = "LaporanToolStripMenuItem"
        Me.LaporanToolStripMenuItem.Size = New System.Drawing.Size(68, 21)
        Me.LaporanToolStripMenuItem.Text = "Laporan"
        '
        'CariNotaToolStripMenuItem
        '
        Me.CariNotaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PembelianToolStripMenuItem1, Me.PenjualanToolStripMenuItem1})
        Me.CariNotaToolStripMenuItem.Name = "CariNotaToolStripMenuItem"
        Me.CariNotaToolStripMenuItem.Size = New System.Drawing.Size(76, 21)
        Me.CariNotaToolStripMenuItem.Text = "Cari Nota"
        '
        'PembelianToolStripMenuItem1
        '
        Me.PembelianToolStripMenuItem1.Name = "PembelianToolStripMenuItem1"
        Me.PembelianToolStripMenuItem1.Size = New System.Drawing.Size(136, 22)
        Me.PembelianToolStripMenuItem1.Text = "Pembelian"
        '
        'PenjualanToolStripMenuItem1
        '
        Me.PenjualanToolStripMenuItem1.Name = "PenjualanToolStripMenuItem1"
        Me.PenjualanToolStripMenuItem1.Size = New System.Drawing.Size(136, 22)
        Me.PenjualanToolStripMenuItem1.Text = "Penjualan"
        '
        'PengaturanToolStripMenuItem
        '
        Me.PengaturanToolStripMenuItem.Name = "PengaturanToolStripMenuItem"
        Me.PengaturanToolStripMenuItem.Size = New System.Drawing.Size(86, 21)
        Me.PengaturanToolStripMenuItem.Text = "Pengaturan"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(61, 21)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'lblNamaToko
        '
        Me.lblNamaToko.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNamaToko.BackColor = System.Drawing.Color.Transparent
        Me.lblNamaToko.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNamaToko.Location = New System.Drawing.Point(16, 119)
        Me.lblNamaToko.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNamaToko.Name = "lblNamaToko"
        Me.lblNamaToko.Size = New System.Drawing.Size(1252, 41)
        Me.lblNamaToko.TabIndex = 9
        Me.lblNamaToko.Text = "<NAMA TOKO>"
        Me.lblNamaToko.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDeskripsi
        '
        Me.lblDeskripsi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDeskripsi.BackColor = System.Drawing.Color.Transparent
        Me.lblDeskripsi.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeskripsi.Location = New System.Drawing.Point(16, 160)
        Me.lblDeskripsi.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDeskripsi.Name = "lblDeskripsi"
        Me.lblDeskripsi.Size = New System.Drawing.Size(1252, 41)
        Me.lblDeskripsi.TabIndex = 10
        Me.lblDeskripsi.Text = "<DESKRIPSI TOKO>"
        Me.lblDeskripsi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAlamat
        '
        Me.lblAlamat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAlamat.BackColor = System.Drawing.Color.Transparent
        Me.lblAlamat.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlamat.Location = New System.Drawing.Point(16, 201)
        Me.lblAlamat.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAlamat.Name = "lblAlamat"
        Me.lblAlamat.Size = New System.Drawing.Size(1252, 41)
        Me.lblAlamat.TabIndex = 11
        Me.lblAlamat.Text = "<ALAMAT TOKO>"
        Me.lblAlamat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTelp
        '
        Me.lblTelp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTelp.BackColor = System.Drawing.Color.Transparent
        Me.lblTelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelp.Location = New System.Drawing.Point(16, 241)
        Me.lblTelp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTelp.Name = "lblTelp"
        Me.lblTelp.Size = New System.Drawing.Size(1252, 41)
        Me.lblTelp.TabIndex = 12
        Me.lblTelp.Text = "<TELP TOKO>"
        Me.lblTelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataKecilToolStripMenuItem
        '
        Me.DataKecilToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.JenisBarangToolStripMenuItem, Me.SatuanToolStripMenuItem})
        Me.DataKecilToolStripMenuItem.Name = "DataKecilToolStripMenuItem"
        Me.DataKecilToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.DataKecilToolStripMenuItem.Text = "Data Kecil"
        '
        'JenisBarangToolStripMenuItem
        '
        Me.JenisBarangToolStripMenuItem.Name = "JenisBarangToolStripMenuItem"
        Me.JenisBarangToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.JenisBarangToolStripMenuItem.Text = "Jenis Barang"
        '
        'SatuanToolStripMenuItem
        '
        Me.SatuanToolStripMenuItem.Name = "SatuanToolStripMenuItem"
        Me.SatuanToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SatuanToolStripMenuItem.Text = "Satuan"
        '
        'FormUtama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1284, 661)
        Me.Controls.Add(Me.lblTelp)
        Me.Controls.Add(Me.lblAlamat)
        Me.Controls.Add(Me.lblDeskripsi)
        Me.Controls.Add(Me.lblNamaToko)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormUtama"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormUtama"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DataMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransaksiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LaporanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CariNotaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblNamaToko As System.Windows.Forms.Label
    Friend WithEvents lblDeskripsi As System.Windows.Forms.Label
    Friend WithEvents lblAlamat As System.Windows.Forms.Label
    Friend WithEvents PengaturanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataBarangToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataPelangganToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataSupplierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataUserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PembelianToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PenjualanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PembelianToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PenjualanToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblTelp As System.Windows.Forms.Label
    Friend WithEvents DataKecilToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JenisBarangToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SatuanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
