<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu_tiles
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu_tiles))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.General_tile = New System.Windows.Forms.PictureBox()
        Me.Breeding_tile = New System.Windows.Forms.PictureBox()
        Me.Lactation_Tile = New System.Windows.Forms.PictureBox()
        Me.Notes_Tile = New System.Windows.Forms.PictureBox()
        Me.Medical_Tile = New System.Windows.Forms.PictureBox()
        Me.Measurements_tile = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.General_tile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Breeding_tile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Lactation_Tile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Notes_Tile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Medical_Tile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Measurements_tile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "GTILE.jpg")
        Me.ImageList1.Images.SetKeyName(1, "BTILE.jpg")
        Me.ImageList1.Images.SetKeyName(2, "MTILE.jpg")
        Me.ImageList1.Images.SetKeyName(3, "MEDITILE.jpg")
        Me.ImageList1.Images.SetKeyName(4, "LTILE.jpg")
        Me.ImageList1.Images.SetKeyName(5, "NTILE.jpg")
        '
        'General_tile
        '
        Me.General_tile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.General_tile.Location = New System.Drawing.Point(126, 30)
        Me.General_tile.Name = "General_tile"
        Me.General_tile.Size = New System.Drawing.Size(116, 116)
        Me.General_tile.TabIndex = 0
        Me.General_tile.TabStop = False
        '
        'Breeding_tile
        '
        Me.Breeding_tile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Breeding_tile.Location = New System.Drawing.Point(366, 30)
        Me.Breeding_tile.Name = "Breeding_tile"
        Me.Breeding_tile.Size = New System.Drawing.Size(116, 116)
        Me.Breeding_tile.TabIndex = 1
        Me.Breeding_tile.TabStop = False
        '
        'Lactation_Tile
        '
        Me.Lactation_Tile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Lactation_Tile.Location = New System.Drawing.Point(366, 211)
        Me.Lactation_Tile.Name = "Lactation_Tile"
        Me.Lactation_Tile.Size = New System.Drawing.Size(116, 116)
        Me.Lactation_Tile.TabIndex = 2
        Me.Lactation_Tile.TabStop = False
        '
        'Notes_Tile
        '
        Me.Notes_Tile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Notes_Tile.Location = New System.Drawing.Point(592, 211)
        Me.Notes_Tile.Name = "Notes_Tile"
        Me.Notes_Tile.Size = New System.Drawing.Size(116, 116)
        Me.Notes_Tile.TabIndex = 3
        Me.Notes_Tile.TabStop = False
        '
        'Medical_Tile
        '
        Me.Medical_Tile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Medical_Tile.Location = New System.Drawing.Point(126, 211)
        Me.Medical_Tile.Name = "Medical_Tile"
        Me.Medical_Tile.Size = New System.Drawing.Size(116, 116)
        Me.Medical_Tile.TabIndex = 5
        Me.Medical_Tile.TabStop = False
        '
        'Measurements_tile
        '
        Me.Measurements_tile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Measurements_tile.Location = New System.Drawing.Point(592, 30)
        Me.Measurements_tile.Name = "Measurements_tile"
        Me.Measurements_tile.Size = New System.Drawing.Size(116, 116)
        Me.Measurements_tile.TabIndex = 4
        Me.Measurements_tile.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(366, 383)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(78, 41)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Edit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(531, 392)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Tag No."
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(625, 391)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 9
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(199, 381)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(73, 44)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Add New"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Menu_tiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(851, 472)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Medical_Tile)
        Me.Controls.Add(Me.Measurements_tile)
        Me.Controls.Add(Me.Notes_Tile)
        Me.Controls.Add(Me.Lactation_Tile)
        Me.Controls.Add(Me.Breeding_tile)
        Me.Controls.Add(Me.General_tile)
        Me.Name = "Menu_tiles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu"
        CType(Me.General_tile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Breeding_tile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Lactation_Tile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Notes_Tile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Medical_Tile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Measurements_tile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents General_tile As System.Windows.Forms.PictureBox
    Friend WithEvents Breeding_tile As System.Windows.Forms.PictureBox
    Friend WithEvents Lactation_Tile As System.Windows.Forms.PictureBox
    Friend WithEvents Notes_Tile As System.Windows.Forms.PictureBox
    Friend WithEvents Medical_Tile As System.Windows.Forms.PictureBox
    Friend WithEvents Measurements_tile As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class
