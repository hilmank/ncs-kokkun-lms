namespace KokkunLMS.Infrastructure.Persistence.Queries
{
    public static class AttendanceQueries
    {
        public const string Table = "attendance";

        public const string AllColumns = @"
        {Table}.attendanceid AS ""Attendanceid"",
        {Table}.scheduleid AS ""Scheduleid"",
        {Table}.studentid AS ""Studentid"",
        {Table}.date AS ""Date"",
        {Table}.status AS ""Status"",
        {Table}.checkedby AS ""Checkedby""
        ";

        public const string BaseSelect = $@"
            SELECT {AllColumns}
            FROM {Table}
        ";

        public const string Insert = $@"
            INSERT INTO {Table} (scheduleid, studentid, date, status, checkedby)
            VALUES (@Scheduleid, @Studentid, @Date, @Status, @Checkedby)
            RETURNING attendanceid;
        ";

        public const string Update = $@"
            UPDATE {Table}
            SET scheduleid = @Scheduleid,
                studentid = @Studentid,
                date = @Date,
                status = @Status,
                checkedby = @Checkedby
            WHERE attendanceid = @Attendanceid;
        ";
    }
}
