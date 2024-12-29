namespace JiffyLend.Core.Common;

using System;

using JiffyLend.Core.Common.Interfaces;

public class JiffyTime : IDateTime
{
    public DateTime Now => TimeProvider.System.GetUtcNow().DateTime;
}