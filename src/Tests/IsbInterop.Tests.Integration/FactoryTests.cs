using IsbInterop.DataTypes.Enumerable;
using NUnit.Framework;
using System;

namespace IsbInterop.Tests.Integration
{
  [TestFixture]
  public class FactoryTests
  {
    /// <summary>
    /// ИД временной организации.
    /// </summary>
    private int tempOrganizationId = 0;

    [SetUp]
    public void Init()
    {
      this.tempOrganizationId = OrganizationUtils.CreateOrganization("test");
    }

    [TearDown]
    public void Clean()
    {
      OrganizationUtils.RemoveOrganization(this.tempOrganizationId);
    }

    [Test]
    public void Factory_GetKind_ShouldSucceed()
    {
      var context = ContextFactory.CreateContext();
      using (var scope = context.CreateScope())
      {
        var referencesFactory = scope.Application.GetReferencesFactory();
        var referenceFactory = referencesFactory.GetReferenceFactory(ReferenceConfiguration.Organizations.ReferenceName);
        var objectKind = referenceFactory.Kind;

        Assert.AreEqual(objectKind, TContentKind.ckReference);
      }
    }

    [Test]
    public void Factory_GetNonExistentObject_ThrowsIsbIntropException()
    {
      var context = ContextFactory.CreateContext();
      using (var scope = context.CreateScope())
      {
        var referencesFactory = scope.Application.GetReferencesFactory();
        var referenceFactory = referencesFactory.GetReferenceFactory(ReferenceConfiguration.Organizations.ReferenceName);
        Assert.Catch<IsbInteropException>(() => referenceFactory.GetObjectById(-1));
      }
    }

    [Test]
    public void References_EditObjectWithoutSave_CloseRecordShouldFail()
    {
      var context = ContextFactory.CreateContext();
      using (var scope = context.CreateScope())
      {
        var referencesFactory = scope.Application.GetReferencesFactory();

        Assert.Catch<IsbInteropException>(() =>
        {
          var referenceFactory = referencesFactory.GetReferenceFactory(ReferenceConfiguration.Organizations.ReferenceName);
          var reference = referenceFactory.GetObjectById(tempOrganizationId);

          var noteRequisite = reference.GetRequisite(ReferenceConfiguration.Organizations.Requisites.Note);
          noteRequisite.Value = Guid.NewGuid().ToString();

          reference.CloseRecord();
          reference.Close();
        });
      }
    }
  }
}
