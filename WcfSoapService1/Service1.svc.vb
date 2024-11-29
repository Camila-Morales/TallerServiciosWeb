Imports Entities
Imports BLL

Public Class Service1
    Implements IService1

    Public Function GetByID(ByVal id As Integer) As CompositeType Implements IService1.GetByID
        ' Crear una instancia de la capa de lógica de negocios
        Dim bll As New ProductLogic()

        ' Obtener la entidad desde la capa BLL
        Dim entity As Products = bll.RetrieveByID(id)

        ' Validar si se encontró la entidad
        If entity Is Nothing Then
            Return Nothing
        End If

        ' Mapear la entidad al tipo compuesto (CompositeType)
        Dim composite As New CompositeType() With {
        .ProductID = entity.ProductID,
        .ProductName = entity.ProductName,
        .CategoryID = entity.CategoryID,
        .UnitPrice = entity.UnitPrice,
        .UnitsInStock = entity.UnitsInStock
    }
        Return composite
    End Function


    Public Function GetAll() As List(Of CompositeType) Implements IService1.GetAll
        ' Crear una instancia de la capa de lógica de negocios
        Dim bll As New ProductLogic()

        ' Obtener la lista de entidades desde la capa BLL
        Dim entities As List(Of Products) = bll.ListAll()

        ' Validar si la lista no contiene elementos
        If entities Is Nothing OrElse entities.Count = 0 Then
            Return Nothing
        End If

        ' Mapear las entidades a tipos compuestos (CompositeType)
        Dim compositeList As New List(Of CompositeType)()
        For Each entity As Products In entities
            Dim composite As New CompositeType() With {
                .ProductID = entity.ProductID,
                .ProductName = entity.ProductName,
                .CategoryID = entity.CategoryID,
                .UnitPrice = entity.UnitPrice,
                .UnitsInStock = entity.UnitsInStock
            }
            compositeList.Add(composite)
        Next

        Return compositeList
    End Function

    'CREATE'
    Public Function Create(ByVal product As CompositeType) As Boolean Implements IService1.Create
        Try
            ' Crear una instancia de la capa de lógica de negocios
            Dim bll As New ProductLogic()

            ' Mapear el tipo compuesto (CompositeType) a la entidad (Products)
            Dim entity As New Products() With {
            .ProductName = product.ProductName,
            .CategoryID = product.CategoryID,
            .UnitPrice = product.UnitPrice,
            .UnitsInStock = product.UnitsInStock
        }

            ' Llamar al método de creación en la lógica de negocios
            Dim result As Products = bll.Create(entity)

            ' Si el resultado es diferente de Nothing, significa que el producto fue creado
            Return result IsNot Nothing
        Catch ex As Exception
            ' Manejar la excepción adecuadamente
            Throw New FaultException("Error al crear el producto: " & ex.Message)
        End Try
    End Function


    'UPDATE'
    Public Function Update(ByVal product As CompositeType) As Boolean Implements IService1.Update
        Try
            Dim bll As New ProductLogic()
            Dim entity As New Products() With {
            .ProductID = product.ProductID,
            .ProductName = product.ProductName,
            .CategoryID = product.CategoryID,
            .UnitPrice = product.UnitPrice,
            .UnitsInStock = product.UnitsInStock
        }
            Return bll.Update(entity)
        Catch ex As Exception
            Throw
        End Try
    End Function

    'DELETE'
    Public Function Delete(ByVal id As Integer) As Boolean Implements IService1.Delete
        Try
            Dim bll As New ProductLogic()
            Return bll.Delete(id)
        Catch ex As Exception
            Throw
        End Try
    End Function

    'CATEGORIAS'
    Public Function GetByIDCat(ByVal id As Integer) As CompositeType1 Implements IService1.GetByIDCat
        ' Crear una instancia de la capa de lógica de negocios
        Dim bll As New CategoryLogic()

        ' Obtener la entidad desde la capa BLL
        Dim entity As Categories = bll.RetrieveByID(id)

        ' Validar si se encontró la entidad
        If entity Is Nothing Then
            Return Nothing
        End If

        ' Mapear la entidad al tipo compuesto (CompositeType)
        Dim composite As New CompositeType1() With {
            .CategoryID = entity.CategoryID,
            .CategoryName = entity.CategoryName,
            .Description = entity.Description
        }
        Return composite
    End Function


    Public Function GetAllCat() As List(Of CompositeType1) Implements IService1.GetAllCat
        ' Crear una instancia de la capa de lógica de negocios
        Dim bll As New CategoryLogic()

        ' Obtener la lista de entidades desde la capa BLL
        Dim entities As List(Of Categories) = bll.ListAll()

        ' Validar si la lista no contiene elementos
        If entities Is Nothing OrElse entities.Count = 0 Then
            Return Nothing
        End If

        ' Mapear las entidades a tipos compuestos (CompositeType)
        Dim compositeList As New List(Of CompositeType1)()
        For Each entity As Categories In entities
            Dim composite As New CompositeType1() With {
                .CategoryID = entity.CategoryID,
                .CategoryName = entity.CategoryName,
                .Description = entity.Description
            }
            compositeList.Add(composite)
        Next

        Return compositeList
    End Function

    'CREATE'
    Public Function CreateCat(ByVal product As CompositeType1) As Boolean Implements IService1.CreateCat
        Try
            ' Crear una instancia de la capa de lógica de negocios
            Dim bll As New CategoryLogic()

            ' Mapear el tipo compuesto (CompositeType1) a la entidad (Categories)
            Dim entity As New Categories() With {
            .CategoryID = product.CategoryID,  ' Asumiendo que CompositeType1 tiene CategoryID
            .CategoryName = product.CategoryName,  ' Asumiendo que CompositeType1 tiene CategoryName
            .Description = product.Description  ' Asumiendo que CompositeType1 tiene Description
        }

            ' Llamar al método de creación en la lógica de negocios
            Dim result As Categories = bll.Create(entity)

            ' Si el resultado es diferente de Nothing, significa que la categoria fue creada
            Return result IsNot Nothing
        Catch ex As Exception
            ' Manejar la excepción adecuadamente
            Throw New FaultException("Error al crear la categoria: " & ex.Message)
        End Try
    End Function



    'UPDATE'
    Public Function UpdateCat(ByVal product As CompositeType1) As Boolean Implements IService1.UpdateCat
        Try
            Dim bll As New CategoryLogic()

            ' Mapear el tipo compuesto (CompositeType1) a la entidad (Categories)
            Dim entity As New Categories() With {
            .CategoryID = product.CategoryID,  ' Asumiendo que CompositeType1 tiene CategoryID
            .CategoryName = product.CategoryName,  ' Asumiendo que CompositeType1 tiene CategoryName
            .Description = product.Description  ' Asumiendo que CompositeType1 tiene Description
        }

            ' Llamar al método de actualización en la lógica de negocios
            Return bll.Update(entity)
        Catch ex As Exception
            ' Manejar la excepción adecuadamente
            Throw
        End Try
    End Function


    'DELETE'
    Public Function DeleteCat(ByVal id As Integer) As Boolean Implements IService1.DeleteCat
        Try
            Dim bll As New CategoryLogic()
            Return bll.Delete(id)
        Catch ex As Exception
            Throw
        End Try
    End Function

End Class
