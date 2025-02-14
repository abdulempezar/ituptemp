namespace API;

public partial class APIQueries
{
    public static readonly Query Users = new()
    {
        APIBaseUri = APIList.Users.Description(),

        CreateQuery = @"INSERT INTO master.users(mobno, uname, email, urole, apikey, dept, createdby, lastmodifiedby, permission) 
						VALUES (@mobno, @uname, LOWER(@email), @urole::JSONB, RPAD(md5(random()::text), 58, floor(random()*100000000)::TEXT) || md5(now()::text||random()::text), @dept, @createdby, @lastmodifiedby, @permission::JSONB)
						RETURNING uin;",
        ReadQuery = @"SELECT * FROM master.fetchusers(@offset, @limit, @uin, @isactive, @mobno, @uname, @email, @urole, @dept, @apikey, @isapplogin);",
        UpdateQuery = @"UPDATE  master.users 
                        SET     uname = @uname, urole = @urole::JSONB, dept = @dept, signature = @signature::JSONB, permission = @permission::JSONB,
						        isapplogin = @isapplogin, modifieddate = NOW(), modifiedby = @modifiedby, lastmodifiedby = @lastmodifiedby, 
                                isactive = CASE WHEN @isactive IS NOT NULL THEN @isactive ELSE isactive END
						WHERE   uin = @uin;",
        DeleteQuery = @"UPDATE	master.users 
						SET		isactive = false, modifieddate = NOW(), modifiedby = @modifiedby, lastmodifiedby = @lastmodifiedby 
						WHERE	uin = @uin;",
		
        ReadQueryPolicy = new string[] { "admin" },
		UpdateQueryPolicy = new string[] { "admin" },
        CreateQueryPolicy = new string[] { "admin" }
    };
}
