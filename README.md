# Sàn Giao Dịch Việc Làm Trực Tuyến

## Giới Thiệu
Dự án này là một sàn giao dịch việc làm trực tuyến, giúp kết nối nhà tuyển dụng và người tìm việc. Ứng dụng cung cấp nhiều tính năng hỗ trợ việc tìm kiếm, đăng tuyển và quản lý tuyển dụng hiệu quả.

## Tính Năng
- 💼 **Dành cho nhà tuyển dụng:**
  - Đăng tin tuyển dụng
  - Quản lý danh sách ứng viên
  - Liên hệ với người tìm việc
  
- 🤝 **Dành cho người tìm việc:**
  - Tìm kiếm việc làm theo ngành nghề, địa điểm, mức lương
  - Đăng ký tài khoản, tạo CV trực tuyến
  - Nộp đơn xin việc và nhận thông báo tuyển dụng

- 🌐 **Tính năng khác:**
  - Hỗ trợ AI gợi ý công việc phù hợp
  - Hệ thống đánh giá và bình luận
  - Quản lý lưu lượng tuyển dụng

## Công Nghệ Sử Dụng
- **Back-end:** PHP (CodeIgniter 4), Node.js
- **Front-end:** HTML, CSS, JavaScript (React, Bootstrap 5)
- **Cơ sở dữ liệu:** MySQL, PostgreSQL
- **Authentication:** OAuth 2.0, JWT
- **Hỗ trợ gửi mail:** PHPMailer
- **Triển khai:** Docker, Nginx

## Cài Đặt
### Yêu cầu hệ thống
- PHP 8.1+
- Composer
- Node.js 18+
- MySQL hoặc PostgreSQL
- Docker (tùy chọn)

### Hướng dẫn cài đặt
1. Clone repository:
   ```sh
   git clone https://github.com/your-repo/job-marketplace.git
   cd job-marketplace
   ```
2. Cài đặt dependencies:
   ```sh
   composer install
   npm install
   ```
3. Cấu hình môi trường:
   - Sao chép file `.env.example` thành `.env` và chỉnh sửa thông tin kết nối database.
4. Chạy ứng dụng:
   ```sh
   php spark serve
   npm start
   ```
5. Truy cập ứng dụng tại: `http://localhost:8000`

## Đóng Góp
Chúng tôi hoan nghênh mọi đóng góp! Hãy fork repo, tạo branch mới, commit thay đổi và gửi pull request.

## Giấy Phép
Dự án này được phát hành dưới giấy phép MIT.

## Liên Hệ
- **Email:** support@example.com
- **Website:** https://yourwebsite.com

