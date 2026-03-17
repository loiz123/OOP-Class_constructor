using System;
using System.Collections.Generic;
using Library_Management.Models;

namespace Library_Management.Services
{
    public class BorrowService : IManageable<BorrowRecord>
    {
        private List<BorrowRecord> _records = new List<BorrowRecord>();
        private List<Fine> _fines = new List<Fine>(); // Quản lý thêm danh sách phạt

        // ─── Implement IManageable ────────────────────────────────────────
        public void Add(BorrowRecord item) { _records.Add(item); }
        public void Remove(string id) { var r = FindById(id); if (r != null) _records.Remove(r); }
        public BorrowRecord FindById(string id) { return _records.Find(r => r.IdRecord == id); }
        public List<BorrowRecord> GetAll() { return _records; }
        public void Update(BorrowRecord item) { /* Logic cập nhật phiếu mượn */ }

        // ─── Yêu cầu của giảng viên ───────────────────────────────────────
        public void BorrowBook(Reader reader, Book book, Librarian librarian)
        {
            if (!book.IsAvailable()) { Console.WriteLine("Sách đã hết."); return; }
            if (!reader.CanBorrow()) { Console.WriteLine("Độc giả đã mượn tối đa."); return; }

            BorrowRecord record = new BorrowRecord
            {
                IdRecord = Guid.NewGuid().ToString().Substring(0, 8), // Tạo ID ngẫu nhiên
                Reader = reader,
                Book = book,
                Librarian = librarian,
                BorrowDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7),
                Status = BorrowStatus.Borrowing
            };

            book.Checkout(); // Giảm số lượng sách
            reader.IncreaseBorrowCount(); // Tăng số lượng mượn của độc giả
            Add(record);
            Console.WriteLine("Mượn sách thành công.");
        }

        public void ReturnBook(string recordId)
        {
            BorrowRecord record = FindById(recordId);
            if (record == null) { Console.WriteLine("Không tìm thấy phiếu mượn."); return; }

            record.CompleteReturn();

            if (record.IsOverdue())
            {
                Fine fine = new Fine { IdFine = _fines.Count + 1, Record = record };
                fine.Calculate();
                _fines.Add(fine);
                Console.WriteLine($"Trả sách trễ. Bị phạt: {fine.Amount} VND");
            }
            else
            {
                Console.WriteLine("Trả sách thành công, đúng hạn.");
            }
        }

        public List<BorrowRecord> GetOverdueRecords() { return _records.FindAll(r => r.IsOverdue()); }
        public List<BorrowRecord> GetRecordsByReader(string readerId) { return _records.FindAll(r => r.Reader.Id == readerId); }
        public List<Fine> GetUnpaidFines() { return _fines.FindAll(f => !f.IsPaid); }
    }
}