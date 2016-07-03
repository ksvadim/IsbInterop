namespace IsbInterop.Tests.Integration
{
  /// <summary>
  /// Утилиты для работ с организацией.
  /// </summary>
  public static class OrganizationUtils
  {
    /// <summary>
    /// Создать запись организации.
    /// </summary>
    /// <param name="name">Имя организации.</param>
    /// <returns>ИД организации.</returns>
    public static int CreateOrganization(string name)
    {
      var app = IsbApplicationManager.Instance.GetApplication();
      using (var referencesFactory = app.GetReferencesFactory())
      using (var referenceFactory = referencesFactory.GetReferenceFactory(ReferenceConfiguration.Organizations.ReferenceName))
      {
        var tempOrganization = referenceFactory.CreateNew();
        tempOrganization.GetRequisite(ReferenceConfiguration.Organizations.Requisites.Name).Value = name;
        tempOrganization.GetRequisite(ReferenceConfiguration.Organizations.Requisites.JuridicalName).Value = name;
        tempOrganization.Save();
        return tempOrganization.Id;
      }
    }

    /// <summary>
    /// Удалить организацию.
    /// </summary>
    /// <param name="id">ИД организации.</param>
    public static void RemoveOrganization(int id)
    {
      var app = IsbApplicationManager.Instance.GetApplication();
      using (var referencesFactory = app.GetReferencesFactory())
      using (var referenceFactory = referencesFactory.GetReferenceFactory(ReferenceConfiguration.Organizations.ReferenceName))
      {
        referenceFactory.DeleteById(id);
      }
    }
  }
}
