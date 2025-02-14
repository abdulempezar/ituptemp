
CREATE OR REPLACE FUNCTION public.fn_auditlog()
    RETURNS trigger
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE NOT LEAKPROOF
AS $BODY$
BEGIN 
	IF (TG_OP = 'DELETE') THEN
		INSERT INTO master.usersactivities (activity, createdby, oldvalue, tablename)
		SELECT 	TG_OP, o.uin, row_to_json(o.*) oldvalue, TG_TABLE_NAME
		FROM 	OLD o;
	ELSIF (TG_OP = 'UPDATE') THEN
		INSERT INTO master.usersactivities (activity, createdby, newvalue, oldvalue, tablename)                
		SELECT 	TG_OP, n.uin, row_to_json(n.*) newvalue, row_to_json(o.*) oldvalue, TG_TABLE_NAME
		FROM 	NEW n INNER JOIN OLD o on o.uin = n.uin;
	ELSIF (TG_OP = 'INSERT') THEN
		INSERT INTO master.usersactivities (activity, createdby, newvalue, tablename)
		SELECT 	TG_OP, n.uin, row_to_json(n.*) newvalue, TG_TABLE_NAME
		FROM 	NEW n;
	END IF;
	
	return new;
END;
$BODY$;

