namespace KokkunLMS.Infrastructure.Persistence.Queries
{
    public static class ParentsstudentsQueries
    {
        public const string Table = "parentsstudents";

        public const string AllColumns = @"
        {Table}.parentstudentid AS ""Parentstudentid"",
        {Table}.parentid AS ""Parentid"",
        {Table}.studentid AS ""Studentid""
        ";

        public const string BaseSelect = $@"
            SELECT {AllColumns}
            FROM {Table}
        ";

        public const string Insert = $@"
            INSERT INTO {Table} (parentid, studentid)
            VALUES (@Parentid, @Studentid)
            RETURNING parentstudentid;
        ";

        public const string Update = $@"
            UPDATE {Table}
            SET parentid = @Parentid,
                studentid = @Studentid
            WHERE parentstudentid = @Parentstudentid;
        ";

        public const string GetChildrenIdsByParentId = $@"
            SELECT studentid
            FROM {Table}
            WHERE parentid = @ParentId;
        ";
    }
}
