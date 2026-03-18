using Abp.Dependency;
using System;

namespace Nhom10_HoDuongTien.Timing;

public class AppTimes : ISingletonDependency
{
    /// <summary>
    /// Gets the startup time of the application.
    /// </summary>
    public DateTime StartupTime { get; set; }
}
