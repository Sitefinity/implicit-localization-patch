using System;

namespace SitefinityWebApp.Patches.ImplicitLocalization
{
    public interface IKeyFormatter
    {
        string BuildCompositeKey(LocalizationEntry localizationEntry);
        LocalizationEntry ParseCompositeKey(string key);
    }
}
