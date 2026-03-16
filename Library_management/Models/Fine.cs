public class Fine
{
    public int IdFine { get; set; }

    public BorrowRecord Record { get; set; }

    public double Amount { get; set; }

    public bool IsPaid { get; set; }

    public double Calculate()
    {
        int overdueDays = Record.GetOverdueDays();

        if (overdueDays <= 0)
            return 0;

        Amount = overdueDays * 5000; // 5000đ mỗi ngày
        return Amount;
    }

    public void MarkAsPaid()
    {
        IsPaid = true;
    }

    public string GetInfo()
    {
        return $"Fine: {Amount} - Paid: {IsPaid}";
    }
}