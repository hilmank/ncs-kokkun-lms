namespace KokkunLMS.Infrastructure.Persistence.Queries
{
    public static class DiscussionthreadsQueries
    {
        public const string Table = "discussionthreads";

        public const string AllColumns = @"
        {Table}.threadid AS ""Threadid"",
        {Table}.courseid AS ""Courseid"",
        {Table}.createdby AS ""Createdby"",
        {Table}.title AS ""Title"",
        {Table}.createdat AS ""Createdat""
        ";

        public const string BaseSelect = $@"
            SELECT {AllColumns}
            FROM {Table}
        ";

        public const string Insert = $@"
            INSERT INTO {Table} (courseid, createdby, title, createdat)
            VALUES (@Courseid, @Createdby, @Title, @Createdat)
            RETURNING threadid;
        ";

        public const string Update = $@"
            UPDATE {Table}
            SET courseid = @Courseid,
                createdby = @Createdby,
                title = @Title,
                createdat = @Createdat
            WHERE threadid = @Threadid;
        ";
    }
}
