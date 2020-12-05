namespace Fanda2.Backend.Database
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int InventoryId { get; set; }
        public string ItemDesc { get; set; }
        public int UnitId { get; set; }
        public decimal Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPct { get; set; }
        public decimal TaxPct { get; set; }

        #region Readonly

        public decimal Price
        {
            get => _price == 0 ? Qty * UnitPrice : _price;
            internal set { _price = value; }
        }

        public decimal DiscountAmt
        {
            get => _discountAmt == 0 ? Price * (DiscountPct / 100) : _discountAmt;
            internal set { _discountAmt = value; }
        }

        public decimal TaxAmt
        {
            get => _taxAmt == 0 ? (Price - DiscountAmt) * (TaxPct / 100) : _taxAmt;
            internal set { _taxAmt = value; }
        }

        public decimal LineTotal
        {
            get => _lineTotal == 0 ? Price - DiscountAmt + TaxAmt : _lineTotal;
            internal set { _lineTotal = value; }
        }

        #endregion Readonly

        #region Privates

        private decimal _price;
        private decimal _discountAmt;
        private decimal _taxAmt;
        private decimal _lineTotal;

        #endregion Privates
    }
}
