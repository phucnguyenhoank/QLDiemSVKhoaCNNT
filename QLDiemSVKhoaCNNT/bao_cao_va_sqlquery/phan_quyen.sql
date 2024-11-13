use master;

CREATE LOGIN adsv1 WITH PASSWORD = '1234';
CREATE LOGIN adgv1 WITH PASSWORD = '1234';
CREATE LOGIN admh1 WITH PASSWORD = '1234';
CREATE LOGIN adlh1 WITH PASSWORD = '1234';
CREATE LOGIN mainad1 WITH PASSWORD = '1234';

use QLDiemSVKhoaCNTT;

CREATE USER adsv1 FOR LOGIN adsv1;
CREATE USER adgv1 FOR LOGIN adgv1;
CREATE USER admh1 FOR LOGIN admh1;
CREATE USER adlh1 FOR LOGIN adlh1;
CREATE USER mainad1 FOR LOGIN mainad1;

CREATE ROLE AdminSVRole;
CREATE ROLE AdminGVRole;
CREATE ROLE AdminMHRole;
CREATE ROLE AdminLHRole;
CREATE ROLE MainAdminRole;

-- Thêm User vào Role
ALTER ROLE AdminSVRole ADD MEMBER adsv1;
ALTER ROLE AdminGVRole ADD MEMBER adgv1;
ALTER ROLE AdminMHRole ADD MEMBER admh1;
ALTER ROLE AdminLHRole ADD MEMBER adlh1;
ALTER ROLE MainAdminRole ADD MEMBER mainad1;

-- admin sinh vien
GRANT SELECT ON dbo.vw_SinhVien TO AdminSVRole;
GRANT SELECT ON dbo.vw_XepHangSinhVienBangDiemTBTichLuy TO AdminSVRole;
GRANT SELECT ON dbo.vw_LopHoc TO AdminSVRole;
GRANT SELECT ON dbo.fn_LayDanhSachSinhVienTrongLop TO AdminSVRole;
GRANT SELECT ON dbo.fn_LayBangDiemSinhVien TO AdminSVRole;
GRANT EXECUTE ON dbo.fn_DemSoLuongLopDangKy TO AdminSVRole;
GRANT EXECUTE ON dbo.proc_XemThoiKhoaBieuSinhVien TO AdminSVRole;
GRANT EXECUTE ON dbo.proc_ThemSinhVien TO AdminSVRole;
GRANT EXECUTE ON dbo.proc_XoaSinhVien TO AdminSVRole;
GRANT EXECUTE ON dbo.proc_SuaSinhVien TO AdminSVRole;
GRANT EXECUTE ON dbo.proc_CapNhatDiemSinhVien TO AdminSVRole;
GRANT EXECUTE ON dbo.fn_TinhDiemTrungBinh TO AdminSVRole;
GRANT EXECUTE ON dbo.fn_TinhDiemTrungBinhTichLuy TO AdminSVRole;
GRANT EXECUTE ON dbo.fn_SoTinChiDaHoanThanh TO AdminSVRole;

-- admin giang vien
GRANT SELECT ON dbo.vw_GiangVien TO AdminGVRole;
GRANT EXECUTE ON dbo.proc_XoaGiangVien TO AdminGVRole;
GRANT EXECUTE ON dbo.proc_ThemGiangVien TO AdminGVRole;
GRANT EXECUTE ON dbo.proc_SuaGiangVien TO AdminGVRole;
GRANT EXECUTE ON dbo.fn_KiemTraQuaMon TO AdminGVRole;
GRANT EXECUTE ON dbo.fn_XemHocLucSinhVien TO AdminGVRole;

-- admin mon hoc
GRANT SELECT ON dbo.vw_MonHoc TO AdminMHRole;
GRANT EXECUTE ON dbo.proc_ThemMonHoc TO AdminMHRole;
GRANT EXECUTE ON dbo.proc_XoaMonHoc TO AdminMHRole;
GRANT EXECUTE ON dbo.proc_SuaMonHoc TO AdminMHRole;

-- admin lop hoc
GRANT SELECT ON dbo.vw_GiangVien TO AdminLHRole;
GRANT SELECT ON dbo.vw_MonHoc TO AdminLHRole;
GRANT SELECT ON dbo.vw_LopHoc TO AdminLHRole;
GRANT SELECT ON dbo.vw_SinhVien TO AdminLHRole;
GRANT SELECT ON dbo.PhongHoc TO AdminLHRole;
GRANT SELECT ON dbo.vw_LopHocConTrong TO AdminLHRole;
GRANT SELECT ON dbo.vw_LopHocGiangVienPhuTrach TO AdminLHRole;
GRANT SELECT ON dbo.fn_LayDanhSachSinhVienTrongLop TO AdminLHRole;
GRANT EXECUTE ON proc_ThemLopHoc TO AdminLHRole;
GRANT EXECUTE ON proc_XoaLopHoc TO AdminLHRole;
GRANT EXECUTE ON proc_SuaLopHoc TO AdminLHRole;
GRANT EXECUTE ON proc_DangKySinhVienVaoLop TO AdminLHRole;
GRANT EXECUTE ON proc_XemKetQuaHocTapCuaLop TO AdminLHRole;
GRANT EXECUTE ON dbo.fn_DemSoLopGiangVienPhuTrach TO AdminLHRole;
GRANT EXECUTE ON dbo.fn_DemSoLuongSinhVienCuaLop TO AdminLHRole;
GRANT EXECUTE ON dbo.fn_TinhPhanTramQuaMon TO AdminLHRole;

-- main admin
ALTER ROLE db_owner ADD MEMBER MainAdminRole;







