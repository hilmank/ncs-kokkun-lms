namespace KokkunLMS.Infrastructure.Persistence.Queries
{
    public static class StudentsQueries
    {
        public const string Table = "students";

        public const string AllColumns = $@"
            {Table}.userid AS ""UserId"",
            {Table}.dateofbirth AS ""DateOfBirth"",
            {Table}.gendercode AS ""GenderCode"",
            {Table}.registrationdat AS ""RegistrationDat"",
            {Table}.enrollmentdat AS ""EnrollmentDat"",
            {Table}.classcode AS ""ClassCode"",
            {Table}.status AS ""Status""
        ";

        public const string BaseSelect = $@"
            SELECT {AllColumns}
            FROM {Table}
        ";

        public const string Insert = $@"
            INSERT INTO {Table} 
            (userid, dateofbirth, gendercode, registrationdat, enrollmentdat, classcode, status)
            VALUES 
            (@UserId, @DateOfBirth, @GenderCode, @RegistrationDat, @EnrollmentDat, @ClassCode, @Status)
        ";

        public const string Update = $@"
            UPDATE {Table}
            SET dateofbirth = @DateOfBirth,
                gendercode = @GenderCode,
                registrationdat = @RegistrationDat,
                enrollmentdat = @EnrollmentDat,
                classcode = @ClassCode,
                status = @Status
            WHERE userid = @UserId
        ";
    }
}
