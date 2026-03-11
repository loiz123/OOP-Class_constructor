public class BorrowRecord
{
    public int IdRecord { get; set; }

    public Sach Sach { get; set; }

    public string TenNguoiMuon { get; set; }

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

        Sach.TinhTrang = "Con";
    }

    public string GetInfo()
    {
        return $"{IdRecord} - {Sach.TenSach} - {TenNguoiMuon} - {Status}";
    }
}