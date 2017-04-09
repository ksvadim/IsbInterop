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
      var context = ContextFactory.CreateContext();
      using (var scope = context.CreateScope())
      {
        var referencesFactory = scope.Application.ReferencesFactory;
        var referenceFactory = referencesFactory.GetReferenceFactory(ReferenceConfiguration.Organizations.ReferenceName);
        var historyComponent = referenceFactory.GetHistory(tempOrganizationId);
        var form = historyComponent.GetComponentForm();
      
        form.ShowNoModal();
      }
    }
  }
}
