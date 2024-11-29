<ServiceContract()>
Public Interface IService1
    'GET ALL'
    <OperationContract()>
    Function GetAll() As List(Of CompositeType)

    'GET BY ID'
    <OperationContract()>
    Function GetByID(ByVal id As Integer) As CompositeType

    'CREATE'
    <OperationContract()>
    Function Create(ByVal product As CompositeType) As Boolean

    'UPDATE'
    <OperationContract()>
    Function Update(ByVal product As CompositeType) As Boolean

    'DELETE'
    <OperationContract()>
    Function Delete(ByVal id As Integer) As Boolean



    'CATEGORIAS'


    'GET ALL'
    <OperationContract()>
    Function GetAllCat() As List(Of CompositeType1)

    'GET BY ID'
    <OperationContract()>
    Function GetByIDCat(ByVal id As Integer) As CompositeType1

    'CREATE'
    <OperationContract()>
    Function CreateCat(ByVal product As CompositeType1) As Boolean

    'UPDATE'
    <OperationContract()>
    Function UpdateCat(ByVal product As CompositeType1) As Boolean

    'DELETE'
    <OperationContract()>
    Function DeleteCat(ByVal id As Integer) As Boolean
End Interface


' Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
<DataContract()>
Public Class CompositeType
    <DataMember()>
    Public Property ProductID As Integer

    <DataMember()>
    Public Property ProductName As String

    <DataMember()>
    Public Property CategoryID As Integer

    <DataMember()>
    Public Property UnitPrice As Decimal

    <DataMember()>
    Public Property UnitsInStock As Integer
End Class

'CATEGORIAS'
<DataContract()>
Public Class CompositeType1
    <DataMember()>
    Public Property CategoryID As Integer

    <DataMember()>
    Public Property CategoryName As String

    <DataMember()>
    Public Property Description As String
End Class