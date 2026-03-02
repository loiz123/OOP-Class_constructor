public static class SachService
{
    public static void ThemSach(Sach s, List<int> dsTheLoai)
    {
        Database.DsSach.Add(s);

        foreach (int idTL in dsTheLoai)
        {
            Database.DsSachTheLoai.Add(new SachTheLoai
            {
                IdSach = s.IdSach,
                IdTheLoai = idTL
            });
        }
    }

    public static void CapNhatSach(Sach sMoi)
    {
        var s = Database.DsSach.Find(x => x.IdSach == sMoi.IdSach);
        if (s == null) return;

        s.TenSach = sMoi.TenSach;
        s.TenTacGia = sMoi.TenTacGia;
        s.NgayXuatBan = sMoi.NgayXuatBan;
        s.TinhTrang = sMoi.TinhTrang;
    }
    
        public static void XoaSach(int idSach)
    {
        Database.DsSach.RemoveAll(x => x.IdSach == idSach);
        Database.DsSachTheLoai.RemoveAll(x => x.IdSach == idSach);
    }


}

