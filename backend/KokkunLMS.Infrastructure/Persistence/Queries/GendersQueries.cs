namespace KokkunLMS.Infrastructure.Persistence.Queries
{
    public static class GendersQueries
    {
        public const string Table = "genders";

        public const string AllColumns = $@"
            {Table}.code AS ""Code"",
            {Table}.name AS ""Name""
        ";

        public const string BaseSelect = $@"
            SELECT {AllColumns}
            FROM {Table}
        ";

        public const string Insert = $@"
            INSERT INTO {Table} (code, name)
            VALUES (@Code, @Name)
        ";

        public const string Update = $@"
            UPDATE {Table}
            SET name = @Name
            WHERE code = @Code
        ";
    }
}
