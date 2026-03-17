using System;
using Library_Management.Models;

namespace Library_Management.Models
{
    public class BorrowRecord
    {
        public string IdRecord { get; set; } = string.Empty;
        public Book Book { get; set; }
        public Reader Reader { get; set; }       // Đã bổ sung Reader
        public Librarian Librarian { get; set; } // Đã bổ sung Librarian

        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public BorrowStatus Status { get; set; }

        public bool IsOverdue()
        {
            if (Status == BorrowStatus.Returned) return false;
            return DateTime.Now > DueDate;
        }

        public int GetOverdueDays()
        {
            if (!IsOverdue()) return 0;
            return (DateTime.Now - DueDate).Days;
        }

        public void CompleteReturn()
        {
            ReturnDate = DateTime.Now;
            Status = BorrowStatus.Returned;
            Book.Return();                // Sử dụng hàm Return của Book
            Reader.DecreaseBorrowCount(); // Giảm số lượng sách độc giả đang mượn
        }

        public string GetInfo()
        {
            return $"[{IdRecord}] Độc giả: {Reader?.Name} - Sách: {Book?.Title} - Trạng thái: {Status}";
        }
    }
}