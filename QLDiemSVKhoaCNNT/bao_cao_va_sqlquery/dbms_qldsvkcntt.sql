USE master;
go
ALTER DATABASE QLDiemSVKhoaCNTT SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
go
DROP DATABASE QLDiemSVKhoaCNTT;


create database QLDiemSVKhoaCNTT;
go
use QLDiemSVKhoaCNTT;
go

-- Bảng SinhVien
CREATE TABLE SinhVien (
    MaSinhVien INT,
    HoVaTen NVARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    SoDienThoai VARCHAR(20) NOT NULL UNIQUE,
    QueQuan NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_SinhVien PRIMARY KEY (MaSinhVien)
);

-- Bảng MonHoc
CREATE TABLE MonHoc (
    MaMonHoc INT,
    TenMonHoc NVARCHAR(100) NOT NULL,
    SoTinChi TINYINT NOT NULL,
    CONSTRAINT PK_MonHoc PRIMARY KEY (MaMonHoc),
    CONSTRAINT CHK_SoTinChiHopLe CHECK (SoTinChi >= 1 AND SoTinChi <= 5)
);

-- Bảng GiangVien
CREATE TABLE GiangVien (
    MaGiangVien INT,
    HoVaTen NVARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    SoDienThoai VARCHAR(20) NOT NULL UNIQUE,
    CONSTRAINT PK_GiangVien PRIMARY KEY (MaGiangVien)
);

-- Bảng PhongHoc
CREATE TABLE PhongHoc (
    MaPhongHoc INT,
    SucChua TINYINT NOT NULL,
    CONSTRAINT PK_PhongHoc PRIMARY KEY (MaPhongHoc),
    CONSTRAINT CHK_SucChuaHopLe CHECK (SucChua >= 10 AND SucChua <= 100)
);

-- Bảng LopHoc
CREATE TABLE LopHoc (
    MaLopHoc INT,
    Thu TINYINT NOT NULL,
    TietBatDau TINYINT NOT NULL,
    TietKetThuc TINYINT NOT NULL,
    MaPhongHoc INT NOT NULL,
    MaGiangVien INT NOT NULL,
    MaMonHoc INT NOT NULL,
    CONSTRAINT PK_LopHoc PRIMARY KEY (MaLopHoc),
    CONSTRAINT CHK_ThuHopLe CHECK (Thu >= 1 AND Thu <= 7),
    CONSTRAINT CHK_TietHopLe CHECK (TietBatDau >= 1 AND TietBatDau <= 12 AND TietKetThuc >= 1 AND TietKetThuc <= 12 AND TietBatDau <= TietKetThuc),
    CONSTRAINT FK_LopHoc_PhongHoc FOREIGN KEY (MaPhongHoc) REFERENCES PhongHoc(MaPhongHoc) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT FK_LopHoc_GiangVien FOREIGN KEY (MaGiangVien) REFERENCES GiangVien(MaGiangVien) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT FK_LopHoc_MonHoc FOREIGN KEY (MaMonHoc) REFERENCES MonHoc(MaMonHoc) ON UPDATE CASCADE
);

-- Bảng DangKy
CREATE TABLE DangKy (
    MaSinhVien INT NOT NULL,
    MaLopHoc INT NOT NULL,
    DiemQuaTrinh DECIMAL(4, 2),
    DiemCuoiKy DECIMAL(4, 2),
    CONSTRAINT PK_DangKy PRIMARY KEY (MaSinhVien, MaLopHoc),
    CONSTRAINT CHK_DiemQuaTrinhHopLe CHECK (DiemQuaTrinh >= 0 AND DiemQuaTrinh <= 10),
    CONSTRAINT CHK_DiemCuoiKyHopLe CHECK (DiemCuoiKy >= 0 AND DiemCuoiKy <= 10),
    CONSTRAINT FK_DangKy_SinhVien FOREIGN KEY (MaSinhVien) REFERENCES SinhVien(MaSinhVien) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT FK_DangKy_LopHoc FOREIGN KEY (MaLopHoc) REFERENCES LopHoc(MaLopHoc) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE Account (
    AccUsername VARCHAR(50), 
    AccPassword VARCHAR(50) NOT NULL, 
    AccRole VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Account PRIMARY KEY (AccUsername)
);

-- TRIGGER: 4 LOẠI
/*
trg_ThemSinhVien, trg_ThemGiangVien, trg_ThemMonHoc, trg_TruocKhiSuaDangKy.
trg_ThemLopHoc.
trg_ThemDangKy.
trg_KiemTraSucChua.
trg_SauKhiSuaDangKy* CÁI THỨ 5 NÀY CHƯA HOÀN THIỆN NÊN CHỈ CÓ 4
*/
GO
CREATE TRIGGER trg_ThayViThemSinhVien ON SinhVien
INSTEAD OF INSERT
AS
BEGIN
    DECLARE 
        @MaSinhVien INT, 
        @HoVaTen NVARCHAR(100), 
        @Email VARCHAR(100), 
        @SoDienThoai VARCHAR(20), 
        @QueQuan NVARCHAR(100);

    -- Lấy dữ liệu từ bảng inserted
    SELECT 
        @MaSinhVien = i.MaSinhVien,
        @HoVaTen = i.HoVaTen,
        @Email = i.Email,
        @SoDienThoai = i.SoDienThoai,
        @QueQuan = i.QueQuan
    FROM inserted i;

    -- Kiểm tra nếu mã sinh viên đã tồn tại
    IF EXISTS (
        SELECT 1
        FROM SinhVien sv
        WHERE sv.MaSinhVien = @MaSinhVien
    )
    BEGIN
        RAISERROR('Mã sinh viên %d đã tồn tại.', 16, 1, @MaSinhVien);
        RETURN;
    END;

    -- Kiểm tra điều kiện rỗng và định dạng
    IF @HoVaTen = N''
    BEGIN
        RAISERROR('Họ và tên không được để trống.', 16, 1);
        RETURN;
    END;

    IF @SoDienThoai = ''
    BEGIN
        RAISERROR('Số điện thoại không được để trống.', 16, 1);
        RETURN;
    END;

    IF @QueQuan = N''
    BEGIN
        RAISERROR('Quê quán không được để trống.', 16, 1);
        RETURN;
    END;

    IF @Email NOT LIKE '_%@_%._%'
    BEGIN
        RAISERROR('Email không đúng định dạng.', 16, 1);
        RETURN;
    END;

    IF @SoDienThoai LIKE '%[^0-9]%'
    BEGIN
        RAISERROR('Số điện thoại không đúng định dạng.', 16, 1);
        RETURN;
    END;

    -- Kiểm tra trùng lặp
    IF EXISTS (SELECT 1 FROM SinhVien WHERE Email = @Email)
    BEGIN
        RAISERROR(N'Email %s đã được sử dụng.', 16, 1, @Email);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM SinhVien WHERE SoDienThoai = @SoDienThoai)
    BEGIN
        RAISERROR(N'Số điện thoại %s đã được sử dụng.', 16, 1, @SoDienThoai);
        RETURN;
    END

    -- Chèn dữ liệu hợp lệ vào bảng SinhVien
    INSERT INTO SinhVien (MaSinhVien, HoVaTen, Email, SoDienThoai, QueQuan)
    VALUES (@MaSinhVien, @HoVaTen, @Email, @SoDienThoai, @QueQuan);
END;


GO
CREATE TRIGGER trg_ThayViThemGiangVien
ON GiangVien
INSTEAD OF INSERT
AS
BEGIN
    DECLARE 
        @MaGiangVien INT, 
        @HoVaTen NVARCHAR(100), 
        @Email VARCHAR(100), 
        @SoDienThoai VARCHAR(20);

    -- Lấy dữ liệu từ bảng inserted
    SELECT 
        @MaGiangVien = i.MaGiangVien,
        @HoVaTen = i.HoVaTen,
        @Email = i.Email,
        @SoDienThoai = i.SoDienThoai
    FROM inserted i;

    -- Kiểm tra nếu mã giảng viên đã tồn tại
    IF EXISTS (
        SELECT 1
        FROM GiangVien gv
        WHERE gv.MaGiangVien = @MaGiangVien
    )
    BEGIN
        RAISERROR('Mã giảng viên %d đã tồn tại.', 16, 1, @MaGiangVien);
        RETURN;
    END;

    -- Kiểm tra điều kiện rỗng và định dạng
    IF @HoVaTen = N'' 
    BEGIN
        RAISERROR('Họ và tên không được để trống.', 16, 1);
        RETURN;
    END;

    IF @SoDienThoai = ''
    BEGIN
        RAISERROR('Số điện thoại không được để trống.', 16, 1);
        RETURN;
    END;

    IF @Email NOT LIKE '_%@_%._%'
    BEGIN
        RAISERROR('Email không đúng định dạng.', 16, 1);
        RETURN;
    END;
    
    IF @SoDienThoai LIKE '%[^0-9]%'
    BEGIN
        RAISERROR('Số điện thoại không đúng định dạng.', 16, 1);
        RETURN;
    END;

    -- Kiểm tra trùng lặp
    IF EXISTS (SELECT 1 FROM GiangVien WHERE Email = @Email)
    BEGIN
        RAISERROR(N'Email %s đã được sử dụng.', 16, 1, @Email);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM GiangVien WHERE SoDienThoai = @SoDienThoai)
    BEGIN
        RAISERROR(N'Số điện thoại %s đã được sử dụng.', 16, 1, @SoDienThoai);
        RETURN;
    END

    -- Chèn dữ liệu hợp lệ vào bảng GiangVien
    INSERT INTO GiangVien (MaGiangVien, HoVaTen, Email, SoDienThoai)
    VALUES (@MaGiangVien, @HoVaTen, @Email, @SoDienThoai);
END;

GO
CREATE TRIGGER trg_ThayViThemMonHoc
ON MonHoc
INSTEAD OF INSERT
AS
BEGIN
    DECLARE 
        @MaMonHoc INT, 
        @TenMonHoc NVARCHAR(100), 
        @SoTinChi TINYINT;

    -- Lấy dữ liệu từ bảng inserted
    SELECT 
        @MaMonHoc = i.MaMonHoc,
        @TenMonHoc = i.TenMonHoc,
        @SoTinChi = i.SoTinChi
    FROM inserted i;

    -- Kiểm tra nếu mã môn học đã tồn tại
    IF EXISTS (
        SELECT 1
        FROM MonHoc mh
        WHERE mh.MaMonHoc = @MaMonHoc
    )
    BEGIN
        RAISERROR('Mã môn học %d đã tồn tại.', 16, 1, @MaMonHoc);
        RETURN;
    END;

    -- Kiểm tra điều kiện hợp lệ cho tên môn học và số tín chỉ
    IF @TenMonHoc = N''
    BEGIN
        RAISERROR('Tên môn học không được để trống.', 16, 1);
        RETURN;
    END;

    -- Kiểm tra điều kiện hợp lệ cho tên môn học và số tín chỉ
    IF @SoTinChi < 1 
       OR @SoTinChi > 5
    BEGIN
        RAISERROR('Số tín chỉ phải từ 1 đến 5.', 16, 1);
        RETURN;
    END;

    -- Chèn dữ liệu hợp lệ vào bảng MonHoc
    INSERT INTO MonHoc (MaMonHoc, TenMonHoc, SoTinChi)
    VALUES (@MaMonHoc, @TenMonHoc, @SoTinChi);
END;

GO
CREATE TRIGGER trg_ThayViThemLopHoc ON LopHoc
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @MaLopHoc INT, @Thu TINYINT, @TietBatDau TINYINT, @TietKetThuc TINYINT, @MaPhongHoc INT;
    SELECT 
        @MaLopHoc = i.MaLopHoc,
        @Thu = i.Thu, 
        @TietBatDau = i.TietBatDau, 
        @TietKetThuc = i.TietKetThuc, 
        @MaPhongHoc = i.MaPhongHoc
    FROM inserted i;

    -- Kiểm tra trùng mã lớp học
    IF EXISTS (
        SELECT 1
        FROM LopHoc lh
        WHERE lh.MaLopHoc = @MaLopHoc
    )
    BEGIN
        RAISERROR ('Mã lớp học %d đã tồn tại.', 16, 1, @MaLopHoc);
        RETURN;
    END

    -- Kiểm tra điều kiện hợp lệ cho thứ
    IF @Thu < 1 OR @Thu > 7
    BEGIN
        RAISERROR('Thứ phải từ 1 đến 7.', 16, 1);
        RETURN;
    END;

    -- Kiểm tra điều kiện hợp lệ cho tiết học
    IF @TietBatDau < 1 OR @TietBatDau > 12
       OR @TietKetThuc < 1 OR @TietKetThuc > 12
    BEGIN
        RAISERROR('Tiết bắt đầu và kết thúc phải từ 1 đến 12.', 16, 1);
        RETURN;
    END;

    IF @TietBatDau > @TietKetThuc
    BEGIN
        RAISERROR('Tiết bắt đầu không được lớn hơn tiết kết thúc.', 16, 1);
        RETURN;
    END;

    -- Kiểm tra trùng lịch học với lớp học khác
    DECLARE @MaLopHocTrung INT;
    SELECT @MaLopHocTrung = lh.MaLopHoc
    FROM LopHoc lh
    WHERE lh.MaLopHoc != @MaLopHoc AND lh.MaPhongHoc = @MaPhongHoc AND lh.Thu = @Thu AND
    (
        (@TietKetThuc BETWEEN lh.TietBatDau AND lh.TietKetThuc)OR
        (@TietBatDau BETWEEN lh.TietBatDau AND lh.TietKetThuc)
    )
    IF @MaLopHocTrung IS NOT NULL
    BEGIN
        RAISERROR ('Lớp học %d cần được thêm bị trùng lịch với lớp học %d cùng phòng.', 16, 1, @MaLopHoc, @MaLopHocTrung);
        RETURN;
    END

    -- Chèn lớp học mới
    INSERT INTO LopHoc (MaLopHoc, Thu, TietBatDau, TietKetThuc, MaPhongHoc, MaGiangVien, MaMonHoc)
    SELECT i.MaLopHoc, i.Thu, i.TietBatDau, i.TietKetThuc, i.MaPhongHoc, i.MaGiangVien, i.MaMonHoc
    FROM inserted i;
END;

GO
CREATE TRIGGER trg_ThayViThemDangKy ON DangKy
INSTEAD OF INSERT
AS
BEGIN
    -- Kiểm tra xem sinh viên có tồn tại không
    IF NOT EXISTS (
        SELECT 1 
        FROM SinhVien sv
        JOIN inserted i ON sv.MaSinhVien = i.MaSinhVien
    )
    BEGIN
        RAISERROR(N'Không tồn tại mã sinh viên muốn chèn.', 16, 1);
        RETURN;
    END

    -- Kiểm tra xem lớp học có tồn tại không
    IF NOT EXISTS (
        SELECT 1 
        FROM LopHoc lh
        JOIN inserted i ON lh.MaLopHoc = i.MaLopHoc)
    BEGIN
        RAISERROR(N'Không tồn tại mã lớp học muốn chèn.', 16, 1);
        RETURN;
    END

    -- Lấy mã sinh viên, mã lớp học, và mã môn học sinh viên muốn đăng ký
    DECLARE @MaSinhVien INT, @MaLopHoc INT, @MaMonHocSinhVienDangKy INT;
    SELECT @MaSinhVien = i.MaSinhVien, @MaLopHoc = lh.MaLopHoc, @MaMonHocSinhVienDangKy = lh.MaMonHoc
    FROM inserted i
    INNER JOIN LopHoc lh ON i.MaLopHoc = lh.MaLopHoc;

    -- Tìm trong những lớp học mà sinh viên đã đăng ký, kiểm tra có lớp học nào đang dạy môn mà sinh viên muốn đăng ký hay không
    DECLARE @MaLopHocBiTrung INT;
    SELECT @MaLopHocBiTrung = dk.MaLopHoc
    FROM DangKy dk
    INNER JOIN LopHoc lh ON dk.MaLopHoc = lh.MaLopHoc
    WHERE dk.MaSinhVien = @MaSinhVien AND lh.MaMonHoc = @MaMonHocSinhVienDangKy;
    
    -- Kiểm tra trùng môn
    -- Nếu tìm thấy lớp học bị trùng, ném lỗi
    IF @MaLopHocBiTrung IS NOT NULL
    BEGIN
        RAISERROR ('Sinh viên (MaSinhVien = %d) muốn đăng ký môn học (MaMonHoc = %d), nhưng đã bị trùng với lớp học (MaLopHoc = %d).', 16, 1, @MaSinhVien, @MaMonHocSinhVienDangKy, @MaLopHocBiTrung);
        RETURN;
    END

    -- Chèn dữ liệu nếu không có lỗi
    INSERT INTO DangKy (MaSinhVien, MaLopHoc, DiemQuaTrinh, DiemCuoiKy)
    SELECT i.MaSinhVien, i.MaLopHoc, i.DiemQuaTrinh, i.DiemCuoiKy
    FROM inserted i;
END;

GO
CREATE TRIGGER trg_SauKhiThemDangKy ON DangKy
AFTER INSERT
AS
BEGIN
    -- Nếu như phòng học bị vượt quá sức chứa thì sẽ hủy việc đăng ký vừa thực hiện
    DECLARE @MaLopHoc INT, @SoLuongSinhVien INT, @SucChua INT;

    SELECT @MaLopHoc = i.MaLopHoc, @SucChua = ph.SucChua
    FROM inserted i
	INNER JOIN LopHoc lh ON i.MaLopHoc = lh.MaLopHoc
	INNER JOIN PhongHoc ph on lh.MaPhongHoc = ph.MaPhongHoc

	SELECT @SoLuongSinhVien = COUNT(dk.MaSinhVien)
    FROM DangKy dk
    WHERE dk.MaLopHoc = @MaLopHoc;

    IF @SoLuongSinhVien > @SucChua
    BEGIN
        RAISERROR ('Không thể đăng ký vì lớp học (MaLopHoc = %d) đã đạt sức chứa tối đa', 16, 1, @MaLopHoc);
        ROLLBACK TRANSACTION;
    END
END;

GO
CREATE TRIGGER trg_SauKhiSuaDangKy ON DangKy
AFTER UPDATE
AS
BEGIN
    DECLARE @MaSinhVien INT, @MaLopHoc INT, @DiemQuaTrinh DECIMAL(4, 2), @DiemCuoiKy DECIMAL(4, 2);
    -- Lấy dữ liệu từ bảng inserted
    SELECT 
       @MaSinhVien = i.MaSinhVien,
       @MaLopHoc = i.MaLopHoc,
       @DiemQuaTrinh = i.DiemQuaTrinh,
       @DiemCuoiKy = i.DiemCuoiKy
    FROM inserted i;

    DECLARE @MaMonHoc INT;
    SELECT @MaMonHoc = lh.MaMonHoc
    FROM DangKy dk
    JOIN LopHoc lh ON dk.MaLopHoc = lh.MaLopHoc
    WHERE lh.MaLopHoc = @MaLopHoc

    DECLARE @QuaMon INT;
    SELECT @QuaMon = dbo.fn_KiemTraQuaMon(@MaSinhVien, @MaMonHoc)

    -- Nếu sinh viên rớt môn thì gửi mail
    IF @QuaMon = 0
    BEGIN
        DECLARE @EmailSinhVien VARCHAR(100), @TenMonHoc NVARCHAR(100);
        -- Lấy thông tin email của sinh viên rớt môn
        SELECT @EmailSinhVien = sv.Email
        FROM SinhVien sv
        WHERE sv.MaSinhVien = @MaSinhVien

        -- Lấy thêm thông tin môn học bị rớt
        SELECT @TenMonHoc = mh.TenMonHoc
        FROM MonHoc mh
        WHERE mh.MaMonHoc = @MaMonHoc;

        DECLARE @EmailBody NVARCHAR(300);
        -- Tạo nội dung email trong biến @EmailBody
        SET @EmailBody = N'Dear Student,' + CHAR(13) + CHAR(10) +
            N'You have failed a class.' + CHAR(13) + CHAR(10) +
            N'Class ID: ' + CAST(@MaLopHoc AS NVARCHAR(10)) + CHAR(13) + CHAR(10) +
            N'Subject ID: ' + CAST(@MaMonHoc AS NVARCHAR(10)) + CHAR(13) + CHAR(10) +
            N'Subject Name: ' + @TenMonHoc + CHAR(13) + CHAR(10) +
            N'If you consider this a misunderstanding, please contact your advisor for more details.';

        -- Gọi hàm gửi email
        EXEC msdb.dbo.sp_send_dbmail 
            @profile_name = 'nhp_profile', 
            @recipients = @EmailSinhVien, 
            @subject = 'Notice of Failure', 
            @body = @EmailBody;
    END
END;

GO
-- Tạo view vw_SinhVien để truy xuất thông tin sinh viên từ bảng SinhVien.
-- View này bao gồm các trường: MaSinhVien, HoVaTen, Email, SoDienThoai và QueQuan.
CREATE VIEW vw_SinhVien AS
SELECT sv.MaSinhVien, sv.HoVaTen, sv.Email, sv.SoDienThoai, sv.QueQuan
FROM SinhVien sv

GO
CREATE VIEW vw_GiangVien AS
SELECT gv.MaGiangVien, gv.HoVaTen, gv.Email, gv.SoDienThoai
FROM GiangVien gv

GO
CREATE VIEW vw_MonHoc AS
SELECT mh.MaMonHoc, mh.TenMonHoc, mh.SoTinChi
FROM MonHoc mh

GO
CREATE VIEW vw_LopHoc AS
SELECT 
    MaLopHoc, 
    Thu, 
    TietBatDau, 
    TietKetThuc, 
    MaPhongHoc, 
    MaGiangVien, 
    MaMonHoc
FROM LopHoc;

GO
CREATE VIEW vw_LopHocGiangVienPhuTrach AS
SELECT 
    lh.MaLopHoc, 
    lh.Thu, 
    lh.TietBatDau, 
    lh.TietKetThuc, 
    lh.MaPhongHoc,
    lh.MaMonHoc, 
    gv.MaGiangVien, 
    gv.HoVaTen, 
    gv.Email, 
    gv.SoDienThoai
FROM LopHoc lh
INNER JOIN GiangVien gv ON lh.MaGiangVien = gv.MaGiangVien;

GO
CREATE VIEW vw_LopHocConTrong AS
SELECT
    lh.MaLopHoc,
    ph.MaPhongHoc,
    ph.SucChua,
    COUNT(dk.MaSinhVien) AS SoSinhVienDaDangKy,
    (ph.SucChua - COUNT(dk.MaSinhVien)) AS SoLuongConTrong
FROM LopHoc lh
INNER JOIN PhongHoc ph ON lh.MaPhongHoc = ph.MaPhongHoc
LEFT JOIN DangKy dk ON lh.MaLopHoc = dk.MaLopHoc
GROUP BY 
    lh.MaLopHoc, ph.MaPhongHoc, ph.SucChua
HAVING COUNT(dk.MaSinhVien) < ph.SucChua;

GO
CREATE VIEW vw_DiemTrungBinhSinhVien AS
SELECT 
    sv.MaSinhVien,
    sv.HoVaTen,
    AVG((dk.DiemQuaTrinh + dk.DiemCuoiKy) / 2.0) AS DiemTrungBinh
FROM SinhVien sv
INNER JOIN DangKy dk ON sv.MaSinhVien = dk.MaSinhVien
WHERE dk.DiemQuaTrinh IS NOT NULL AND dk.DiemCuoiKy IS NOT NULL
GROUP BY sv.MaSinhVien, sv.HoVaTen;

GO
CREATE VIEW vw_DiemTrungBinhTichLuySinhVien AS
SELECT 
    sv.MaSinhVien,
    sv.HoVaTen,
    AVG((dk.DiemQuaTrinh + dk.DiemCuoiKy) / 2.0) AS DiemTrungBinhTichLuy
FROM SinhVien sv
INNER JOIN DangKy dk ON sv.MaSinhVien = dk.MaSinhVien
WHERE 
    dk.DiemQuaTrinh IS NOT NULL 
    AND dk.DiemCuoiKy IS NOT NULL
    AND dk.DiemCuoiKy >= 3.0
    AND ((dk.DiemQuaTrinh + dk.DiemCuoiKy) / 2.0) >= 5.0
GROUP BY 
    sv.MaSinhVien, sv.HoVaTen;

GO
CREATE VIEW vw_XepHangSinhVienBangDiemTBTichLuy AS
SELECT 
    ROW_NUMBER() OVER (ORDER BY ROUND(SUM(((dk.DiemQuaTrinh + dk.DiemCuoiKy) / 2) * mh.SoTinChi) / SUM(mh.SoTinChi), 2) DESC) AS XepHang,
    sv.MaSinhVien,
    sv.HoVaTen,
    ROUND(SUM(((dk.DiemQuaTrinh + dk.DiemCuoiKy) / 2) * mh.SoTinChi) / SUM(mh.SoTinChi), 2) AS DiemTrungBinhTichLuy
FROM 
    SinhVien sv
JOIN 
    DangKy dk ON sv.MaSinhVien = dk.MaSinhVien
JOIN 
    LopHoc lh ON dk.MaLopHoc = lh.MaLopHoc
JOIN 
    MonHoc mh ON lh.MaMonHoc = mh.MaMonHoc
WHERE 
    dk.DiemQuaTrinh IS NOT NULL 
    AND dk.DiemCuoiKy IS NOT NULL
    AND dk.DiemCuoiKy >= 3
    AND (dk.DiemQuaTrinh + dk.DiemCuoiKy) >= 5
GROUP BY 
    sv.MaSinhVien, sv.HoVaTen;

GO
CREATE PROCEDURE proc_ThemSinhVien
    @MaSinhVien INT,              -- Mã sinh viên
    @HoVaTen NVARCHAR(100),       -- Họ và tên sinh viên
    @Email VARCHAR(100),          -- Email sinh viên
    @SoDienThoai VARCHAR(20),     -- Số điện thoại sinh viên
    @QueQuan NVARCHAR(100)        -- Quê quán của sinh viên
AS
BEGIN
    BEGIN TRY
        INSERT INTO SinhVien (MaSinhVien, HoVaTen, Email, SoDienThoai, QueQuan)
        VALUES (@MaSinhVien, @HoVaTen, @Email, @SoDienThoai, @QueQuan);
        PRINT N'Sinh viên ' + CAST(@MaSinhVien AS NVARCHAR) + N' đã được thêm thành công.';
    END TRY
    BEGIN CATCH
        -- Bắt thông báo lỗi từ trigger
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;

GO
CREATE PROCEDURE proc_ThemGiangVien
    @MaGiangVien INT,         -- Mã giảng viên
    @HoVaTen NVARCHAR(100),   -- Họ và tên giảng viên
    @Email NVARCHAR(100),     -- Email của giảng viên
    @SoDienThoai NVARCHAR(20) -- Số điện thoại của giảng viên
AS
BEGIN
    BEGIN TRY
        INSERT INTO GiangVien (MaGiangVien, HoVaTen, Email, SoDienThoai)
        VALUES (@MaGiangVien, @HoVaTen, @Email, @SoDienThoai);
        PRINT N'Giảng viên ' + CAST(@MaGiangVien AS NVARCHAR) + N' đã được thêm thành công.';
    END TRY
    BEGIN CATCH
        -- Bắt thông báo lỗi từ trigger
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;

GO
CREATE PROCEDURE proc_ThemMonHoc 
	@MaMonHoc INT,              -- Mã môn học cần thêm
	@TenMonHoc NVARCHAR(100),   -- Tên môn học cần thêm
	@SoTinChi TINYINT           -- Số tín chỉ
AS
BEGIN
    BEGIN TRY
        INSERT INTO MonHoc(MaMonHoc, TenMonHoc, SoTinChi)
        VALUES (@MaMonHoc, @TenMonHoc, @SoTinChi)
        PRINT N'Môn học ' + CAST(@MaMonHoc AS NVARCHAR) + N' đã được thêm thành công.';
    END TRY
    BEGIN CATCH
        -- Bắt thông báo lỗi từ trigger
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;

GO
CREATE PROCEDURE proc_ThemLopHoc 
    @MaLopHoc INT,          -- Mã lớp học cần thêm
    @Thu TINYINT,           -- Ngày trong tuần
    @TietBatDau TINYINT,    -- Tiết bắt đầu
    @TietKetThuc TINYINT,   -- Tiết kết thúc
    @MaPhongHoc INT,        -- Mã phòng học
    @MaGiangVien INT,       -- Mã giảng viên
    @MaMonHoc INT           -- Mã môn học
AS
BEGIN
    BEGIN TRY
        INSERT INTO LopHoc(MaLopHoc, Thu, TietBatDau, TietKetThuc, MaPhongHoc, MaGiangVien, MaMonHoc)
        VALUES (@MaLopHoc, @Thu, @TietBatDau, @TietKetThuc, @MaPhongHoc, @MaGiangVien, @MaMonHoc);
        PRINT N'Lớp học ' + CAST(@MaLopHoc AS NVARCHAR) + N' đã được thêm thành công.';
    END TRY
    BEGIN CATCH
        -- Bắt thông báo lỗi từ trigger
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;

GO
CREATE PROCEDURE proc_XoaSinhVien
    @MaSinhVien INT -- Mã sinh viên cần xóa
AS
BEGIN
    BEGIN TRY
        DELETE FROM SinhVien
        WHERE MaSinhVien = @MaSinhVien;
        PRINT N'Sinh viên ' + CAST(@MaSinhVien AS NVARCHAR) + N' đã được xóa thành công.';
    END TRY
    BEGIN CATCH
        -- Bắt thông báo lỗi từ trigger
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;

GO
CREATE PROCEDURE proc_XoaGiangVien
    @MaGiangVien INT -- Mã giảng viên cần xóa
AS
BEGIN
    BEGIN TRY
        DELETE FROM GiangVien
        WHERE MaGiangVien = @MaGiangVien;
        PRINT N'Giảng viên ' + CAST(@MaGiangVien AS NVARCHAR) + N' đã được xóa thành công.';
    END TRY
    BEGIN CATCH
        -- Bắt thông báo lỗi từ trigger
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;

GO
CREATE PROCEDURE proc_XoaMonHoc
    @MaMonHoc INT -- Mã môn học cần xóa
AS
BEGIN
    BEGIN TRY
        DELETE FROM MonHoc
        WHERE MaMonHoc = @MaMonHoc;
        PRINT N'Môn học ' + CAST(@MaMonHoc AS NVARCHAR) + N' đã được xóa thành công.';
    END TRY
    BEGIN CATCH
        -- Bắt thông báo lỗi từ trigger
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;

GO
CREATE PROCEDURE proc_XoaLopHoc 
    @MaLopHoc INT   -- Mã lớp học cần xóa
AS
BEGIN
    BEGIN TRY
        DELETE FROM LopHoc WHERE MaLopHoc = @MaLopHoc;
        PRINT N'Lớp học ' + CAST(@MaLopHoc AS NVARCHAR) + N' đã được xóa thành công.';
    END TRY
    BEGIN CATCH
        -- Bắt thông báo lỗi từ trigger
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;

GO
CREATE PROCEDURE proc_SuaSinhVien
    @MaSinhVien INT,            -- Mã sinh viên cần sửa
    @HoVaTen NVARCHAR(100),     -- Họ và Tên mới
    @Email VARCHAR(100),        -- Email mới
    @SoDienThoai VARCHAR(20),   -- Số điện thoại mới
    @QueQuan NVARCHAR(100)      -- Quê quán mới
AS
BEGIN
    BEGIN TRY
        UPDATE SinhVien
        SET HoVaTen = @HoVaTen,
            Email = @Email,
            SoDienThoai = @SoDienThoai,
            QueQuan = @QueQuan
        WHERE MaSinhVien = @MaSinhVien
        PRINT N'Sửa sinh viên ' + CAST(@MaSinhVien AS NVARCHAR) + N'thành công'
    END TRY
    BEGIN CATCH
        -- Bắt thông báo lỗi từ trigger
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;

GO
CREATE PROCEDURE proc_SuaGiangVien
    @MaGiangVien INT,         -- Mã giảng viên cần sửa
    @HoVaTen NVARCHAR(100),   -- Họ và tên mới của giảng viên
    @Email VARCHAR(100),      -- Email mới của giảng viên
    @SoDienThoai VARCHAR(20)  -- Số điện thoại mới của giảng viên
AS
BEGIN
    BEGIN TRY
        UPDATE GiangVien
        SET HoVaTen = @HoVaTen, Email = @Email, SoDienThoai = @SoDienThoai
        WHERE MaGiangVien = @MaGiangVien;
        PRINT N'Sửa giảng viên ' + CAST(@MaGiangVien AS NVARCHAR) + N' thành công.';
    END TRY
    BEGIN CATCH
        -- Bắt thông báo lỗi từ trigger
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;

GO
CREATE PROCEDURE proc_SuaMonHoc
    @MaMonHoc INT,              -- Mã môn học cần sửa
    @TenMonHoc NVARCHAR(100),   -- Tên môn học mới
    @SoTinChi TINYINT           -- Số tín chỉ mới
AS
BEGIN
    BEGIN TRY
        UPDATE MonHoc
        SET TenMonHoc = @TenMonHoc, SoTinChi = @SoTinChi
        WHERE MaMonHoc = @MaMonHoc
        PRINT N'Sửa môn học ' + CAST(@MaMonHoc AS NVARCHAR) + N' thành công.'
    END TRY
    BEGIN CATCH
        -- Bắt thông báo lỗi từ trigger
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;

GO
CREATE PROCEDURE proc_SuaLopHoc 
    @MaLopHoc INT,          -- Mã lớp học cần sửa
    @Thu TINYINT,           -- Ngày trong tuần
    @TietBatDau TINYINT,    -- Tiết bắt đầu
    @TietKetThuc TINYINT,   -- Tiết kết thúc
    @MaPhongHoc INT,        -- Mã phòng học
    @MaGiangVien INT,       -- Mã giảng viên
    @MaMonHoc INT           -- Mã môn học
AS
BEGIN
    BEGIN TRY

        -- Kiểm tra trùng mã lớp học
        IF NOT EXISTS (
            SELECT 1
            FROM LopHoc lh
            WHERE lh.MaLopHoc = @MaLopHoc
        )
        BEGIN
            RAISERROR ('Mã lớp học %d không tồn tại.', 16, 1, @MaLopHoc);
            RETURN;
        END

        -- Kiểm tra điều kiện hợp lệ cho thứ
        IF @Thu < 1 OR @Thu > 7
        BEGIN
            RAISERROR('Thứ phải từ 1 đến 7.', 16, 1);
            RETURN;
        END;

        -- Kiểm tra điều kiện hợp lệ cho tiết học
        IF @TietBatDau < 1 OR @TietBatDau > 12
           OR @TietKetThuc < 1 OR @TietKetThuc > 12
        BEGIN
            RAISERROR('Tiết bắt đầu và kết thúc phải từ 1 đến 12.', 16, 1);
            RETURN;
        END;

        IF @TietBatDau > @TietKetThuc
        BEGIN
            RAISERROR('Tiết bắt đầu không được lớn hơn tiết kết thúc.', 16, 1);
            RETURN;
        END;

        -- Kiểm tra trùng lịch học với lớp học khác
        DECLARE @MaLopHocTrung INT;
        SELECT @MaLopHocTrung = lh.MaLopHoc
        FROM LopHoc lh
        WHERE lh.MaLopHoc != @MaLopHoc AND lh.MaPhongHoc = @MaPhongHoc AND lh.Thu = @Thu AND
        (
            (@TietKetThuc BETWEEN lh.TietBatDau AND lh.TietKetThuc)OR
            (@TietBatDau BETWEEN lh.TietBatDau AND lh.TietKetThuc)
        )
        IF @MaLopHocTrung IS NOT NULL
        BEGIN
            RAISERROR ('Lớp học %d cần sửa bị trùng lịch với lớp học %d cùng phòng.', 16, 1, @MaLopHoc, @MaLopHocTrung);
            RETURN;
        END

        -- Cập nhật lớp học
        UPDATE LopHoc
        SET 
            Thu = @Thu,
            TietBatDau = @TietBatDau,
            TietKetThuc = @TietKetThuc,
            MaPhongHoc = @MaPhongHoc,
            MaGiangVien = @MaGiangVien,
            MaMonHoc = @MaMonHoc
        WHERE MaLopHoc = @MaLopHoc;
        PRINT N'Lớp học ' + CAST(@MaLopHoc AS NVARCHAR) + N' đã được sửa thành công.';
    END TRY
    BEGIN CATCH
        -- Bắt thông báo lỗi từ trigger
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;

GO
CREATE PROCEDURE proc_DangKySinhVienVaoLop
    @MaSinhVien INT,    -- Mã sinh viên
    @MaLopHoc INT       -- Mã lớp học
AS
BEGIN
    BEGIN TRY
        INSERT INTO DangKy (MaSinhVien, MaLopHoc)
        VALUES (@MaSinhVien, @MaLopHoc);
        PRINT N'Sinh viên ' + CAST(@MaSinhVien AS NVARCHAR) + N' đã đăng ký vào lớp học ' + CAST(@MaLopHoc AS NVARCHAR) + N' thành công.';
    END TRY
    BEGIN CATCH
        -- Bắt thông báo lỗi từ trigger
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;

GO
CREATE PROCEDURE proc_CapNhatDiemSinhVien
	@MaSinhVien INT,            -- Mã số sinh viên cần cập nhật điểm
	@MaLopHoc INT,              -- Mã môn học mà sinh viên đăng ký
	@DiemQuaTrinh DECIMAL(4,2), -- Điểm quá trình cần cập nhật
	@DiemCuoiKy DECIMAL(4,2)    -- Điểm cuối kỳ cần cập nhật
AS
BEGIN
    BEGIN TRY
        -- Kiểm tra xem sinh viên có tồn tại không
        IF NOT EXISTS (
            SELECT 1 
            FROM SinhVien sv
            WHERE sv.MaSinhVien = @MaSinhVien
        )
        BEGIN
            RAISERROR(N'Không tồn tại mã sinh viên %d trong thông tin đăng ký cần sửa.', 16, 1, @MaSinhVien);
            RETURN;
        END

        -- Kiểm tra lớp học có tồn tại không
        IF NOT EXISTS (
            SELECT 1
            FROM LopHoc lh
            WHERE lh.MaLopHoc = @MaLopHoc
        )
        BEGIN
            RAISERROR ('Không tồn tại mã lớp học %d trong thông tin đăng ký cần sửa.', 16, 1, @MaLopHoc);
            RETURN;
        END

        -- Kiểm tra sinh viên và lớp học có tồn tại trong bảng DangKy hay không
	    IF NOT EXISTS (SELECT 1 FROM DangKy where MaLopHoc = @MaLopHoc and MaSinhVien = @MaSinhVien)
	    BEGIN
            -- Thông báo sinh viên chưa đăng ký lớp học
		    RAISERROR(N'Sinh viên chưa đăng ký lớp học này.', 16, 1);
            RETURN;
	    END

        -- Kiểm tra điểm hợp lệ
        IF  @DiemQuaTrinh < 0.0 OR
            @DiemQuaTrinh > 10.0 OR
            @DiemCuoiKy < 0.0 OR
            @DiemCuoiKy > 10.0
        BEGIN
            RAISERROR(N'Điểm cần cập nhật không hợp lệ.', 16, 1);
            RETURN;
        END
        -- Cập nhật điểm quá trình và điểm cuối kỳ cho sinh viên
		UPDATE DangKy
		SET DiemQuaTrinh = @DiemQuaTrinh,
			DiemCuoiKy = @DiemCuoiKy
		WHERE MaLopHoc = @MaLopHoc and MaSinhVien = @MaSinhVien
		PRINT N'Cập nhật điểm thành công.'
    END TRY
    BEGIN CATCH
        -- Bắt thông báo lỗi từ trigger
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH

END;

go
CREATE PROCEDURE proc_XemKetQuaHocTapCuaLop
    @MaLopHoc INT
AS
BEGIN
    -- Input: 
    -- Mã lớp học cần xem danh sách sinh viên và xếp loại

    -- Output:
    -- Trả về danh sách sinh viên trong lớp học có mã @MaLopHoc. Bao gồm:
    -- - MaSinhVien: Mã sinh viên
    -- - HoVaTen: Họ và tên của sinh viên
    -- - DiemQuaTrinh: Điểm quá trình của sinh viên
    -- - DiemCuoiKy: Điểm cuối kỳ của sinh viên
    -- - DiemTrungBinhMon: Điểm trung bình môn (trung bình cộng của điểm quá trình và điểm cuối kỳ)
    -- - XepLoai: Xếp loại học lực của sinh viên dựa trên điểm trung bình môn
    --     + 'Giỏi' nếu DiemTrungBinhMon >= 8.0
    --     + 'Khá' nếu DiemTrungBinhMon từ 6.5 đến dưới 8.0
    --     + 'Trung Bình' nếu DiemTrungBinhMon từ 5.0 đến dưới 6.5
    --     + 'Yếu' nếu DiemTrungBinhMon dưới 5.0
    --     + 'Chưa biết' nếu DiemTrungBinhMon chưa có do thiếu điểm
    -- - TrangThaiQuaMon: Trạng thái qua môn của sinh viên
    --     + 'QUA' nếu DiemTrungBinhMon >= 5.0 và DiemCuoiKy >= 3.0
    --     + 'RỚT' nếu không đạt điều kiện qua môn
    --     + 'Chưa biết' nếu DiemTrungBinhMon chưa xác định do thiếu điểm
    SELECT MaSinhVien, 
        HoVaTen, 
        DiemQuaTrinh, 
        DiemCuoiKy, 
        DiemTrungBinhMon,
        CASE
            WHEN DiemTrungBinhMon IS NULL THEN N'Chưa biết'
            WHEN DiemTrungBinhMon >= 8.0 THEN N'Giỏi'
            WHEN DiemTrungBinhMon < 8.0 AND DiemTrungBinhMon >= 6.5 THEN N'Khá'
            WHEN DiemTrungBinhMon < 6.5 AND DiemTrungBinhMon >= 5.0 THEN N'Trung Bình'
            ELSE N'Yếu'
        END AS XepLoai,
        CASE
            WHEN DiemTrungBinhMon IS NULL THEN N'Chưa biết'
            WHEN DiemTrungBinhMon >= 5.0 AND DiemCuoiKy >= 3.0 THEN N'QUA'
            ELSE N'RỚT'
        END AS TrangThaiQuaMon
    FROM (
        SELECT sv.MaSinhVien, 
            sv.HoVaTen, 
            dk.DiemQuaTrinh, 
            dk.DiemCuoiKy, 
            CASE 
                WHEN dk.DiemQuaTrinh IS NULL OR dk.DiemCuoiKy IS NULL THEN NULL
                ELSE (dk.DiemQuaTrinh + dk.DiemCuoiKy) / 2 
            END AS DiemTrungBinhMon
        FROM SinhVien sv
        INNER JOIN DangKy dk ON sv.MaSinhVien = dk.MaSinhVien
        INNER JOIN LopHoc lh ON dk.MaLopHoc = lh.MaLopHoc
        WHERE lh.MaLopHoc = @MaLopHoc
    ) AS Subquery;
END;

GO
CREATE FUNCTION dbo.fn_KiemTraQuaMon (
    @MaSinhVien INT,
    @MaMonHoc INT
)
RETURNS TINYINT
AS
BEGIN
    -- Input:
    -- @MaSinhVien: Mã sinh viên cần kiểm tra
    -- @MaMonHoc: Mã môn học của sinh viên cần kiểm tra

    -- Output:
    -- 1 nếu qua môn, DiemCuoiKy >= 3.0 và điểm trung bình môn (DiemQuaTrinh + DiemCuoiKy) / 2 >= 5.0
    -- 0 nếu rớt môn, DiemCuoiKy < 3.0 hoặc điểm trung bình môn < 5.0
    -- 2 chưa nhập đủ điểm
    -- 3 sinh viên không tồn tại
    -- 4 sinh viên chưa đăng ký môn cần kiểm tra
    
    -- Kiểm tra xem sinh viên có tồn tại trong bảng DangKy không
    IF NOT EXISTS (SELECT 1 FROM DangKy dk WHERE dk.MaSinhVien = @MaSinhVien)
    BEGIN
        RETURN 3
    END

	-- Kiểm tra xem sinh viên có học môn này không
    IF NOT EXISTS (SELECT 1 
                   FROM DangKy dk 
                   INNER JOIN LopHoc lh ON dk.MaLopHoc = lh.MaLopHoc 
                   WHERE dk.MaSinhVien = @MaSinhVien AND lh.MaMonHoc = @MaMonHoc)
    BEGIN
	    RETURN 4	
    END

    DECLARE @DiemQuaTrinh DECIMAL(4, 2), @DiemCuoiKy DECIMAL(4, 2), @DiemTrungBinhMon DECIMAL(4, 2)

    SELECT @DiemQuaTrinh = dk.DiemQuaTrinh, @DiemCuoiKy = dk.DiemCuoiKy
    FROM DangKy dk
    INNER JOIN LopHoc lh ON dk.MaLopHoc = lh.MaLopHoc
    WHERE dk.MaSinhVien = @MaSinhVien AND lh.MaMonHoc = @MaMonHoc

    IF @DiemQuaTrinh IS NULL OR @DiemCuoiKy IS NULL
    BEGIN
        RETURN 2
    END

    SET @DiemTrungBinhMon = (@DiemQuaTrinh + @DiemCuoiKy) / 2.0

    IF @DiemCuoiKy >= 3.0 AND @DiemTrungBinhMon >= 5.0
    BEGIN
        RETURN 1
    END

    RETURN 0
END;

GO
CREATE FUNCTION dbo.fn_XemHocLucSinhVien (
    @MaSinhVien INT
)
RETURNS NVARCHAR(50)
AS
BEGIN
    -- Input:
    -- @MaSinhVien: Mã sinh viên cần xem học lực

    -- Output:
    -- Trả về 1 chuỗi kí tự là học lực của sinh viên, bao gồm: Giỏi, Khá, Trung Bình, Yếu. 

    DECLARE @DiemTrungBinh DECIMAL(4, 2);

    -- Tính điểm trung bình của tất cả các môn mà sinh viên đã đăng ký
    SELECT @DiemTrungBinh = AVG((dk.DiemQuaTrinh + dk.DiemCuoiKy) / 2.0)
    FROM DangKy dk
    WHERE dk.MaSinhVien = @MaSinhVien;

    -- Trả về học lực dựa vào điểm trung bình
    RETURN (
        CASE
            WHEN @DiemTrungBinh >= 8.0 THEN N'Giỏi'
            WHEN @DiemTrungBinh >= 6.5 THEN N'Khá'
            WHEN @DiemTrungBinh >= 5.0 THEN N'Trung Bình'
            ELSE N'Yếu'
        END
    );
END;

go
CREATE FUNCTION dbo.fn_SoTinChiDaHoanThanh(@MaSinhVien INT)
RETURNS INT
AS
BEGIN
	-- Input:
	-- @MaSinhVien: Mã sinh viên cần tính số tính chỉ
	-- Output:
	-- Trả về số tín chỉ đã hoàn thành của sinh viên có mã @MaSinhVien
	DECLARE @SoTCHoanThanh INT;

	SELECT @SoTCHoanThanh = SUM(MH.SoTinChi)
	FROM
		DangKy DK
		INNER JOIN LopHoc LH ON DK.MaLopHoc = LH.MaLopHoc
		INNER JOIN MonHoc MH ON LH.MaMonHoc = MH.MaMonHoc
	WHERE
		DK.MaSinhVien = @MaSinhVien 
		AND DiemQuaTrinh >= 3
		AND (DiemQuaTrinh + DiemCuoiKy)/2 >= 5
	RETURN ISNULL(@SoTCHoanThanh, 0)
END;

go
CREATE FUNCTION dbo.fn_DemSoLuongSinhVienCuaLop(@MaLopHoc INT)
RETURNS INT
AS
BEGIN
    -- Input:
    -- @MaLopHoc: Mã lớp học cần đếm số lượng sinh viên

    -- Output:
    -- Trả về số lượng sinh viên đã đăng ký vào lớp học có mã @MaLopHoc
    DECLARE @SoLuongSinhVien INT;
    
    SELECT @SoLuongSinhVien = COUNT(dk.MaSinhVien)
    FROM DangKy dk
    WHERE dk.MaLopHoc = @MaLopHoc;
    
    RETURN @SoLuongSinhVien;
END;

go
CREATE FUNCTION dbo.fn_TinhPhanTramQuaMon(@MaLopHoc INT)
RETURNS DECIMAL(5, 2)
AS
BEGIN
    -- Input:
	-- @MaLopHoc: Mã lớp học cần tính
	-- Output:
	-- Phần trăm sinh viên qua môn, nhỏ nhất là 0 và lớn nhất là 100
    DECLARE @SoLuongSinhVien INT;
    DECLARE @SoLuongQua INT;

    -- Đếm số lượng sinh viên đã đăng ký vào lớp
    SELECT @SoLuongSinhVien = COUNT(*)
    FROM DangKy
    WHERE MaLopHoc = @MaLopHoc;

    -- Đếm số lượng sinh viên qua môn
    SELECT @SoLuongQua = COUNT(*)
    FROM DangKy dk
    INNER JOIN LopHoc lh ON dk.MaLopHoc = lh.MaLopHoc
    WHERE dk.MaLopHoc = @MaLopHoc AND dbo.fn_KiemTraQuaMon(dk.MaSinhVien, lh.MaMonHoc) = 1;

    -- Kiểm tra tránh chia cho 0
    IF @SoLuongSinhVien = 0
    BEGIN
        RETURN 0.00; -- Nếu không có sinh viên, trả về 0%
    END

    -- Tính phần trăm qua môn
    RETURN (@SoLuongQua * 100.0 / @SoLuongSinhVien);
END;

go
CREATE FUNCTION dbo.fn_DemSoLopGiangVienPhuTrach(@MaGiangVien INT)
RETURNS INT
AS
BEGIN
    -- Input:
    -- @MaGiangVien: Mã giảng viên cần đếm số lượng lớp học mà họ phụ trách.

    -- Output:
    -- Trả về số lượng lớp học mà giảng viên có mã @MaGiangVien phụ trách.

    DECLARE @SoLuongLopHoc INT;
    
    SELECT @SoLuongLopHoc = COUNT(lh.MaLopHoc)
    FROM LopHoc lh
    WHERE lh.MaGiangVien = @MaGiangVien;
    
    RETURN @SoLuongLopHoc;
END;

go
CREATE FUNCTION dbo.fn_LayDanhSachSinhVienTrongLop (
    @MaLopHoc INT
)
RETURNS TABLE
AS
RETURN
(
    -- Input:
    -- @MaLopHoc: Mã lớp học cần lấy danh sách.

    -- Output:
    -- Trả về danh sách sinh viên đăng ký trong lớp học có mã @MaLopHoc. Bao gồm:
    -- - MaSinhVien: Mã sinh viên
    -- - HoVaTen: Họ và tên của sinh viên
    -- - Email: Email của sinh viên
    -- - SoDienThoai: Số điện thoại của sinh viên
    -- - QueQuan: Quê của sinh viên
	-- - DiemQuaTrinh: Điểm quá trình của sinh viên
	-- - DiemCuoiKy: Điểm cuối kỳ của sinh viên

    SELECT 
        sv.MaSinhVien, 
        sv.HoVaTen, 
        sv.Email, 
        sv.SoDienThoai,
        sv.QueQuan,
        dk.DiemQuaTrinh,
		dk.DiemCuoiKy
    FROM DangKy dk
    INNER JOIN SinhVien sv ON dk.MaSinhVien = sv.MaSinhVien
    WHERE dk.MaLopHoc = @MaLopHoc
);

go
CREATE FUNCTION dbo.fn_LayBangDiemSinhVien (
    @MaSinhVien INT
)
RETURNS @BangDiem TABLE (
    MaMonHoc INT,
    TenMonHoc NVARCHAR(255),
    DiemQuaTrinh DECIMAL(4, 2),
    DiemCuoiKy DECIMAL(4, 2),
    DiemTrungBinh DECIMAL(4, 2),
    XepLoaiMon NVARCHAR(50)
)
AS
BEGIN
    -- Input:
    -- @MaSinhVien: Mã sinh viên cần lấy bảng điểm.

    -- Output:
    -- Trả về bảng điểm bao gồm:
    -- - MaMonHoc: Mã môn học
    -- - TenMonHoc: Tên môn học
    -- - DiemQuaTrinh: Điểm quá trình của môn học
    -- - DiemCuoiKy: Điểm cuối kỳ của môn học
    -- - DiemTrungBinh: Điểm trung bình môn (tính trung bình cộng của điểm quá trình và điểm cuối kỳ)
    -- - XepLoaiMon: Xếp loại từng môn dựa trên điểm trung bình

    -- Chèn dữ liệu bảng điểm chi tiết từng môn
    INSERT INTO @BangDiem
    SELECT 
        mh.MaMonHoc,
        mh.TenMonHoc,
        dk.DiemQuaTrinh,
        dk.DiemCuoiKy,
        (dk.DiemQuaTrinh + dk.DiemCuoiKy) / 2.0 AS DiemTrungBinh,
        CASE
            WHEN (dk.DiemQuaTrinh + dk.DiemCuoiKy) / 2.0 >= 8.0 THEN N'Giỏi'
            WHEN (dk.DiemQuaTrinh + dk.DiemCuoiKy) / 2.0 >= 6.5 THEN N'Khá'
            WHEN (dk.DiemQuaTrinh + dk.DiemCuoiKy) / 2.0 >= 5.0 THEN N'Trung Bình'
            ELSE N'Yếu'
        END AS XepLoaiMon
    FROM DangKy dk
    INNER JOIN LopHoc lh ON dk.MaLopHoc = lh.MaLopHoc
    INNER JOIN MonHoc mh ON lh.MaMonHoc = mh.MaMonHoc
    WHERE dk.MaSinhVien = @MaSinhVien;

    RETURN;
END;

go
CREATE FUNCTION dbo.fn_TinhDiemTrungBinh (
    @MaSinhVien INT
)
RETURNS DECIMAL(4, 2)
AS
BEGIN
    -- Input:
	-- @MaSinhVien: Mã sinh viên cần tính điểm trung bình
	-- Output:
	-- Điểm trung bình của sinh viên
    DECLARE @DiemTrungBinh DECIMAL(4, 2);

    -- Tính điểm trung bình học kỳ: Trung bình cộng điểm quá trình và điểm cuối kỳ của tất cả các môn
    SELECT @DiemTrungBinh = AVG((dk.DiemQuaTrinh + dk.DiemCuoiKy) / 2.0)
    FROM DangKy dk
    INNER JOIN LopHoc lh ON dk.MaLopHoc = lh.MaLopHoc
    INNER JOIN MonHoc mh ON lh.MaMonHoc = mh.MaMonHoc
    WHERE dk.MaSinhVien = @MaSinhVien;

    -- Trả về kết quả tính trung bình
    RETURN @DiemTrungBinh;
END;

GO
CREATE FUNCTION dbo.fn_TinhDiemTrungBinhTichLuy (
    @MaSinhVien INT
)
RETURNS DECIMAL(4, 2)
AS
BEGIN
    -- Input:
    -- @MaSinhVien: Mã sinh viên cần tính điểm trung bình
    -- Output:
    -- Điểm trung bình của sinh viên

    DECLARE @DiemTrungBinhTichLuy DECIMAL(4, 2);

    -- Tính điểm trung bình tích lũy: Trung bình cộng điểm quá trình và điểm cuối kỳ của tất cả các môn
    SELECT @DiemTrungBinhTichLuy = AVG((dk.DiemQuaTrinh + dk.DiemCuoiKy) / 2.0)
    FROM DangKy dk
    INNER JOIN LopHoc lh ON dk.MaLopHoc = lh.MaLopHoc
    INNER JOIN MonHoc mh ON lh.MaMonHoc = mh.MaMonHoc
    WHERE 
        dk.MaSinhVien = @MaSinhVien
        AND dk.DiemQuaTrinh IS NOT NULL 
        AND dk.DiemCuoiKy IS NOT NULL
        AND dk.DiemCuoiKy >= 3.0
        AND ((dk.DiemQuaTrinh + dk.DiemCuoiKy) / 2.0) >= 5.0;

    -- Trả về điểm trung bình tích lũy
    RETURN @DiemTrungBinhTichLuy;
END;


GO
EXEC proc_ThemSinhVien 1, N'Nguyễn Văn A', 'nguyenvana@gmail.com', '0912345678', N'Hà Nội';
EXEC proc_ThemSinhVien 2, N'Lê Thị B', 'lethib@gmail.com', '0912345679', N'Hải Phòng';
EXEC proc_ThemSinhVien 3, N'Phạm Văn C', 'phamvanc@gmail.com', '0912345680', N'Nam Định';
EXEC proc_ThemSinhVien 4, N'Ngô Thị D', 'ngothid@gmail.com', '0912345681', N'Hà Nam';
EXEC proc_ThemSinhVien 5, N'Trần Văn E', 'tranvane@gmail.com', '0912345682', N'Nghệ An';
EXEC proc_ThemSinhVien 6, N'Hoàng Thị F', 'hoangthif@gmail.com', '0912345683', N'Thái Nguyên';
EXEC proc_ThemSinhVien 7, N'Bùi Văn G', 'buivang@gmail.com', '0912345684', N'Hà Nội';
EXEC proc_ThemSinhVien 8, N'Đỗ Thị H', 'dothih@gmail.com', '0912345685', N'Hưng Yên';
EXEC proc_ThemSinhVien 9, N'Vũ Văn I', 'vuvani@gmail.com', '0912345686', N'Thanh Hóa';
EXEC proc_ThemSinhVien 10, N'Đinh Thị J', 'dinhthij@gmail.com', '0912345687', N'Quảng Ninh';


GO
EXEC proc_ThemMonHoc 1, N'Toán Cao Cấp', 3;
EXEC proc_ThemMonHoc 2, N'Lập Trình Java', 4;
EXEC proc_ThemMonHoc 3, N'Cấu Trúc Dữ Liệu', 3;
EXEC proc_ThemMonHoc 4, N'Quản Trị Cơ Sở Dữ Liệu', 3;
EXEC proc_ThemMonHoc 5, N'Lập Trình Python', 4;
EXEC proc_ThemMonHoc 6, N'Trí Tuệ Nhân Tạo', 3;
EXEC proc_ThemMonHoc 7, N'Hệ Điều Hành', 3;
EXEC proc_ThemMonHoc 8, N'Mạng Máy Tính', 2;
EXEC proc_ThemMonHoc 9, N'Thống Kê Xác Suất', 3;
EXEC proc_ThemMonHoc 10, N'Kỹ Thuật Số', 2;


GO
EXEC proc_ThemGiangVien 1, N'Nguyễn Thị M', 'nguyenthim@gmail.com', '0987654321';
EXEC proc_ThemGiangVien 2, N'Lê Văn N', 'levann@gmail.com', '0987654322';
EXEC proc_ThemGiangVien 3, N'Trần Văn O', 'tranvano@gmail.com', '0987654323';
EXEC proc_ThemGiangVien 4, N'Ngô Thị P', 'ngothip@gmail.com', '0987654324';
EXEC proc_ThemGiangVien 5, N'Bùi Văn Q', 'buivanq@gmail.com', '0987654325';
EXEC proc_ThemGiangVien 6, N'Phạm Thị R', 'phamthir@gmail.com', '0987654326';
EXEC proc_ThemGiangVien 7, N'Trịnh Văn S', 'trinhvans@gmail.com', '0987654327';
EXEC proc_ThemGiangVien 8, N'Vũ Thị T', 'vuthit@gmail.com', '0987654328';
EXEC proc_ThemGiangVien 9, N'Hoàng Văn U', 'hoangvanu@gmail.com', '0987654329';
EXEC proc_ThemGiangVien 10, N'Lương Thị V', 'luongthiv@gmail.com', '0987654330';


GO
INSERT INTO PhongHoc (MaPhongHoc, SucChua) VALUES
(1, 30),
(2, 50),
(3, 25),
(4, 35),
(5, 40),
(6, 45),
(7, 30),
(8, 60),
(9, 10),
(10, 80);


GO
EXEC proc_ThemLopHoc 1, 2, 1, 3, 1, 1, 1;
EXEC proc_ThemLopHoc 2, 3, 2, 4, 2, 2, 2;
EXEC proc_ThemLopHoc 3, 4, 5, 7, 3, 3, 3;
EXEC proc_ThemLopHoc 4, 5, 1, 3, 4, 4, 4;
EXEC proc_ThemLopHoc 5, 6, 4, 6, 5, 5, 5;
EXEC proc_ThemLopHoc 6, 7, 2, 5, 6, 6, 6;
EXEC proc_ThemLopHoc 7, 1, 3, 6, 7, 7, 7;
EXEC proc_ThemLopHoc 8, 2, 4, 8, 8, 8, 8;
EXEC proc_ThemLopHoc 9, 3, 5, 7, 9, 9, 9;
EXEC proc_ThemLopHoc 10, 4, 1, 3, 10, 10, 10;


GO
INSERT INTO DangKy (MaSinhVien, MaLopHoc, DiemQuaTrinh, DiemCuoiKy) VALUES
(1, 1, 8.5, 9.0),
(2, 2, 7.0, 8.0),
(3, 3, 6.5, 7.5),
(4, 4, 8.0, 9.0),
(5, 5, 7.5, 8.5),
(6, 6, 9.0, 9.5),
(7, 7, 7.0, 8.0),
(8, 8, 6.0, 7.0),
(9, 9, 8.5, 9.5),
(10, 10, 9.0, 9.0);

