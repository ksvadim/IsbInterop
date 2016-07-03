using NUnit.Framework;

namespace IsbInterop.Tests.Integration
{
  [TestFixture]
  public class Presentation
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

    [Test, Category("UI")]
    public void Object_GetForm_ShouldSucceed()
    {
      var app = IsbApplicationManager.Instance.GetApplication();
      using (var referencesFactory = app.GetReferencesFactory())
      using (var referenceFactory = referencesFactory.GetReferenceFactory(ReferenceConfiguration.Organizations.ReferenceName))
      using (var historyComponent = referenceFactory.GetHistory(tempOrganizationId))
      using (var form = historyComponent.GetComponentForm())
      {
        form.ShowNoModal();
      }
    }
  }
}
