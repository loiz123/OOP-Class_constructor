using System;
using Library_Management.Services;

namespace Library_Management.Controllers
{
    public class MenuController
    {
        private readonly ReaderService _readerService;
        private readonly BookService _bookService;
        private readonly BorrowService _borrowService;

        public MenuController()
        {
            // Khởi tạo tất cả Service
            _readerService = new ReaderService();
            _bookService = new BookService();
            _borrowService = new BorrowService();
        }

        public void Run()
        {
            ShowMainMenu();
        }

        public void ShowMainMenu()
        {
            Console.WriteLine("--- CHƯƠNG TRÌNH QUẢN LÝ THƯ VIỆN ---");
            Console.WriteLine("1. Quản lý Sách");
            Console.WriteLine("2. Quản lý Độc giả");
            Console.WriteLine("3. Quản lý Mượn / Trả");
            Console.WriteLine("4. Báo cáo thống kê");
            // Code dùng vòng lặp while(true) và switch-case để gọi các hàm bên dưới
        }

        public void HandleBookMenu() { /* Logic menu sách */ }
        public void HandleReaderMenu() { /* Logic menu độc giả */ }
        public void HandleBorrowMenu() { /* Logic menu mượn trả */ }
        public void HandleReportMenu() { /* Logic menu thống kê */ }
    }
}