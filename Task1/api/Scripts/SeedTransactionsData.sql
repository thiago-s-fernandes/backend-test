-- Sample data insertion script
INSERT INTO Transactions (
    AccountID, TransactionID, TransactionAmount, TransactionCurrencyCode,
    LocalHour, TransactionScenario, TransactionType, TransactionIPaddress,
    IpState, IpPostalCode, IpCountry, IsProxyIP, BrowserLanguage,
    PaymentInstrumentType, CardType, PaymentBillingPostalCode,
    PaymentBillingState, PaymentBillingCountryCode, ShippingPostalCode,
    ShippingState, ShippingCountry, CvvVerifyResult, DigitalItemCount,
    PhysicalItemCount, TransactionDateTime
) VALUES (
    'ACC123456', 'TRX001', 125.99, 'USD',
    14, 'Online Purchase', 'Payment', '192.168.1.1',
    'CA', '90210', 'USA', 0, 'en-US',
    'Credit Card', 'VISA', '90210',
    'CA', 'USA', '90210',
    'CA', 'USA', 'Match', 0,
    2, TIMESTAMP '2023-06-15 14:30:00'
);

INSERT INTO Transactions (
    AccountID, TransactionID, TransactionAmount, TransactionCurrencyCode,
    LocalHour, TransactionScenario, TransactionType, TransactionIPaddress,
    IpState, IpPostalCode, IpCountry, IsProxyIP, BrowserLanguage,
    PaymentInstrumentType, CardType, PaymentBillingPostalCode,
    PaymentBillingState, PaymentBillingCountryCode, ShippingPostalCode,
    ShippingState, ShippingCountry, CvvVerifyResult, DigitalItemCount,
    PhysicalItemCount, TransactionDateTime
) VALUES (
    'ACC789012', 'TRX002', 49.99, 'EUR',
    10, 'Digital Purchase', 'Payment', '10.0.0.1',
    'NY', '10001', 'USA', 0, 'en-GB',
    'PayPal', NULL, '10001',
    'NY', 'USA', NULL,
    NULL, NULL, NULL, 1,
    0, TIMESTAMP '2023-06-16 10:15:00'
);

INSERT INTO Transactions (
    AccountID, TransactionID, TransactionAmount, TransactionCurrencyCode,
    LocalHour, TransactionScenario, TransactionType, TransactionIPaddress,
    IpState, IpPostalCode, IpCountry, IsProxyIP, BrowserLanguage,
    PaymentInstrumentType, CardType, PaymentBillingPostalCode,
    PaymentBillingState, PaymentBillingCountryCode, ShippingPostalCode,
    ShippingState, ShippingCountry, CvvVerifyResult, DigitalItemCount,
    PhysicalItemCount, TransactionDateTime
) VALUES (
    'ACC345678', 'TRX003', 199.50, 'GBP',
    18, 'In-Store Purchase', 'Payment', '172.16.254.1',
    'London', 'SW1A 1AA', 'UK', 0, 'en-GB',
    'Credit Card', 'MASTERCARD', 'SW1A 1AA',
    'London', 'UK', 'SW1A 1AA',
    'London', 'UK', 'Match', 0,
    3, TIMESTAMP '2023-06-17 18:45:00'
);
