using IsbInterop.Data;
using NUnit.Framework;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace IsbInterop.Tests.Integration
{
  [TestFixture]
  public class ObjectTests
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
    private int testDocumentId = 0;

    [SetUp]
    public void Init()
    {
      this.tempOrganizationId = OrganizationUtils.CreateOrganization("test");

      this.testFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestDocument.txt");
      this.testDocumentId = DocumentUtils.CreateDocument("TestDocument", testFilePath);
    }

    [TearDown]
    public void Clean()
    {
      OrganizationUtils.RemoveOrganization(this.tempOrganizationId);

      var context = ContextFactory.CreateContext();
      using (var scope = context.CreateScope())
      {
        var edocumentFactory = scope.Application.GetEDocumentFactory();
        edocumentFactory.DeleteById(this.testDocumentId);
        this.testDocumentId = 0;
      }
    }

    [Test]
    public void References_GetObjectById_ShouldSucceed()
    {
      var context = ContextFactory.CreateContext();
      using (var scope = context.CreateScope())
      {

        var referencesFactory = scope.Application.GetReferencesFactory();
        var referenceFactory = referencesFactory.GetReferenceFactory(ReferenceConfiguration.Organizations.ReferenceName);
        var reference = referenceFactory.GetObjectById(this.tempOrganizationId);

        Assert.NotNull(reference);
      }
    }

    [Test]
    public void EDocuments_GetObjectById_ShouldSucceed()
    {
      int? documentId = null;

      var context = ContextFactory.CreateContext();
      using (var scope = context.CreateScope())
      {
        var edocumentFactory = scope.Application.GetEDocumentFactory();

        var document = edocumentFactory.GetObjectById(this.testDocumentId);
        documentId = document.Id;
      }

      Assert.NotNull(documentId);
    }

    [Test]
    public void EDocument_GetVersion_ShouldSucceed()
    {
      var context = ContextFactory.CreateContext();
      using (var scope = context.CreateScope())
      {
        var edocumentFactory = scope.Application.GetEDocumentFactory();
        var document = edocumentFactory.GetObjectById(this.testDocumentId);
        var documentVersionList = document.GetVersions();
        var version = documentVersionList.GetValues(0);

        Assert.NotNull(version);
      }
    }

    [Test]
    public void Script_GetParamValue_ShouldSucceed()
    {
      var context = ContextFactory.CreateContext();
      using (var scope = context.CreateScope())
      {
        var scriptFactory = scope.Application.GetScriptFactory();
        var script = scriptFactory.GetObjectByName(ReferenceConfiguration.Scripts.ConstantValue.ScriptName);
        var scriptParams = script.GetParams();
        scriptParams.SetVar(ReferenceConfiguration.Scripts.ConstantValue.Params.ConstName, "Weight");
        var param = scriptParams.GetValues(0);
        var rcwObject = ((IUnsafeRcwHolder)param).UnsafeRcwObject;

        Assert.NotNull(rcwObject);
      }
    }

    [Test]
    public void Script_DisposeIntegerParam_ShouldSucceed()
    {
      var context = ContextFactory.CreateContext();
      using (var scope = context.CreateScope())
      {
        var scriptFactory = scope.Application.GetScriptFactory();
        var script = scriptFactory.GetObjectByName(ReferenceConfiguration.Scripts.ConstantValue.ScriptName);

        var scriptParams = script.GetParams();
        scriptParams.SetVar(ReferenceConfiguration.Scripts.ConstantValue.Params.ConstValue, 123);
        var param = scriptParams.GetValues(0);
        param.Dispose();

        TestDelegate getRcwAction = () => { var a = ((IUnsafeRcwHolder)param).UnsafeRcwObject; };

        Assert.Throws<ObjectDisposedException>(getRcwAction);
      }
    }

    [Test]
    public void IReference_GetIPickRequisite_ShouldSucceed()
    {
      var context = ContextFactory.CreateContext();
      using (var scope = context.CreateScope())
      {
        var referencesFactory = scope.Application.GetReferencesFactory();
        var referenceFactory = referencesFactory.GetReferenceFactory(ReferenceConfiguration.Organizations.ReferenceName);
        var reference = referenceFactory.GetObjectById(this.tempOrganizationId);
        var stateRequisite = reference.GetRequisite(ReferenceConfiguration.CommonRequisites.State) as IPickRequisite;

        Assert.NotNull(stateRequisite);
      }
    }

    [Ignore("Создайте сценарий MyTestScript с функцией Exit()")]
    [Test]
    public void ExecuteScript_WithExitFunction_ShouldSucceed()
    {
      TestDelegate executeScriptAction = () =>
      {
        var context = ContextFactory.CreateContext();
        using (var scope = context.CreateScope())
        {
          var scriptFctory = scope.Application.GetScriptFactory();
          var script = scriptFctory.GetObjectByName("MyTestScript");
        
          script.Execute();
        }
      };

      var exception = Assert.Throws<IsbInteropException>(executeScriptAction);
      Assert.IsTrue(exception.InnerException is COMException &&
        exception.InnerException.Source == "ESBUserAbort{A0462B03-C050-40B1-A176-9456937CDAAC}ecException");
    }
  }
}
