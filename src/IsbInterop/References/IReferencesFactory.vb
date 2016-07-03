﻿Namespace References
  ''' <summary>
  ''' Фабрика типов справочников.
  ''' </summary>
  Public Interface IReferencesFactory
    Inherits IIsbComObjectWrapper

    ''' <summary>
    ''' Получить фабрику справочника.
    ''' </summary>
    ''' <param name="name">Имя фабрика справочника.</param>
    ''' <returns>Фабрика справочника с заданным именем.</returns>
    Function GetReferenceFactory(name As String) As IReferenceFactory

  End Interface
End NameSpace