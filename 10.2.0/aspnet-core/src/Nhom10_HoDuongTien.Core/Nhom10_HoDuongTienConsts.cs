using Nhom10_HoDuongTien.Debugging;

namespace Nhom10_HoDuongTien;

public class Nhom10_HoDuongTienConsts
{
    public const string LocalizationSourceName = "Nhom10_HoDuongTien";

    public const string ConnectionStringName = "Default";

    public const bool MultiTenancyEnabled = true;


    /// <summary>
    /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
    /// </summary>
    public static readonly string DefaultPassPhrase =
        DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "c805d207adc046399fa9c3107108497e";
}
