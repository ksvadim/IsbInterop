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
    private int tempOrganizationId = 0;

    /// <summary>
    /// Путь к тестовому файлу.
    /// </summary>
    private string testFilePath;

    /// <summary>
    /// ИД первого тестового документа.
    /// </summary>
    private int firstTestDocumentId = 0;

    /// <summary>
    /// ИД второго тестового документа.
    /// </summary>
    private int secondTestDocumentId = 0;

    [SetUp]
    public void Init()
    {
      this.tempOrganizationId = OrganizationUtils.CreateOrganization("test");

      this.testFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestDocument.txt");

      this.firstTestDocumentId = DocumentUtils.CreateDocument("FirstTestDocument", testFilePath);
      this.secondTestDocumentId = DocumentUtils.CreateDocument("SecondTestDocument", testFilePath);

      DocumentUtils.BindDocument(this.firstTestDocumentId, this.secondTestDocumentId);
    }

    [TearDown]
    public void Clean()
    {
      OrganizationUtils.RemoveOrganization(this.tempOrganizationId);
      this.tempOrganizationId = 0;

      var app = IsbApplicationManager.Instance.GetApplication();

      using (var edocumentFactory = app.GetEDocumentFactory())
      {
        edocumentFactory.DeleteById(this.firstTestDocumentId);
        this.firstTestDocumentId = 0;
        edocumentFactory.DeleteById(this.secondTestDocumentId);
        this.secondTestDocumentId = 0;
      }
    }

    [Test]
    public void ReferenceInfo_Get_ShouldSucceed()
    {
      var app = IsbApplicationManager.Instance.GetApplication();

      using (var referencesFactory = app.GetReferencesFactory())
      using (var referenceFactory = referencesFactory.GetReferenceFactory(ReferenceConfiguration.Organizations.ReferenceName))
      {
        var referenceInfo = referenceFactory.GetObjectInfo(this.tempOrganizationId);

        Assert.NotNull(referenceInfo);
      }
    }

    [Test]
    public void EDocumentInfo_Get_ShouldSucceed()
    {
      var app = IsbApplicationManager.Instance.GetApplication();

      using (var edocumentFactory = app.GetEDocumentFactory())
      {
        var edocumentInfo = edocumentFactory.GetObjectInfo(this.firstTestDocumentId);

        Assert.NotNull(edocumentInfo);
      }
    }

    [Test]
    public void BoundEDocument_Search_ShouldSucceed()
    {
      var app = IsbApplicationManager.Instance.GetApplication();

      using (var searchFactory = app.GetSearchFactory())
      using (ISearchForObjectDescription searchDescription = searchFactory.Load("BOUND_EDOCUMENT_SEARCH"))
      {
        using (var edocumentFactory = app.GetEDocumentFactory())
        {
          var edocumentInfo = edocumentFactory.GetObjectInfo(this.firstTestDocumentId);

          searchDescription.InitializeSearch(edocumentInfo);
          using (var documentInfos = searchDescription.Execute<IEDocumentInfo>())
          {
            while (!documentInfos.EOF)
            {
              using (var foundDocument = documentInfos.GetValue())
              {
                Assert.NotNull(foundDocument);
              }

              documentInfos.Next();
            }
          }
        }
      }
    }
  }
}
