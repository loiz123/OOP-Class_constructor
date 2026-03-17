namespace Library_Management.Controllers
{
    public class MenuController
    {
        private readonly ReaderService _readerService;

        public MenuController()
        {
            // Khởi tạo ReaderService (khi đó FileStorage cũng sẽ tự load dữ liệu)
            _readerService = new ReaderService();
        }

        public void Run()
        {
            // Code hiển thị menu console tại đây
            Console.WriteLine("--- CHƯƠNG TRÌNH QUẢN LÝ THƯ VIỆN ---");
            _readerService.PrintAll();
        }
    }
}