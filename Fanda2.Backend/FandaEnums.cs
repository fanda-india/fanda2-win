namespace Fanda2.Backend
{
    public enum AddressType
    {
        Default = 0,
        Billing = 1,
        Shipping = 2,
        Remittance = 3
    }

    public enum BankAccountType
    {
        Default = 0,
        Savings = 1,
        Current = 2,
        Fixed = 3,
        Demat = 4,
        Salary = 5,
        Other = 6
    }

    public enum PaymentTerm
    {
        None = 0,
        Immediate = 1,
        OnReceipt = 2,
        OnDate = 3,
        Net7 = 4,
        Net10 = 5,
        Net15 = 6,
        Net30 = 7,
        Net45 = 8,
        Net60 = 9,
        Net90 = 10,
    }

    public enum PartyType
    {
        Customer = 1,
        Supplier = 2,
        Buyer = 3,
        Other = 4
    }

    //public enum PartyCategory
    //{
    //    Default = 0,
    //    Consumer = 1,
    //    Producer = 2,
    //    Manufacturer = 3,
    //    Retailer = 4,
    //    Wholesaler = 5,
    //    Agent = 6,
    //    Broker = 7
    //}

    public enum ProductType
    {
        FinishedGoods = 1,
        RawMaterial = 2,
        Services = 3
    }

    public enum ProductTaxPreference
    {
        Taxable = 1,
        NonTaxable = 2
    }

    public enum InvoiceType
    {
        Stock = 1,
        Purchase = 2,
        DebitNote = 3, //PurchaseReturn
        Sales = 4,
        CreditNote = 5, //SalesReturn
        Exchange = 6,
        Transfer = 7
    }

    // Billing Category : It is used to differentiate billing documents based on the requirements for invoice printing...etc
    // Down payment, Billing request etc...we use this billing category = p when we use billing document for down payment.
    //public enum InvoiceCategory
    //{
    //    Cash = 0,
    //    Credit = 1,
    //}

    public enum StockInvoiceType
    {
        None = 0,
        Opening = 1,
        Transfer = 2,
        Wastage = 3,
        Adjustment = 4,
        Loss = 5,
        WriteOff = 6,
        Expired = 7
    }

    public enum GstTreatment
    {
        RegisteredBusiness = 1,
        UnregisteredBusiness = 2,
        Consumer = 3,
        Overseas = 4
    }

    public enum InvoiceTaxPreference
    {
        Taxable = 1,
        TaxExempt = 2
    }

    public enum Status
    {
        Initiated = 0,
        Created = 1,
        Modified = 2,
        Deleted = 3,
        Printed = 4,
        Approved = 5,
        Rejected = 6,
        Cancelled = 7,
        Hold = 8,
        Activated = 9,
        Deactivated = 10
    }

    public enum RoundOffOption
    {
        NoRoundOff = 0,
        NearestTo1 = 1,
        NearestTo5 = 2,

        NearestTo10 = 3
        //NearestTo50 = 4,
        //NearestTo100 = 5,
        //Nearest500=6,
        //Nearest1000=7
    }

    public enum LedgerGroupType
    {
        Asset = 1,
        Liability = 2,
        Income = 3,
        Expense = 4,
        Revenue = 5
        //Branches = 6,
        //Warehouse = 7
    }

    public enum IncomeOrExpenseType
    {
        Manufacturing = 1,
        Tranding = 2,
        Business = 3
    }

    public enum SerialNumberModule
    {
        Receipts = 1,
        Payments = 2,
        Withdrawls = 3,
        Deposits = 4,
        Journals = 5,
        Purchase = 6,
        Sales = 7,
        DebitNote = 8,      // PurchaseReturn
        CreditNote = 9,     // SalesReturn
        RawMaterial = 10,
        TagNumber = 11
    }

    public enum SerialNumberReset
    {
        NoReset = 0,
        Max = 1,
        Daily = 2,
        Monthly = 3,
        CalendarYear = 4,
        AccountingYear = 5
    }

    public enum KeyField
    {
        Code = 1,
        Name = 2,
        Email = 3,
        Mobile = 4,
        Number = 5
    }

    public enum ResourceType
    {
        Master = 1,
        Transaction = 2,
        Configuration = 4,
        Report = 8,
        All = 15
    }

    public enum LedgerType
    {
        Default = 0,
        Party = 1,
        Bank = 2
    }

    public enum JournalType
    {
        Receipts = 1,
        Payments = 2,
        Withdrawls = 3,
        Deposits = 4,
        Journals = 5,
        Purchase = 6,
        Sales = 7,
        DebitNote = 8,  // PurchaseReturn
        CreditNote = 9  // SalesReturn
    }

    //public enum GoodsType
    //{
    //    FinishedGoods = 1,
    //    RawMaterial = 2
    //}
}

//public static class FandaEnums
//{
//    //public static IEnumerable<RoleType> GetRoleTypes() =>
//    //Enum.GetValues(typeof(RoleType)) as IEnumerable<RoleType>;
//    public static IEnumerable<AddressType> GetAddressTypes() =>
//        Enum.GetValues(typeof(AddressType)) as IEnumerable<AddressType>;

//    public static IEnumerable<BankAccountType> GetBankAccountTypes() =>
//        Enum.GetValues(typeof(BankAccountType)) as IEnumerable<BankAccountType>;

//    public static IEnumerable<PaymentTerm> GetPaymentTerms() =>
//        Enum.GetValues(typeof(PaymentTerm)) as IEnumerable<PaymentTerm>;

//    public static IEnumerable<PartyType> GetPartyTypes() =>
//        Enum.GetValues(typeof(PartyType)) as IEnumerable<PartyType>;

//    public static IEnumerable<ProductType> GetProductTypes() =>
//        Enum.GetValues(typeof(ProductType)) as IEnumerable<ProductType>;

//    public static IEnumerable<InvoiceType> GetInvoiceTypes() =>
//        Enum.GetValues(typeof(InvoiceType)) as IEnumerable<InvoiceType>;

//    public static IEnumerable<StockInvoiceType> GetStockInvoiceTypes() =>
//        Enum.GetValues(typeof(StockInvoiceType)) as IEnumerable<StockInvoiceType>;

//    public static IEnumerable<Status> GetStatus() =>
//        Enum.GetValues(typeof(Status)) as IEnumerable<Status>;

//    public static IEnumerable<RoundOffOption> GetRoundOffOptions() =>
//        Enum.GetValues(typeof(RoundOffOption)) as IEnumerable<RoundOffOption>;
//}

//public enum RoleType
//{
//    Guest = 0,
//    User = 1,
//    PowerUser = 2,
//    Manager = 4,
//    Administrator = 8,
//    SuperAdmin = 16
//}

//public enum AccountOwner
//{
//    None = 0,
//    Organization = 1,
//    Party = 2
//}