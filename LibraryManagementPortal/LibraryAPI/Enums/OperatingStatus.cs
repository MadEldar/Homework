namespace LibraryAPI.Enums
{
    public enum OperatingStatus
    {
        KeyNotFound,
        EmptyArgument,
        Created,
        InternalError,
        Modified,
        Deleted,
        RelationshipExists,
        InvalidArgument,
        DuplicatedArgument,
        ExceedMonthlyRequestLimit,
        ExceedMonthlyBookLimit,
        ExceedRemainingMonthlyRequestLimit
    }
}