CREATE LOGIN sv1 WITH PASSWORD = '1234';
CREATE LOGIN gv1 WITH PASSWORD = '1234';
CREATE LOGIN ad1 WITH PASSWORD = '1234';

use QLDiemSVKhoaCNTT;

CREATE USER sv1 FOR LOGIN sv1;
CREATE USER gv1 FOR LOGIN gv1;
CREATE USER ad1 FOR LOGIN ad1;

CREATE ROLE SinhVienRole;
CREATE ROLE GiangVienRole;
CREATE ROLE AdminRole;

-- SinhVien
GRANT SELECT ON dbo.vw_MonHoc TO SinhVienRole;
GRANT SELECT ON dbo.vw_LopHoc TO SinhVienRole;
GRANT SELECT ON dbo.vw_LopHocConTrong TO SinhVienRole;
GRANT EXECUTE ON dbo.proc_DangKySinhVienVaoLop TO SinhVienRole;
GRANT EXECUTE ON dbo.fn_XemHocLucSinhVien TO SinhVienRole;
GRANT EXECUTE ON dbo.fn_SoTinChiDaHoanThanh TO SinhVienRole;
GRANT SELECT ON dbo.DangKy TO SinhVienRole;
GRANT SELECT ON dbo.LopHoc TO SinhVienRole;
GRANT SELECT ON dbo.MonHoc TO SinhVienRole;
GRANT SELECT ON dbo.fn_LayBangDiemSinhVien TO SinhVienRole;
GRANT EXECUTE ON dbo.fn_TinhDiemTrungBinh TO SinhVienRole;
GRANT EXECUTE ON dbo.fn_TinhDiemTrungBinhTichLuy TO SinhVienRole;



-- GiangVien
-- add SinhVienRole
GRANT SELECT ON dbo.vw_MonHoc TO GiangVienRole;
GRANT SELECT ON dbo.vw_LopHoc TO GiangVienRole;
GRANT SELECT ON dbo.vw_LopHocConTrong TO GiangVienRole;
GRANT EXECUTE ON dbo.proc_DangKySinhVienVaoLop TO GiangVienRole;
GRANT EXECUTE ON dbo.fn_XemHocLucSinhVien TO GiangVienRole;
GRANT EXECUTE ON dbo.fn_SoTinChiDaHoanThanh TO GiangVienRole;
GRANT SELECT ON dbo.DangKy TO GiangVienRole;
GRANT SELECT ON dbo.LopHoc TO GiangVienRole;
GRANT SELECT ON dbo.MonHoc TO GiangVienRole;
GRANT SELECT ON dbo.fn_LayBangDiemSinhVien TO GiangVienRole;
GRANT EXECUTE ON dbo.fn_TinhDiemTrungBinh TO GiangVienRole;
GRANT EXECUTE ON dbo.fn_TinhDiemTrungBinhTichLuy TO GiangVienRole;

-- add more for GiangVien
GRANT SELECT ON dbo.vw_SinhVien TO GiangVienRole;
GRANT SELECT ON dbo.vw_LopHocGiangVienPhuTrach TO GiangVienRole;
GRANT SELECT ON dbo.vw_DiemTrungBinhSinhVien TO GiangVienRole;
GRANT SELECT ON dbo.vw_DiemTrungBinhTichLuySinhVien TO GiangVienRole;
GRANT SELECT ON dbo.vw_XepHangSinhVienBangDiemTBTichLuy TO GiangVienRole;
GRANT EXECUTE ON dbo.proc_ThemSinhVien TO GiangVienRole;
GRANT EXECUTE ON dbo.proc_CapNhatDiemSinhVien TO GiangVienRole;
GRANT EXECUTE ON dbo.proc_XemKetQuaHocTapCuaLop TO GiangVienRole;
GRANT EXECUTE ON dbo.fn_KiemTraQuaMon TO GiangVienRole;
GRANT EXECUTE ON dbo.fn_DemSoLuongSinhVienCuaLop TO GiangVienRole;
GRANT EXECUTE ON dbo.fn_TinhPhanTramQuaMon TO GiangVienRole;
GRANT EXECUTE ON dbo.fn_DemSoLopGiangVienPhuTrach TO GiangVienRole;
GRANT SELECT ON dbo.SinhVien TO GiangVienRole;
GRANT SELECT ON dbo.DangKy TO GiangVienRole;
GRANT SELECT ON dbo.fn_LayDanhSachSinhVienTrongLop TO GiangVienRole;
GRANT EXECUTE ON dbo.fn_KiemTraQuaMon TO GiangVienRole;
GRANT EXECUTE ON dbo.fn_KiemTraQuaMon TO GiangVienRole;
GRANT EXECUTE ON dbo.fn_KiemTraQuaMon TO GiangVienRole;


-- Admin
ALTER ROLE db_owner ADD MEMBER AdminRole;

/*
GRANT SELECT ON dbo.vw_GiangVien TO AdminRole;
GRANT EXECUTE ON dbo.proc_ThemGiangVien TO AdminRole;
GRANT EXECUTE ON dbo.proc_ThemMonHoc TO AdminRole;
GRANT EXECUTE ON dbo.proc_ThemLopHoc TO AdminRole;
GRANT EXECUTE ON dbo.proc_XoaSinhVien TO AdminRole;
GRANT EXECUTE ON dbo.proc_XoaGiangVien TO AdminRole;
GRANT EXECUTE ON dbo.proc_XoaMonHoc TO AdminRole;
GRANT EXECUTE ON dbo.proc_XoaLopHoc TO AdminRole;
GRANT EXECUTE ON dbo.proc_SuaSinhVien TO AdminRole;
GRANT EXECUTE ON dbo.proc_SuaGiangVien TO AdminRole;
GRANT EXECUTE ON dbo.proc_SuaMonHoc TO AdminRole;
GRANT EXECUTE ON dbo.proc_SuaLopHoc TO AdminRole;
*/

-- Thêm User vào Role
ALTER ROLE SinhVienRole ADD MEMBER sv1;
ALTER ROLE GiangVienRole ADD MEMBER gv1;
ALTER ROLE AdminRole ADD MEMBER ad1;





