namespace KokkunLMS.Infrastructure.Persistence.Queries
{
    public static class PerformancereportsQueries
    {
        public const string Table = "performancereports";

        public const string AllColumns = @"
        {Table}.reportid AS ""Reportid"",
        {Table}.studentid AS ""Studentid"",
        {Table}.period AS ""Period"",
        {Table}.averagegrade AS ""Averagegrade"",
        {Table}.attendancerate AS ""Attendancerate"",
        {Table}.participationscore AS ""Participationscore"",
        {Table}.generatedat AS ""Generatedat""
        ";

        public const string BaseSelect = $@"
            SELECT {AllColumns}
            FROM {Table}
        ";

        public const string Insert = $@"
            INSERT INTO {Table} (studentid, period, averagegrade, attendancerate, participationscore, generatedat)
            VALUES (@Studentid, @Period, @Averagegrade, @Attendancerate, @Participationscore, @Generatedat)
            RETURNING reportid;
        ";

        public const string Update = $@"
            UPDATE {Table}
            SET studentid = @Studentid,
                period = @Period,
                averagegrade = @Averagegrade,
                attendancerate = @Attendancerate,
                participationscore = @Participationscore,
                generatedat = @Generatedat
            WHERE reportid = @Reportid;
        ";
    }
}
