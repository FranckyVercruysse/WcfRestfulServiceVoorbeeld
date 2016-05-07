Imports System.IO
Imports System.Text
Imports System.Xml.Serialization

Module Module1

    Sub Main()

        Dim persoon As Persoon = New Persoon() With {.naam = "Francky", .paswoord = "123"}
        Console.WriteLine("Naam persoon     : {0}", persoon.naam.ToString())
        Console.WriteLine("paswoord persoon : {0}", persoon.paswoord.ToString())

        'Dim encoding As New ASCIIEncoding()

        Dim postData As String = String.Empty

        Dim xmlser As New XmlSerializer(persoon.GetType)

        Using textWriter As New StringWriter()
            xmlser.Serialize(textWriter, persoon)
            postData = textWriter.ToString
        End Using

        Console.WriteLine("Geserialiseerde data : {0}", postData)

        Dim pers As Persoon

        Using reader As TextReader = New StringReader(postData)
            pers = xmlser.Deserialize(reader)
        End Using

        Console.WriteLine("Na deserialisatie")
        Console.WriteLine("Naam persoon     : {0}", pers.naam.ToString())
        Console.WriteLine("paswoord persoon : {0}", pers.paswoord.ToString())

        Console.ReadKey()
    End Sub
End Module
