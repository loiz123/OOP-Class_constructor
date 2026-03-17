using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Library_Management.Data
{
    /// <summary>
    /// Phụ trách kết nối toàn bộ hệ thống, xử lý lưu/đọc file JSON.
    /// Thể hiện tính chất Generic: Dùng được cho tất cả loại dữ liệu.
    /// </summary>
    public class FileStorage<T>
    {
        private readonly string _directoryPath = "Data";

        public FileStorage()
        {
            // Tự động tạo thư mục Data nếu chưa có để tránh lỗi đường dẫn
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }
        }

        /// <summary>Lưu danh sách dữ liệu ra file JSON.</summary>
        public void Save(string fileName, List<T> data)
        {
            try
            {
                string filePath = Path.Combine(_directoryPath, fileName);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(data, options);
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LỖI] Không thể lưu file {fileName}: {ex.Message}");
            }
        }

        /// <summary>Đọc dữ liệu từ file JSON lên danh sách.</summary>
        public List<T> Load(string fileName)
        {
            try
            {
                string filePath = Path.Combine(_directoryPath, fileName);
                if (!FileExists(fileName)) return new List<T>();

                string jsonString = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<T>>(jsonString) ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LỖI] Không thể đọc file {fileName}: {ex.Message}");
                return new List<T>();
            }
        }

        /// <summary>Kiểm tra sự tồn tại của file dữ liệu.</summary>
        public bool FileExists(string fileName)
        {
            string filePath = Path.Combine(_directoryPath, fileName);
            return File.Exists(filePath);
        }

        /// <summary>Tạo bản sao lưu cho file dữ liệu hiện tại.</summary>
        public void BackupFile(string fileName)
        {
            try
            {
                string sourcePath = Path.Combine(_directoryPath, fileName);
                if (FileExists(fileName))
                {
                    string backupFileName = $"{Path.GetFileNameWithoutExtension(fileName)}_backup_{DateTime.Now:yyyyMMdd_HHmmss}.json";
                    string destPath = Path.Combine(_directoryPath, backupFileName);
                    File.Copy(sourcePath, destPath, true);
                    Console.WriteLine($"[OK] Đã tạo bản sao lưu: {backupFileName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LỖI] Không thể tạo bản sao lưu: {ex.Message}");
            }
        }
    }
}