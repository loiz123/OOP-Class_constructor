using System;

namespace Library_Management.Models
{
    /// <summary>
    /// Abstract base class cho tất cả người dùng trong hệ thống.
    /// Không thể tạo đối tượng Person trực tiếp.
    /// Thể hiện: Abstraction, Encapsulation, Inheritance
    /// </summary>
    [Serializable]
    public abstract class Person
    {
        // ─── Fields (private/protected — Encapsulation) ───────────────────
        protected string _id;
        protected string _name;
        protected string _phone;
        protected string _email;
        protected string _address;

        // ─── Properties ───────────────────────────────────────────────────
        public string Id
        {
            get { return _id; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ID không được để trống.");
                _id = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên không được để trống.");
                _name = value;
            }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        // ─── Constructors ─────────────────────────────────────────────────
        // Constructor mặc định (cần cho Serialization)
        protected Person()
        {
            _id = string.Empty;
            _name = string.Empty;
            _phone = string.Empty;
            _email = string.Empty;
            _address = string.Empty;
        }

        protected Person(string id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
            _email = string.Empty;
            _address = string.Empty;
        }

        // ─── Abstract Methods (lớp con BẮT BUỘC phải override) ───────────
        /// <summary>Trả về thông tin chi tiết của người dùng.</summary>
        public abstract string GetInfo();

        /// <summary>Trả về vai trò của người dùng trong hệ thống.</summary>
        public abstract string GetRole();

        // ─── Concrete Methods (dùng chung cho tất cả lớp con) ────────────
        /// <summary>Trả về thông tin cơ bản, dùng chung không cần override.</summary>
        public string GetBasicInfo()
        {
            return "[" + GetRole() + "] " + _id + " — " + _name + " | SĐT: " + _phone;
        }

        public override string ToString()
        {
            return GetInfo();
        }
    }
}