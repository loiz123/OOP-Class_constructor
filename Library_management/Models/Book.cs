using System;

namespace Library_Management.Models
{
    /// <summary>
    /// Lớp đại diện cho Sách trong thư viện.
    /// Thể hiện: Encapsulation.
    /// </summary>
    [Serializable]
    public class Book
    {
        // ─── Fields ───────────────────────────────────────────────────────
        private string _bookId = string.Empty;
        private string _title = string.Empty;
        private string _author = string.Empty;
        private int _totalQuantity;
        private int _availableQuantity;

        // ─── Properties ───────────────────────────────────────────────────
        public string BookId
        {
            get { return _bookId; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã sách không được để trống.");
                _bookId = value;
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên sách không được để trống.");
                _title = value;
            }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public int TotalQuantity
        {
            get { return _totalQuantity; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Tổng số lượng không được âm.");
                _totalQuantity = value;
            }
        }

        public int AvailableQuantity
        {
            get { return _availableQuantity; }
            set
            {
                if (value < 0 || value > _totalQuantity)
                    throw new ArgumentException("Số lượng hiện có không hợp lệ.");
                _availableQuantity = value;
            }
        }

        // ─── Constructors ─────────────────────────────────────────────────
        // Constructor mặc định (cần cho Serialization)
        public Book()
        {
            _bookId = string.Empty;
            _title = string.Empty;
            _author = string.Empty;
            _totalQuantity = 0;
            _availableQuantity = 0;
        }

        public Book(string bookId, string title, string author, int quantity)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            TotalQuantity = quantity;
            AvailableQuantity = quantity; // Khi mới nhập, số lượng hiện có bằng tổng số lượng
        }

        // ─── Methods ──────────────────────────────────────────────────────
        public override string ToString()
        {
            return $"[Sách] ID: {_bookId} - Tựa: {_title} - Tác giả: {_author} - Còn: {_availableQuantity}/{_totalQuantity}";
        }
    }
}