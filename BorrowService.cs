using System;
using System.Collections.Generic;
using LibraryManagement.Models;

namespace LibraryManagement.Services
{
    /// <summary>
    /// Quản lý mượn trả sách
    /// </summary>
    public class BorrowService : IManageable<BorrowRecord>
    {
        private List<BorrowRecord> _records;

        public BorrowService()
        {
            _records = new List<BorrowRecord>();
        }

        public void Add(BorrowRecord record)
        {
            _records.Add(record);
        }

        public void Remove(string id)
        {
            for (int i = 0; i < _records.Count; i++)
            {
                if (_records[i].RecordId == id)
                {
                    _records.RemoveAt(i);
                    break;
                }
            }
        }

        public BorrowRecord FindById(string id)
        {
            for (int i = 0; i < _records.Count; i++)
            {
                if (_records[i].RecordId == id)
                {
                    return _records[i];
                }
            }

            return null;
        }

        public List<BorrowRecord> GetAll()
        {
            return _records;
        }

        public void Update(BorrowRecord record)
        {
            for (int i = 0; i < _records.Count; i++)
            {
                if (_records[i].RecordId == record.RecordId)
                {
                    _records[i] = record;
                    break;
                }
            }
        }

        /// <summary>
        /// Mượn sách
        /// </summary>
        public void BorrowBook(BorrowRecord record)
        {
            _records.Add(record);
        }

        /// <summary>
        /// Trả sách
        /// </summary>
        public void ReturnBook(string recordId)
        {
            BorrowRecord record = FindById(recordId);

            if (record != null)
            {
                record.CompleteReturn();
            }
        }

        /// <summary>
        /// Danh sách quá hạn
        /// </summary>
        public List<BorrowRecord> GetOverdueRecords()
        {
            List<BorrowRecord> result = new List<BorrowRecord>();

            for (int i = 0; i < _records.Count; i++)
            {
                if (_records[i].IsOverdue())
                {
                    result.Add(_records[i]);
                }
            }

            return result;
        }

        /// <summary>
        /// Lấy phiếu mượn theo Reader
        /// </summary>
        public List<BorrowRecord> GetRecordsByReader(string readerId)
        {
            List<BorrowRecord> result = new List<BorrowRecord>();

            for (int i = 0; i < _records.Count; i++)
            {
                if (_records[i].Reader.Id == readerId)
                {
                    result.Add(_records[i]);
                }
            }

            return result;
        }
    }
}

//lab 08
// 1. Lớp Human Human(name, age)age

// 2. Employeee kế thừa Human (id,coef salary, pảticipant date, edu_level)

// 3. Company (name, address)

// xây dựng các class, bổ sung các phương thức cần thiết như get,set, cóntructor, tostring
// bổ sung công thức tính lương cho lớp Employee biết rằng (coef salary) là hệ số lương khởi điểm, cứ 3năm
// từ lúc vào được tăng lương 1 lần với % hệ số coef salary = 0.3
// Lương = hệ số lương * lương cơ bản

//khởi tạo com với 5 employee. Sau đó bổ sung vào companypany công thức in bảng lương cho tất cả nhân viên trong cty
// trong đó có tính tổng lương đã chi trong từng tháng (tham số "tháng")

//4. triển khai kĩ thuật dezerialize để cho phép lưu ra file và đọc dữ liệu tưd file của cty