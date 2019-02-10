Imports Microsoft.VisualBasic

Public Class xmlFunctions

    'Public Function Base64_HMACSHA256(ByVal iteration As Integer, ByVal sTextToHash As String, ByVal sSharedSecretKey As String)


    Public Function Base64_HMACSHA256(ByVal iteration As Integer, ByVal sTextToHash As String, ByVal sSharedSecretKey As String)
        Dim asc, enc As Object
        asc = CreateObject("System.Text.UTF8Encoding")

        Dim TextToHash() As Byte
        Dim SharedSecretKey() As Byte
        asc = CreateObject("System.Text.UTF8Encoding")
        enc = CreateObject("System.Security.Cryptography.HMACSHA256")
        TextToHash = asc.GetBytes(sTextToHash)
        SharedSecretKey = asc.GetBytes(sSharedSecretKey)
        enc.Key = SharedSecretKey
        Dim bytes() As Byte
        bytes = enc.ComputeHash((TextToHash))
        For i = 1 To iteration
            bytes = enc.ComputeHash((bytes))
        Next

        Base64_HMACSHA256 = EncodeBase64(bytes)
        Return Base64_HMACSHA256

        asc = Nothing
        enc = Nothing
    End Function
    Private Function EncodeBase64(ByRef arrData() As Byte) As String
        Dim objXML As Object
        Dim objNode As Object
        objXML = CreateObject("MSXML2.DOMDocument")
        objNode = objXML.createElement("b64")
        objNode.DataType = "bin.base64"
        objNode.nodeTypedValue = arrData
        EncodeBase64 = objNode.Text
        objNode = Nothing
        objXML = Nothing
    End Function
End Class
