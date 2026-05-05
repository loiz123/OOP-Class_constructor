using System;

namespace Library_Management.Models
{
    /// <summary>
    /// Phiếu phạt khi trả sách trễ
    /// </summary>
    public class Fine
    {
        public string FineId { get; set; }
        public BorrowRecord BorrowRecord { get; set; }
        public double Amount { get; set; }
        public bool IsPaid { get; set; }

        public Fine(BorrowRecord record)
        {
            FineId = Guid.NewGuid().ToString();
            BorrowRecord = record;
            Amount = 0;
            IsPaid = false;
        }

        public void Calculate()
        {
            int daysLate = BorrowRecord.GetOverdueDays();
            if (daysLate > 0)
            {
                Amount = daysLate * 5000;
            }
        }

        public void MarkAsPaid()
        {
            IsPaid = true;
        }

        public string GetInfo()
        {
            return $"FineId: {FineId} | Amount: {Amount} | Paid: {IsPaid}";
        }
    }
}