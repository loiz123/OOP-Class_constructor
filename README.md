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



1️⃣ Encapsulation – Tính đóng gói
📌 Thể hiện ở đâu?
✅ Person, Reader, Librarian

Các fields như _id, _name, _phone, _borrowedCount đều để private hoặc protected

Không cho truy cập trực tiếp từ bên ngoài

Truy cập thông qua property hoặc method

Ví dụ:

IncreaseBorrowCount()

DecreaseBorrowCount()

Checkout() trong Book

CompleteReturn() trong BorrowRecord

👉 Logic xử lý được đặt bên trong class, bên ngoài không thể tự ý thay đổi dữ liệu.

✅ Book

_availableQuantity không cho sửa trực tiếp

Muốn mượn phải gọi Checkout()

Muốn trả phải gọi Return()

👉 Đảm bảo số lượng sách không bị thay đổi sai.

✅ BorrowRecord

Trạng thái _status chỉ thay đổi thông qua CompleteReturn()

Không cho bên ngoài chỉnh status tùy ý

2️⃣ Abstraction – Tính trừu tượng
📌 Thể hiện ở đâu?
✅ Person là abstract class
abstract class Person

Không thể tạo object trực tiếp từ Person

Bắt buộc lớp con phải override:

GetInfo()

GetRole()

👉 Đây là trừu tượng hóa: định nghĩa khung chung, không quan tâm chi tiết.

✅ IManageable<T> là interface
interface IManageable<T>

Chỉ định nghĩa:

Add()

Remove()

FindById()

GetAll()

Update()

👉 Không quan tâm cách cài đặt bên trong.

BookService và BorrowService chỉ cần implement lại.

3️⃣ Inheritance – Tính kế thừa
📌 Thể hiện ở đâu?
✅ Reader và Librarian kế thừa Person
class Reader : Person
class Librarian : Person

Reader và Librarian:

Tự động có _id, _name, _phone, _email

Tái sử dụng method chung

👉 Không cần viết lại từ đầu.

4️⃣ Polymorphism – Tính đa hình
📌 Thể hiện ở đâu?
✅ Override phương thức

Trong Person:

public abstract string GetInfo();

Trong Reader:

public override string GetInfo()

Trong Librarian:

public override string GetInfo()

Cùng tên phương thức, nhưng hành vi khác nhau.

✅ Polymorphism qua Interface

BookService và BorrowService đều:

implement IManageable<T>
