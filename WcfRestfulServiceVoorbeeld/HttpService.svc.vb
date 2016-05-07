Imports System.IO

Public Class HttpService
    Implements IHttpService

    Public Function TestGetData(naam As String) As String Implements IHttpService.TestGetData

        Dim strReturnValue As New StringBuilder()
        strReturnValue.Append(String.Format("De naam die u ingevoerd hebt is : {0}", naam))
        Return strReturnValue.ToString()
    End Function

    Public Function TestPostData(data As Stream) As Persoon Implements IHttpService.TestPostData
        Dim dcs As New DataContractSerializer(GetType(Persoon))
        ' Deserialize the data and read it from the instance.
        Dim deserializedPersoon As Persoon = DirectCast(dcs.ReadObject(data), Persoon)

        Return deserializedPersoon
    End Function
End Class
