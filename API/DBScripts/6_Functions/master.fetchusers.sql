DROP FUNCTION IF EXISTS master.fetchusers(INTEGER, INTEGER, BIGINT, BOOLEAN, TEXT, TEXT, TEXT, TEXT, TEXT, TEXT, BOOLEAN);

CREATE OR REPLACE FUNCTION master.fetchusers(
	p_offset INTEGER DEFAULT 0,
	p_limit INTEGER DEFAULT NULL::INTEGER,
	p_uin BIGINT DEFAULT NULL::BIGINT,
	p_isactive BOOLEAN DEFAULT NULL::BOOLEAN,
	p_mobno TEXT DEFAULT NULL::TEXT,
	p_uname TEXT DEFAULT NULL::TEXT,
	p_email TEXT DEFAULT NULL::TEXT,
	p_urole TEXT DEFAULT NULL::TEXT,
	p_dept TEXT DEFAULT NULL::TEXT,
	p_apikey TEXT DEFAULT NULL::TEXT,
	p_isapplogin BOOLEAN DEFAULT NULL::BOOLEAN)
RETURNS TABLE(LIKE master.users) 
LANGUAGE 'plpgsql'
COST 100
VOLATILE PARALLEL UNSAFE
ROWS 10000
AS $BODY$
BEGIN
	RETURN QUERY 
		SELECT  usr.*
		FROM    master.users usr
		WHERE 	(p_uin IS NULL OR usr.uin = p_uin) AND 
				(p_isactive IS NULL OR usr.isactive = p_isactive) AND
				(p_mobno IS NULL OR usr.mobno = p_mobno) AND 
				(p_uname IS NULL OR usr.uname = p_uname) AND
				(p_email IS NULL OR usr.email COLLATE caseinsensitive  = p_email COLLATE caseinsensitive ) AND
				(p_dept IS NULL OR usr.dept = p_dept) AND
				(p_urole IS NULL OR usr.urole @> JSONB_BUILD_ARRAY(JSONB_BUILD_OBJECT('role', p_urole)) ) AND
				(p_apikey IS NULL OR usr.apikey = p_apikey) AND
				(p_isapplogin IS NULL OR usr.isapplogin = p_isapplogin)
		OFFSET p_offset
		LIMIT p_limit;
END 
$BODY$;
