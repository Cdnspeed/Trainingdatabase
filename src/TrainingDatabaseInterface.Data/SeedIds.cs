using System;

namespace TrainingDatabaseInterface.Data;

internal static class SeedIds
{
    internal static readonly Guid RoleAdminId = Guid.Parse("6E9E05F2-0998-4D14-86C7-2D77C6CF52D0");
    internal static readonly Guid RoleTrainerId = Guid.Parse("A2F7CC77-2EC2-4E27-8AD1-6C5AE5D2E8C3");
    internal static readonly Guid RoleManagerId = Guid.Parse("63F1A2F4-9B4A-4B79-B6C6-2BB1D2BA9E6F");
    internal static readonly Guid RoleEmployeeId = Guid.Parse("44B7DBB0-6191-4D44-B384-9091F8C5D132");

    internal static readonly Guid AdminUserId = Guid.Parse("0C5F3F23-4A5B-4A37-A1E6-3AB6467F2DD3");

    internal static readonly Guid TrainingTypeInPersonId = Guid.Parse("60B2B4C2-55A6-4B9A-9E1E-6B3A27AC2412");
    internal static readonly Guid TrainingTypeOnlineId = Guid.Parse("7A785C7B-6E6F-4D39-8A2F-6B6A7437C9D1");
    internal static readonly Guid TrainingTypeVirtualIltId = Guid.Parse("E7E1DF36-0E07-4D47-9D9A-07F3E0DA4C1D");
    internal static readonly Guid TrainingTypeBlendedId = Guid.Parse("DA9D26F5-5E2C-4BC5-9A12-5A822120BC5E");
    internal static readonly Guid TrainingTypeExternalVendorId = Guid.Parse("5F51E7C0-4B61-4E18-9F5C-821CE1E2EABB");

    internal static readonly Guid DomainCategorySafetyId = Guid.Parse("51D5A72E-1E08-40D2-A8C7-0C4C1F26AFC5");
    internal static readonly Guid DomainCategoryQualityId = Guid.Parse("B38A7C3B-7A43-4C5D-AF4D-42FAE7723A15");

    internal static readonly byte[] AdminPasswordSalt = { 0x6B, 0x39, 0x81, 0x7D, 0x33, 0xD2, 0x1F, 0xC4, 0xF6, 0xA1, 0x52, 0x99, 0x01, 0x8D, 0xCE, 0xAA };
    internal const string AdminPassword = "Admin!123";
}
