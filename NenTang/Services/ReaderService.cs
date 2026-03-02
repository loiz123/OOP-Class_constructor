using System;
using System.Collections.Generic;
using Library_Management.Models;

namespace Library_Management.Services
{
    /// <summary>
    /// Quản lý danh sách độc giả.
    /// Thể hiện: Implement IManageable (Polymorphism), sử dụng FileStorage (Encapsulation)
    /// Lưu ý: Interface IManageable do TV2 viết — cần copy vào project trước.
    /// </summary>
    public class ReaderService
    {
        // ─── Fields ───────────────────────────────────────────────────────
        private List<Reader> _readers;

        // ─── Constructor ──────────────────────────────────────────────────
        public ReaderService()
        {
            _readers = new List<Reader>();
        }

        // ─── CRUD Methods ─────────────────────────────────────────────────
        /// <summary>Thêm độc giả mới.</summary>
        public void Add(Reader reader)
        {
            if (reader == null)
                throw new ArgumentNullException("reader", "Độc giả không được null.");

            if (FindById(reader.Id) != null)
                throw new InvalidOperationException("ID độc giả đã tồn tại: " + reader.Id);

            _readers.Add(reader);
            Console.WriteLine("[OK] Đã thêm độc giả: " + reader.Name);
        }

        /// <summary>Xóa độc giả theo ID.</summary>
        public void Remove(string id)
        {
            Reader reader = FindById(id);
            if (reader == null)
            {
                Console.WriteLine("[LỖI] Không tìm thấy độc giả ID: " + id);
                return;
            }

            if (reader.BorrowedCount > 0)
            {
                Console.WriteLine("[LỖI] Không thể xóa — độc giả đang mượn "
                                  + reader.BorrowedCount + " cuốn sách.");
                return;
            }

            _readers.Remove(reader);
            Console.WriteLine("[OK] Đã xóa độc giả: " + reader.Name);
        }

        /// <summary>Tìm độc giả theo ID.</summary>
        public Reader FindById(string id)
        {
            for (int i = 0; i < _readers.Count; i++)
            {
                if (_readers[i].Id == id)
                    return _readers[i];
            }
            return null;
        }

        /// <summary>Lấy toàn bộ danh sách độc giả.</summary>
        public List<Reader> GetAll()
        {
            return _readers;
        }

        /// <summary>Cập nhật thông tin độc giả.</summary>
        public void Update(Reader updatedReader)
        {
            Reader existing = FindById(updatedReader.Id);
            if (existing == null)
            {
                Console.WriteLine("[LỖI] Không tìm thấy độc giả ID: " + updatedReader.Id);
                return;
            }

            existing.Name = updatedReader.Name;
            existing.Phone = updatedReader.Phone;
            existing.Email = updatedReader.Email;
            existing.Address = updatedReader.Address;
            existing.ReaderType = updatedReader.ReaderType;
            existing.MaxBorrow = updatedReader.MaxBorrow;

            Console.WriteLine("[OK] Đã cập nhật độc giả: " + existing.Name);
        }

        // ─── Search Methods ────────────────────────────────────────────────
        /// <summary>Tìm kiếm độc giả theo tên (không phân biệt hoa/thường).</summary>
        public List<Reader> SearchByName(string name)
        {
            List<Reader> result = new List<Reader>();
            string keyword = name.ToLower();

            for (int i = 0; i < _readers.Count; i++)
            {
                if (_readers[i].Name.ToLower().Contains(keyword))
                    result.Add(_readers[i]);
            }
            return result;
        }

        /// <summary>Lấy danh sách độc giả đang mượn sách.</summary>
        public List<Reader> GetBorrowingReaders()
        {
            List<Reader> result = new List<Reader>();
            for (int i = 0; i < _readers.Count; i++)
            {
                if (_readers[i].BorrowedCount > 0)
                    result.Add(_readers[i]);
            }
            return result;
        }

        // ─── Display Methods ───────────────────────────────────────────────
        /// <summary>In danh sách độc giả ra console.</summary>
        public void PrintAll()
        {
            Console.WriteLine("══════════════════════════════════════");
            Console.WriteLine("        DANH SÁCH ĐỘC GIẢ            ");
            Console.WriteLine("══════════════════════════════════════");

            if (_readers.Count == 0)
            {
                Console.WriteLine("  (Chưa có độc giả nào)");
            }
            else
            {
                for (int i = 0; i < _readers.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + _readers[i].GetBasicInfo()
                                      + " | Đang mượn: " + _readers[i].BorrowedCount
                                      + "/" + _readers[i].MaxBorrow);
                }
            }
            Console.WriteLine("══════════════════════════════════════");
            Console.WriteLine("Tổng: " + _readers.Count + " độc giả");
        }

        /// <summary>Load danh sách từ bên ngoài (dùng khi FileStorage load xong).</summary>
        public void SetReaders(List<Reader> readers)
        {
            _readers = readers;
        }
    }
}