--
-- File generated with SQLiteStudio v3.2.1 on Sun Nov 29 10:02:43 2020
--
-- Text encoding used: System
--
-- PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: users
CREATE TABLE users (
    id            CHAR (36)     PRIMARY KEY
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
    is_reset_pwd  INTEGER       NOT NULL,
    is_enabled    INTEGER       NOT NULL,
    created_at    DATETIME      NOT NULL,
    updated_at    DATETIME
);

-- Table: addresses
CREATE TABLE addresses (
    id          CHAR (36)    PRIMARY KEY
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
    id            CHAR (36)     PRIMARY KEY
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
    id         CHAR (36)     PRIMARY KEY
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
    address_id CHAR (36)     REFERENCES addresses (id) ON DELETE NO ACTION
                                                       ON UPDATE CASCADE,
    contact_id CHAR (36)     REFERENCES contacts (id) ON DELETE NO ACTION
                                                      ON UPDATE CASCADE,
    is_enabled INTEGER       NOT NULL,
    created_at DATETIME      NOT NULL,
    updated_at DATETIME
);

-- Table: ledger_groups
CREATE TABLE ledger_groups (
    id         CHAR (36)     PRIMARY KEY
                             NOT NULL,
    code       VARCHAR (16)  NOT NULL,
    group_name VARCHAR (25)  NOT NULL,
    group_desc VARCHAR (255),
    group_type INTEGER       NOT NULL,
    parent_id  CHAR (36)     REFERENCES ledger_groups (id) ON DELETE NO ACTION
                                                           ON UPDATE NO ACTION
);

-- Table: ledgers
CREATE TABLE ledgers (
    id          CHAR (36)     PRIMARY KEY
                              NOT NULL,
    code        VARCHAR (16)  NOT NULL,
    ledger_name VARCHAR (25)  NOT NULL,
    ledger_desc VARCHAR (255),
    group_id    CHAR (36)     NOT NULL
                              REFERENCES ledger_groups (id) ON DELETE NO ACTION
                                                            ON UPDATE CASCADE,
    ledger_type INTEGER       NOT NULL,
    is_sytem    INTEGER       NOT NULL,
    org_id      CHAR (36)     NOT NULL
                              REFERENCES organizations (id) ON DELETE NO ACTION
                                                            ON UPDATE NO ACTION,
    is_enabled  INTEGER       NOT NULL,
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
    ledger_id      CHAR (36)    REFERENCES ledgers (id) ON DELETE CASCADE
                                                        ON UPDATE CASCADE
                                PRIMARY KEY
                                NOT NULL,
    account_number VARCHAR (25) UNIQUE
	                            NOT NULL,
    account_type   INTEGER,
    ifsc_code      VARCHAR (16) NOT NULL,
    micr_code      VARCHAR (16),
    branch_code    VARCHAR (16),
    branch_name    VARCHAR (25),
    address_id     CHAR (36)    REFERENCES addresses (id) ON DELETE NO ACTION
                                                          ON UPDATE NO ACTION,
    contact_id     CHAR (36)    REFERENCES contacts (id) ON DELETE NO ACTION
                                                         ON UPDATE NO ACTION,
    is_default     INTEGER      NOT NULL
);

-- Table: parties
CREATE TABLE parties (
    ledger_id    CHAR (36)       PRIMARY KEY
                                 REFERENCES ledgers (id) ON DELETE CASCADE
                                                         ON UPDATE CASCADE
                                 NOT NULL,
    payment_term INTEGER         NOT NULL,
    credit_limit DECIMAL (12, 2) NOT NULL,
    address_id   CHAR (36)       REFERENCES addresses (id) ON DELETE NO ACTION
                                                           ON UPDATE NO ACTION,
    contact_id   CHAR (36)       REFERENCES contacts (id) ON DELETE NO ACTION
                                                          ON UPDATE NO ACTION
);

-- Table: units
CREATE TABLE units (
    id         CHAR (36)     PRIMARY KEY
                             NOT NULL,
    code       VARCHAR (16)  NOT NULL,
    unit_name  VARCHAR (25)  NOT NULL,
    unit_desc  VARCHAR (255),
    org_id     CHAR (36)     REFERENCES organizations (id) ON DELETE NO ACTION
                                                           ON UPDATE CASCADE
                             NOT NULL,
    is_enabled INTEGER       NOT NULL,
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
    id            CHAR (36)     PRIMARY KEY
                                NOT NULL,
    code          VARCHAR (16)  NOT NULL,
    category_name VARCHAR (25)  NOT NULL,
    category_desc VARCHAR (255),
    parent_id     CHAR (36)     REFERENCES product_categories (id) ON DELETE NO ACTION
                                                                   ON UPDATE NO ACTION,
    org_id        CHAR (36)     REFERENCES organizations (id) ON DELETE NO ACTION
                                                              ON UPDATE CASCADE
                                NOT NULL,
    is_enabled    INTEGER       NOT NULL,
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
    id             CHAR (36)       PRIMARY KEY
                                   NOT NULL,
    code           VARCHAR (16)    NOT NULL,
    product_name   VARCHAR (25)    NOT NULL,
    product_desc   VARCHAR (255),
    product_type   INTEGER         NOT NULL,
    category_id    CHAR (36)       REFERENCES product_categories (id) ON DELETE NO ACTION
                                                                      ON UPDATE CASCADE
                                   NOT NULL,
    unit_id        CHAR (36)       REFERENCES units (id) ON DELETE NO ACTION
                                                         ON UPDATE NO ACTION
                                   NOT NULL,
    cost_price     DECIMAL (12, 2) NOT NULL,
    selling_price  DECIMAL (12, 2) NOT NULL,
    tax_code       VARCHAR (16)    NOT NULL,
    tax_preference INTEGER         NOT NULL,
    tax_pct        DECIMAL (5, 2)  NOT NULL,
    org_id         CHAR (36)       REFERENCES organizations (id) ON DELETE NO ACTION
                                                                 ON UPDATE NO ACTION
                                   NOT NULL,
    is_enabled     INTEGER         NOT NULL,
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
    id         CHAR (36)    PRIMARY KEY
                            NOT NULL,
    year_code  VARCHAR (16) NOT NULL,
    year_begin DATE         NOT NULL,
    year_end   DATE         NOT NULL,
    org_id     CHAR (36)    REFERENCES organizations (id) ON DELETE NO ACTION
                                                          ON UPDATE CASCADE,
	UNIQUE (
	   year_code,
	   org_id
	)
);

-- Table: ledger_balances
CREATE TABLE ledger_balances (
    ledger_id       CHAR (36)       NOT NULL,
    year_id         CHAR (36)       NOT NULL
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
    year_id       CHAR (36)    NOT NULL
                               REFERENCES account_years (id) ON DELETE NO ACTION
                                                             ON UPDATE CASCADE,
    serial_module INTEGER      NOT NULL,
    serial_prefix VARCHAR (5),
    serial_format VARCHAR (16) NOT NULL,
    serial_suffix VARCHAR (5),
    last_value    VARCHAR (16),
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
    id             CHAR (36)    PRIMARY KEY
                                NOT NULL,
    journal_number VARCHAR (16) NOT NULL,
    journal_date   DATETIME     NOT NULL,
    journal_type   INTEGER      NOT NULL,
    journal_sign   CHAR (1)     NOT NULL,
    ledger_id      CHAR (36)    REFERENCES ledgers (id) ON DELETE NO ACTION
                                                        ON UPDATE CASCADE
                                NOT NULL,
    year_id        CHAR (36)    NOT NULL
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
    id           CHAR (36)       PRIMARY KEY
                                 NOT NULL,
    journal_id   CHAR (36)       REFERENCES journals (id) ON DELETE CASCADE
                                                          ON UPDATE CASCADE
                                 NOT NULL,
    ledger_id    CHAR (36)       REFERENCES ledgers (id) ON DELETE NO ACTION
                                                         ON UPDATE NO ACTION,
    quantity     DECIMAL (7, 3)  NOT NULL,
    amount       DECIMAL (12, 2) NOT NULL,
    journal_desc VARCHAR (255),
    ref_num      VARCHAR (16),
    ref_date     DATE
);

-- Table: buyers
CREATE TABLE buyers (
    id         CHAR (36)    PRIMARY KEY
                            NOT NULL,
    contact_id CHAR (36)    REFERENCES contacts (id) ON DELETE NO ACTION
                                                     ON UPDATE CASCADE,
    address_id CHAR (36)    REFERENCES addresses (id) ON DELETE NO ACTION
                                                      ON UPDATE CASCADE
);

-- Table: invoices
CREATE TABLE invoices (
    id             CHAR (36)       PRIMARY KEY
                                   NOT NULL,
    invoice_number VARCHAR (16)    NOT NULL,
    invoice_date   DATETIME        NOT NULL,
    invoice_type   INTEGER         NOT NULL,
    gst_treatment  INTEGER         NOT NULL,
    tax_preference INTEGER         NOT NULL,
    notes          VARCHAR (255),
    party_id       CHAR (36)       REFERENCES ledgers (id) ON DELETE NO ACTION
                                                           ON UPDATE CASCADE
                                   NOT NULL,
    ref_num        VARCHAR (16),
    ref_date       DATE,
    buyer_id       CHAR (36)       REFERENCES buyers (id) ON DELETE NO ACTION
                                                          ON UPDATE NO ACTION,
    subtotal       DECIMAL (12, 2) NOT NULL,
	total_qty      DECIMAL (10, 3)  NOT NULL,
    discount_pct   DECIMAL (5, 2)  NOT NULL,
    discount_amt   DECIMAL (9, 2)  NOT NULL,
    total_tax_amt  DECIMAL (9, 2)  NOT NULL,
    misc_add_desc  VARCHAR (25),
    misc_add_amt   DECIMAL (9, 2)  NOT NULL,
    net_amount     DECIMAL (12, 2) NOT NULL,
    year_id        CHAR (36)       REFERENCES account_years (id) ON DELETE NO ACTION
                                                                 ON UPDATE NO ACTION
                                   NOT NULL,
    created_at     DATETIME        NOT NULL,
    updated_at     DATETIME,
    UNIQUE (
        invoice_number,
        year_id
    )
);

-- Table: stocks
CREATE TABLE inventory (
    id          CHAR (36)       PRIMARY KEY
                                NOT NULL,
    product_id  CHAR (36)       NOT NULL
                                REFERENCES products (id) ON DELETE NO ACTION
                                                          ON UPDATE CASCADE,
    tag_number  VARCHAR (16)    NOT NULL
                                UNIQUE,
    mfg_date    DATE,
    expire_date DATE,
    unit_id     CHAR (36)       REFERENCES units (id) ON DELETE NO ACTION
                                                      ON UPDATE NO ACTION
                                NOT NULL,
    qty_on_hand DECIMAL (10, 3) NOT NULL
);

-- Table: invoice_items
CREATE TABLE invoice_items (
    id           CHAR (36)      PRIMARY KEY
                                NOT NULL,
    invoice_id   CHAR (36)      REFERENCES invoices (id) ON DELETE CASCADE
                                                         ON UPDATE CASCADE
                                NOT NULL,
    inventory_id CHAR (36)      REFERENCES inventory (id) ON DELETE NO ACTION
                                                          ON UPDATE NO ACTION,
    item_desc    VARCHAR (255)  NOT NULL,
    unit_id      CHAR (36)      NOT NULL
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
    id               CHAR (36)       PRIMARY KEY
                                     NOT NULL,
    debit_ledger_id  CHAR (36)       REFERENCES ledgers (id) ON DELETE NO ACTION
                                                             ON UPDATE NO ACTION
                                     NOT NULL,
    credit_ledger_id CHAR (36)       REFERENCES ledgers (id) ON DELETE NO ACTION
                                                             ON UPDATE NO ACTION
                                     NOT NULL,
    quantity         DECIMAL (9, 3)  NOT NULL,
    amount           DECIMAL (12, 2) NOT NULL,
    tran_desc        VARCHAR (255),
    ref_num          VARCHAR (16),
    ref_date         DATE,
    journal_id       CHAR (36)       REFERENCES journals (id) ON DELETE CASCADE
                                                              ON UPDATE NO ACTION,
    invoice_id       CHAR (36)       REFERENCES invoices (id) ON DELETE CASCADE
                                                              ON UPDATE NO ACTION
);

COMMIT TRANSACTION;
-- PRAGMA foreign_keys = on;
