Imports System.IO
Imports System.ServiceModel

<ServiceContract()>
Public Interface IHttpService
    <OperationContract(Name:="GetSampleMethod")>
    <WebInvoke(Method:="GET",
              UriTemplate:="MijnHttpGet/ingaveNaam/{naam}")>
    Function TestGetData(ByVal naam As String) As String

    <OperationContract(Name:=“MijnHttpPostData”)>
    <WebInvoke(Method:=“POST”,
         UriTemplate:=“MijnHttpPostData/Nieuw”)>
    Function TestPostData(data As Stream) As Persoon
End Interface

<DataContract([Namespace]:="")>
Public Class Persoon

    ' Deze private variable wordt niet ge serialiseerd, wel de property ervan.
    Private naamValue As String

    'wordt geserialiseerd
    <DataMember()>
    Public Property naam() As String
        Get
            Return naamValue
        End Get
        Set
            naamValue = Value
        End Set
    End Property

    ' Deze private variable serialized, but the property is.
    Private paswoordValue As String

    <DataMember()>
    Public Property paswoord() As String
        Get
            Return paswoordValue
        End Get
        Set
            paswoordValue = Value
        End Set
    End Property
End Class
