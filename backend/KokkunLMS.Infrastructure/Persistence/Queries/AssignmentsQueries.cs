namespace KokkunLMS.Infrastructure.Persistence.Queries
{
    public static class AssignmentsQueries
    {
        public const string Table = "assignments";

        public const string AllColumns = $@"
        {Table}.assignmentid AS ""Assignmentid"",
        {Table}.courseid AS ""Courseid"",
        {Table}.title AS ""Title"",
        {Table}.description AS ""Description"",
        {Table}.duedate AS ""Duedate"",
        {Table}.attachmenturl AS ""Attachmenturl"",
        {Table}.createdat AS ""Createdat""
        ";

        public const string BaseSelect = $@"
            SELECT {AllColumns}
            FROM {Table}
        ";

        public const string Insert = $@"
            INSERT INTO {Table} (courseid, title, description, duedate, attachmenturl)
            VALUES (@CourseId, @Title, @Description, @DueDate, @AttachmentUrl)
            RETURNING assignmentid;
        ";

        public const string Update = $@"
            UPDATE {Table}
            SET courseid = @CourseId, title = @Title, description = @Description, duedate = @DueDate, attachmenturl = @AttachmentUrl
            WHERE assignmentid = @AssignmentId;
        ";

    }
}
