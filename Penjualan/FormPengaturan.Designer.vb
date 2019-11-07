<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPengaturan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPengaturan))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbNamaToko = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbDeskripsi = New System.Windows.Forms.TextBox()
        Me.tbAlamat = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbNoTelp = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(460, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "PENGATURAN"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nama Toko :"
        '
        'tbNamaToko
        '
        Me.tbNamaToko.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNamaToko.Location = New System.Drawing.Point(109, 49)
        Me.tbNamaToko.MaxLength = 32
        Me.tbNamaToko.Name = "tbNamaToko"
        Me.tbNamaToko.Size = New System.Drawing.Size(363, 22)
        Me.tbNamaToko.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Deskripsi :"
        '
        'tbDeskripsi
        '
        Me.tbDeskripsi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDeskripsi.Location = New System.Drawing.Point(109, 80)
        Me.tbDeskripsi.MaxLength = 64
        Me.tbDeskripsi.Name = "tbDeskripsi"
        Me.tbDeskripsi.Size = New System.Drawing.Size(363, 22)
        Me.tbDeskripsi.TabIndex = 5
        '
        'tbAlamat
        '
        Me.tbAlamat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAlamat.Location = New System.Drawing.Point(109, 111)
        Me.tbAlamat.MaxLength = 64
        Me.tbAlamat.Name = "tbAlamat"
        Me.tbAlamat.Size = New System.Drawing.Size(363, 22)
        Me.tbAlamat.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Alamat :"
        '
        'tbNoTelp
        '
        Me.tbNoTelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNoTelp.Location = New System.Drawing.Point(109, 142)
        Me.tbNoTelp.MaxLength = 64
        Me.tbNoTelp.Name = "tbNoTelp"
        Me.tbNoTelp.Size = New System.Drawing.Size(363, 22)
        Me.tbNoTelp.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "No. Telepon :"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(397, 176)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 65)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Simpan"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FormPengaturan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 251)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tbNoTelp)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbAlamat)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbDeskripsi)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbNamaToko)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FormPengaturan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormPengaturan"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbNamaToko As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbDeskripsi As System.Windows.Forms.TextBox
    Friend WithEvents tbAlamat As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbNoTelp As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
