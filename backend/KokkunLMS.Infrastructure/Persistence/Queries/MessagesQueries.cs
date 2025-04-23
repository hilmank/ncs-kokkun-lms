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

        public const string GetMessagesBetween = $@"
            {BaseSelect}
            WHERE ({Table}.senderid = @SenderId AND {Table}.receiverid = @ReceiverId)
            OR ({Table}.senderid = @ReceiverId AND {Table}.receiverid = @SenderId)
            ORDER BY {Table}.sentat ASC
        ";

        public const string MarkAsRead = $@"
            UPDATE {Table}
            SET isread = TRUE
            WHERE messageid = @MessageId;
        ";
    }
}
