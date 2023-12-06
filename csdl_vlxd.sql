create database VLXD
use VLXD
go

create table LoaiHang(
	MaLoai char(10) primary key,
	TenLoai nvarchar(20),
	Flag int
)
create table HangHoa(
	MaHH char(10) primary key,
	TenHH nvarchar(30),
	MaLoai char(10),
	DonVi nvarchar(10),
	constraint fk_HangHoa_LoaiHang foreign key (MaLoai) references LoaiHang(MaLoai)
)
create table Kho(
	MaKho char(10) primary key,
	MaHH char(10),
	SoLuong int,
	constraint fk_Kho_HangHoa foreign key (MaHH) references HangHoa(MaHH)
)
create table KhachHang(
	MaKH char(10) primary key,
	TenKH nvarchar(30),
	DiaChi nvarchar(20),
	SDT varchar(20),
)
create table NhanVien(
	MaNV char(10) primary key,
	TenNV nvarchar(30),
	GioiTinh nvarchar(10),
	NgaySinh date,
	DiaChi nvarchar(30),
	SDT varchar(20),
)
create table PhieuXuat(
	MaHDXuat char(10) primary key,
	MaKH char(10),
	MaNV char(10),
	NgayXuat date,
	constraint fk_PhieuXuat_KhachHang foreign key (MaKH) references KhachHang(MaKH),
	constraint fk_PhieuXuat_NhanVien foreign key (MaNV) references NhanVien(MaNV)
)
create table ChiTietPhieuXuat(
	SoPX int primary key,
	MaKho char(10),
	MaHDXuat char(10),
	SLXuat int,
	DonGiaXuat float,
	constraint fk_CT_PhieuXuat_PX foreign key (MaHDXuat) references PhieuXuat(MaHDXuat),
	constraint fk_CT_PhieuXuat_Kho foreign key (MaKho) references Kho(MaKho)
)
create table NhaCC(
	MaNCC char(10) primary key,
	TenNCC nvarchar(30),
	DiaChi nvarchar(20),
	SDT varchar(20),
)
create table PhieuNhap(
	MaHDNhap char(10) primary key,
	MaNCC char(10),
	MaNV char(10),
	NgayNhap date,
	constraint fk_PhieuNhap_NhaCC foreign key (MaNCC) references NhaCC(MaNCC),
	constraint fk_PhieuNhap_NhanVien foreign key (MaNV) references NhanVien(MaNV)
)
create table ChiTietPhieuNhap(
	SoPN int primary key,
	MaHH char(10),
	MaHDNhap char(10),
	SLNhap int,
	DonGiaNhap float,
	constraint fk_CT_PhieuXuat_PN foreign key (MaHDNhap) references PhieuNhap(MaHDNhap),
	constraint fk_CT_PhieuXuat_HangHoa foreign key (MaHH) references HangHoa(MaHH)
)
create table NguoiDung(
	TenND varchar(20) primary key,
	MatKhau varchar(20),
	Loai int,
)
create table NguoiDung_NhanVien(
	ID int primary key,
	TenND varchar(20),
	MaNV char(10),
	constraint fk_NguoiDung_NhanVien foreign key (MaNV) references NhanVien(MaNV),
	constraint fk_NDNV_NguoiDung foreign key (TenND) references NguoiDung(TenND)
)



INSERT INTO LoaiHang
VALUES
    (N'LH001', N'Đá xây dựng', 1),
    (N'LH002', N'Cát xây dựng', 1),
    (N'LH003', N'Sắt thép', 1),
    (N'LH004', N'Gạch xây', 1),
    (N'LH005', N'Xi măng', 1);


INSERT INTO HangHoa 
VALUES
    (N'HH001', N'Đá granite', N'LH001', N'Mét khối'),
    (N'HH002', N'Cát xây', N'LH002', N'Mét khối'),
    (N'HH003', N'Sắt hộp', N'LH003', N'Thanh'),
    (N'HH004', N'Gạch ceramic', N'LH004', N'Cái'),
    (N'HH005', N'Cement X', N'LH005', N'Bao');


INSERT INTO Kho
VALUES
    (N'K001', N'HH001', 100),
    (N'K002', N'HH002', 150),
    (N'K003', N'HH003', 200),
    (N'K004', N'HH004', 80),
    (N'K005', N'HH005', 120);


INSERT INTO KhachHang 
VALUES
    (N'KH001', N'Nguyễn Văn A', N'Hà Nội', '0123456789'),
    (N'KH002', N'Trần Thị B', N'Đà Nẵng', '0987654321'),
    (N'KH003', N'Lê Văn C', N'Hải Phòng', '0365478912'),
    (N'KH004', N'Phạm Thị D', N'Vũng Tàu', '0987123456'),
    (N'KH005', N'Hồ Văn E', N'TPHCM', '0765432190');


INSERT INTO NhanVien
VALUES
    (N'NV001', N'Nguyễn Văn Nam', N'Nam', '1990-05-15', N'Vũng Tàu', '0123456789'),
    (N'NV002', N'Trần Thị Nữ', N'Nữ', '1995-08-20', N'Cà Mau', '0987654321'),
    (N'NV003', N'Lê Văn Đức', N'Nam', '1985-10-10', N'Đà Lạt', '0365478912'),
    (N'NV004', N'Phạm Thị Hương', N'Nữ', '1988-03-25', N'TPHCM', '0987123456'),
    (N'NV005', N'Hồ Văn Tùng', N'Nam', '1992-12-01', N'Hà Nội', '0765432190');


INSERT INTO PhieuXuat
VALUES
    (N'HDX001', N'KH001', N'NV001', '2023-11-01'),
    (N'HDX002', N'KH002', N'NV002', '2023-11-02'),
    (N'HDX003', N'KH003', N'NV003', '2023-11-03'),
    (N'HDX004', N'KH004', N'NV004', '2023-11-04'),
    (N'HDX005', N'KH005', N'NV005', '2023-11-05');


INSERT INTO ChiTietPhieuXuat
VALUES
    (1, N'K001', N'HDX001', 10, 100000),
    (2, N'K002', N'HDX002', 20, 80000),
    (3, N'K003', N'HDX003', 15, 120000),
    (4, N'K004', N'HDX004', 12, 150000),
    (5, N'K005', N'HDX005', 18, 90000);


INSERT INTO NhaCC
VALUES
    (N'NCC001', N'Công ty VLXD Sài Gòn', N'TP.HCM', '0123456789'),
    (N'NCC002', N'Công ty VLXD An Phát', N'Thái Nguyên', '0987654321'),
    (N'NCC003', N'Công ty VLXD Tân Thuận', N'Kon Tum', '0365478912'),
    (N'NCC004', N'Công ty VLXD Long Hoa', N'Lâm Đồng', '0987123456'),
    (N'NCC005', N'Công ty VLXD Minh Thành', N'Huế', '0765432190');


INSERT INTO PhieuNhap
VALUES
    (N'HDN001', N'NCC001', N'NV001', '2023-11-01'),
    (N'HDN002', N'NCC002', N'NV002', '2023-11-02'),
    (N'HDN003', N'NCC003', N'NV003', '2023-11-03'),
    (N'HDN004', N'NCC004', N'NV004', '2023-11-04'),
    (N'HDN005', N'NCC005', N'NV005', '2023-11-05');

INSERT INTO ChiTietPhieuNhap
VALUES
    (1, N'HH001', N'HDN001', 50, 90000),
    (2, N'HH002', N'HDN002', 70, 75000),
    (3, N'HH003', N'HDN003', 60, 120000),
    (4, N'HH004', N'HDN004', 40, 110000),
    (5, N'HH005', N'HDN005', 80, 80000);


INSERT INTO NguoiDung
VALUES
    (N'User1', 'user123', 1),
    (N'Admin1', 'admin123', 2),
    (N'User2', 'user123', 1),
    (N'Admin2', 'admin123', 2),
    (N'User3', 'user123', 1);


INSERT INTO NguoiDung_NhanVien
VALUES
    (1, N'User1', N'NV001'),
    (2, N'User2', N'NV002'),
    (3, N'User3', N'NV003'),
    (4, N'User4', N'NV004'),
    (5, N'User5', N'NV005');




