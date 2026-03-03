using System;

namespace LibraryManagement.Models
{
    /// <summary>
    /// Phiếu phạt
    /// </summary>
    [Serializable]
    public class Fine
    {
        private string _fineId;
        private BorrowRecord _record;
        private double _amount;
        private bool _paid;

        private const double FINE_PER_DAY = 5000;

        public string FineId
        {
            get { return _fineId; }
            set { _fineId = value; }
        }

        public BorrowRecord Record
        {
            get { return _record; }
            set { _record = value; }
        }

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public bool Paid
        {
            get { return _paid; }
            set { _paid = value; }
        }

        /// <summary>
        /// Tính tiền phạt
        /// </summary>
        public void Calculate()
        {
            int overdueDays = _record.GetOverdueDays();
            _amount = overdueDays * FINE_PER_DAY;
        }

        /// <summary>
        /// Đánh dấu đã thanh toán
        /// </summary>
        public void MarkAsPaid()
        {
            _paid = true;
        }

        /// <summary>
        /// Thông tin tiền phạt
        /// </summary>
        public string GetInfo()
        {
            string info = "Fine ID: " + _fineId +
                          " | Amount: " + _amount +
                          " | Paid: " + _paid;

            return info;
        }
    }
}