--
-- File generated with SQLiteStudio v3.2.1 on Sun Nov 29 10:02:43 2020
--
-- Text encoding used: System
--
-- PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: users
CREATE TABLE users (
    id            INTEGER       PRIMARY KEY
                                NOT NULL,
    login_name    VARCHAR (16)  UNIQUE
                                NOT NULL,
    email         VARCHAR (100) UNIQUE
                                NOT NULL,
    mobile_number VARCHAR (10)  UNIQUE
                                NOT NULL,
    first_name    VARCHAR (25),
    last_name     VARCHAR (25),
    user_password VARCHAR (16)  NOT NULL,
    login_at      DATETIME,
    is_reset_pwd  BOOLEAN       NOT NULL,
    is_enabled    BOOLEAN       NOT NULL,
    created_at    DATETIME      NOT NULL,
    updated_at    DATETIME
);

-- Table: addresses
CREATE TABLE addresses (
    id          INTEGER      PRIMARY KEY
                             NOT NULL,
    attention   VARCHAR (25),
    addr_line1  VARCHAR (50),
    addr_line2  VARCHAR (50),
    city        VARCHAR (25),
    addr_state  VARCHAR (25),
    country     VARCHAR (25),
    postal_code VARCHAR (10),
    phone       VARCHAR (25),
    fax         VARCHAR (25) 
);

-- Table: contacts
CREATE TABLE contacts (
    id            INTEGER       PRIMARY KEY
                                NOT NULL,
    salutation    VARCHAR (5),
    first_name    VARCHAR (25),
    last_name     VARCHAR (25),
    designation   VARCHAR (25),
    department    VARCHAR (25),
    email         VARCHAR (100),
    work_phone    VARCHAR (25),
    mobile_number VARCHAR (25) 
);

-- Table: organizations
CREATE TABLE organizations (
    id         INTEGER       PRIMARY KEY
                             NOT NULL,
    code       VARCHAR (16)  UNIQUE
                             NOT NULL,
    org_name   VARCHAR (50)  UNIQUE
                             NOT NULL,
    org_desc   VARCHAR (255),
    regd_num   VARCHAR (25),
    org_pan    VARCHAR (25),
    org_tan    VARCHAR (25),
    gstin      VARCHAR (25),
    address_id INTEGER       REFERENCES addresses (id) ON DELETE NO ACTION
                                                       ON UPDATE CASCADE,
    contact_id INTEGER       REFERENCES contacts (id) ON DELETE NO ACTION
                                                      ON UPDATE CASCADE,
    is_enabled BOOLEAN       NOT NULL,
    created_at DATETIME      NOT NULL,
    updated_at DATETIME
);

-- Table: ledger_groups
CREATE TABLE ledger_groups (
    id         INTEGER       PRIMARY KEY
                             NOT NULL,
    code       VARCHAR (16)  NOT NULL,
    group_name VARCHAR (25)  NOT NULL,
    group_desc VARCHAR (255),
    group_type INTEGER       NOT NULL,
    parent_id  INTEGER       REFERENCES ledger_groups (id) ON DELETE NO ACTION
                                                           ON UPDATE NO ACTION
);

-- Table: ledgers
CREATE TABLE ledgers (
    id          INTEGER       PRIMARY KEY
                              NOT NULL,
    code        VARCHAR (16)  NOT NULL,
    ledger_name VARCHAR (25)  NOT NULL,
    ledger_desc VARCHAR (255),
    group_id    INTEGER       NOT NULL
                              REFERENCES ledger_groups (id) ON DELETE NO ACTION
                                                            ON UPDATE CASCADE,
    ledger_type INTEGER       NOT NULL,
    is_system   BOOLEAN       NOT NULL,
    org_id      INTEGER       NOT NULL
                              REFERENCES organizations (id) ON DELETE NO ACTION
                                                            ON UPDATE NO ACTION,
    is_enabled  BOOLEAN       NOT NULL,
    created_at  DATETIME      NOT NULL,
    updated_at  DATETIME,
	UNIQUE (
	    code,
		org_id
	),
	UNIQUE (
	    ledger_name,
		org_id
	)
);

-- Table: banks
CREATE TABLE banks (
    id             INTEGER      PRIMARY KEY
                                NOT NULL,
    ledger_id      INTEGER      NOT NULL
                                REFERENCES ledgers (id) ON DELETE CASCADE
                                                        ON UPDATE CASCADE,
    account_number VARCHAR (25) UNIQUE
	                            NOT NULL,
    account_type   INTEGER,
    ifsc_code      VARCHAR (16) NOT NULL,
    micr_code      VARCHAR (16),
    branch_code    VARCHAR (16),
    branch_name    VARCHAR (25),
    address_id     INTEGER      REFERENCES addresses (id) ON DELETE NO ACTION
                                                          ON UPDATE NO ACTION,
    contact_id     INTEGER      REFERENCES contacts (id) ON DELETE NO ACTION
                                                         ON UPDATE NO ACTION,
    is_default     BOOLEAN      NOT NULL
);

-- Table: parties
CREATE TABLE parties (
    id           INTEGER         PRIMARY KEY
                                 NOT NULL,
    ledger_id    INTEGER         NOT NULL
                                 REFERENCES ledgers (id) ON DELETE CASCADE
                                                         ON UPDATE CASCADE,
    regd_num     VARCHAR (25),
    party_pan    VARCHAR (25),
    party_tan    VARCHAR (25),
    gstin        VARCHAR (25),    
    payment_term INTEGER         NOT NULL,
    credit_limit DECIMAL (12, 2) NOT NULL,
    address_id   INTEGER         REFERENCES addresses (id) ON DELETE NO ACTION
                                                           ON UPDATE NO ACTION,
    contact_id   INTEGER         REFERENCES contacts (id) ON DELETE NO ACTION
                                                          ON UPDATE NO ACTION
);

-- Table: units
CREATE TABLE units (
    id         INTEGER       PRIMARY KEY
                             NOT NULL,
    code       VARCHAR (16)  NOT NULL,
    unit_name  VARCHAR (25)  NOT NULL,
    unit_desc  VARCHAR (255),
    org_id     INTEGER       NOT null
                             REFERENCES organizations (id) ON DELETE NO ACTION
                                                           ON UPDATE CASCADE,
    is_enabled BOOLEAN       NOT NULL,
    created_at DATETIME      NOT NULL,
    updated_at DATETIME,
	UNIQUE (
	    code,
		org_id
	),
	UNIQUE (
	    unit_name,
		org_id
	)
);

-- Table: product_categories
CREATE TABLE product_categories (
    id            INTEGER       PRIMARY KEY
                                NOT NULL,
    code          VARCHAR (16)  NOT NULL,
    category_name VARCHAR (25)  NOT NULL,
    category_desc VARCHAR (255),
    parent_id     INTEGER       REFERENCES product_categories (id) ON DELETE NO ACTION
                                                                   ON UPDATE NO ACTION,
    org_id        INTEGER       NOT NULL
                                REFERENCES organizations (id) ON DELETE NO ACTION
                                                              ON UPDATE CASCADE,
    is_enabled    BOOLEAN       NOT NULL,
    created_at    DATETIME      NOT NULL,
    updated_at    DATETIME,
	UNIQUE (
	    code,
		org_id
	),
	UNIQUE (
	    category_name,
		org_id
	)
);

-- Table: products
CREATE TABLE products (
    id             INTEGER         PRIMARY KEY
                                   NOT NULL,
    code           VARCHAR (16)    NOT NULL,
    product_name   VARCHAR (25)    NOT NULL,
    product_desc   VARCHAR (255),
    product_type   INTEGER         NOT NULL,
    category_id    INTEGER         NOT NULL
    							   REFERENCES product_categories (id) ON DELETE NO ACTION
                                                                      ON UPDATE CASCADE,
    unit_id        INTEGER         NOT NULL
    							   REFERENCES units (id) ON DELETE NO ACTION
                                                         ON UPDATE NO ACTION,
    cost_price     DECIMAL (12, 2) NOT NULL,
    selling_price  DECIMAL (12, 2) NOT NULL,
    tax_code       VARCHAR (16)    NOT NULL,
    tax_preference INTEGER         NOT NULL,
    tax_pct        DECIMAL (5, 2)  NOT NULL,
    org_id         INTEGER         NOT null
                                   REFERENCES organizations (id) ON DELETE NO ACTION
                                                                 ON UPDATE NO ACTION,
    is_enabled     BOOLEAN         NOT NULL,
    created_at     DATETIME        NOT NULL,
    updated_at     DATETIME,
	UNIQUE (
	    code,
		org_id
	),
	UNIQUE (
	    product_name,
		org_id
	)
);

-- Table: account_years
CREATE TABLE account_years (
    id         INTEGER      PRIMARY KEY
                            NOT NULL,
    year_code  VARCHAR (16) NOT NULL,
    year_begin DATE         NOT NULL,
    year_end   DATE         NOT NULL,
    org_id     INTEGER      NOT NULL
     					    REFERENCES organizations (id) ON DELETE NO ACTION
                                                          ON UPDATE CASCADE,
    is_enabled BOOLEAN      NOT NULL,
    created_at DATETIME     NOT NULL,
    updated_at DATETIME,	
    UNIQUE (
	   year_code,
	   org_id
	)
);

-- Table: ledger_balances
CREATE TABLE ledger_balances (
    ledger_id       INTEGER         NOT NULL,
    year_id         INTEGER         NOT NULL
                                    REFERENCES account_years (id) ON DELETE NO ACTION
                                                                  ON UPDATE CASCADE,
    opening_balance DECIMAL (12, 2) NOT NULL,
    balance_sign    CHAR (1)        NOT NULL,
    PRIMARY KEY (
        ledger_id,
        year_id
    )
);

-- Table: serial_numbers
CREATE TABLE serial_numbers (
    year_id       INTEGER      NOT NULL
                               REFERENCES account_years (id) ON DELETE NO ACTION
                                                             ON UPDATE CASCADE,
    serial_module INTEGER      NOT NULL,
    serial_prefix VARCHAR (5),
    serial_format VARCHAR (16) NOT NULL,
    serial_suffix VARCHAR (5),
    last_serial   VARCHAR (16),
    last_number   INTEGER      NOT NULL,
    last_date     DATETIME     NOT NULL,
    serial_reset  INTEGER      NOT NULL,
    PRIMARY KEY (
        year_id,
        serial_module
    )
);

-- Table: journals
CREATE TABLE journals (
    id             INTEGER      PRIMARY KEY
                                NOT NULL,
    journal_number VARCHAR (16) NOT NULL,
    journal_date   DATETIME     NOT NULL,
    journal_type   INTEGER      NOT NULL,
    journal_sign   CHAR (1)     NOT NULL,
    ledger_id      INTEGER      NOT NULL
    							REFERENCES ledgers (id) ON DELETE NO ACTION
                                                        ON UPDATE CASCADE,
    year_id        INTEGER      NOT NULL
	                            REFERENCES account_years (id) ON DELETE NO ACTION
								                              ON UPDATE NO ACTION,
    created_at     DATETIME     NOT NULL,
    updated_at     DATETIME,
    UNIQUE (
        journal_number,
        year_id
    )
);

-- Table: journal_items
CREATE TABLE journal_items (
    id           INTEGER         PRIMARY KEY
                                 NOT NULL,
    journal_id   INTEGER         NOT NULL
    							 REFERENCES journals (id) ON DELETE CASCADE
                                                          ON UPDATE CASCADE,
    ledger_id    INTEGER         REFERENCES ledgers (id) ON DELETE NO ACTION
                                                         ON UPDATE NO ACTION,
    quantity     DECIMAL (7, 3)  NOT NULL,
    amount       DECIMAL (12, 2) NOT NULL,
    journal_desc VARCHAR (255),
    ref_num      VARCHAR (16),
    ref_date     DATE
);

-- Table: consumers
CREATE TABLE consumers (
    id         INTEGER      PRIMARY KEY
                            NOT NULL,
    contact_id INTEGER      REFERENCES contacts (id) ON DELETE NO ACTION
                                                     ON UPDATE CASCADE,
    address_id INTEGER      REFERENCES addresses (id) ON DELETE NO ACTION
                                                      ON UPDATE CASCADE
);

-- Table: invoices
CREATE TABLE invoices (
    id             INTEGER         PRIMARY KEY
                                   NOT NULL,
    invoice_number VARCHAR (16)    NOT NULL,
    invoice_date   DATETIME        NOT NULL,
    invoice_type   INTEGER         NOT NULL,
    stock_invoice_type INTEGER     NOT NULL,
    gst_treatment  INTEGER         NOT NULL,
    tax_preference INTEGER         NOT NULL,
    notes          VARCHAR (255),
    party_id       INTEGER         NOT NULL
    							   REFERENCES ledgers (id) ON DELETE NO ACTION
                                                           ON UPDATE CASCADE,
    ref_num        VARCHAR (16),
    ref_date       DATE,
    consumer_id    INTEGER         REFERENCES consumers (id) ON DELETE NO ACTION
                                                             ON UPDATE NO ACTION,
    subtotal       DECIMAL (12, 2) NOT NULL,
	total_qty      DECIMAL (10, 3) NOT NULL,
    discount_pct   DECIMAL (5, 2)  NOT NULL,
    discount_amt   DECIMAL (9, 2)  NOT NULL,
    total_tax_amt  DECIMAL (9, 2)  NOT NULL,
    misc_add_desc  VARCHAR (25),
    misc_add_amt   DECIMAL (9, 2)  NOT NULL,
    net_amount     DECIMAL (12, 2) NOT NULL,
    year_id        INTEGER         NOT NULL
    							   REFERENCES account_years (id) ON DELETE NO ACTION
                                                                 ON UPDATE NO ACTION,
    created_at     DATETIME        NOT NULL,
    updated_at     DATETIME,
    UNIQUE (
        invoice_number,
        year_id
    )
);

-- Table: inventory
CREATE TABLE inventory (
    id          INTEGER         PRIMARY KEY
                                NOT NULL,
    product_id  INTEGER         NOT NULL
                                REFERENCES products (id) ON DELETE NO ACTION
                                                          ON UPDATE CASCADE,
    tag_number  VARCHAR (16)    NOT NULL
                                UNIQUE,
    mfg_date    DATE,
    expire_date DATE,
    unit_id     INTEGER         NOT NULL
    							REFERENCES units (id) ON DELETE NO ACTION
                                                      ON UPDATE NO ACTION,
    qty_on_hand DECIMAL (10, 3) NOT NULL
);

-- Table: invoice_items
CREATE TABLE invoice_items (
    id           INTEGER        PRIMARY KEY
                                NOT NULL,
    invoice_id   INTEGER        NOT NULL
    							REFERENCES invoices (id) ON DELETE CASCADE
                                                         ON UPDATE CASCADE,
    inventory_id INTEGER        REFERENCES inventory (id) ON DELETE NO ACTION
                                                          ON UPDATE NO ACTION,
    item_desc    VARCHAR (255)  NOT NULL,
    unit_id      INTEGER        NOT NULL
                                REFERENCES units (id) ON DELETE NO ACTION
                                                      ON UPDATE NO ACTION,
    qty          DECIMAL (9, 3) NOT NULL,
    unit_price   DECIMAL (9, 2) NOT NULL,
    price        DECIMAL (9, 2) NOT NULL,
    discount_pct DECIMAL (5, 2) NOT NULL,
    discount_amt DECIMAL (9, 2) NOT NULL,
    tax_pct      DECIMAL (5, 2) NOT NULL,
    tax_amt      DECIMAL (9, 2) NOT NULL,
    line_total   DECIMAL (9, 2) NOT NULL
);

-- Table: transactions
CREATE TABLE transactions (
    id               INTEGER         PRIMARY KEY
                                     NOT NULL,
    debit_ledger_id  INTEGER         NOT NULL
    								 REFERENCES ledgers (id) ON DELETE NO ACTION
                                                             ON UPDATE NO ACTION,
    credit_ledger_id INTEGER         NOT NULL
    								 REFERENCES ledgers (id) ON DELETE NO ACTION
                                                             ON UPDATE NO ACTION,
    quantity         DECIMAL (9, 3)  NOT NULL,
    amount           DECIMAL (12, 2) NOT NULL,
    tran_desc        VARCHAR (255),
    ref_num          VARCHAR (16),
    ref_date         DATE,
    journal_id       INTEGER         REFERENCES journals (id) ON DELETE CASCADE
                                                              ON UPDATE NO ACTION,
    invoice_id       INTEGER         REFERENCES invoices (id) ON DELETE CASCADE
                                                              ON UPDATE NO ACTION
);

COMMIT TRANSACTION;
-- PRAGMA foreign_keys = on;
