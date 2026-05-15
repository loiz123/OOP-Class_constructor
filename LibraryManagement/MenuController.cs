using System;
using System.Collections.Generic;
using Library_Management.Models;
using Library_Management.Services;

namespace Library_Management
{
    /// <summary>
    /// Controller điều hướng menu chính của hệ thống.
    /// Giữ toàn bộ logic điều hướng bên trong (Encapsulation).
    /// </summary>
    public class MenuController
    {
        private ReaderService _readerService;
        private BookService _bookService;

        // Uncomment sau khi Định Quốc hoàn thành BorrowService
        // private BorrowService _borrowService;

        public MenuController()
        {
            _readerService = new ReaderService();
            _bookService = new BookService();
            // _borrowService = new BorrowService();
        }

        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                try
                {
                    ShowMainMenu();
                    Console.Write("Chọn chức năng (0-4): ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            HandleReaderMenu();
                            break;
                        case "2":
                            HandleBookMenu();
                            break;
                        case "3":
                            HandleBorrowMenu();
                            break;
                        case "4":
                            HandleReportMenu();
                            break;
                        case "0":
                            isRunning = false;
                            Console.WriteLine("Đang đóng chương trình. Tạm biệt!");
                            break;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập lại.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý exception toàn cục để chống crash chương trình
                    Console.WriteLine($"\n[LỖI HỆ THỐNG PHÁT HIỆN Ở MENU]: {ex.Message}");
                    Console.WriteLine("Chương trình đã ngăn chặn lỗi crash. Nhấn phím bất kỳ để quay lại menu...");
                    Console.ReadKey();
                }
            }
        }

        private void ShowMainMenu()
        {
            Console.WriteLine("\n===== HỆ THỐNG QUẢN LÝ THƯ VIỆN OOP =====");
            Console.WriteLine("1. Quản lý Bạn Đọc");
            Console.WriteLine("2. Quản lý Sách");
            Console.WriteLine("3. Quản lý Mượn / Trả (Nghiệp vụ)");
            Console.WriteLine("4. Báo cáo & Thống kê");
            Console.WriteLine("0. Thoát chương trình");
            Console.WriteLine("=========================================");
        }

        private void HandleReaderMenu()
        {
            Console.WriteLine("\n--- QUẢN LÝ BẠN ĐỌC ---");
            Console.WriteLine("1. Thêm bạn đọc mới");
            Console.WriteLine("2. Xem danh sách bạn đọc");
            Console.WriteLine("0. Quay lại");
            Console.Write("Lựa chọn của bạn: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Nhập ID: ");
                string id = Console.ReadLine();
                Console.Write("Nhập Tên: ");
                string name = Console.ReadLine();
                Console.Write("Nhập SDT: ");
                string phone = Console.ReadLine();
                Console.Write("Loại bạn đọc (SinhVien/GiangVien): ");
                string type = Console.ReadLine();

                Reader newReader = new Reader(id, name, phone, "N/A", "N/A", type, 3);
                _readerService.Add(newReader);
            }
            else if (choice == "2")
            {
                _readerService.PrintAll();
            }
        }

        private void HandleBookMenu()
        {
            Console.WriteLine("\n--- QUẢN LÝ SÁCH ---");
            Console.WriteLine("1. Xem danh sách toàn bộ sách");
            Console.WriteLine("0. Quay lại");
            Console.Write("Lựa chọn của bạn: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                List<Book> books = _bookService.GetAll();
                if (books.Count == 0)
                {
                    Console.WriteLine("Danh sách sách trống.");
                }
                else
                {
                    for (int i = 0; i < books.Count; i++)
                    {
                        Console.WriteLine(books[i].GetInfo());
                    }
                }
            }
        }

        private void HandleBorrowMenu()
        {
            Console.WriteLine("\n--- QUẢN LÝ MƯỢN TRẢ ---");
            Console.WriteLine("Chức năng đang chờ nhánh của Định Quốc (BorrowService) merge vào.");
            // Logic Mượn / Trả sẽ viết ở đây
        }

        private void HandleReportMenu()
        {
            Console.WriteLine("\n--- BÁO CÁO THỐNG KÊ ---");
            Console.WriteLine("1. Danh sách bạn đọc đang mượn sách");
            Console.WriteLine("0. Quay lại");
            Console.Write("Lựa chọn của bạn: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                List<Reader> borrowing = _readerService.GetBorrowingReaders();
                if (borrowing.Count == 0) Console.WriteLine("Không có ai đang mượn sách.");
                for (int i = 0; i < borrowing.Count; i++)
                {
                    Console.WriteLine(borrowing[i].GetInfo());
                }
            }
        }
    }
}