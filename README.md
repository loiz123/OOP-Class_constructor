XÂY DỰNG HỆ THỐNG QUẢN LÝ MƯỢN TRẢ SÁCH THƯ VIỆN
Thành viên:

Trần Đại Phát - loiz123

Hà Ngọc Thiện - HNTRHunter

Khiếu Hoàng Nam Anh - nvm4nh

Tiêu Lâm Định Quốc - dinhquoc03032626



Sơ đồ quan hệ cơ bản
<img width="1116" height="746" alt="image" src="https://github.com/user-attachments/assets/db453745-cdfb-479d-bc18-62f27988b5ae" />



Xem phân công nhiệm vụ ở đây
https://docs.google.com/document/d/1FpFU-Zol2SmEm832tv-UKfhWURjXS9Z5/edit?usp=sharing&ouid=106548223410039392007&rtpof=true&sd=true



Các nguyên tắc OOP được áp dụng
1. Encapsulation (Đóng gói)

Tất cả các thuộc tính trong các lớp như Person, Reader, Librarian, Book, BorrowRecord, Fine đều được khai báo private hoặc protected và truy cập thông qua property hoặc phương thức công khai.

Các lớp như Book (Checkout, Return), BorrowRecord (CompleteReturn, IsOverdue), Fine (Calculate, MarkAsPaid) và Reader (IncreaseBorrowCount, DecreaseBorrowCount) đều ẩn toàn bộ logic xử lý bên trong class. Điều này giúp đảm bảo tính toàn vẹn dữ liệu và tránh việc thay đổi trạng thái trực tiếp từ bên ngoài.

Các lớp Service như ReaderService, BookService, BorrowService cũng quản lý danh sách đối tượng thông qua các phương thức công khai thay vì cho truy cập trực tiếp vào danh sách nội bộ.

2. Abstraction (Trừu tượng)

Lớp Person được khai báo là abstract class, không thể tạo đối tượng trực tiếp mà chỉ dùng làm lớp cơ sở cho Reader và Librarian. Lớp này định nghĩa các phương thức trừu tượng như GetInfo() và GetRole() để lớp con bắt buộc phải triển khai.

Interface IManageable<T> định nghĩa các phương thức chung như Add, Remove, FindById, GetAll, Update. Các lớp BookService và BorrowService triển khai interface này, giúp ẩn chi tiết cài đặt bên trong và chỉ cung cấp hợp đồng sử dụng.

3. Inheritance (Kế thừa)

Hai lớp Reader và Librarian kế thừa từ lớp Person, tái sử dụng toàn bộ các thuộc tính chung như _id, _name, _phone, _email, _address.

Lớp con mở rộng thêm các thuộc tính riêng:

Reader: _maxBorrow, _borrowedCount, _readerType

Librarian: _staffCode, _department, _hireDate

Việc kế thừa giúp giảm lặp code và xây dựng cấu trúc phân cấp rõ ràng trong hệ thống.

4. Polymorphism (Đa hình)

Các phương thức trừu tượng GetInfo() và GetRole() được override khác nhau trong Reader và Librarian, thể hiện đa hình thông qua method overriding.

Ngoài ra, các lớp BookService và BorrowService cùng triển khai interface IManageable<T>, cho phép sử dụng thông qua kiểu interface mà không cần quan tâm lớp cụ thể bên dưới. Đây là đa hình thông qua interface.>
