namespace KokkunLMS.Infrastructure.Persistence.Queries
{
    public static class ContentapprovalQueries
    {
        public const string Table = "contentapproval";

        public const string AllColumns = @"
        {Table}.approvalid AS ""Approvalid"",
        {Table}.contenttype AS ""Contenttype"",
        {Table}.contentid AS ""Contentid"",
        {Table}.submittedby AS ""Submittedby"",
        {Table}.status AS ""Status"",
        {Table}.reviewedby AS ""Reviewedby"",
        {Table}.reviewnotes AS ""Reviewnotes"",
        {Table}.reviewedat AS ""Reviewedat""
        ";

        public const string BaseSelect = $@"
            SELECT {AllColumns}
            FROM {Table}
        ";

        public const string Insert = $@"
            INSERT INTO {Table} (contenttype, contentid, submittedby, status, reviewedby, reviewnotes, reviewedat)
            VALUES (@Contenttype, @Contentid, @Submittedby, @Status, @Reviewedby, @Reviewnotes, @Reviewedat)
            RETURNING approvalid;
        ";

        public const string Update = $@"
            UPDATE {Table}
            SET contenttype = @Contenttype,
                contentid = @Contentid,
                submittedby = @Submittedby,
                status = @Status,
                reviewedby = @Reviewedby,
                reviewnotes = @Reviewnotes,
                reviewedat = @Reviewedat
            WHERE approvalid = @Approvalid;
        ";
    }
}
