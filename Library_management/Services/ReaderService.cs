using System;
using System.Collections.Generic;
using Library_Management.Models;
using Library_Management.Data; // Cần thiết để gọi FileStorage

namespace Library_Management.Services
{
    /// <summary>
    /// Quản lý danh sách độc giả và kết nối lưu trữ file.
    /// </summary>
    public class ReaderService : IManageable<Reader>
    {
        // ─── Fields ───────────────────────────────────────────────────────
        private List<Reader> _readers;
        private readonly FileStorage<Reader> _storage;
        private const string FileName = "readers.json";

        // ─── Constructor ──────────────────────────────────────────────────
        public ReaderService()
        {
            // Khởi tạo đối tượng lưu trữ Generic
            _storage = new FileStorage<Reader>();

            // Tải dữ liệu từ file JSON ngay khi khởi tạo
            // Nếu file chưa tồn tại, FileStorage.Load sẽ trả về list rỗng
            _readers = _storage.Load(FileName);

            if (_readers == null)
            {
                _readers = new List<Reader>();
            }
        }

        // ─── CRUD Methods ─────────────────────────────────────────────────

        /// <summary>Thêm độc giả và lưu vào file.</summary>
        public void Add(Reader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            if (FindById(reader.Id) != null)
            {
                Console.WriteLine("[LỖI] ID độc giả đã tồn tại.");
                return;
            }

            _readers.Add(reader);

            // Gọi phương thức Save của FileStorage để ghi xuống đĩa
            _storage.Save(FileName, _readers);
            Console.WriteLine("[OK] Đã thêm và lưu dữ liệu vào JSON.");
        }

        /// <summary>Xóa độc giả và cập nhật lại file.</summary>
        public void Remove(string id)
        {
            Reader reader = FindById(id);

            // Chỉ xóa nếu tìm thấy và độc giả không còn nợ sách
            if (reader != null && reader.BorrowedCount == 0)
            {
                _readers.Remove(reader);

                // Cập nhật lại file sau khi danh sách thay đổi
                _storage.Save(FileName, _readers);
                Console.WriteLine("[OK] Đã xóa và cập nhật file lưu trữ.");
            }
            else if (reader != null && reader.BorrowedCount > 0)
            {
                Console.WriteLine("[LỖI] Không thể xóa độc giả đang mượn sách.");
            }
        }

        /// <summary>Cập nhật thông tin và lưu file.</summary>
        public void Update(Reader updatedReader)
        {
            Reader existing = FindById(updatedReader.Id);
            if (existing != null)
            {
                existing.Name = updatedReader.Name;
                existing.Phone = updatedReader.Phone;
                existing.Email = updatedReader.Email;
                existing.Address = updatedReader.Address;
                existing.ReaderType = updatedReader.ReaderType;
                existing.MaxBorrow = updatedReader.MaxBorrow;

                // Lưu các thay đổi vào file JSON
                _storage.Save(FileName, _readers);
                Console.WriteLine("[OK] Đã cập nhật thông tin và lưu file.");
            }
        }

        // ─── Helper Methods ───────────────────────────────────────────────

        public Reader FindById(string id)
        {
            foreach (Reader r in _readers)
            {
                if (r.Id == id)
                {
                    return r;
                }
            }
            return null;
        }

        public List<Reader> GetAll()
        {
            return _readers;
        }

        public void PrintAll()
        {
            Console.WriteLine("══════════════════════════════════════");
            Console.WriteLine($"   DANH SÁCH ĐỘC GIẢ ({_readers.Count})");
            Console.WriteLine("══════════════════════════════════════");

            foreach (Reader r in _readers)
            {
                Console.WriteLine($"{r.Id} | {r.Name} | Mượn: {r.BorrowedCount}/{r.MaxBorrow}");
            }
            Console.WriteLine("══════════════════════════════════════");
        }

        /// <summary>Tạo bản sao lưu dữ liệu hiện tại.</summary>
        public void Backup()
        {
            _storage.BackupFile(FileName);
        }
    }
}