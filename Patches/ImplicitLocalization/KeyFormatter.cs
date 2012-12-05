using System;
using System.Linq;

namespace SitefinityWebApp.Patches.ImplicitLocalization
{
    public class KeyFormatter : SitefinityWebApp.Patches.ImplicitLocalization.IKeyFormatter
    {
        public string BuildCompositeKey(LocalizationEntry localizationEntry)
        {
            if (string.IsNullOrEmpty(localizationEntry.Culture))
                return localizationEntry.Key;

            return localizationEntry.Key + "$" + localizationEntry.Culture;
        }

        public LocalizationEntry ParseCompositeKey(string key)
        {
            var keySegments = key.Split('$');

            var localizationEntry = new LocalizationEntry();
            if (keySegments.Length > 1)
            {
                localizationEntry.Key = keySegments[0];
                localizationEntry.Culture = keySegments[1];
            }
            else
            {
                localizationEntry.Key = key;
            }

            return localizationEntry;
        }
    }
}