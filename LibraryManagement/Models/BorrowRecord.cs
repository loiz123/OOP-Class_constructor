using System;

namespace Library_Management.Models
{
    /// <summary>
    /// Phiếu mượn sách - liên kết Reader, Book, Librarian
    /// </summary>
    public class BorrowRecord
    {
        public string RecordId { get; set; }

        public required Reader Reader { get; set; }
        public required Book Book { get; set; }
        public required Librarian Librarian { get; set; }

        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public BorrowStatus Status { get; set; }

        public BorrowRecord()
        {
            RecordId = Guid.NewGuid().ToString();
            Status = BorrowStatus.Borrowing;
        }

        public bool IsOverdue()
        {
            return Status == BorrowStatus.Borrowing && DateTime.Now > DueDate;
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
        }

        public string GetInfo()
        {
            return $"RecordId: {RecordId} | Book: {Book.Title} | Reader: {Reader.Name} | Status: {Status}";
        }
    }
}