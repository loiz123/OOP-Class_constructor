using Library_Management.Models;

public class BorrowRecord
{
    public int IdRecord { get; set; }

    public Book Book{ get; set; }


    public DateTime BorrowDate { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public BorrowStatus Status { get; set; }

    public bool IsOverdue()
    {
        if (Status == BorrowStatus.Returned)
            return false;

        return DateTime.Now > DueDate;
    }

    public int GetOverdueDays()
    {
        if (!IsOverdue())
            return 0;

        return (DateTime.Now - DueDate).Days;
    }

    public void CompleteReturn()
    {
        ReturnDate = DateTime.Now;
        Status = BorrowStatus.Returned;

        Book.AvailableQuantity++;
    }

    public string GetInfo()
    {
        return $"{IdRecord} - {Book.Title} - {Book.AvailableQuantity} - {Status}";
    }
}