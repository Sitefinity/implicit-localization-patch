using System;
using System.Linq;

namespace SitefinityWebApp.Patches.ImplicitLocalization
{
    public struct LocalizationEntry
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Culture { get; set; }
    }
}