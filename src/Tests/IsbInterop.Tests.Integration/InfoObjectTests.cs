using NUnit.Framework;
using System.IO;
using IsbInterop.EDocuments;
using IsbInterop.Searches;

namespace IsbInterop.Tests.Integration
{
  [TestFixture]
  public class ObjectInfoTests
  {
    /// <summary>
    /// ИД временной организации.
    /// </summary>
    private int _tempOrganizationId = 0;

    /// <summary>
    /// Путь к тестовому файлу.
    /// </summary>
    private string _testFilePath;

    /// <summary>
    /// ИД первого тестового документа.
    /// </summary>
    private int _firstTestDocumentId = 0;

    /// <summary>
    /// ИД второго тестового документа.
    /// </summary>
    private int _secondTestDocumentId = 0;

    [SetUp]
    public void Init()
    {
      _tempOrganizationId = OrganizationUtils.CreateOrganization("test");

      _testFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestDocument.txt");

      _firstTestDocumentId = DocumentUtils.CreateDocument("FirstTestDocument", _testFilePath);
      _secondTestDocumentId = DocumentUtils.CreateDocument("SecondTestDocument", _testFilePath);

      DocumentUtils.BindDocument(_firstTestDocumentId, _secondTestDocumentId);
    }

    [TearDown]
    public void Clean()
    {
      OrganizationUtils.RemoveOrganization(_tempOrganizationId);
      _tempOrganizationId = 0;

      var context = ContextFactory.CreateContext();
      using (var scope = context.CreateScope())
      {
        var edocumentFactory = scope.Application.GetEDocumentFactory();
        edocumentFactory.DeleteById(_firstTestDocumentId);
        _firstTestDocumentId = 0;
        edocumentFactory.DeleteById(_secondTestDocumentId);
        _secondTestDocumentId = 0;
      }
    }

    [Test]
    public void ReferenceInfo_Get_ShouldSucceed()
    {
      var context = ContextFactory.CreateContext();
      using (var scope = context.CreateScope())
      {
        var referencesFactory = scope.Application.GetReferencesFactory();
        var referenceFactory = referencesFactory.GetReferenceFactory(ReferenceConfiguration.Organizations.ReferenceName);

        var referenceInfo = referenceFactory.GetObjectInfo(_tempOrganizationId);

        Assert.NotNull(referenceInfo);
      }
    }

    [Test]
    public void EDocumentInfo_Get_ShouldSucceed()
    {
      var context = ContextFactory.CreateContext();
      using (var scope = context.CreateScope())
      {
        var edocumentFactory = scope.Application.GetEDocumentFactory();
        var edocumentInfo = edocumentFactory.GetObjectInfo(_firstTestDocumentId);

        Assert.NotNull(edocumentInfo);
      }
    }

    [Test]
    public void BoundEDocument_Search_ShouldSucceed()
    {
      var context = ContextFactory.CreateContext();
      using (var scope = context.CreateScope())
      {
        var searchFactory = scope.Application.GetSearchFactory();
        var searchDescription = searchFactory.Load("BOUND_EDOCUMENT_SEARCH");
        var edocumentFactory = scope.Application.GetEDocumentFactory();
        var edocumentInfo = edocumentFactory.GetObjectInfo(_firstTestDocumentId);

        searchDescription.InitializeSearch(edocumentInfo);
        var documentInfos = searchDescription.Execute<IEDocumentInfo>();
        while (!documentInfos.EOF)
        {
          var foundDocument = documentInfos.GetValue();
          Assert.NotNull(foundDocument);
          documentInfos.Next();
        }
      }
    }
  }
}
