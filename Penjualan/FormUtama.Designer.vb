﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DataMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataBarangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DaftarBarangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JenisBarangToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SatuanBarangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataPelangganToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataSupplierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataSopirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransaksiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PembelianToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PenjualanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SuratJalanToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CariTRXToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PembelianToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PenjualanToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SuratJalanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataMasterToolStripMenuItem, Me.TransaksiToolStripMenuItem, Me.LaporanToolStripMenuItem, Me.CariTRXToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1284, 25)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DataMasterToolStripMenuItem
        '
        Me.DataMasterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataBarangToolStripMenuItem, Me.DataPelangganToolStripMenuItem, Me.DataSupplierToolStripMenuItem, Me.DataSopirToolStripMenuItem})
        Me.DataMasterToolStripMenuItem.Name = "DataMasterToolStripMenuItem"
        Me.DataMasterToolStripMenuItem.Size = New System.Drawing.Size(92, 21)
        Me.DataMasterToolStripMenuItem.Text = "Data Master"
        '
        'DataBarangToolStripMenuItem
        '
        Me.DataBarangToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DaftarBarangToolStripMenuItem, Me.JenisBarangToolStripMenuItem1, Me.SatuanBarangToolStripMenuItem})
        Me.DataBarangToolStripMenuItem.Name = "DataBarangToolStripMenuItem"
        Me.DataBarangToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.DataBarangToolStripMenuItem.Text = "Data Barang"
        '
        'DaftarBarangToolStripMenuItem
        '
        Me.DaftarBarangToolStripMenuItem.Name = "DaftarBarangToolStripMenuItem"
        Me.DaftarBarangToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.DaftarBarangToolStripMenuItem.Text = "Daftar Barang"
        '
        'JenisBarangToolStripMenuItem1
        '
        Me.JenisBarangToolStripMenuItem1.Name = "JenisBarangToolStripMenuItem1"
        Me.JenisBarangToolStripMenuItem1.Size = New System.Drawing.Size(160, 22)
        Me.JenisBarangToolStripMenuItem1.Text = "Jenis Barang"
        '
        'SatuanBarangToolStripMenuItem
        '
        Me.SatuanBarangToolStripMenuItem.Name = "SatuanBarangToolStripMenuItem"
        Me.SatuanBarangToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.SatuanBarangToolStripMenuItem.Text = "Satuan Barang"
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
        'DataSopirToolStripMenuItem
        '
        Me.DataSopirToolStripMenuItem.Name = "DataSopirToolStripMenuItem"
        Me.DataSopirToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.DataSopirToolStripMenuItem.Text = "Data Sopir"
        '
        'TransaksiToolStripMenuItem
        '
        Me.TransaksiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PembelianToolStripMenuItem, Me.PenjualanToolStripMenuItem, Me.SuratJalanToolStripMenuItem1})
        Me.TransaksiToolStripMenuItem.Name = "TransaksiToolStripMenuItem"
        Me.TransaksiToolStripMenuItem.Size = New System.Drawing.Size(73, 21)
        Me.TransaksiToolStripMenuItem.Text = "Transaksi"
        '
        'PembelianToolStripMenuItem
        '
        Me.PembelianToolStripMenuItem.Name = "PembelianToolStripMenuItem"
        Me.PembelianToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PembelianToolStripMenuItem.Text = "Pembelian"
        '
        'PenjualanToolStripMenuItem
        '
        Me.PenjualanToolStripMenuItem.Name = "PenjualanToolStripMenuItem"
        Me.PenjualanToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PenjualanToolStripMenuItem.Text = "Penjualan"
        '
        'SuratJalanToolStripMenuItem1
        '
        Me.SuratJalanToolStripMenuItem1.Name = "SuratJalanToolStripMenuItem1"
        Me.SuratJalanToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.SuratJalanToolStripMenuItem1.Text = "Surat Jalan"
        '
        'LaporanToolStripMenuItem
        '
        Me.LaporanToolStripMenuItem.Name = "LaporanToolStripMenuItem"
        Me.LaporanToolStripMenuItem.Size = New System.Drawing.Size(68, 21)
        Me.LaporanToolStripMenuItem.Text = "Laporan"
        '
        'CariTRXToolStripMenuItem
        '
        Me.CariTRXToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PembelianToolStripMenuItem1, Me.PenjualanToolStripMenuItem1, Me.SuratJalanToolStripMenuItem})
        Me.CariTRXToolStripMenuItem.Name = "CariTRXToolStripMenuItem"
        Me.CariTRXToolStripMenuItem.Size = New System.Drawing.Size(100, 21)
        Me.CariTRXToolStripMenuItem.Text = "Cari Transaksi"
        '
        'PembelianToolStripMenuItem1
        '
        Me.PembelianToolStripMenuItem1.Name = "PembelianToolStripMenuItem1"
        Me.PembelianToolStripMenuItem1.Size = New System.Drawing.Size(139, 22)
        Me.PembelianToolStripMenuItem1.Text = "Pembelian"
        '
        'PenjualanToolStripMenuItem1
        '
        Me.PenjualanToolStripMenuItem1.Name = "PenjualanToolStripMenuItem1"
        Me.PenjualanToolStripMenuItem1.Size = New System.Drawing.Size(139, 22)
        Me.PenjualanToolStripMenuItem1.Text = "Penjualan"
        '
        'SuratJalanToolStripMenuItem
        '
        Me.SuratJalanToolStripMenuItem.Name = "SuratJalanToolStripMenuItem"
        Me.SuratJalanToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.SuratJalanToolStripMenuItem.Text = "Surat Jalan"
        '
        'FormUtama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 661)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormUtama"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormUtama"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DataMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransaksiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LaporanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CariTRXToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataBarangToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataPelangganToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataSupplierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PembelianToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PenjualanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PembelianToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PenjualanToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataSopirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SuratJalanToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SuratJalanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DaftarBarangToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JenisBarangToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SatuanBarangToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
