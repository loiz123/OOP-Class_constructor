class Program
{
    static void Main()
    {
        // Thể loại
        Database.DsTheLoai.Add(new TheLoai { IdTheLoai = 1, TenTheLoai = "CNTT" });
        Database.DsTheLoai.Add(new TheLoai { IdTheLoai = 2, TenTheLoai = "Van hoc" });

        // Thêm sách
        SachService.ThemSach(new Sach
        {
            IdSach = 1,
            TenSach = "Lap trinh C#",
            TenTacGia = "Nguyen Van A",
            NgayXuatBan = new DateTime(2024, 1, 1),
            TinhTrang = "Con"
        }, new List<int> { 1 });

        SachService.ThemSach(new Sach
        {
            IdSach = 2,
            TenSach = "Truyen Kieu",
            TenTacGia = "Nguyen Du",
            NgayXuatBan = new DateTime(1800, 1, 1),
            TinhTrang = "Con"
        }, new List<int> { 2 });

        // Tìm theo thể loại
        var kq = SachService.TimTheoTheLoai("CNTT");
        foreach (var s in kq)
            Console.WriteLine(s.TenSach);
    }
}
