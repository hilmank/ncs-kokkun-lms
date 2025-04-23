namespace KokkunLMS.Infrastructure.Persistence.Queries
{
    public static class CoursesQueries
    {
        public const string Table = "courses";

        public const string AllColumns = @"
        {Table}.courseid AS ""Courseid"",
        {Table}.title AS ""Title"",
        {Table}.paketlevel AS ""Paketlevel"",
        {Table}.gradelevel AS ""Gradelevel"",
        {Table}.subject AS ""Subject"",
        {Table}.teacherid AS ""Teacherid"",
        {Table}.createdat AS ""Createdat""
        ";

        public const string BaseSelect = $@"
            SELECT {AllColumns}
            FROM {Table}
        ";

        public const string Insert = $@"
            INSERT INTO {Table} (title, paketlevel, gradelevel, subject, teacherid, createdat)
            VALUES (@Title, @Paketlevel, @Gradelevel, @Subject, @Teacherid, @Createdat)
            RETURNING courseid;
        ";

        public const string Update = $@"
            UPDATE {Table}
            SET title = @Title,
                paketlevel = @Paketlevel,
                gradelevel = @Gradelevel,
                subject = @Subject,
                teacherid = @Teacherid,
                createdat = @Createdat
            WHERE courseid = @Courseid;
        ";

        public const string GetById = $@"
            {BaseSelect}
            WHERE {Table}.courseid = @CourseId
        ";
    }
}
