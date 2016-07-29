<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnListOPCServer = New System.Windows.Forms.Button()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.btnDisconnect = New System.Windows.Forms.Button()
        Me.txtNode = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusConnection = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusCommand = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnBrowseOPCItems = New System.Windows.Forms.Button()
        Me.lstOPCItems = New System.Windows.Forms.ListBox()
        Me.treeOPC = New System.Windows.Forms.TreeView()
        Me.btnAddToMonitoring = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lstOPCItems2 = New System.Windows.Forms.ListBox()
        Me.txtNodeName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lstOPCServer = New System.Windows.Forms.TreeView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dataOPC = New System.Windows.Forms.DataGridView()
        Me.ColumnItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtRate = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnWrite = New System.Windows.Forms.Button()
        Me.btnRead = New System.Windows.Forms.Button()
        Me.btnMonitoringOff = New System.Windows.Forms.Button()
        Me.btnMonitoringOn = New System.Windows.Forms.Button()
        Me.TimerMonitoring = New System.Windows.Forms.Timer(Me.components)
        Me.cmsOPCServer = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ConnectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisconnectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dataOPC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsOPCServer.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnListOPCServer
        '
        Me.btnListOPCServer.BackColor = System.Drawing.SystemColors.Control
        Me.btnListOPCServer.Location = New System.Drawing.Point(8, 19)
        Me.btnListOPCServer.Name = "btnListOPCServer"
        Me.btnListOPCServer.Size = New System.Drawing.Size(161, 29)
        Me.btnListOPCServer.TabIndex = 0
        Me.btnListOPCServer.Text = "View OPC Server"
        Me.btnListOPCServer.UseVisualStyleBackColor = False
        '
        'btnConnect
        '
        Me.btnConnect.BackColor = System.Drawing.SystemColors.Control
        Me.btnConnect.Enabled = False
        Me.btnConnect.Location = New System.Drawing.Point(27, 221)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(76, 29)
        Me.btnConnect.TabIndex = 0
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = False
        Me.btnConnect.Visible = False
        '
        'btnDisconnect
        '
        Me.btnDisconnect.BackColor = System.Drawing.SystemColors.Control
        Me.btnDisconnect.Enabled = False
        Me.btnDisconnect.Location = New System.Drawing.Point(109, 221)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(77, 29)
        Me.btnDisconnect.TabIndex = 0
        Me.btnDisconnect.Text = "Disconnect"
        Me.btnDisconnect.UseVisualStyleBackColor = False
        Me.btnDisconnect.Visible = False
        '
        'txtNode
        '
        Me.txtNode.Location = New System.Drawing.Point(175, 24)
        Me.txtNode.Name = "txtNode"
        Me.txtNode.Size = New System.Drawing.Size(161, 20)
        Me.txtNode.TabIndex = 2
        Me.txtNode.Text = "127.0.0.1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.StatusConnection, Me.ToolStripStatusLabel2, Me.StatusCommand, Me.ToolStripStatusLabel4})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 602)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(720, 24)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Gray
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(78, 19)
        Me.ToolStripStatusLabel1.Text = "Connection : "
        '
        'StatusConnection
        '
        Me.StatusConnection.BackColor = System.Drawing.SystemColors.Control
        Me.StatusConnection.ForeColor = System.Drawing.Color.Blue
        Me.StatusConnection.Name = "StatusConnection"
        Me.StatusConnection.Size = New System.Drawing.Size(84, 19)
        Me.StatusConnection.Text = "not connected"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.Gray
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(77, 19)
        Me.ToolStripStatusLabel2.Text = "Command : "
        '
        'StatusCommand
        '
        Me.StatusCommand.AutoSize = False
        Me.StatusCommand.BackColor = System.Drawing.SystemColors.Control
        Me.StatusCommand.ForeColor = System.Drawing.Color.Blue
        Me.StatusCommand.Name = "StatusCommand"
        Me.StatusCommand.Size = New System.Drawing.Size(200, 19)
        Me.StatusCommand.Text = "-"
        Me.StatusCommand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.AutoSize = False
        Me.ToolStripStatusLabel4.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(80, 19)
        Me.ToolStripStatusLabel4.Text = " "
        '
        'btnBrowseOPCItems
        '
        Me.btnBrowseOPCItems.BackColor = System.Drawing.SystemColors.Control
        Me.btnBrowseOPCItems.Enabled = False
        Me.btnBrowseOPCItems.Location = New System.Drawing.Point(192, 221)
        Me.btnBrowseOPCItems.Name = "btnBrowseOPCItems"
        Me.btnBrowseOPCItems.Size = New System.Drawing.Size(120, 29)
        Me.btnBrowseOPCItems.TabIndex = 4
        Me.btnBrowseOPCItems.Text = "Browse OPC Items"
        Me.btnBrowseOPCItems.UseVisualStyleBackColor = False
        Me.btnBrowseOPCItems.Visible = False
        '
        'lstOPCItems
        '
        Me.lstOPCItems.FormattingEnabled = True
        Me.lstOPCItems.Location = New System.Drawing.Point(175, 241)
        Me.lstOPCItems.Name = "lstOPCItems"
        Me.lstOPCItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstOPCItems.Size = New System.Drawing.Size(161, 303)
        Me.lstOPCItems.TabIndex = 5
        '
        'treeOPC
        '
        Me.treeOPC.Location = New System.Drawing.Point(8, 241)
        Me.treeOPC.Name = "treeOPC"
        Me.treeOPC.Size = New System.Drawing.Size(161, 303)
        Me.treeOPC.TabIndex = 6
        '
        'btnAddToMonitoring
        '
        Me.btnAddToMonitoring.BackColor = System.Drawing.SystemColors.Control
        Me.btnAddToMonitoring.Enabled = False
        Me.btnAddToMonitoring.Location = New System.Drawing.Point(175, 556)
        Me.btnAddToMonitoring.Name = "btnAddToMonitoring"
        Me.btnAddToMonitoring.Size = New System.Drawing.Size(161, 29)
        Me.btnAddToMonitoring.TabIndex = 4
        Me.btnAddToMonitoring.Text = "Add Item to Monitor"
        Me.btnAddToMonitoring.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstOPCItems2)
        Me.GroupBox1.Controls.Add(Me.btnBrowseOPCItems)
        Me.GroupBox1.Controls.Add(Me.btnDisconnect)
        Me.GroupBox1.Controls.Add(Me.btnConnect)
        Me.GroupBox1.Controls.Add(Me.txtNodeName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.treeOPC)
        Me.GroupBox1.Controls.Add(Me.lstOPCItems)
        Me.GroupBox1.Controls.Add(Me.btnAddToMonitoring)
        Me.GroupBox1.Controls.Add(Me.txtNode)
        Me.GroupBox1.Controls.Add(Me.btnListOPCServer)
        Me.GroupBox1.Controls.Add(Me.lstOPCServer)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(353, 602)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'lstOPCItems2
        '
        Me.lstOPCItems2.FormattingEnabled = True
        Me.lstOPCItems2.Location = New System.Drawing.Point(186, 247)
        Me.lstOPCItems2.Name = "lstOPCItems2"
        Me.lstOPCItems2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstOPCItems2.Size = New System.Drawing.Size(161, 303)
        Me.lstOPCItems2.TabIndex = 10
        Me.lstOPCItems2.Visible = False
        '
        'txtNodeName
        '
        Me.txtNodeName.Location = New System.Drawing.Point(79, 561)
        Me.txtNodeName.Name = "txtNodeName"
        Me.txtNodeName.Size = New System.Drawing.Size(90, 20)
        Me.txtNodeName.TabIndex = 8
        Me.txtNodeName.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 564)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Node Name:"
        Me.Label2.Visible = False
        '
        'lstOPCServer
        '
        Me.lstOPCServer.Location = New System.Drawing.Point(8, 54)
        Me.lstOPCServer.Name = "lstOPCServer"
        Me.lstOPCServer.Size = New System.Drawing.Size(328, 181)
        Me.lstOPCServer.TabIndex = 9
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dataOPC)
        Me.GroupBox2.Controls.Add(Me.txtRate)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.btnWrite)
        Me.GroupBox2.Controls.Add(Me.btnRead)
        Me.GroupBox2.Controls.Add(Me.btnMonitoringOff)
        Me.GroupBox2.Controls.Add(Me.btnMonitoringOn)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(353, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(367, 602)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        '
        'dataOPC
        '
        Me.dataOPC.BackgroundColor = System.Drawing.Color.Beige
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataOPC.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dataOPC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataOPC.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnItem, Me.ColumnValue})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dataOPC.DefaultCellStyle = DataGridViewCellStyle2
        Me.dataOPC.Enabled = False
        Me.dataOPC.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dataOPC.Location = New System.Drawing.Point(19, 38)
        Me.dataOPC.Name = "dataOPC"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataOPC.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dataOPC.RowHeadersWidth = 30
        Me.dataOPC.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dataOPC.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dataOPC.Size = New System.Drawing.Size(328, 434)
        Me.dataOPC.TabIndex = 9
        '
        'ColumnItem
        '
        Me.ColumnItem.HeaderText = "Item"
        Me.ColumnItem.Name = "ColumnItem"
        Me.ColumnItem.ReadOnly = True
        Me.ColumnItem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColumnItem.Width = 180
        '
        'ColumnValue
        '
        Me.ColumnValue.HeaderText = "Value"
        Me.ColumnValue.Name = "ColumnValue"
        Me.ColumnValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'txtRate
        '
        Me.txtRate.Location = New System.Drawing.Point(186, 524)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(68, 20)
        Me.txtRate.TabIndex = 8
        Me.txtRate.Text = "1000"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(73, 527)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Monitoring Rate (ms):"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Monitor Select Items:"
        '
        'btnWrite
        '
        Me.btnWrite.BackColor = System.Drawing.SystemColors.Control
        Me.btnWrite.Enabled = False
        Me.btnWrite.Location = New System.Drawing.Point(186, 478)
        Me.btnWrite.Name = "btnWrite"
        Me.btnWrite.Size = New System.Drawing.Size(161, 29)
        Me.btnWrite.TabIndex = 4
        Me.btnWrite.Text = "Write Value"
        Me.btnWrite.UseVisualStyleBackColor = False
        '
        'btnRead
        '
        Me.btnRead.BackColor = System.Drawing.SystemColors.Control
        Me.btnRead.Enabled = False
        Me.btnRead.Location = New System.Drawing.Point(19, 478)
        Me.btnRead.Name = "btnRead"
        Me.btnRead.Size = New System.Drawing.Size(161, 29)
        Me.btnRead.TabIndex = 4
        Me.btnRead.Text = "Read Value"
        Me.btnRead.UseVisualStyleBackColor = False
        '
        'btnMonitoringOff
        '
        Me.btnMonitoringOff.BackColor = System.Drawing.SystemColors.Control
        Me.btnMonitoringOff.Enabled = False
        Me.btnMonitoringOff.Location = New System.Drawing.Point(186, 556)
        Me.btnMonitoringOff.Name = "btnMonitoringOff"
        Me.btnMonitoringOff.Size = New System.Drawing.Size(161, 29)
        Me.btnMonitoringOff.TabIndex = 4
        Me.btnMonitoringOff.Text = "Monitoring OFF"
        Me.btnMonitoringOff.UseVisualStyleBackColor = False
        '
        'btnMonitoringOn
        '
        Me.btnMonitoringOn.BackColor = System.Drawing.SystemColors.Control
        Me.btnMonitoringOn.Enabled = False
        Me.btnMonitoringOn.Location = New System.Drawing.Point(19, 556)
        Me.btnMonitoringOn.Name = "btnMonitoringOn"
        Me.btnMonitoringOn.Size = New System.Drawing.Size(161, 29)
        Me.btnMonitoringOn.TabIndex = 4
        Me.btnMonitoringOn.Text = "Monitoring ON"
        Me.btnMonitoringOn.UseVisualStyleBackColor = False
        '
        'TimerMonitoring
        '
        '
        'cmsOPCServer
        '
        Me.cmsOPCServer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnectToolStripMenuItem, Me.DisconnectToolStripMenuItem})
        Me.cmsOPCServer.Name = "cmsOPCServer"
        Me.cmsOPCServer.Size = New System.Drawing.Size(134, 48)
        '
        'ConnectToolStripMenuItem
        '
        Me.ConnectToolStripMenuItem.Name = "ConnectToolStripMenuItem"
        Me.ConnectToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.ConnectToolStripMenuItem.Text = "Connect"
        '
        'DisconnectToolStripMenuItem
        '
        Me.DisconnectToolStripMenuItem.Name = "DisconnectToolStripMenuItem"
        Me.DisconnectToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.DisconnectToolStripMenuItem.Text = "Disconnect"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(720, 626)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "VB OPC Client - for testing"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dataOPC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsOPCServer.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnListOPCServer As System.Windows.Forms.Button
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents btnDisconnect As System.Windows.Forms.Button
    Friend WithEvents txtNode As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusConnection As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnBrowseOPCItems As System.Windows.Forms.Button
    Friend WithEvents lstOPCItems As System.Windows.Forms.ListBox
    Friend WithEvents treeOPC As System.Windows.Forms.TreeView
    Friend WithEvents btnAddToMonitoring As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRate As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnRead As System.Windows.Forms.Button
    Friend WithEvents txtNodeName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dataOPC As System.Windows.Forms.DataGridView
    Friend WithEvents btnWrite As System.Windows.Forms.Button
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusCommand As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnMonitoringOff As System.Windows.Forms.Button
    Friend WithEvents btnMonitoringOn As System.Windows.Forms.Button
    Friend WithEvents TimerMonitoring As System.Windows.Forms.Timer
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ColumnItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lstOPCServer As System.Windows.Forms.TreeView
    Friend WithEvents cmsOPCServer As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ConnectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisconnectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lstOPCItems2 As System.Windows.Forms.ListBox
End Class
