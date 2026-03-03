namespace LibraryManagement.Models
{
    /// <summary>
    /// Trạng thái của phiếu mượn
    /// </summary>
    public enum BorrowStatus
    {
        Borrowing,
        Returned,
        Overdue,
        Lost
    }
}