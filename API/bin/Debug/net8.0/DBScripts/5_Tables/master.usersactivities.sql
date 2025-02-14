CREATE TABLE IF NOT EXISTS master.usersactivities(
	uin BIGSERIAL PRIMARY KEY,
	mobno TEXT NOT NULL,
	activity TEXT NOT NULL,
	oldvalue JSONB,
	newvalue JSONB,
	createdate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
	modifieddate TIMESTAMP,
	createdby INT NOT NULL,
	modifiedby INT
);

ALTER TABLE master.usersactivities	ADD COLUMN IF NOT EXISTS tablename VARCHAR(50),
									DROP COLUMN IF EXISTS mobno;

CREATE INDEX IF NOT EXISTS idx_usersactivities ON master.usersactivities USING btree (createdby, tablename, activity);

