using System;

namespace Library_Management.Models
{
    /// <summary>
    /// Thủ thư — kế thừa từ Person.
    /// Thể hiện: Inheritance, Polymorphism (override GetInfo, GetRole)
    /// </summary>
    [Serializable]
    public class Librarian : Person
    {
        // ─── Fields ───────────────────────────────────────────────────────
        private string _staffCode;    // Mã nhân viên
        private string _department;  // Phòng ban
        private DateTime _hireDate;    // Ngày vào làm

        // ─── Properties ───────────────────────────────────────────────────
        public string StaffCode
        {
            get { return _staffCode; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã nhân viên không được để trống.");
                _staffCode = value;
            }
        }

        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public DateTime HireDate
        {
            get { return _hireDate; }
            set { _hireDate = value; }
        }

        // ─── Constructors ─────────────────────────────────────────────────
        // Constructor mặc định (cần cho Serialization)
        public Librarian() : base()
        {
            _staffCode = string.Empty;
            _department = "Thư viện";
            _hireDate = DateTime.Now;
        }

        public Librarian(string id, string name, string phone, string staffCode)
            : base(id, name, phone)
        {
            _staffCode = staffCode;
            _department = "Thư viện";
            _hireDate = DateTime.Now;
        }

        public Librarian(string id, string name, string phone, string staffCode, string department)
            : base(id, name, phone)
        {
            _staffCode = staffCode;
            _department = department;
            _hireDate = DateTime.Now;
        }

        // ─── Override Abstract Methods (Polymorphism) ─────────────────────
        public override string GetInfo()
        {
            return "=== THỦ THƯ ===" + Environment.NewLine
                + "ID       : " + _id + Environment.NewLine
                + "Họ tên   : " + _name + Environment.NewLine
                + "SĐT      : " + _phone + Environment.NewLine
                + "Email    : " + _email + Environment.NewLine
                + "Mã NV    : " + _staffCode + Environment.NewLine
                + "Phòng ban: " + _department + Environment.NewLine
                + "Ngày vào : " + _hireDate.ToString("dd/MM/yyyy");
        }

        public override string GetRole()
        {
            return "THỦ THƯ";
        }

        // ─── Business Logic Methods ────────────────────────────────────────
        /// <summary>Thủ thư duyệt yêu cầu mượn sách.</summary>
        public bool ApproveBorrow(Reader reader, string bookTitle)
        {
            if (!reader.CanBorrow())
            {
                Console.WriteLine("[TỪ CHỐI] " + reader.Name + " đã đạt giới hạn mượn sách.");
                return false;
            }
            Console.WriteLine("[DUYỆT] " + _name + " đã duyệt cho " + reader.Name
                              + " mượn sách: " + bookTitle);
            return true;
        }

        /// <summary>Thủ thư xác nhận trả sách.</summary>
        public bool ApproveReturn(Reader reader, string bookTitle)
        {
            Console.WriteLine("[XÁC NHẬN] " + _name + " đã xác nhận " + reader.Name
                              + " trả sách: " + bookTitle);
            return true;
        }
    }
}