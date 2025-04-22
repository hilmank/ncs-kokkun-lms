namespace KokkunLMS.Infrastructure.Persistence.Queries
{
    public static class QuizzesQueries
    {
        public const string Table = "quizzes";

        public const string AllColumns = @"
        {Table}.quizid AS ""Quizid"",
        {Table}.courseid AS ""Courseid"",
        {Table}.title AS ""Title"",
        {Table}.description AS ""Description"",
        {Table}.createdat AS ""Createdat""
        ";

        public const string BaseSelect = $@"
            SELECT {AllColumns}
            FROM {Table}
        ";

        public const string Insert = $@"
            INSERT INTO {Table} (courseid, title, description, createdat)
            VALUES (@Courseid, @Title, @Description, @Createdat)
            RETURNING quizid;
        ";

        public const string Update = $@"
            UPDATE {Table}
            SET courseid = @Courseid,
                title = @Title,
                description = @Description,
                createdat = @Createdat
            WHERE quizid = @Quizid;
        ";
    }
}
