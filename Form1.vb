Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TreeView1.DrawMode = TreeViewDrawMode.OwnerDrawText
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
    Dim webpage As String = ""

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim hhh As String = "http://" & TextBox1.Text.Trim & ":" & TextBox2.Text.Trim & "/api/v1/allmetrics?format=json"
        webpage = hhh
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
        TextBox4.Enabled = True
        Button7.Enabled = True

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

    Sub UnsetColor(ByVal TV As TreeView)
        For Each TVNode As TreeNode In TV.Nodes
            UnsetColorRecursion(TVNode, TV.BackColor)
        Next
    End Sub
    Sub UnsetColorRecursion(ByVal TN As TreeNode, ByVal BGcolor As Color)
        TN.BackColor = BGcolor
        For Each TVNode As TreeNode In TN.Nodes
            UnsetColorRecursion(TVNode, BGcolor)
        Next
    End Sub
    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        UnsetColor(sender)
        e.Node.BackColor = Color.Gray
    End Sub
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If TextBox4.Focus() = False Then
            Exit Sub
        End If
        Button5.Enabled = True
        Button6.Enabled = True
        RadioButton1.Enabled = True
        RadioButton2.Enabled = True
        RadioButton3.Enabled = True

        cercami()

    End Sub
    Sub cercami()
        If SearchTheTreeView(TreeView1, TextBox4.Text.ToLower.Trim) Is Nothing Then

        Else
            TreeView1.SelectedNode = SearchTheTreeView(TreeView1, TextBox4.Text.ToLower.Trim)
        End If
    End Sub
    Dim NodesThatMatch As New List(Of TreeNode)

    Private Function SearchTheTreeView(ByVal TV As TreeView, ByVal TextToFind As String) As TreeNode
        '  Empty previous
        NodesThatMatch.Clear()

        ' Keep calling RecursiveSearch
        For Each TN As TreeNode In TV.Nodes
            If RadioButton1.Checked Then
                If TN.Text.StartsWith(TextToFind) Then
                    NodesThatMatch.Add(TN)
                End If
            ElseIf RadioButton2.Checked Then
                If TN.Text.Contains(TextToFind) Then
                    NodesThatMatch.Add(TN)
                End If
            ElseIf RadioButton3.Checked Then
                If TN.Text.EndsWith(TextToFind) Then
                    NodesThatMatch.Add(TN)
                End If
            End If


            RecursiveSearch(TN, TextToFind)
        Next

        If NodesThatMatch.Count > 0 Then
            Label7.Text = "Search istances: 1 of " & NodesThatMatch.Count
            numero = 0
            colorami = NodesThatMatch(0)
            Return NodesThatMatch(0)
            colorami = Nothing
        Else
            numero = 0
            Label7.Text = "Search istances: 0"
            Return Nothing
        End If

    End Function

    Private Sub RecursiveSearch(ByVal treeNode As TreeNode, ByVal TextToFind As String)

        ' Keep calling the test recursively.
        For Each TN As TreeNode In treeNode.Nodes
            If RadioButton1.Checked Then
                If TN.Text.StartsWith(TextToFind) Then
                    NodesThatMatch.Add(TN)
                End If
            ElseIf RadioButton2.Checked Then
                If TN.Text.Contains(TextToFind) Then
                    NodesThatMatch.Add(TN)
                End If
            ElseIf RadioButton3.Checked Then
                If TN.Text.EndsWith(TextToFind) Then
                    NodesThatMatch.Add(TN)
                End If
            End If


            RecursiveSearch(TN, TextToFind)
        Next
    End Sub

    Dim numero As Integer = 0

    Dim colorami As TreeNode = Nothing

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        numero = numero + 1


        If numero > NodesThatMatch.Count - 1 Then
            numero = numero - 1
            Exit Sub
        End If
        Label7.Text = "Search istances: " & numero + 1 & " of " & NodesThatMatch.Count
        colorami = NodesThatMatch(numero)
        TreeView1.SelectedNode = NodesThatMatch(numero)
        colorami = Nothing
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        numero = numero - 1
        If numero < 0 Then
            numero = 0
            Exit Sub
        End If
        Label7.Text = "Search istances: " & numero + 1 & " of " & NodesThatMatch.Count
        colorami = NodesThatMatch(numero)
        TreeView1.SelectedNode = NodesThatMatch(numero)
        colorami = Nothing
    End Sub

    Private Sub TreeView1_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeSelect

    End Sub

    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick

        TextBox4.Text = e.Node.Text

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

        cercami()

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

        cercami()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged

        cercami()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim webx As String = webpage
        If RadioButton4.Checked Then

        ElseIf RadioButton5.Checked Then
            webx = webx.Replace("?format=json", "?format=prometheus")
        ElseIf RadioButton6.Checked Then
            webx = webx.Replace("?format=json", "")

        End If
        NavigateWebURL(webx, "default")
    End Sub
    Private Sub NavigateWebURL(ByVal URL As String, Optional browser As String = "default")

        If Not (browser = "default") Then
            Try
                '// try set browser if there was an error (browser not installed)
                Process.Start(browser, URL)
            Catch ex As Exception
                '// use default browser
                Process.Start(URL)
            End Try

        Else
            '// use default browser
            Process.Start(URL)

        End If

    End Sub


    Private greenBrush As SolidBrush = New SolidBrush(Color.Gray)
    Private graybrush As SolidBrush = New SolidBrush(Color.DarkGray)

    Private Sub TreeView1_DrawNode(sender As Object, e As DrawTreeNodeEventArgs) Handles TreeView1.DrawNode
        If e.Node.IsSelected Then
            If TreeView1.Focused Then e.Graphics.FillRectangle(greenBrush, e.Bounds)
        Else
            e.Graphics.FillRectangle(Brushes.White, e.Bounds)
        End If
        If colorami Is Nothing Then
        Else
            If colorami Is e.Node Then
                e.Graphics.FillRectangle(graybrush, e.Bounds)
                colorami = Nothing
            End If
        End If

        TextRenderer.DrawText(e.Graphics, e.Node.Text, e.Node.TreeView.Font, e.Node.Bounds, e.Node.ForeColor)
    End Sub

    Private Sub TreeView1_MouseDown(sender As Object, e As MouseEventArgs) Handles TreeView1.MouseDown

    End Sub
End Class

<Serializable()>
Public Class clsTreeFile
    Public oTreeNode As TreeNode
End Class