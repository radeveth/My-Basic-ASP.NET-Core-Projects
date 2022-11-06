namespace ForumSystem.Services.Data.SettingsService.SettingsService
{
    using System.Collections.Generic;

    public interface ISettingsService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();
    }
}
