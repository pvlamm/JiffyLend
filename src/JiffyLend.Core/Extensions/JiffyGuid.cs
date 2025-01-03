namespace JiffyLend.Core.Extensions;
using System;

using UuidExtensions;

public static class JiffyGuid
{
    /// <summary>
    /// Uuid7
    /// </summary>
    /// <returns></returns>
    public static Guid NewId() => Uuid7.Guid();
}
