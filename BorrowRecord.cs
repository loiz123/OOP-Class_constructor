using System;

namespace LibraryManagement.Models
{
    /// <summary>
    /// Phiếu mượn sách
    /// </summary>
    [Serializable]
    public class BorrowRecord
    {
        private string _recordId;
        private Reader _reader;
        private Book _book;
        private Librarian _librarian;

        private DateTime _borrowDate;
        private DateTime _dueDate;
        private DateTime? _returnDate;

        private BorrowStatus _status;

        public string RecordId
        {
            get { return _recordId; }
            set { _recordId = value; }
        }

        public Reader Reader
        {
            get { return _reader; }
            set { _reader = value; }
        }

        public Book Book
        {
            get { return _book; }
            set { _book = value; }
        }

        public Librarian Librarian
        {
            get { return _librarian; }
            set { _librarian = value; }
        }

        public DateTime BorrowDate
        {
            get { return _borrowDate; }
            set { _borrowDate = value; }
        }

        public DateTime DueDate
        {
            get { return _dueDate; }
            set { _dueDate = value; }
        }

        public DateTime? ReturnDate
        {
            get { return _returnDate; }
            set { _returnDate = value; }
        }

        public BorrowStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// Hoàn thành việc trả sách
        /// </summary>
        public void CompleteReturn()
        {
            _returnDate = DateTime.Now;

            if (IsOverdue())
            {
                _status = BorrowStatus.Overdue;
            }
            else
            {
                _status = BorrowStatus.Returned;
            }
        }

        /// <summary>
        /// Kiểm tra quá hạn
        /// </summary>
        public bool IsOverdue()
        {
            if (_returnDate == null)
            {
                return DateTime.Now > _dueDate;
            }
            else
            {
                return _returnDate.Value > _dueDate;
            }
        }

        /// <summary>
        /// Số ngày trễ
        /// </summary>
        public int GetOverdueDays()
        {
            if (!IsOverdue())
            {
                return 0;
            }

            DateTime compareDate;

            if (_returnDate == null)
            {
                compareDate = DateTime.Now;
            }
            else
            {
                compareDate = _returnDate.Value;
            }

            TimeSpan span = compareDate - _dueDate;

            return span.Days;
        }

        /// <summary>
        /// Thông tin phiếu mượn
        /// </summary>
        public string GetInfo()
        {
            string info = "Record ID: " + _recordId +
                          " | Reader: " + _reader.Name +
                          " | Book: " + _book.Title +
                          " | Borrow Date: " + _borrowDate.ToShortDateString() +
                          " | Due Date: " + _dueDate.ToShortDateString() +
                          " | Status: " + _status;

            return info;
        }
    }
}