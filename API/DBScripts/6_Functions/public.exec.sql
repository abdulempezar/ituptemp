--select * from exec('select now()') as t(dt timestamptz);
CREATE OR REPLACE FUNCTION public.exec(text)
RETURNS SETOF RECORD
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN 
    RETURN QUERY EXECUTE $1; 
END 
$BODY$;
