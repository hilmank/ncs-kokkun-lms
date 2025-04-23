namespace KokkunLMS.Infrastructure.Persistence.Queries
{
    public static class LessonsQueries
    {
        public const string Table = "lessons";

        public const string AllColumns = @"
        {Table}.lessonid AS ""Lessonid"",
        {Table}.courseid AS ""Courseid"",
        {Table}.title AS ""Title"",
        {Table}.description AS ""Description"",
        {Table}.videourl AS ""Videourl"",
        {Table}.documenturl AS ""Documenturl"",
        {Table}.createdat AS ""Createdat""
        ";

        public const string BaseSelect = $@"
            SELECT {AllColumns}
            FROM {Table}
        ";

        public const string Insert = $@"
            INSERT INTO {Table} (courseid, title, description, videourl, documenturl, createdat)
            VALUES (@Courseid, @Title, @Description, @Videourl, @Documenturl, @Createdat)
            RETURNING lessonid;
        ";

        public const string Update = $@"
            UPDATE {Table}
            SET courseid = @Courseid,
                title = @Title,
                description = @Description,
                videourl = @Videourl,
                documenturl = @Documenturl,
                createdat = @Createdat
            WHERE lessonid = @Lessonid;
        ";

        public static readonly string GetByCourseId = $@"
            {BaseSelect}
            WHERE {Table}.courseid = @CourseId
        ";
    }
}
