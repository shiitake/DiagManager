Option Explicit 

Dim SqlServer, WindowsAuth, SqlLogin, SqlPassword
Dim cn, strCn, rs, cmd

If WScript.Arguments.Count < 4 Then
  WScript.Echo "Usage: enumdbs.vbs <sqlserver> <windowsauth> <sqllogin> <sqlpassword>"
  WScript.Echo ""
  WScript.Echo "   <windowsauth> is 0 or 1"
  WScript.Echo ""
  WScript.Quit (-1)
Else
  SqlServer = WScript.Arguments(0)
  WindowsAuth = WScript.Arguments(1)
  SqlLogin = WScript.Arguments(2)
  SqlPassword = WScript.Arguments(3)
End If

' Open connection
Set cn = CreateObject("ADODB.Connection") 
strCn = "Provider=sqloledb;Data Source=" & SqlServer 
If WindowsAuth = "1" Then
  strCn = strCn & ";Integrated Security=SSPI;" 
Else
  strCn = strCn & ";UID=" & SqlLogin & ";PWD=" & SqlPassword
End If
cn.Open strCn

' Run query
Set rs = CreateObject("ADODB.Recordset")
Set cmd = CreateObject("ADODB.Command")
cmd.CommandText = "SELECT name FROM master.dbo.sysdatabases"
cmd.ActiveConnection = cn
Set rs = cmd.Execute
Do While (Not rs.EOF)
  WScript.Echo rs("name")
  rs.MoveNext
Loop
rs.Close
cn.Close
WScript.Quit (0)
