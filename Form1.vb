Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub FindNode(ByVal tNode As TreeNode)
        Dim tn As TreeNode
        For Each tn In tNode.Nodes
            If tn.Text.Trim.EndsWith(":") And tn.Text.Trim.Contains("resources") = False Then
                Exit For
            Else
                TreeView1.SelectedNode = tn
                TreeView1.SelectedNode.Expand()
                Application.DoEvents()

            End If
            FindNode(tn)
        Next
        TreeView1.SelectedNode = TreeView1.Nodes(0)
    End Sub

    Dim l As List(Of String)
    Dim contali As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim hhh As String = "http://" & TextBox1.Text.Trim & ":" & TextBox2.Text.Trim & "/api/v1/allmetrics?format=json"
        request = DirectCast(WebRequest.Create(hhh), HttpWebRequest)
        Try
            response = DirectCast(request.GetResponse(), HttpWebResponse)
        Catch ex As Exception
            MsgBox("Cannot connect to: " & TextBox1.Text & " be shure is right server IP and PORT")
            Exit Sub
        End Try

        reader = New StreamReader(response.GetResponseStream())
        l = New List(Of String)
        l.Clear()


        Dim json As String = reader.ReadToEnd

        Dim ser As JObject = JObject.Parse(json)
        Dim data As List(Of JToken) = ser.Children().ToList
        Dim datagroup As New List(Of String)
        Dim num As Integer = 0
        For Each item As JProperty In data

            For Each comment As JObject In item
                Dim u As String = comment("name")


                For Each item2 As JProperty In comment("dimensions")

                    For Each comment2 As JObject In item2
                        num = 0



                        For Each s1 As String In datagroup
                            If s1 = u.ToLower Then
                                num = num + 1
                            End If
                        Next
                        datagroup.Add(u.ToLower)

                        Dim k2 As Object = comment2("name")
                        contali = contali + 1
                        l.Add(u & "_" & k2 & ":") '"CStr(num) & ":")
                        l.Add("data_group: " & u)
                        l.Add("element: " & k2)
                    Next
                Next




            Next



        Next





        'create a new TreeView

        TreeView1.Nodes.Clear()
        'Creating the root node
        Dim root = New TreeNode("sensor:")
        TreeView1.Nodes.Add(root)
        TreeView1.Nodes(0).Nodes.Add(New TreeNode("- platform: netdata"))
        TreeView1.Nodes(0).ForeColor = Color.Black


        TreeView1.Nodes(0).Nodes(0).Nodes.Add(New TreeNode("host: " & TextBox1.Text.Trim))
        TreeView1.Nodes(0).Nodes(0).ForeColor = Color.Black

        TreeView1.Nodes(0).Nodes(0).Nodes.Add(New TreeNode("port: " & TextBox2.Text))
        TreeView1.Nodes(0).Nodes(0).Nodes(0).ForeColor = Color.Black


        TreeView1.Nodes(0).Nodes(0).Nodes.Add(New TreeNode("name: " & TextBox3.Text.Trim.Replace(" ", "-")))
        TreeView1.Nodes(0).Nodes(0).Nodes(1).ForeColor = Color.Black

        TreeView1.Nodes(0).Nodes(0).Nodes.Add(New TreeNode("resources:"))
        TreeView1.Nodes(0).Nodes(0).Nodes(2).ForeColor = Color.Black


        'Creating child nodes under the first child
        Dim conta As Integer = -1
        For Each s As String In l
            If s.Trim.EndsWith(":") Then
                conta = conta + 1
                TreeView1.Nodes(0).Nodes(0).Nodes(3).Nodes.Add(New TreeNode(s.Trim))

                TreeView1.Nodes(0).Nodes(0).Nodes(3).Nodes(conta).ForeColor = Color.DarkGreen

            Else
                TreeView1.Nodes(0).Nodes(0).Nodes(3).Nodes(conta).Nodes.Add(New TreeNode(s.Trim))
                TreeView1.Nodes(0).Nodes(0).Nodes(3).Nodes(conta).Nodes(0).ForeColor = Color.DarkOliveGreen
                If s.Trim.ToLower.StartsWith("element:") Then
                    TreeView1.Nodes(0).Nodes(0).Nodes(3).Nodes(conta).Nodes(1).ForeColor = Color.DarkOliveGreen
                End If


            End If



        Next
        ' creating child nodes under the root
        Dim Nodes As TreeNodeCollection = TreeView1.Nodes
        Dim Node As TreeNode
        For Each Node In Nodes
            FindNode(Node)
        Next
        contali = 0
        Label5.Text = "Items Selected: " & contali

        addall(False)


        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True

    End Sub


    Private Sub savenode()

        'create buffer for storing string data
        Dim buffer As New List(Of String)
        'loop through each of the treeview's root nodes
        For Each rootNode As TreeNode In TreeView1.Nodes
            'call recursive function
            BuildTreeString(rootNode, buffer)
        Next
        'write data to file
        Dim w As New StreamWriter(Application.StartupPath & "\NetDATA-HA-Config.txt")
        Dim spazio As String = ""
        For x As Integer = 0 To buffer.Count - 1
            Select Case x
                Case 0
                    spazio = ""
                Case 1
                    spazio = "  "
                Case 2, 3, 4, 5
                    spazio = "    "
                Case Else
                    If x Mod 3 = 0 Then
                        spazio = "      "
                    End If
                    If x Mod 3 = 1 Or x Mod 3 = 2 Then
                        spazio = "        "
                    End If
            End Select
            w.WriteLine(spazio & Space(NumericUpDown1.Value) & buffer(x))
        Next
        w.WriteLine("")
        w.WriteLine("")
        w.WriteLine("")

        w.Close()
        w.Dispose()
        MessageBox.Show("NetDATA HA Config saved successfully.", "File saved", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub BuildTreeString(ByVal rootNode As TreeNode, buffer As List(Of String))

        If rootNode.ForeColor = Color.DarkRed Or rootNode.ForeColor = Color.IndianRed Then

        Else
            buffer.Add(rootNode.Text)
        End If



        Dim spazio As String = ""
        For Each childNode As TreeNode In rootNode.Nodes
            BuildTreeString(childNode, buffer)
        Next


    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        savenode()
        Process.Start("explorer.exe", "/select," & Application.StartupPath & "\NetDATA-HA-Config.txt")

    End Sub
    Dim node As TreeNode


    Private Sub RemoveITEMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveITEMToolStripMenuItem.Click
        node.ForeColor = Color.DarkRed
        contali = contali - 1
        Label5.Text = "Items Selected: " & contali

        For Each top As TreeNode In node.Nodes
            top.ForeColor = Color.IndianRed
        Next
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        node.ForeColor = Color.DarkGreen
        contali = contali + 1
        Label5.Text = "Items Selected: " & contali
        For Each top As TreeNode In node.Nodes
            top.ForeColor = Color.DarkOliveGreen
        Next
    End Sub

    Private Sub TreeView1_MouseUp(sender As Object, e As MouseEventArgs) Handles TreeView1.MouseUp
        If e.Button = MouseButtons.Right Then
            Dim ClickPoint As Point = New Point(e.X, e.Y)
            Dim ClickNode As TreeNode = TreeView1.GetNodeAt(ClickPoint)
            If ClickNode Is Nothing Then
                Return
            End If
            TreeView1.SelectedNode = ClickNode
            Dim c As Color = ClickNode.ForeColor

            ' Convert from Tree coordinates to Screen coordinates    
            Dim ScreenPoint As Point = TreeView1.PointToScreen(ClickPoint)
            ' Convert from Screen coordinates to Form coordinates    
            Dim FormPoint As Point = Me.PointToClient(ScreenPoint)

            If c = Color.DarkGreen Then

                node = ClickNode
                ContextMenuStrip2.Show(Me, FormPoint)
            End If

            If c = Color.DarkRed Then

                node = ClickNode
                ContextMenuStrip1.Show(Me, FormPoint)
            End If

        End If

    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        contali = 0
        Label5.Text = "Items Selected: " & contali

        Button4.Enabled = True
        addall(False)
    End Sub

    Sub addall(abilita As Boolean)
        For Each rootNode As TreeNode In TreeView1.Nodes
            'call recursive function
            abilitali(rootNode, abilita)
        Next
    End Sub
    Private Sub abilitali(ByVal rootNode As TreeNode, abilita As Boolean)

        If abilita Then
            If rootNode.ForeColor = Color.DarkRed Or rootNode.ForeColor = Color.DarkGreen Then
                contali = contali + 1
            End If

            If rootNode.ForeColor = Color.DarkRed Then
                rootNode.ForeColor = Color.DarkGreen
            End If

            If rootNode.ForeColor = Color.IndianRed Then
                rootNode.ForeColor = Color.DarkOliveGreen
            End If
        Else
            If rootNode.ForeColor = Color.DarkGreen Then
                rootNode.ForeColor = Color.DarkRed
            End If

            If rootNode.ForeColor = Color.DarkOliveGreen Then
                rootNode.ForeColor = Color.IndianRed
            End If

        End If





        For Each childNode As TreeNode In rootNode.Nodes
            abilitali(childNode, abilita)
        Next


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button3.Enabled = True

        contali = 0
        addall(True)
        Label5.Text = "Items Selected: " & contali
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub
End Class

<Serializable()>
Public Class clsTreeFile
    Public oTreeNode As TreeNode
End Class