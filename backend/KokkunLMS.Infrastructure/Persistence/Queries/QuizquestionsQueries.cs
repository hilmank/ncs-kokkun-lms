namespace KokkunLMS.Infrastructure.Persistence.Queries
{
    public static class QuizquestionsQueries
    {
        public const string Table = "quizquestions";

        public const string AllColumns = @"
        {Table}.questionid AS ""Questionid"",
        {Table}.quizid AS ""Quizid"",
        {Table}.questiontext AS ""Questiontext"",
        {Table}.questiontype AS ""Questiontype"",
        {Table}.options AS ""Options"",
        {Table}.correctanswer AS ""Correctanswer"",
        {Table}.points AS ""Points""
        ";

        public const string BaseSelect = $@"
            SELECT {AllColumns}
            FROM {Table}
        ";

        public const string Insert = $@"
            INSERT INTO {Table} (quizid, questiontext, questiontype, options, correctanswer, points)
            VALUES (@Quizid, @Questiontext, @Questiontype, @Options, @Correctanswer, @Points)
            RETURNING questionid;
        ";

        public const string Update = $@"
            UPDATE {Table}
            SET quizid = @Quizid,
                questiontext = @Questiontext,
                questiontype = @Questiontype,
                options = @Options,
                correctanswer = @Correctanswer,
                points = @Points
            WHERE questionid = @Questionid;
        ";

        public const string GetByQuizId = $@"
            {BaseSelect}
            WHERE {Table}.quizid = @QuizId
        ";
    }
}
