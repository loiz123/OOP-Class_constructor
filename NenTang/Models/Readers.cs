using System;

namespace Library_Management.Models
{
    /// <summary>
    /// Độc giả — kế thừa từ Person.
    /// Thể hiện: Inheritance, Polymorphism (override GetInfo, GetRole)
    /// </summary>
    [Serializable]
    public class Reader : Person
    {
        // ─── Fields ───────────────────────────────────────────────────────
        private int _maxBorrow;       // Số sách tối đa được mượn cùng lúc
        private int _borrowedCount;   // Số sách đang mượn hiện tại
        private DateTime _registeredDate;  // Ngày đăng ký thẻ thư viện
        private string _readerType;      // "Sinh viên" / "Giảng viên" / "Khách"

        // ─── Properties ───────────────────────────────────────────────────
        public int MaxBorrow
        {
            get { return _maxBorrow; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Số sách tối đa phải lớn hơn 0.");
                _maxBorrow = value;
            }
        }

        public int BorrowedCount
        {
            get { return _borrowedCount; }
        }

        public DateTime RegisteredDate
        {
            get { return _registeredDate; }
            set { _registeredDate = value; }
        }

        public string ReaderType
        {
            get { return _readerType; }
            set { _readerType = value; }
        }

        // ─── Constructors ─────────────────────────────────────────────────
        // Constructor mặc định (cần cho Serialization)
        public Reader() : base()
        {
            _maxBorrow = 3;
            _borrowedCount = 0;
            _registeredDate = DateTime.Now;
            _readerType = "Sinh viên";
        }

        public Reader(string id, string name, string phone) : base(id, name, phone)
        {
            _maxBorrow = 3;
            _borrowedCount = 0;
            _registeredDate = DateTime.Now;
            _readerType = "Sinh viên";
        }

        public Reader(string id, string name, string phone, string readerType, int maxBorrow)
            : base(id, name, phone)
        {
            _readerType = readerType;
            _maxBorrow = maxBorrow;
            _borrowedCount = 0;
            _registeredDate = DateTime.Now;
        }

        // ─── Override Abstract Methods (Polymorphism) ─────────────────────
        public override string GetInfo()
        {
            return "=== ĐỘC GIẢ ===" + Environment.NewLine
                + "ID       : " + _id + Environment.NewLine
                + "Họ tên   : " + _name + Environment.NewLine
                + "SĐT      : " + _phone + Environment.NewLine
                + "Email    : " + _email + Environment.NewLine
                + "Loại     : " + _readerType + Environment.NewLine
                + "Đang mượn: " + _borrowedCount + "/" + _maxBorrow + " cuốn" + Environment.NewLine
                + "Ngày đăng ký: " + _registeredDate.ToString("dd/MM/yyyy");
        }

        public override string GetRole()
        {
            return "ĐỘC GIẢ";
        }

        // ─── Business Logic Methods ────────────────────────────────────────
        /// <summary>Kiểm tra độc giả có thể mượn thêm sách không.</summary>
        public bool CanBorrow()
        {
            return _borrowedCount < _maxBorrow;
        }

        /// <summary>Tăng số sách đang mượn khi mượn thành công.</summary>
        public void IncreaseBorrowCount()
        {
            if (!CanBorrow())
                throw new InvalidOperationException("Độc giả đã đạt giới hạn mượn sách.");
            _borrowedCount++;
        }

        /// <summary>Giảm số sách đang mượn khi trả sách.</summary>
        public void DecreaseBorrowCount()
        {
            if (_borrowedCount <= 0)
                throw new InvalidOperationException("Số sách đang mượn đã là 0.");
            _borrowedCount--;
        }

        /// <summary>Số slot mượn còn lại.</summary>
        public int GetRemainingSlots()
        {
            return _maxBorrow - _borrowedCount;
        }
    }
}