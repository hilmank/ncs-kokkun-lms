namespace KokkunLMS.Infrastructure.Persistence.Queries
{
    public static class RolesQueries
    {
        public const string Table = "roles";

        public const string AllColumns = $@"
        {Table}.roleid AS ""Roleid"",
        {Table}.rolename AS ""Rolename""
        ";

        public const string BaseSelect = $@"
            SELECT {AllColumns}
            FROM {Table}
        ";

        public const string Insert = $@"
            INSERT INTO {Table} (rolename)
            VALUES (@Rolename)
            RETURNING roleid;
        ";

        public const string Update = $@"
            UPDATE {Table}
            SET rolename = @Rolename
            WHERE roleid = @Roleid;
        ";

        public const string GetById = $@"
            {BaseSelect}
            WHERE {Table}.roleid = @Id
        ";
    }
}
