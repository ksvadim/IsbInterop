using IsbInterop.IsblSystemConstants.DataConstants.ObjectRequisites;

namespace IsbInterop.Tests.Integration
{
  /// <summary>
  /// Утилиты для работы с документами.
  /// </summary>
  public static class DocumentUtils
  {
    /// <summary>
    /// Создать документ.
    /// </summary>
    /// <param name="name">Имя документа.</param>
    /// <param name="filePath">Путь к файлу.</param>
    /// <returns>ИД электронного документа.</returns>
    public static int CreateDocument(string name, string filePath)
    {
      var context = ContextFactory.CreateContext();
      using (var scope = context.CreateScope())
      {
        var edocumentFactory = scope.Application.EDocumentFactory;
        var document = edocumentFactory.CreateNewFromFile(
          ReferenceConfiguration.DocumentCardTypes.DefaultRecords.ArbitraryFormDocuments.Name,
          ReferenceConfiguration.DocumentKinds.DefaultRecords.OtherDocuments.Code,
          ReferenceConfiguration.DocumentEditors.DefaultRecords.TextEditor.Code,
          filePath);

        document.GetRequisite(PredefinedEDocumentsRequisites.SYSREQ_EDOC_NAME).Value = name;
        document.Save();

        return document.Id;
      }
    }

    /// <summary>
    /// Удалить документ.
    /// </summary>
    /// <param name="documentId">ИД документа.</param>
    public static void DeleteDocument(int documentId)
    {
      var context = ContextFactory.CreateContext();
      using (var scope = context.CreateScope())
      {
        var edocumentFactory = scope.Application.EDocumentFactory;
        edocumentFactory.DeleteById(documentId);
      }
    }

    /// <summary>
    /// Связать документы.
    /// </summary>
    /// <param name="sourceDocumentId">ИД исходного документа.</param>
    /// <param name="documentIdToBind">ИД документа, который нужно связать с исходным.</param>
    public static void BindDocument(int sourceDocumentId, int documentIdToBind)
    {
      var context = ContextFactory.CreateContext();
      using (var scope = context.CreateScope())
      {
        var edocumentFactory = scope.Application.EDocumentFactory;
        var firstTestDocumentInfo = edocumentFactory.GetObjectInfo(sourceDocumentId);
        var secondTestDocumentInfo = edocumentFactory.GetObjectInfo(documentIdToBind);
        edocumentFactory.BindTo(firstTestDocumentInfo, secondTestDocumentInfo);
      }
    }
  }
}
