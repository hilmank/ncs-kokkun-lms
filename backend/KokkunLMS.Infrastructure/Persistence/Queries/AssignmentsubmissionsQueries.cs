namespace KokkunLMS.Infrastructure.Persistence.Queries
{
    public static class AssignmentsubmissionsQueries
    {
        public const string Table = "assignmentsubmissions";

        public const string AllColumns = @"
        {Table}.submissionid AS ""Submissionid"",
        {Table}.assignmentid AS ""Assignmentid"",
        {Table}.studentid AS ""Studentid"",
        {Table}.fileurl AS ""Fileurl"",
        {Table}.submittedat AS ""Submittedat"",
        {Table}.grade AS ""Grade"",
        {Table}.feedback AS ""Feedback""
        ";

        public const string BaseSelect = $@"
            SELECT {AllColumns}
            FROM {Table}
        ";

        public const string Insert = $@"
            INSERT INTO {Table} (assignmentid, studentid, fileurl, submittedat, grade, feedback)
            VALUES (@Assignmentid, @Studentid, @Fileurl, @Submittedat, @Grade, @Feedback)
            RETURNING submissionid;
        ";

        public const string Update = $@"
            UPDATE {Table}
            SET assignmentid = @Assignmentid,
                studentid = @Studentid,
                fileurl = @Fileurl,
                submittedat = @Submittedat,
                grade = @Grade,
                feedback = @Feedback
            WHERE submissionid = @Submissionid;
        ";

        public const string GetByAssignmentId = $@"
            {BaseSelect}
            WHERE {Table}.assignmentid = @AssignmentId
        ";

        public const string GradeSubmission = $@"
            UPDATE {Table}
            SET grade = @Grade,
                feedback = @Feedback
            WHERE submissionid = @SubmissionId;
        ";
    }
}
