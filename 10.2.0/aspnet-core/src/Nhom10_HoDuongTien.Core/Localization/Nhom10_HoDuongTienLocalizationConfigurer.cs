using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Nhom10_HoDuongTien.Localization;

public static class Nhom10_HoDuongTienLocalizationConfigurer
{
    public static void Configure(ILocalizationConfiguration localizationConfiguration)
    {
        localizationConfiguration.Sources.Add(
            new DictionaryBasedLocalizationSource(Nhom10_HoDuongTienConsts.LocalizationSourceName,
                new XmlEmbeddedFileLocalizationDictionaryProvider(
                    typeof(Nhom10_HoDuongTienLocalizationConfigurer).GetAssembly(),
                    "Nhom10_HoDuongTien.Localization.SourceFiles"
                )
            )
        );
    }
}
