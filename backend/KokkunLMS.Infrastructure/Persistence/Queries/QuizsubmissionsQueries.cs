namespace KokkunLMS.Infrastructure.Persistence.Queries
{
    public static class QuizsubmissionsQueries
    {
        public const string Table = "quizsubmissions";

        public const string AllColumns = @"
        {Table}.submissionid AS ""Submissionid"",
        {Table}.quizid AS ""Quizid"",
        {Table}.studentid AS ""Studentid"",
        {Table}.score AS ""Score"",
        {Table}.submittedat AS ""Submittedat""
        ";

        public const string BaseSelect = $@"
            SELECT {AllColumns}
            FROM {Table}
        ";

        public const string Insert = $@"
            INSERT INTO {Table} (quizid, studentid, score, submittedat)
            VALUES (@Quizid, @Studentid, @Score, @Submittedat)
            RETURNING submissionid;
        ";

        public const string Update = $@"
            UPDATE {Table}
            SET quizid = @Quizid,
                studentid = @Studentid,
                score = @Score,
                submittedat = @Submittedat
            WHERE submissionid = @Submissionid;
        ";
    }
}
