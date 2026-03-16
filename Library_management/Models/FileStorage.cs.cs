using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Library_Management.Storage
{
    /// <summary>
    /// Lớp Generic xử lý lưu trữ dữ liệu dưới dạng JSON.
    /// Thể hiện: Generic Class, Serialization.
    /// </summary>
    public class FileStorage<T>
    {
        private string _filePath;

        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        public FileStorage(string filePath)
        {
            _filePath = filePath;
            // Đảm bảo thư mục tồn tại
            string directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        /// <summary>Kiểm tra file dữ liệu có tồn tại không.</summary>
        public bool FileExists()
        {
            return File.Exists(_filePath);
        }

        /// <summary>Lưu danh sách đối tượng vào file JSON.</summary>
        public void Save(List<T> data)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[LỖI LƯU FILE] " + ex.Message);
            }
        }

        /// <summary>Đọc danh sách đối tượng từ file JSON.</summary>
        public List<T> Load()
        {
            try
            {
                if (!FileExists())
                {
                    return new List<T>();
                }
                string jsonString = File.ReadAllText(_filePath);
                List<T> data = JsonSerializer.Deserialize<List<T>>(jsonString);
                return data ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[LỖI ĐỌC FILE] " + ex.Message);
                return new List<T>();
            }
        }

        /// <summary>Tạo bản sao lưu cho file dữ liệu.</summary>
        public void BackupFile()
        {
            if (FileExists())
            {
                File.Copy(_filePath, _filePath + ".bak", true);
            }
        }
    }
}