namespace KokkunLMS.Infrastructure.Persistence.Queries
{
    public static class DiscussionrepliesQueries
    {
        public const string Table = "discussionreplies";

        public const string AllColumns = @"
        {Table}.replyid AS ""Replyid"",
        {Table}.threadid AS ""Threadid"",
        {Table}.repliedby AS ""Repliedby"",
        {Table}.content AS ""Content"",
        {Table}.createdat AS ""Createdat""
        ";

        public const string BaseSelect = $@"
            SELECT {AllColumns}
            FROM {Table}
        ";

        public const string Insert = $@"
            INSERT INTO {Table} (threadid, repliedby, content, createdat)
            VALUES (@Threadid, @Repliedby, @Content, @Createdat)
            RETURNING replyid;
        ";

        public const string Update = $@"
            UPDATE {Table}
            SET threadid = @Threadid,
                repliedby = @Repliedby,
                content = @Content,
                createdat = @Createdat
            WHERE replyid = @Replyid;
        ";
    }
}
