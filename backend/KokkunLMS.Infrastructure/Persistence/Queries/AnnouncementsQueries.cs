namespace KokkunLMS.Infrastructure.Persistence.Queries
{
    public static class AnnouncementsQueries
    {
        public const string Table = "announcements";

        public const string AllColumns = $@"
        {Table}.announcementid AS ""Announcementid"",
        {Table}.courseid AS ""Courseid"",
        {Table}.title AS ""Title"",
        {Table}.content AS ""Content"",
        {Table}.postedby AS ""Postedby"",
        {Table}.postedat AS ""Postedat""
        ";

        public const string BaseSelect = $@"
            SELECT {AllColumns}
            FROM {Table}
        ";
        public const string Insert = $@"
            INSERT INTO {Table} (courseid, title, content, postedby, postedat)
            VALUES (@Courseid, @Title, @Content, @Postedby, @Postedat)
            RETURNING announcementid;
        ";

        public const string Update = $@"
            UPDATE {Table}
            SET courseid = @Courseid, title = @Title, content = @Content, postedby = @Postedby, postedat = @Postedat
            WHERE announcementid = @Announcementid;
        ";
    }
}
