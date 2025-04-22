namespace KokkunLMS.Infrastructure.Persistence.Queries
{
    public static class TeacherfeedbackQueries
    {
        public const string Table = "teacherfeedback";

        public const string AllColumns = @"
        {Table}.feedbackid AS ""Feedbackid"",
        {Table}.teacherid AS ""Teacherid"",
        {Table}.studentid AS ""Studentid"",
        {Table}.courseid AS ""Courseid"",
        {Table}.rating AS ""Rating"",
        {Table}.comment AS ""Comment"",
        {Table}.createdat AS ""Createdat""
        ";

        public const string BaseSelect = $@"
            SELECT {AllColumns}
            FROM {Table}
        ";

        public const string Insert = $@"
            INSERT INTO {Table} (teacherid, studentid, courseid, rating, comment, createdat)
            VALUES (@Teacherid, @Studentid, @Courseid, @Rating, @Comment, @Createdat)
            RETURNING feedbackid;
        ";

        public const string Update = $@"
            UPDATE {Table}
            SET teacherid = @Teacherid,
                studentid = @Studentid,
                courseid = @Courseid,
                rating = @Rating,
                comment = @Comment,
                createdat = @Createdat
            WHERE feedbackid = @Feedbackid;
        ";
    }
}
