using System.Collections.Generic;

namespace Library_Management.Services
{
    /// <summary>
    /// Interface dùng chung cho việc quản lý các đối tượng trong hệ thống.
    /// Thể hiện: Abstraction, Polymorphism.
    /// </summary>
    public interface IManageable<T>
    {
        void Add(T item);
        void Remove(string id);
        T FindById(string id);
        List<T> GetAll();
        void Update(T item);
    }
}