Imports System.IO
Imports System.Xml.Serialization
Imports OPCAutomation
Imports System.Xml

Public Class frmMain

    Public OPCServers As New OPCServer
    Public arrOPCServer(10) As strOPCServer

    Public WithEvents OPCGroups As OPCGroup
    Public WithEvents OPCGroup_0 As OPCGroup
    Public WithEvents OPCGroup_1 As OPCGroup
    Public WithEvents OPCGroup_2 As OPCGroup
    Public WithEvents OPCGroup_3 As OPCGroup

    Public arrOPCGroup(10) As OPCGroup

    Const OPC_DS_CACHE = 1
    Const OPC_DS_DEVICE = 2

    Public iOPC As Integer
    Public ConnectedServer As Integer = 0
    Public MonitorItem_Count As Integer = 0
    Public MonitorItem_Name As New List(Of String)
    Public MonitorItem_Value As New List(Of VariantType)

    Structure strOPCServer

        Dim Server As OPCServer
        Dim Group
        Dim Item As OPCItem
        Dim ServerHandles As Array
        Dim Errors As Array
        Dim Values As Array
        Dim MonitorCount As Integer

    End Structure

    Structure strcMonitorItem

        Dim _Server As Integer
        Dim _Name As String
        Dim _Value
        Dim _Index As Integer
        Dim _ServerHandles

    End Structure

    Public MonitorItem() As strcMonitorItem

    Dim treePath As String
    Dim oldCellValue

    Private Sub btnBrowseOPCServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListOPCServer.Click

        Dim LocalServer
        Dim tmp

        LocalServer = OPCServers.GetOPCServers(txtNode.Text)
        lstOPCServer.Nodes.Clear()

        For Each tmp In LocalServer
            lstOPCServer.Nodes.Add(tmp)
        Next

    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click

        If lstOPCServer.SelectedNode.Index < 0 Then Exit Sub

        Try
            arrOPCServer(iOPC).Server.Connect(lstOPCServer.SelectedNode.Text, txtNode.Text)

            If arrOPCServer(iOPC).Server.ServerState = 1 Then

                StatusConnection.Text = "Connected"
                btnConnect.Enabled = False
                btnDisconnect.Enabled = True
                btnBrowseOPCItems.Enabled = True
                treeOPC.Enabled = True
                lstOPCItems.Enabled = True
                btnRead.Enabled = True
                btnWrite.Enabled = True

                lstOPCServer.SelectedNode.ForeColor = Color.Red

                lstOPCItems.Items.Clear()
                lstOPCItems2.Items.Clear()
                treeOPC.Nodes.Clear()

                cmsOPCServer.Items(0).Enabled = False
                cmsOPCServer.Items(1).Enabled = True

                If btnMonitoringOn.Enabled = False And btnMonitoringOff.Enabled = False Then
                    btnMonitoringOn.Enabled = True
                End If

                If arrOPCGroup(iOPC) Is Nothing Then
                    arrOPCGroup(iOPC) = arrOPCServer(iOPC).Server.OPCGroups.Add("MyOPC_" & iOPC)
                End If

                arrOPCGroup(iOPC).IsActive = False
                arrOPCGroup(iOPC).IsSubscribed = True
                arrOPCGroup(iOPC).UpdateRate = CInt(txtRate.Text)

                AddHandler arrOPCGroup(iOPC).DataChange, AddressOf OPCGroup_DataChange
                AddHandler arrOPCGroup(iOPC).AsyncWriteComplete, AddressOf OPCGroup_AsyncWriteComplete
                AddHandler arrOPCGroup(iOPC).AsyncReadComplete, AddressOf OPCGroup_AsyncReadComplete

                btnBrowseOPCItems_Click(sender, e)
            Else

                StatusConnection.Text = "ERROR Connect!"

            End If

        Catch ex As Exception
            StatusConnection.Text = "ERROR Connect!"
            StatusCommand.Text = ex.Message
        End Try

    End Sub

    Private Sub btnDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnect.Click

        Try

            For i = 0 To 10

                arrOPCServer(i).Item = Nothing

                If arrOPCServer(i).Server.ServerState = 1 Then

                    arrOPCServer(i).Server.OPCGroups.RemoveAll()
                    arrOPCGroup(i).IsSubscribed = False
                    arrOPCGroup(i).IsActive = False

                End If

                arrOPCGroup(i) = Nothing

            Next

            Dim okDisconnected As Boolean = True

            For i = 0 To 10

                If arrOPCServer(i).Server.ServerState = 1 Then

                    arrOPCServer(i).Server.Disconnect()

                    If arrOPCServer(i).Server.ServerState = 1 Then

                        okDisconnected = False

                    End If

                End If

            Next

            If okDisconnected = True Then

                StatusConnection.Text = "Disconnected"
                btnConnect.Enabled = True
                btnDisconnect.Enabled = False
                lstOPCServer.Enabled = True
                treeOPC.Enabled = False
                lstOPCItems.Enabled = False
                btnBrowseOPCItems.Enabled = False
                btnAddToMonitoring.Enabled = False
                btnRead.Enabled = False
                btnWrite.Enabled = False
                dgvDataOPC.Enabled = False
                btnMonitoringOn.Enabled = False
                btnMonitoringOff.Enabled = False
                MonitorItem_Count = 0

0:          Else

                StatusConnection.Text = "ERROR Disconnect!"

            End If

        Catch ex As Exception

            StatusConnection.Text = "ERROR Disconnect!"
            StatusCommand.Text = ex.Message

        End Try

    End Sub

    Private Sub btnBrowseOPCItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseOPCItems.Click

        Try

            treeOPC.Enabled = True
            lstOPCItems.Enabled = True
            lstOPCItems.Items.Clear()
            lstOPCItems2.Items.Clear()
            treeOPC.Nodes.Clear()
            btnAddToMonitoring.Enabled = False
            treePath = ""

            If lstOPCServer.SelectedNode.ForeColor <> Color.Red Then

                Exit Sub

            End If

            Dim MyOPCBrowser As OPCBrowser

            MyOPCBrowser = arrOPCServer(iOPC).Server.CreateBrowser

            MyOPCBrowser.MoveToRoot()
            Show_Leafs(MyOPCBrowser)

            MyOPCBrowser.MoveToRoot()
            Show_Branches(MyOPCBrowser, treeOPC.SelectedNode)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Form2_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        If StatusConnection.Text = "Connected" Then

            btnDisconnect_Click(sender, e)

        End If

    End Sub

    Private Sub treeOPC_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles treeOPC.NodeMouseClick

        Try
            treeOPC.SelectedNode = treeOPC.GetNodeAt(e.X, e.Y)
            Dim nPath
            nPath = e.Node.FullPath

            If nPath = treePath Then

                Exit Sub

            Else

                treePath = nPath
                btnAddToMonitoring.Enabled = False

            End If

            Dim sPath() As String
            Dim sBranch(10) As String
            Dim branchCount As Integer

            sPath = Split(nPath, "\")
            branchCount = sPath.Count

            For i = 0 To branchCount - 1

                sBranch(i) = sPath(i)

            Next


            Dim MyOPCBrowser As OPCBrowser

            MyOPCBrowser = arrOPCServer(iOPC).Server.CreateBrowser
            MyOPCBrowser.MoveToRoot()

            For i = 0 To branchCount - 1

                MyOPCBrowser.ShowBranches()
                MyOPCBrowser.MoveDown(sBranch(i))

            Next

            Show_Leafs(MyOPCBrowser)
            Show_Branches(MyOPCBrowser, treeOPC.SelectedNode)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub lstOPCItems_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstOPCItems.Click

        lstOPCItems_SelectedIndexChanged(sender, e)

    End Sub

    Private Sub lstOPCItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstOPCItems.SelectedIndexChanged

        If lstOPCItems.SelectedIndex < 0 Then
            btnAddToMonitoring.Enabled = False
        Else
            btnAddToMonitoring.Enabled = True
        End If

    End Sub

    Private Sub btnAddToMonitoring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToMonitoring.Click

        Try

            dgvDataOPC.Enabled = True

            Dim index = lstOPCItems.SelectedIndex
            Dim icount = lstOPCItems.SelectedItems.Count

            For i = index To (index + icount - 1)

                Dim itemName As String
                itemName = lstOPCItems2.Items(i)

                dgvDataOPC.Rows.Add()
                dgvDataOPC.Item(0, MonitorItem_Count).Value = itemName

                MonitorItem_Count += 1

                ReDim Preserve MonitorItem(MonitorItem_Count)
                MonitorItem(MonitorItem_Count)._Server = iOPC
                MonitorItem(MonitorItem_Count)._Name = itemName
                MonitorItem(MonitorItem_Count)._Index = dgvDataOPC.RowCount - 1

                arrOPCServer(iOPC).Item = arrOPCGroup(iOPC).OPCItems.AddItem(itemName, MonitorItem_Count)
                arrOPCServer(iOPC).ServerHandles(MonitorItem_Count) = arrOPCServer(iOPC).Item.ServerHandle

            Next

            If btnMonitoringOn.Enabled = False And btnMonitoringOff.Enabled = True Then

                arrOPCGroup(iOPC).IsActive = True

            End If

            lstOPCItems.ClearSelected()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRead.Click

        Try
            If MonitorItem_Count = 0 Then
                SubscribeItems()
            End If

            Dim numItems As Integer = MonitorItem_Count
            arrOPCGroup(iOPC).AsyncRead(numItems, arrOPCServer(iOPC).ServerHandles, arrOPCServer(iOPC).Errors, Second(Now), Second(Now))

            StatusCommand.Text = "OK Read"

        Catch ex As Exception
            StatusCommand.Text = "ERROR Read - " & ex.Message
        End Try

    End Sub

    Private Sub btnWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWrite.Click
        Try

            If MonitorItem_Count = 0 Then
                SubscribeItems()
            End If

            Dim ServerHandlesLocal(MonitorItem_Count) As Integer
            Dim ValuesLocal(MonitorItem_Count)
            Dim ErrorsLocal(MonitorItem_Count) As Integer
            Dim numItems As Integer = 0
            Dim j As Integer = 1

            For i = 1 To MonitorItem_Count

                If dgvDataOPC.Item(1, i - 1).Style.BackColor = Color.Yellow Then
                    ValuesLocal(j) = dgvDataOPC.Item(1, i - 1).Value
                    Dim iServer As Integer = MonitorItem(i)._Server
                    ServerHandlesLocal(j) = arrOPCServer(iServer).ServerHandles(i)

                    arrOPCGroup(iServer).AsyncWrite(1, ServerHandlesLocal, ValuesLocal, arrOPCServer(iServer).Errors, Second(Now), Second(Now))

                    dgvDataOPC.Item(1, i - 1).Style.BackColor = Color.White
                End If

            Next

            StatusCommand.Text = "OK Write"

        Catch ex As Exception
            StatusCommand.Text = "ERROR Write - " & ex.Message
        End Try


    End Sub

    Private Sub dataOPC_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvDataOPC.CellBeginEdit

        dgvDataOPC.Item(1, e.RowIndex).Style.BackColor = Color.Yellow

    End Sub

    Private Sub dataOPC_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvDataOPC.RowsRemoved

        If dgvDataOPC.Rows.Count > MonitorItem_Count Or arrOPCServer(iOPC).Server.ServerState <> 1 Then
            Exit Sub
        End If

        Try

            MonitorItem_Count -= 1

            Dim a As Integer = e.RowIndex
            Dim ServerHandlesLocal(1) As Integer
            Dim iA As Integer = a + 1
            Dim iServer As Integer = MonitorItem(iA)._Server

            ServerHandlesLocal(1) = arrOPCServer(iServer).ServerHandles(iA)
            arrOPCGroup(iServer).OPCItems.Remove(1, ServerHandlesLocal, arrOPCServer(iServer).Errors)

            For i = iA To dgvDataOPC.RowCount - 1

                Dim ClientHandlesLocal(1) As Integer

                iServer = MonitorItem(i + 1)._Server
                ServerHandlesLocal(1) = arrOPCServer(iServer).ServerHandles(i + 1)
                ClientHandlesLocal(1) = i

                arrOPCGroup(iServer).OPCItems.SetClientHandles(1, ServerHandlesLocal, ClientHandlesLocal, arrOPCServer(iServer).Errors)
                arrOPCServer(iServer).ServerHandles(i) = arrOPCServer(iServer).ServerHandles(i + 1)
                arrOPCServer(iServer).Values(i) = arrOPCServer(iServer).Values(i + 1)

            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dataOPC_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDataOPC.CellEndEdit

        Try

            Dim i As Integer = e.RowIndex

            If dgvDataOPC.Item(0, i).Value = "" Then

                dgvDataOPC.Rows.RemoveAt(i)

            Else

                If dgvDataOPC.Item(1, i).Value = arrOPCServer(iOPC).Values(i + 1) Then
                    dgvDataOPC.Item(1, e.RowIndex).Style.BackColor = Color.White
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnMonitoringOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMonitoringOn.Click

        If MonitorItem_Count = 0 Then
            SubscribeItems()
        End If

        For i = 0 To 10

            If arrOPCServer(i).Server.ServerState = 1 Then
                arrOPCGroup(i).IsActive = True
            End If

        Next

        btnMonitoringOn.Enabled = False
        btnMonitoringOff.Enabled = True

    End Sub

    Private Sub btnMonitoringOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMonitoringOff.Click

        For i = 0 To 10
            If arrOPCServer(i).Server.ServerState = 1 Then
                arrOPCGroup(i).IsActive = False
            End If
        Next

        btnMonitoringOn.Enabled = True
        btnMonitoringOff.Enabled = False

    End Sub

    Private Sub OPCGroup_DataChange(ByVal TransactionID As Integer, ByVal NumItems As Integer, ByRef ClientHandles As System.Array, ByRef ItemValues As System.Array, ByRef Qualities As System.Array, ByRef TimeStamps As System.Array)

        For i = 1 To NumItems
            Dim iHandles As Integer = ClientHandles(i)
            dgvDataOPC.Item(1, iHandles - 1).Value = ItemValues(i)
            dgvDataOPC.Item(1, iHandles - 1).Style.BackColor = Color.White
        Next

        StatusCommand.Text = "OK OnChange"

    End Sub

    Private Sub OPCGroup_AsyncWriteComplete(ByVal TransactionID As Integer, ByVal NumItems As Integer, ByRef ClientHandles As System.Array, ByRef Errors As System.Array)

    End Sub

    Public Sub MyOPCGroups_DataChange(ByVal TransactionID As Integer, ByVal NumItems As Integer, ByRef ClientHandles As System.Array, ByRef ItemValues As System.Array, ByRef Qualities As System.Array, ByRef TimeStamps As System.Array) Handles OPCGroups.DataChange, OPCGroup_0.DataChange

        For i = 1 To NumItems
            Dim iHandles As Integer = ClientHandles(i)
            dgvDataOPC.Item(1, iHandles - 1).Value = ItemValues(i)
            dgvDataOPC.Item(1, iHandles - 1).Style.BackColor = Color.White
        Next

        StatusCommand.Text = "OK OnChange"

    End Sub

    Private Sub OPCGroup_AsyncReadComplete(ByVal TransactionID As Integer, ByVal NumItems As Integer, ByRef ClientHandles As System.Array, ByRef ItemValues As System.Array, ByRef Qualities As System.Array, ByRef TimeStamps As System.Array, ByRef Errors As System.Array)

        For i = 1 To NumItems
            Dim iHandles As Integer = ClientHandles(i)
            dgvDataOPC.Item(1, iHandles - 1).Value = ItemValues(i)
            dgvDataOPC.Item(1, iHandles - 1).Style.BackColor = Color.White
        Next

        StatusCommand.Text = "OK AsyncRead"
    End Sub

    Public Sub MyOPCGroup_2_DataChange(ByVal TransactionID As Integer, ByVal NumItems As Integer, ByRef ClientHandles As System.Array, ByRef ItemValues As System.Array, ByRef Qualities As System.Array, ByRef TimeStamps As System.Array) Handles OPCGroup_2.DataChange

        For i = 1 To NumItems
            Dim iHandles As Integer = ClientHandles(i)
            dgvDataOPC.Item(1, iHandles - 1).Value = ItemValues(i)
            dgvDataOPC.Item(1, iHandles - 1).Style.BackColor = Color.White
        Next

        StatusCommand.Text = "OK OnChange"

    End Sub

    Sub SubscribeItems()

        For i = 1 To dgvDataOPC.RowCount - 1
            Dim itemName As String = MonitorItem(i)._Name
            Dim iServer As Integer = MonitorItem(i)._Server
            arrOPCServer(iOPC).Item(iServer) = arrOPCServer(iOPC).Group.OPCItems.AddItem(itemName, i)
            arrOPCServer(iOPC).ServerHandles(i) = arrOPCServer(iOPC).Item.ServerHandle
            MonitorItem_Count += 1
        Next

    End Sub

    Private Sub lstOPCServer_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles lstOPCServer.AfterSelect

        For i = 0 To lstOPCServer.Nodes.Count - 1
            lstOPCServer.Nodes(i).BackColor = Color.White
        Next

        lstOPCServer.SelectedNode.BackColor = Color.Silver
        iOPC = lstOPCServer.SelectedNode.Index

    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        For i = 0 To 10
            arrOPCServer(i).Server = New OPCServer

            Dim Dims() As Integer = New Integer() {1000}
            Dim Bounds() As Integer = New Integer() {1}

            arrOPCServer(i).ServerHandles = Array.CreateInstance(GetType(Integer), Dims, Bounds)
            arrOPCServer(i).Errors = Array.CreateInstance(GetType(Integer), Dims, Bounds)
            arrOPCServer(i).Values = Array.CreateInstance(GetType(Object), Dims, Bounds)
        Next

        '''''''XML setting'''''''''''''''''''
        If IO.File.Exists("MyXML.xml") = False Then

            Dim settings As New XmlWriterSettings()
            settings.Indent = True

            Dim XmlWrt As XmlWriter = XmlWriter.Create("MyXML.xml", settings)

            With XmlWrt

                ' Write the Xml declaration.
                .WriteStartDocument()

                ' Write a comment.
                .WriteComment("XML Database.")

                ' Write the root element.
                .WriteStartElement("Server")

                ' Start our first person.
                .WriteStartElement("Folder")

                ' The person nodes.

                .WriteStartElement("Item")
                .WriteString("testItem")
                .WriteEndElement()

                .WriteStartElement("Monitor")
                .WriteString("yes")
                .WriteEndElement()


                ' The end of this person.
                .WriteEndElement()

                ' Close the XmlTextWriter.
                .WriteEndDocument()
                .Close()

            End With

            MessageBox.Show("XML file saved.")

        End If
        ''''''''''''''''''''

    End Sub

    Private Sub lstOPCServer_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles lstOPCServer.NodeMouseClick

        lstOPCServer.SelectedNode = lstOPCServer.GetNodeAt(e.X, e.Y)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            If lstOPCServer.SelectedNode.ForeColor <> Color.Red Then

                cmsOPCServer.Items(0).Enabled = True
                cmsOPCServer.Items(1).Enabled = False

            Else

                cmsOPCServer.Items(0).Enabled = False
                cmsOPCServer.Items(1).Enabled = True

            End If

            cmsOPCServer.Show(lstOPCServer, New Point(e.X, e.Y))

        Else

            btnBrowseOPCItems_Click(sender, e)

        End If

    End Sub

    Private Sub lstOPCServer_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles lstOPCServer.NodeMouseDoubleClick

        lstOPCServer.SelectedNode = lstOPCServer.GetNodeAt(e.X, e.Y)

        If lstOPCServer.SelectedNode.ForeColor <> Color.Red Then
            btnConnect.Enabled = True
            btnDisconnect.Enabled = False
            btnConnect_Click(sender, e)
        End If

    End Sub

    Private Sub ConnectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectToolStripMenuItem.Click

        btnConnect_Click(sender, e)

    End Sub

    Private Sub DisconnectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisconnectToolStripMenuItem.Click

        arrOPCServer(iOPC).Item = Nothing

        If arrOPCServer(iOPC).Server.ServerState = 1 Then
            arrOPCServer(iOPC).Server.OPCGroups.RemoveAll()
            arrOPCServer(iOPC).Server.Disconnect()
        End If

        arrOPCGroup(iOPC) = Nothing

        lstOPCServer.SelectedNode.ForeColor = Color.Black
        cmsOPCServer.Items(0).Enabled = True
        cmsOPCServer.Items(1).Enabled = False


        StatusConnection.Text = "Disconnected"
        treeOPC.Enabled = False
        lstOPCItems.Enabled = False
        btnBrowseOPCItems.Enabled = False
        btnAddToMonitoring.Enabled = False

    End Sub

    Sub Show_Leafs(ByVal MyOPCBrowser As OPCBrowser)

        MyOPCBrowser.ShowLeafs()

        Dim a, iA

        iA = MyOPCBrowser.Count
        lstOPCItems.Items.Clear()
        lstOPCItems2.Items.Clear()

        For a = 1 To iA

            Dim name1, name2

            name1 = MyOPCBrowser.Item(a)
            name2 = MyOPCBrowser.GetItemID(name1)
            lstOPCItems.Items.Add(name1)
            lstOPCItems2.Items.Add(name2)

        Next

    End Sub

    Sub Show_Branches(ByVal MyOPCBrowser As OPCBrowser, ByVal aNode As TreeNode)

        MyOPCBrowser.ShowBranches()

        If Not aNode Is Nothing Then
            aNode.Nodes.Clear()
        End If

        Dim iA, iB

        iA = MyOPCBrowser.Count

        For a = 1 To iA

            Try

                Dim sName = MyOPCBrowser.Item(a)

                If aNode Is Nothing Then
                    treeOPC.Nodes.Add(sName)
                Else
                    aNode.Nodes.Add(sName)
                End If

                MyOPCBrowser.MoveDown(sName)
                MyOPCBrowser.ShowBranches()
                iB = MyOPCBrowser.Count

                If iB > 0 Then

                    If aNode Is Nothing Then
                        treeOPC.Nodes(a - 1).nodes.Add("-")
                    Else
                        aNode.Nodes(a - 1).Nodes.Add("-")
                    End If

                End If

                MyOPCBrowser.MoveUp()

            Catch ex As Exception
                '
            End Try
            MyOPCBrowser.ShowBranches()
        Next
    End Sub

    Private Sub treeOPC_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles treeOPC.AfterSelect

    End Sub

    Private Sub TimerMonitoring_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerMonitoring.Tick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btReadXML.Click

        If (IO.File.Exists("MyXML.xml")) Then

            Dim document As XmlReader = New XmlTextReader("MyXML.xml")

            While (document.Read())

                Dim type = document.NodeType

                If (type = XmlNodeType.Element) Then

                    If (document.Name = "FirstName") Then

                        'TextBox1.Text = document.ReadInnerXml.ToString()

                    End If

                    If (document.Name = "LastName") Then

                        'TextBox2.Text = document.ReadInnerXml.ToString()

                    End If

                End If

            End While

        Else
            MessageBox.Show("The filename you selected was not found.")
        End If

    End Sub

End Class