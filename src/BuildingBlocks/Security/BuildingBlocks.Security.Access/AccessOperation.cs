using System;

namespace BuildingBlocks.Security.Access
{
    [Flags]
    public enum AccessOperation
    {
        NONE,
        CREATE,
        READ,
        UPDATE,
        DELETE
    }
}