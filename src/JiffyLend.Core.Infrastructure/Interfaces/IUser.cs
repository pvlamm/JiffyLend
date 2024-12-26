namespace JiffyLend.Core.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public interface IUser
{
    Guid Id { get; }
    string DisplayName { get; }
    string EmailAddress { get; }
}
