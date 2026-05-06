using System;
using Library_Management.Models;

namespace Library_Management.Models
{
    /// <summary>
    /// Phiếu phạt khi trả sách trễ
    /// </summary>
    public class Fine
    {
        private string _fineId;
        private BorrowRecord _borrowRecord;
        private double _amount;
        private bool _isPaid;

        public Fine(BorrowRecord borrowRecord)
        {
            _fineId = Guid.NewGuid().ToString();

            _borrowRecord = borrowRecord
                ?? throw new ArgumentNullException(nameof(borrowRecord));

            _amount = 0;
            _isPaid = false;
        }

        // ===== Properties =====
        public string FineId => _fineId;
        public BorrowRecord BorrowRecord => _borrowRecord;
        public double Amount => _amount;
        public bool IsPaid => _isPaid;

        // ===== Logic =====
        public void Calculate()
        {
            if (_borrowRecord == null)
                throw new InvalidOperationException("BorrowRecord không tồn tại.");

            int daysLate = _borrowRecord.GetOverdueDays();

            if (daysLate <= 0)
            {
                _amount = 0;
                return;
            }

            _amount = daysLate * 5000;

            // chống tiền âm (safe guard)
            if (_amount < 0)
            {
                _amount = 0;
            }
        }

        public void MarkAsPaid()
        {
            _isPaid = true;
        }

        public string GetInfo()
        {
            return $"FineId: {_fineId} | Amount: {_amount} | Paid: {_isPaid}";
        }
    }
}