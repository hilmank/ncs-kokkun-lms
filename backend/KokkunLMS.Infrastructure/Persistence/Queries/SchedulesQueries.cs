namespace KokkunLMS.Infrastructure.Persistence.Queries
{
    public static class SchedulesQueries
    {
        public const string Table = "schedules";

        public const string AllColumns = @"
        {Table}.scheduleid AS ""Scheduleid"",
        {Table}.courseid AS ""Courseid"",
        {Table}.dayofweek AS ""Dayofweek"",
        {Table}.starttime AS ""Starttime"",
        {Table}.endtime AS ""Endtime"",
        {Table}.virtualclasslink AS ""Virtualclasslink""
        ";

        public const string BaseSelect = $@"
            SELECT {AllColumns}
            FROM {Table}
        ";

        public const string Insert = $@"
            INSERT INTO {Table} (courseid, dayofweek, starttime, endtime, virtualclasslink)
            VALUES (@Courseid, @Dayofweek, @Starttime, @Endtime, @Virtualclasslink)
            RETURNING scheduleid;
        ";

        public const string Update = $@"
            UPDATE {Table}
            SET courseid = @Courseid,
                dayofweek = @Dayofweek,
                starttime = @Starttime,
                endtime = @Endtime,
                virtualclasslink = @Virtualclasslink
            WHERE scheduleid = @Scheduleid;
        ";
    }
}
