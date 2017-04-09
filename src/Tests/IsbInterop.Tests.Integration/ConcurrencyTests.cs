using NUnit.Framework;
using System;
using System.Threading;

namespace IsbInterop.Tests.Integration
{
  [TestFixture]
  public class ConcurrencyTests
  {
    private readonly ManualResetEvent blocker = new ManualResetEvent(false);

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
    public void UpdateRecord_WithTwoThreads_ShouldSucceed()
    {
      bool operationSucceed = false;
      var secondThread = new Thread(() => operationSucceed = this.ActWithReference(tempOrganizationId));

      var context = ContextFactory.CreateContext();
      using (var scope = context.CreateScope())
      {
        var referencesFactory = scope.Application.ReferencesFactory;
        var referenceFactory = referencesFactory.GetReferenceFactory(ReferenceConfiguration.Organizations.ReferenceName);
        var reference = referenceFactory.GetObjectById(tempOrganizationId);
        reference.GetRequisite(ReferenceConfiguration.Organizations.Requisites.Note).Value = "Punch";
        secondThread.Start();
        blocker.Set();
        secondThread.Join();
        reference.Save();
      }

      Assert.IsTrue(operationSucceed);
    }

    /// <summary>
    /// Выполнить действие с записью справочника.
    /// </summary>
    /// <param name="recodId">ИД записи справочника.</param>
    /// <returns>True, если операция успешна, иначе false.</returns>
    public bool ActWithReference(int recodId)
    {
      try
      {
        var context = ContextFactory.CreateContext();
        using (var scope = context.CreateScope())
        {
          var referencesFactory = scope.Application.ReferencesFactory;
          var referenceFactory = referencesFactory.GetReferenceFactory(ReferenceConfiguration.Organizations.ReferenceName);
          var reference = referenceFactory.GetObjectById(recodId);
          reference.GetRequisite(ReferenceConfiguration.Organizations.Requisites.Note).Value = "Pinch";
          blocker.WaitOne();
          reference.Save();

          return true;
        }
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}
