using System;

namespace Library_Management.Models
{
    /// <summary>
    /// Đại diện cho một cuốn sách trong thư viện.
    /// Thể hiện tính Encapsulation: quản lý chặt chẽ số lượng sách khi mượn/trả.
    /// </summary>
    public class Book
    {
        private string _bookId;
        private string _title;
        private string _author;
        private string _category;
        private string _publisher;
        private int _totalQuantity;
        private int _availableQuantity;

        public Book(string bookId, string title, string author, string category, string publisher, int totalQuantity)
        {
            _bookId = bookId;
            _title = title;
            _author = author;
            _category = category;
            _publisher = publisher;
            _totalQuantity = totalQuantity;
            _availableQuantity = totalQuantity; // Khi mới nhập về, số lượng sẵn có bằng tổng số lượng
        }

        // Properties (Encapsulation)
        public string BookId
        {
            get { return _bookId; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ID sách không được để trống.");
                _bookId = value;
            }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public string Publisher
        {
            get { return _publisher; }
            set { _publisher = value; }
        }

        public int TotalQuantity
        {
            get { return _totalQuantity; }
            set
            {
                if (value < 0) throw new ArgumentException("Tổng số lượng không được âm.");
                _totalQuantity = value;
            }
        }

        public int AvailableQuantity
        {
            get { return _availableQuantity; }
            set
            {
                if (value < 0 || value > _totalQuantity)
                    throw new ArgumentException("Số lượng sẵn có không hợp lệ.");
                _availableQuantity = value;
            }
        }

        /// <summary>Kiểm tra xem sách còn có thể mượn không.</summary>
        public bool IsAvailable()
        {
            return _availableQuantity > 0;
        }

        /// <summary>Thực hiện mượn sách (giảm số lượng sẵn có).</summary>
        public void Checkout()
        {
            if (!IsAvailable())
                throw new InvalidOperationException("Sách này đã hết, không thể mượn.");
            _availableQuantity--;
        }

        /// <summary>Thực hiện trả sách (tăng số lượng sẵn có).</summary>
        public void Return()
        {
            if (_availableQuantity >= _totalQuantity)
                throw new InvalidOperationException("Lỗi: Số lượng sách trả vượt quá tổng số lượng ban đầu.");
            _availableQuantity++;
        }

        /// <summary>Trả về thông tin chi tiết của sách.</summary>
        public string GetInfo()
        {
            return $"[Sách] ID: {_bookId} | Tựa: {_title} | Tác giả: {_author} | Thể loại: {_category} | NXB: {_publisher} | Còn lại: {_availableQuantity}/{_totalQuantity}";
        }
    }
}