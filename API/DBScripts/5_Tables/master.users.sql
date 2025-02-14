--urole: {{"roles": [{"role":"admin"}, {"role":"worker"}]}}
CREATE TABLE IF NOT EXISTS master.users(
	uin SERIAL,
	mobno TEXT,
	uname TEXT NOT NULL COLLATE public.caseinsensitive,
	email TEXT NOT NULL PRIMARY KEY COLLATE public.caseinsensitive,
	urole JSONB,
	apikey TEXT UNIQUE,
	isapplogin BOOLEAN DEFAULT true,
	dept TEXT,
	permission JSONB,
	lastotp TEXT,
	authenticatorkey TEXT,
	isactive BOOLEAN DEFAULT true, 
	createdate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
	modifieddate TIMESTAMP,
	createdby INT NOT NULL,
	modifiedby INT,
	lastmodifiedby TEXT
);

CREATE INDEX IF NOT EXISTS idx_users_uin ON master.users USING BRIN (uin);

IF NOT EXISTS (SELECT 1 FROM master.users WHERE mobno='auth') THEN
	INSERT INTO master.users(mobno, uname, email, urole, createdby, isapplogin, apikey)
	VALUES 
		('auth', 'Auth Permission', 'admin@empezar.test', '[{"role": "auth"}]', 1, false, 
		RPAD(md5(random()::text), 58, floor(random()*100000000)::TEXT) || md5(now()::text||random()::text));
END IF;

