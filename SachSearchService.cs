public class SachSearchService
{
    public static List<Sach> TimTheoTen(string ten)
    {
        return Database.DsSach.FindAll(
            s => s.TenSach.ToLower().Contains(ten.ToLower())
        );
    }

    public static List<Sach> TimTheoTacGia(string tacGia)
    {
        return Database.DsSach.FindAll(
            s => s.TenTacGia.ToLower().Contains(tacGia.ToLower())
        );
    }

    public static List<Sach> TimTheoTheLoai(string tenTheLoai)
{
    var theLoai = Database.DsTheLoai
                    .Find(t => t.TenTheLoai.ToLower() == tenTheLoai.ToLower());

    if (theLoai == null) return new List<Sach>();

    var dsIdSach = Database.DsSachTheLoai
                    .FindAll(x => x.IdTheLoai == theLoai.IdTheLoai)
                    .ConvertAll(x => x.IdSach);

    return Database.DsSach.FindAll(s => dsIdSach.Contains(s.IdSach));
}
}