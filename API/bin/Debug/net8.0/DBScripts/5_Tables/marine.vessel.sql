
CREATE TABLE IF NOT EXISTS marine.vessel(
	uin SERIAL,
	vessel_name TEXT,
    intvslno BIGINT,
    tcs_terminal_no INT,
    call_sign TEXT,
    imo_nbr TEXT,
    otherdets JSONB,
    hatchdets JSONB,
    cranedets JSONB,
    vesseldocs JSONB,
	vesselEdited JSONB,
    port_approved_flg BOOLEAN DEFAULT false,
    port_approved_date TIMESTAMP,
    approved_by TEXT,
    rejremark TEXT,
	isactive BOOLEAN DEFAULT true, 
	createdate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
	modifieddate TIMESTAMP,
	createdby INT NOT NULL,
	modifiedby INT,
	lastmodifiedby TEXT
);

CREATE INDEX IF NOT EXISTS idx_vessel_uin ON marine.vessel USING BRIN (uin);
