CREATE DATABASE QuanLyBanHangN_63132681;
USE QuanLyBanHangN_63132681;

go
-- tạo bảng loại sản phẩm
CREATE TABLE LoaiSanPham (
    MaLoaiSanPham varchar(10) PRIMARY KEY,
    TenLoaiSanPham NVARCHAR(50) NOT NULL,
	AnhLoaiSP varchar(200),
	Mota nvarchar(255)
);
go
-- tạo bảng sản phẩm
CREATE TABLE SanPham (
    MaSanPham INT IDENTITY(1, 1) PRIMARY KEY,
    TenSanPham NVARCHAR(100) NOT NULL,
    DonGia INT NOT NULL,
    MoTa NVARCHAR(255),
    AnhSanPham NVARCHAR(255),
    MaLoaiSanPham VARCHAR(10),
    SoLuongDaBan INT, -- dùng để xét điều kiện có là sản phẩm phổ biến không
    TinhTrang BIT, -- dùng để sản phẩm được giảm giá hay không
    FOREIGN KEY (MaLoaiSanPham) REFERENCES LoaiSanPham(MaLoaiSanPham)
);


go
-- tạo bảng khách hàng
CREATE TABLE KhachHang (
    MaKhachHang INT IDENTITY(1, 1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(100) NOT NULL,
    DienThoai NVARCHAR(15) NOT NULL,
    Email NVARCHAR(50) NOT NULL,
    MatKhau NVARCHAR(255) NOT NULL
);
go
-- tạo bảng nhân viên
CREATE TABLE NhanVien (
    MaNhanVien INT IDENTITY(1, 1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
	AnhNhanVien nvarchar(255) not null,
	DienThoai NVARCHAR(15) NOT NULL,
	DiaChi NVARCHAR(100) NOT NULL,
    Email NVARCHAR(50) NOT NULL,
    MatKhau NVARCHAR(255) NOT NULL,
    QuyenTruyCap NVARCHAR(50) NOT NULL
);
go
-- tạo bảng hóa đơn
CREATE TABLE HoaDon (
    MaHoaDon INT IDENTITY(1, 1) PRIMARY KEY,
	TenHoaDon nvarchar(255),
    NgayDat DATETIME NOT NULL,
    NgayGiao DATETIME,
    MaKhachHang INT,
    MaNhanVien INT,
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
go
-- tạo bảng chi tiết hóa đơn
CREATE TABLE ChiTietHoaDon (
	MaCTHD int identity(1,1) primary key,
    MaHoaDon INT,
    MaSanPham int,
    SoLuong INT NOT NULL,
    DonGia int NOT NULL,
    FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon) ON DELETE CASCADE,
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham) ON DELETE CASCADE
);

-- chèn dữ liệu vào bảng loại sản phẩm
INSERT INTO LoaiSanPham (MaLoaiSanPham, TenLoaiSanPham,AnhLoaiSP, Mota)
VALUES
('SS', N'SamSung', 'ssmau.jpg', N'Dòng điện thoại samsung với thiết kế vô cùng đẹp mắt'),
('AP', N'Apple', 'ipmau.jpg', N'Dòng điện thoại iphone với thiết kế vô cùng đẹp mắt'),
('OP', N'Oppo', 'opmau.png', N'Dòng điện thoại oppo với thiết kế vô cùng đẹp mắt'),
('Xi', N'Xiaomi', 'ximau.png', N'Dòng điện thoại xiaomi với thiết kế vô cùng đẹp mắt'),
('Vi', N'Vivo', 'vimau.jpg', N'Dòng điện thoại vivo với thiết kế vô cùng đẹp mắt');
go
-- bảng sản phẩm là bản chính trong hệ thống gồm 30 bản ghi
INSERT INTO SanPham (TenSanPham, DonGia, MoTa, AnhSanPham, MaLoaiSanPham, SoLuongDaBan, TinhTrang)
VALUES
    (N'Samsung Galaxy S21', 10000000, N'Samsung cao cấp', N'samsung_s21.jpg', 'SS', 0, 1),
    (N'Iphone 14 Pro', 20000000, N'Iphone cao cấp', N'iphone14pro.jpg', 'AP', 100, 1),
    (N'OPPO Reno10', 7000000, N'Oppo cao cấp', N'opre10.jpg', 'OP', 20, 0),
    (N'Xiaomi Redmi', 12000000, N'Điện thoại xịn xò', N'xiaore.jpg', 'Xi', 10, 0),
    (N'vivo Y36', 2000000, N'Điện thoại xịn xò', N'vivo-y36.jpg', 'Vi', 36, 0),
	(N'Samsung Galaxy S23', 10500000, N'Samsung cao cấp', N'samsung_s23.jpg', 'SS', 123, 1),
    (N'iPhone 15 Pro', 22000000, N'iPhone cao cấp', N'iphone_15.jpg', 'AP', 111, 1),
    (N'OPPO F19', 6500000, N'Oppo phổ thông', N'oppo-f19.jpg', 'OP', 59, 0),
    (N'Xiaomi Mi 12', 13000000, N'Điện thoại Xiaomi', N'xiaomi-12.jpg', 'Xi', 1, 0),
    (N'vivo V24', 2300000, N'Điện thoại Vivo', N'vivo_v24.jpg', 'Vi', 23,0),
	 (N'Samsung Galaxy Note 20 Ultra 5G', 30000000, N'Samsung cao cấp', N'ssgn20.jpg', 'SS', 0, 1),
    (N'Iphone X', 9000000, N'Iphone cao cấp', N'ipx.png', 'AP', 0, 1),
    (N'OPPO A12 s', 7000000, N'Oppo cao cấp', N'opa12s.jpg', 'OP', 0, 0),
    (N'Xiaomi Redmi Note 10 Pro 128 Blue', 12000000, N'Điện thoại xịn xò', N'xireno10pro.jpg', 'Xi', 0, 0),
    (N'vivo V29E 8GB 256GB', 9000000, N'Điện thoại xịn xò', N'viv29.jpg', 'Vi', 0, 0),
	(N'Samsung Galaxy S22 Ultra 5G 128GB', 16500000, N'Samsung cao cấp', N'ss22ul.jpg', 'SS', 0, 1),
    (N'iPhone 11 Pro Max', 15000000, N'iPhone cao cấp', N'ip11promax.jpg', 'AP', 0, 1),
    (N'OPPO A58', 9500000, N'Oppo phổ thông', N'opa58.jpg', 'OP', 0, 0),
    (N'Xiaomi Redmi Note 12 8GB 128GB', 5000000, N'Điện thoại Xiaomi', N'reno12.jpg', 'Xi', 1, 0),
    (N'vivo V25 Pro 8GB 128GB', 8000000, N'Điện thoại Vivo', N'viv25.jpg', 'Vi', 0,0),
	 (N'Samsung Galaxy S10+', 10000000, N'Samsung cao cấp', N'samsung_s21.jpg', 'SS', 0, 1),
    (N'Iphone 12 Pro', 20000000, N'Iphone cao cấp', N'ip12pro.jpg', 'AP', 0, 1),
    (N'OPPO Reno8 Pro', 9000000, N'Oppo cao cấp', N'opre8pro.jpg', 'OP', 0, 0),
    (N'Xiaomi Redmi 13C 6GB 128GB', 4000000, N'Điện thoại xịn xò', N're13c.jpg', 'Xi', 0, 0),
    (N'vivo Y02s 3GB 64GB', 2600000, N'Điện thoại xịn xò', N'viy02.jpg', 'Vi', 0, 0),
	(N'Samsung Galaxy S22 Ultra', 10500000, N'Samsung cao cấp', N'ssul20.jpg', 'SS', 0, 1),
    (N'iPhone 13 Pro Max', 22000000, N'iPhone cao cấp', N'ip13promax.jpg', 'AP', 0, 1),
    (N'OPPO A11', 6500000, N'Oppo phổ thông', N'opa11.jpg', 'OP', 0, 0),
    (N'Xiaomi 13T Pro 5G (12GB - 512GB)', 13000000, N'Điện thoại Xiaomi', N'xi13t.jpg', 'Xi', 1, 0),
    (N'vivo Y02t 4GB 64GB', 3000000, N'Điện thoại Vivo', N'viy02t.jpg', 'Vi', 0,0);


	-- chèn dữ liệu vào bảng khách hàng
INSERT INTO KhachHang (HoTen, DiaChi, DienThoai, Email, MatKhau)
VALUES
(N'Nguyễn Văn A', N'123 Đường ABC, Quận 1, TP.HCM', '0901234567', 'nguyenvana@gmail.com', 'matkhauA'),
(N'Lê Thị B', N'456 Đường XYZ, Quận 2, TP.HCM', '0909876543', 'lethib@gmail.com', 'matkhauB'),
(N'Trần Văn C', N'789 Đường KLM, Quận 3, TP.HCM', '0908765432', 'tranvanc@gmail.com', 'matkhauC');

-- chèn dữ liệu vào bảng nhân viên
INSERT INTO NhanVien ( HoTen,AnhNhanVien, DienThoai, DiaChi, Email, MatKhau, QuyenTruyCap)
VALUES
(N'Lê Văn Tiến','avatar.png','0338203413',N'Phú Yên', 'tien.lv.63cntt@ntu.edu.vn', '12345a', N'Admin'), -- tài khoản admin của hệ thống
(N'Nguyễn Văn E','avatar.png','0338203414',N'Phú Yên', 'nguyenvane@company.com', 'matkhauE', N'Nhân viên bán hàng'),
(N'Trần Thị F','avatar.png','0338203415',N'Phú Yên', 'tranthif@company.com', 'matkhauF', N'Nhân viên bán hàng');

-- chèn dữ liệu vào bảng hóa đơn
INSERT INTO HoaDon (TenHoaDon,NgayDat, NgayGiao, MaKhachHang, MaNhanVien)
VALUES
(N'Đơn hàng - 111','2023-01-15 10:30:00', '2023-01-18 14:45:00', 1, 1),
(N'Đơn hàng - 112','2023-02-10 11:15:00', NULL, 2, 1),
(N'Đơn hàng - 113','2023-02-20 13:20:00', '2023-02-22 16:30:00', 3, 2);

-- chèn dữ liệu vào bảng chi tiết hóa đơn
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia)
VALUES
(1, 1, 2, 8000000),
(2, 2, 1, 20000000), 
(3, 3, 1, 7000000); 

