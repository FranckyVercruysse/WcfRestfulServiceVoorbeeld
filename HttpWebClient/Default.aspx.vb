Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Net.Http
Imports System.Web

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub TestGet_Click(sender As Object, e As EventArgs) Handles TestGet.Click
        If TextGet.Text.Length > 0 Then
            CallGetMethod()
        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "myalert", "alert(' Vul een naam in ! ');", True)
        End If

    End Sub

    Private Sub CallGetMethod()

        Dim client As New HttpClient()
        Dim wcfResponse As HttpResponseMessage = client.GetAsync("http://localhost:52660/HttpService.svc/MijnHttpGet/ingaveNaam/" + TextGet.Text).Result
        Dim stream As HttpContent = wcfResponse.Content
        Dim data = stream.ReadAsStringAsync()

        lblResultGet.Text = HttpUtility.HtmlEncode(data.Result)

    End Sub

    Protected Sub TestPost_Click(sender As Object, e As EventArgs) Handles TestPost.Click
        CallPostMethod()
    End Sub

    Private Sub CallPostMethod()
        ' Restful service URL
        Dim url As String = "http://localhost:52660/HttpService.svc/MijnHttpPostData/Nieuw"

        ' declareer utf8 encoding
        Dim encoding As New UTF8Encoding()

        Dim strResult As String = String.Empty
        Dim xmlString As String = String.Empty


        Dim persoon As Persoon = New Persoon() With {.naam = "Test", .paswoord = "123"}

        Dim xmlser As New XmlSerializer(GetType(Persoon))

        Using memoryStream As New MemoryStream()
            Using xmltextWriter As New XmlTextWriter(memoryStream, encoding)
                ' maak een instantie van de XmlSerializer voor het type 'Persoon'
                xmlser.Serialize(xmltextWriter, persoon)
                xmlString = encoding.GetString(memoryStream.ToArray())
            End Using
        End Using


        ' converteer result naar byte-array gebruikmakend van ut8-encoding
        Dim postData As Byte() = encoding.GetBytes(xmlString)
        ' declareer httpwebrequestuet webrequest met de hierboven gedefiniëerde url
        Dim webrequest As HttpWebRequest = DirectCast(HttpWebRequest.Create(url), HttpWebRequest)
        'set method as post
        webrequest.Method = "POST"
        'set content type
        webrequest.ContentType = "application/x-www-form-urlencoded"
        'set content length
        webrequest.ContentLength = postData.Length
        'haal Stream-object uit webrequest object
        Dim nieuweSteam As Stream = webrequest.GetRequestStream()
        nieuweSteam.Write(postData, 0, postData.Length)
        nieuweSteam.Close()

        'declareer & lees response van service
        Dim webresponse As HttpWebResponse = DirectCast(webrequest.GetResponse(), HttpWebResponse)


        Dim responseString As [String]

        Using stream As Stream = webresponse.GetResponseStream()
            Using reader As New StreamReader(stream, encoding)
                responseString = reader.ReadToEnd()
            End Using
        End Using

        'close the response object
        webresponse.Close()

        Dim persoonResponse As New Persoon

        Using reader As TextReader = New StringReader(responseString)
            persoonResponse = DirectCast(xmlser.Deserialize(reader), Persoon)
        End Using

        lblResultPost.Text = "naam : " + persoonResponse.naam.ToString +
            "       paswoord: " + persoonResponse.paswoord.ToString

        lblResultPostXML.Text = HttpUtility.HtmlEncode(xmlString)
    End Sub
End Class