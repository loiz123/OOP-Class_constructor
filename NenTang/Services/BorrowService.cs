public static class BorrowService
{
    public static List<BorrowRecord> DsRecord = new();
    public static List<Fine> DsFine = new();

    public static void BorrowBook(Sach sach, string tenNguoiMuon)
    {
        if (sach.TinhTrang != "Con")
        {
            Console.WriteLine("Sach khong co san.");
            return;
        }

        BorrowRecord record = new BorrowRecord
        {
            IdRecord = DsRecord.Count + 1,
            Sach = sach,
            TenNguoiMuon = tenNguoiMuon,
            BorrowDate = DateTime.Now,
            DueDate = DateTime.Now.AddDays(7),
            Status = BorrowStatus.Borrowing
        };

        DsRecord.Add(record);

        sach.TinhTrang = "Het";

        Console.WriteLine("Muon sach thanh cong.");
    }

    public static void ReturnBook(int idRecord)
    {
        BorrowRecord record = DsRecord.Find(x => x.IdRecord == idRecord);

        if (record == null)
        {
            Console.WriteLine("Khong tim thay phieu muon.");
            return;
        }

        record.CompleteReturn();

        if (record.IsOverdue())
        {
            Fine fine = new Fine
            {
                IdFine = DsFine.Count + 1,
                Record = record
            };

            fine.Calculate();

            DsFine.Add(fine);

            Console.WriteLine("Sach tra tre. Tien phat: " + fine.Amount);
        }
        else
        {
            Console.WriteLine("Tra sach thanh cong.");
        }
    }

    public static List<BorrowRecord> GetOverdueRecords()
    {
        List<BorrowRecord> list = new();

        foreach (BorrowRecord r in DsRecord)
        {
            if (r.IsOverdue())
                list.Add(r);
        }

        return list;
    }
}