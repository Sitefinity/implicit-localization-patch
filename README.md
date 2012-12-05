implicit-localization-patch
===========================

Patch for implicit localization for Sitefinity versions 4.0 to 5.2

## Implicit localization patch for Sitefinity 4.0 and higher

### The problem
At the moment, Sitefinity local resource provider does not support implicit localization (more info on implicit localization: http://msdn.microsoft.com/en-us/library/fw69ke6f%28v=vs.80%29.aspx).

Basically, if you try to localize a Literal control as follows:

```csharp
<asp:Literal ID="ltr1" runat="server" meta:resourcekey="Literal1"></asp:Literal>
```

you will get an error.

The provided patch fixes this problem.

### Installation
To install the patch you need to perform two steps:

1. Use NuGet to install the following package: SitefinityImplicitLocalizationPatchWebApp
2. Open the web.config file of your web application and replace the following line:

```xml
<globalization uiCulture="auto" culture="auto" resourceProviderFactoryType="Telerik.Sitefinity.Localization.ExtendedResourceProviderFactory, Telerik.Sitefinity" />
```

with this:

```xml
<globalization uiCulture="auto" culture="auto" resourceProviderFactoryType="SitefinityWebApp.Patches.ImplicitLocalization.ExtendedResourceProviderFactory2" />
```

> Note: If you are using your project as a website, move the "Patches" folder to App_Code folder.

### Uninstall

When this improvement is included in the core product you can uninstall the NuGet package and revert the web.config setting to it's original state.