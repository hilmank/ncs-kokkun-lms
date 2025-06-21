namespace KokkunLMS.Infrastructure.Persistence.Queries
{
    public static class CourseClassQueries
    {
        public const string Table = "courseclass";

        public const string AllColumns = $@"
            {Table}.code AS ""Code"",
            {Table}.name AS ""Name"",
            {Table}.courseid AS ""CourseId""
        ";

        public const string BaseSelect = $@"
            SELECT {AllColumns}
            FROM {Table}
        ";

        public const string Insert = $@"
            INSERT INTO {Table} (code, name, courseid)
            VALUES (@Code, @Name, @CourseId)
        ";

        public const string Update = $@"
            UPDATE {Table}
            SET name = @Name,
                courseid = @CourseId
            WHERE code = @Code
        ";
    }
}
