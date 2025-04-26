namespace KokkunLMS.Infrastructure.Persistence.Queries
{
    public static class UsersQueries
    {
        public const string Table = "users";

        public const string AllColumns = $@"
        {Table}.userid AS ""Userid"",
        {Table}.username AS ""Username"",
        {Table}.passwordhash AS ""Passwordhash"",
        {Table}.fullname AS ""Fullname"",
        {Table}.email AS ""Email"",
        {Table}.phonenumber AS ""Phonenumber"",
        {Table}.profilepicture AS ""Profilepicture"",
        {Table}.roleid AS ""Roleid"",
        {Table}.isactive AS ""IsActive"",
        {Table}.isdeleted AS ""IsDeleted"",
        {Table}.createdat AS ""Createdat"",
        {Table}.refreshtoken AS ""Refreshtoken"",
        {Table}.refreshtokenexpirytime AS ""Refreshtokenexpirytime"",
        {Table}.lastlogin AS ""Lastlogin"",
        {Table}.lastpasswordchange AS ""Lastpasswordchange""
        ";

        public const string BaseSelect = $@"
            SELECT {AllColumns}
            FROM {Table}
        ";

        public const string Insert = $@"
            INSERT INTO {Table} (username, passwordhash, fullname, email, phonenumber, profilepicture, roleid, createdat, isactive, isdeleted, refreshtoken, refreshtokenexpirytime, lastlogin, lastpasswordchange)
            VALUES (@Username, @Passwordhash, @Fullname, @Email, @Phonenumber, @Profilepicture, @Roleid, @Createdat, @IsActive, @IsDeleted, @Refreshtoken, @Refreshtokenexpirytime, @Lastlogin, @Lastpasswordchange)
            RETURNING userid;
        ";

        public const string Update = $@"
            UPDATE {Table}
            SET username = @Username,
                passwordhash = @Passwordhash,
                fullname = @Fullname,
                email = @Email,
                phonenumber = @Phonenumber,
                profilepicture = @Profilepicture,
                roleid = @Roleid,
                isactive = @IsActive,
                isdeleted = @IsDeleted,
                createdat = @Createdat,
                refreshtoken = @Refreshtoken,
                refreshtokenexpirytime = @Refreshtokenexpirytime,
                lastlogin = @Lastlogin,
                lastpasswordchange = @Lastpasswordchange
            WHERE userid = @Userid;
        ";
    }
}
