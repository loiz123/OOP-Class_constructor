using System;
using System.Collections.Generic;
using Library_Management.Models;

namespace Library_Management.Services
{
    /// <summary>
    /// Quản lý danh sách sách trong thư viện.
    /// Thể hiện: Implement IManageable (Polymorphism), sử dụng List (Encapsulation).
    /// </summary>
    public class BookService : IManageable<Book>
    {
        // ─── Fields ───────────────────────────────────────────────────────
        private List<Book> _books;

        // ─── Constructor ──────────────────────────────────────────────────
        public BookService()
        {
            _books = new List<Book>();
        }

        // ─── CRUD Methods ─────────────────────────────────────────────────
        /// <summary>Thêm sách mới.</summary>
        public void Add(Book book)
        {
            if (book == null)
                throw new ArgumentNullException("book", "Sách không được null.");

            if (FindById(book.BookId) != null)
                throw new InvalidOperationException("ID sách đã tồn tại: " + book.BookId);

            _books.Add(book);
            Console.WriteLine("[OK] Đã thêm sách: " + book.Title);
        }

        /// <summary>Xóa sách theo ID.</summary>
        public void Remove(string id)
        {
            Book book = FindById(id);
            if (book == null)
            {
                Console.WriteLine("[LỖI] Không tìm thấy sách ID: " + id);
                return;
            }

            _books.Remove(book);
            Console.WriteLine("[OK] Đã xóa sách: " + book.Title);
        }

        /// <summary>Tìm sách theo ID.</summary>
        public Book FindById(string id)
        {
            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].BookId == id)
                    return _books[i];
            }
            return null;
        }

        /// <summary>Lấy toàn bộ danh sách sách.</summary>
        public List<Book> GetAll()
        {
            return _books;
        }

        /// <summary>Cập nhật thông tin sách.</summary>
        public void Update(Book updatedBook)
        {
            Book existing = FindById(updatedBook.BookId);
            if (existing == null)
            {
                Console.WriteLine("[LỖI] Không tìm thấy sách ID: " + updatedBook.BookId);
                return;
            }

            existing.Title = updatedBook.Title;
            existing.Author = updatedBook.Author;
            existing.TotalQuantity = updatedBook.TotalQuantity;
            existing.AvailableQuantity = updatedBook.AvailableQuantity;

            Console.WriteLine("[OK] Đã cập nhật sách: " + existing.Title);
        }

        // ─── Display Methods ───────────────────────────────────────────────
        public void PrintAll()
        {
            Console.WriteLine("══════════════════════════════════════");
            Console.WriteLine("          DANH SÁCH SÁCH              ");
            Console.WriteLine("══════════════════════════════════════");

            if (_books.Count == 0)
            {
                Console.WriteLine("  (Chưa có sách nào)");
            }
            else
            {
                for (int i = 0; i < _books.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + _books[i].ToString());
                }
            }
            Console.WriteLine("══════════════════════════════════════");
            Console.WriteLine("Tổng: " + _books.Count + " đầu sách");
        }
    }
}