CREATE TABLE Transactions (
    AccountID VARCHAR2(100) NOT NULL,
    TransactionID VARCHAR2(100) PRIMARY KEY,
    TransactionAmount NUMBER(18,2) NOT NULL,
    TransactionCurrencyCode VARCHAR2(3) NOT NULL,
    LocalHour NUMBER(2) NOT NULL,
    TransactionScenario VARCHAR2(100) NOT NULL,
    TransactionType VARCHAR2(100) NOT NULL,
    TransactionIPaddress VARCHAR2(50) NOT NULL,
    IpState VARCHAR2(100),
    IpPostalCode VARCHAR2(20),
    IpCountry VARCHAR2(100) NOT NULL,
    IsProxyIP NUMBER(1) DEFAULT 0 NOT NULL,
    BrowserLanguage VARCHAR2(50),
    PaymentInstrumentType VARCHAR2(100),
    CardType VARCHAR2(50),
    PaymentBillingPostalCode VARCHAR2(20),
    PaymentBillingState VARCHAR2(100),
    PaymentBillingCountryCode VARCHAR2(3),
    ShippingPostalCode VARCHAR2(20),
    ShippingState VARCHAR2(100),
    ShippingCountry VARCHAR2(100),
    CvvVerifyResult VARCHAR2(50),
    DigitalItemCount NUMBER(10) DEFAULT 0 NOT NULL,
    PhysicalItemCount NUMBER(10) DEFAULT 0 NOT NULL,
    TransactionDateTime TIMESTAMP NOT NULL
);

-- Create index for better performance
CREATE INDEX idx_account_id ON Transactions(AccountID);
CREATE INDEX idx_transaction_date ON Transactions(TransactionDateTime);
