namespace KokkunLMS.Infrastructure.Persistence.Queries
{
    public static class MessagesQueries
    {
        public const string Table = "messages";

        public const string AllColumns = @"
        {Table}.messageid AS ""Messageid"",
        {Table}.senderid AS ""Senderid"",
        {Table}.receiverid AS ""Receiverid"",
        {Table}.content AS ""Content"",
        {Table}.sentat AS ""Sentat"",
        {Table}.isread AS ""Isread""
        ";

        public const string BaseSelect = $@"
            SELECT {AllColumns}
            FROM {Table}
        ";

        public const string Insert = $@"
            INSERT INTO {Table} (senderid, receiverid, content, sentat, isread)
            VALUES (@Senderid, @Receiverid, @Content, @Sentat, @Isread)
            RETURNING messageid;
        ";

        public const string Update = $@"
            UPDATE {Table}
            SET senderid = @Senderid,
                receiverid = @Receiverid,
                content = @Content,
                sentat = @Sentat,
                isread = @Isread
            WHERE messageid = @Messageid;
        ";
    }
}
