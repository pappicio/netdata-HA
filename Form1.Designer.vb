<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveITEMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(16, 36)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(136, 28)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "192.168.1.171"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(238, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "NETDATA Server IP:PORT"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 168)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(354, 50)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Get Data From SERVER"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(16, 444)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(354, 39)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Save HA Config"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(158, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 24)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = ":"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(179, 36)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(71, 28)
        Me.TextBox2.TabIndex = 6
        Me.TextBox2.Text = "19999"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(226, 24)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "NETDATA Server NAME:"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(16, 119)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(354, 28)
        Me.TextBox3.TabIndex = 8
        Me.TextBox3.Text = "MyNetDATA Server"
        '
        'TreeView1
        '
        Me.TreeView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.Location = New System.Drawing.Point(487, 36)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(550, 686)
        Me.TreeView1.TabIndex = 9
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(152, 28)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(151, 24)
        Me.AddToolStripMenuItem.Text = "Insert ITEM"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveITEMToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(170, 28)
        '
        'RemoveITEMToolStripMenuItem
        '
        Me.RemoveITEMToolStripMenuItem.Name = "RemoveITEMToolStripMenuItem"
        Me.RemoveITEMToolStripMenuItem.Size = New System.Drawing.Size(169, 24)
        Me.RemoveITEMToolStripMenuItem.Text = "Remove ITEM"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(493, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(540, 24)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Right click on a Resource item to remove/insert into sensors list!"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 257)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(153, 24)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Items Selected: 0"
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(16, 294)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(157, 39)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Remove ALL"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Enabled = False
        Me.Button4.Location = New System.Drawing.Point(213, 294)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(157, 39)
        Me.Button4.TabIndex = 13
        Me.Button4.Text = "Add ALL"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(308, 393)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(62, 28)
        Me.NumericUpDown1.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 395)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(284, 24)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "TABULATION SPACES (before):"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 22.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1049, 734)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "netdata2HA"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents RemoveITEMToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label6 As Label
End Class
