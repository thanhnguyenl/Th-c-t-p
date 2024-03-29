Use Master
GO
    IF exists(Select name From sys.databases Where name='doan' )
    DROP Database doan
GO
    Create Database doan
GO

USE doan;

GO

CREATE TABLE CSKCB(
	MA_CSKCB varchar(5) primary key,
	STT int identity(1,1),
	TAI_KHOAN varchar(30) not null,
	MAT_KHAU varchar(20) not null
)

CREATE TABLE THUOC(
	STT int primary key identity(1,1),
	MA_THUOC varchar(10) not null,
	TEN_HOAT_CHAT varchar(100),
	TEN_THUOC nvarchar(100),
	DON_VI_TINH nvarchar(20),
	HAM_LUONG nvarchar(255),
	DUONG_LUONG nvarchar(20),
	MA_DUONG_LUONG varchar(10),
	DANG_BAO_CHE nvarchar(20),
	SO_DANG_KY varchar(20),
	SO_LUONG int default 0,
	DON_GIA int default 0,
	DON_GIA_BH int default 0,
	QUY_CACH nvarchar(100),
	NHA_SX nvarchar(100),
	NUOC_SX nvarchar(100),
	NHA_THAU varchar(50),
	TT_THAU nvarchar(30),
	TU_NGAY varchar(8),
	DEN_NGAY varchar(8),
	MA_CSKCB varchar(5) foreign key(MA_CSKCB) references CSKCB(MA_CSKCB),
	LOAI_THUOC varchar(1),
	LOAI_THAU varchar(1),
	HT_THAU varchar(1),
	MA_DVKT nvarchar(100),
	TCCL nvarchar(100),
	BO_PHAN_VT nvarchar(100),
	TEN_KHOA_HOC nvarchar(100),
	NGUON_GOC nvarchar(100),
	PP_CHEBIEN nvarchar(100),
	MA_DL_NHAP nvarchar(100),
	MA_DL_CB nvarchar(100),
	MA_TLHH_CB nvarchar(100),
	TLHH_BQ nvarchar(100),
	ID varchar(8)
) 

GO

CREATE TABLE TAIKHOANQUANTRI(
	STT int primary key identity(1,1),
	TAI_KHOAN varchar(30) not null,
	MAT_KHAU varchar(20) not null
)
GO

CREATE TABLE NHANVIEN(
	STT int primary key identity(1,1),
	MA_LOAI_KCB int not null,
	MA_KHOA varchar(10) not null,
	MA_BHXH varchar(10) not null,
	HO_TEN nvarchar(100) not null,
	MACCHN varchar(30) not null,
	MA_CSKCB varchar(5) foreign key(MA_CSKCB) references CSKCB(MA_CSKCB)
)
GO

CREATE TABLE VATTU(
	STT int primary key identity(1,1),
	MA_VAT_TU varchar(20) not null,
	NHOM_VAT_TU nvarchar(255) not null,
	TEN_VAT_TU nvarchar(255) not null,
	MA_HIEU varchar(20),
	QUY_CACH nvarchar(20) not null,
	HANG_SX nvarchar(255) not null,
	NUOC_SX nvarchar(255) not null,
	DON_VI_TINH nvarchar(20) not null,
	DON_GIA int default 0,
	DON_GIA_BH int default 0,
	TYLE_TT_BH int default 0,
	SO_LUONG int default 0,
	DANH_MUC nvarchar(100),
	NHA_THAU nvarchar(100) not null,
	TT_THAU varchar(100) not null,
	TU_NGAY varchar(8),
	DEN_NGAY varchar(8),
	MA_CSKCB varchar(5) foreign key(MA_CSKCB) references CSKCB(MA_CSKCB),
	LOAI_THAU varchar(1) not null,
	HT_THAU varchar(1) not null,
	ID varchar(8) not null,
)
GO

CREATE TABLE DICHVU(
	STT int primary key identity(1,1),
	MA_DICH_VU varchar(20) not null,
	TEN_DICH_VU nvarchar(255) not null,
	DON_GIA int default 0,
	QUY_TRINH varchar(30) not null,
	CSKCB_CGKT nvarchar(255),
	CSKCB_CLS nvarchar(255),
	ID varchar(8) not null,
	MA_CSKCB varchar(5) foreign key(MA_CSKCB) references CSKCB(MA_CSKCB)
)

GO

-- Dữ liệu bảng CSKCB
INSERT INTO CSKCB(MA_CSKCB,TAI_KHOAN,MAT_KHAU) VALUES('67009','bva','123');
INSERT INTO CSKCB(MA_CSKCB,TAI_KHOAN,MAT_KHAU) VALUES('67010','bvb','123');

-- Dữ liệu bảng THUOC
INSERT INTO THUOC(MA_THUOC,TEN_HOAT_CHAT,TEN_THUOC,DON_VI_TINH,HAM_LUONG,DUONG_LUONG,MA_DUONG_LUONG,DANG_BAO_CHE,SO_DANG_KY,SO_LUONG,DON_GIA,DON_GIA_BH,QUY_CACH,NHA_SX,NUOC_SX,NHA_THAU,TT_THAU,TU_NGAY,DEN_NGAY,MA_CSKCB,LOAI_THUOC,LOAI_THAU,HT_THAU,MA_DVKT,TCCL,BO_PHAN_VT,TEN_KHOA_HOC,NGUON_GOC,PP_CHEBIEN,MA_DL_NHAP,MA_DL_CB,MA_TLHH_CB,TLHH_BQ,ID) VALUES('40.455','Albumin',N'Albuminar 25',N'Chai',N'25%/50ml',N'Tiêm truyền','2.15',N'Dung dich','VN-13414-11','2','870000','870000',N'Hộp 1 chai 50ml',N'CSL Behring LLC',N'Mỹ',N'CPDP_Ha_Noi','989/QĐ-SYT;G1;N1;2020','20221119','','67009','1','1','1',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'','47362415');
INSERT INTO THUOC(MA_THUOC,TEN_HOAT_CHAT,TEN_THUOC,DON_VI_TINH,HAM_LUONG,DUONG_LUONG,MA_DUONG_LUONG,DANG_BAO_CHE,SO_DANG_KY,SO_LUONG,DON_GIA,DON_GIA_BH,QUY_CACH,NHA_SX,NUOC_SX,NHA_THAU,TT_THAU,TU_NGAY,DEN_NGAY,MA_CSKCB,LOAI_THUOC,LOAI_THAU,HT_THAU,MA_DVKT,TCCL,BO_PHAN_VT,TEN_KHOA_HOC,NGUON_GOC,PP_CHEBIEN,MA_DL_NHAP,MA_DL_CB,MA_TLHH_CB,TLHH_BQ,ID) VALUES('40.2','Bupivacain hydroclorid',N'Marcaine Spinal Heavy Inj 0.5% 4ml x 5s',N'Ống',N'0.5% (5mg/ml) - 4ml',N'Tiêm','2.10',N'Dung dich','VN-19785-16','500','37872','37872',N'Hộp 5 ống x 4ml',N'Cenexi',N'Pháp',N'DLTW_2','989/QĐ-SYT;G1;N1;2020','20221119','','67009','1','1','1',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'','47362417');
INSERT INTO THUOC(MA_THUOC,TEN_HOAT_CHAT,TEN_THUOC,DON_VI_TINH,HAM_LUONG,DUONG_LUONG,MA_DUONG_LUONG,DANG_BAO_CHE,SO_DANG_KY,SO_LUONG,DON_GIA,DON_GIA_BH,QUY_CACH,NHA_SX,NUOC_SX,NHA_THAU,TT_THAU,TU_NGAY,DEN_NGAY,MA_CSKCB,LOAI_THUOC,LOAI_THAU,HT_THAU,MA_DVKT,TCCL,BO_PHAN_VT,TEN_KHOA_HOC,NGUON_GOC,PP_CHEBIEN,MA_DL_NHAP,MA_DL_CB,MA_TLHH_CB,TLHH_BQ,ID) VALUES('40.495','Candesartan',N'Candesartan BluePharma',N'Viên',N'8mg',N'Uống','1.01',N'Viên','VN-20392-17','200','4560','4560',N'Hộp 2 vỉ x 14 viên, hộp 4 vỉ x 14 viên, hộp 5 vỉ x 14 viên',N'Bluepharma- Indústria Farmacêutica, S.A. (Fab.Coimbra)',N'Portugal',N'Tu_Duc','989/QĐ-SYT;G1;N1;2020','20221119','','67010','1','1','1',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'','47362418');
INSERT INTO THUOC(MA_THUOC,TEN_HOAT_CHAT,TEN_THUOC,DON_VI_TINH,HAM_LUONG,DUONG_LUONG,MA_DUONG_LUONG,DANG_BAO_CHE,SO_DANG_KY,SO_LUONG,DON_GIA,DON_GIA_BH,QUY_CACH,NHA_SX,NUOC_SX,NHA_THAU,TT_THAU,TU_NGAY,DEN_NGAY,MA_CSKCB,LOAI_THUOC,LOAI_THAU,HT_THAU,MA_DVKT,TCCL,BO_PHAN_VT,TEN_KHOA_HOC,NGUON_GOC,PP_CHEBIEN,MA_DL_NHAP,MA_DL_CB,MA_TLHH_CB,TLHH_BQ,ID) VALUES('40.497','Carvedilol',N'Talliton',N'Chai',N'6,25mg',N'Tiêm truyền','1.01',N'Viên','VN-19942-16','100','3100','3100',N'Hộp 2 vỉ x 7 viênl',N'Egis Pharmaceuticals Private Limited Company',N'Hungary',N'Ben_tre','989/QĐ-SYT;G1;N1;2020','20221119','','67010','1','1','1',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'','47362419');


-- Dữ liệu bảng TAIKHOANQUANTRI
INSERT INTO TAIKHOANQUANTRI(TAI_KHOAN,MAT_KHAU) VALUES('admin','123');
INSERT INTO TAIKHOANQUANTRI(TAI_KHOAN,MAT_KHAU) VALUES('admin2','123');
INSERT INTO TAIKHOANQUANTRI(TAI_KHOAN,MAT_KHAU) VALUES('admin3','123');

-- Dữ liệu bảng NHANVIEN
INSERT INTO NHANVIEN(MA_LOAI_KCB,MA_KHOA,MA_BHXH,HO_TEN,MACCHN,MA_CSKCB) VALUES('4','K02031811','6710002766',N'Phạm Ngọc Biên','0000574/ĐNO-CCHN','67009');
INSERT INTO NHANVIEN(MA_LOAI_KCB,MA_KHOA,MA_BHXH,HO_TEN,MACCHN,MA_CSKCB) VALUES('2','K02031812','6710002763',N'Lê Văn An','0000573/ĐNO-CCHN','67009');
INSERT INTO NHANVIEN(MA_LOAI_KCB,MA_KHOA,MA_BHXH,HO_TEN,MACCHN,MA_CSKCB) VALUES('3','K02031813','6710002769',N'Nguyễn Phước Hậu','0000572/ĐNO-CCHN','67010');
INSERT INTO NHANVIEN(MA_LOAI_KCB,MA_KHOA,MA_BHXH,HO_TEN,MACCHN,MA_CSKCB) VALUES('1','K02031814','6710002761',N'Nguyễn Văn Phước','0000571/ĐNO-CCHN','67010');


-- Dữ liệu bảng VATTU
INSERT INTO VATTU(MA_VAT_TU,NHOM_VAT_TU,TEN_VAT_TU,MA_HIEU,QUY_CACH,HANG_SX,NUOC_SX,DON_VI_TINH,DON_GIA,DON_GIA_BH,TYLE_TT_BH,SO_LUONG,DANH_MUC,NHA_THAU,TT_THAU,TU_NGAY,DEN_NGAY,MA_CSKCB,LOAI_THAU,HT_THAU,ID) VALUES('N04.01.090',N'Thông (sonde) các loại, các cỡ',N'Thông (sonde) các loại, các cỡ','',N'Cái',N'Suzhou Yudu Trung Quốc',N'Suzhou Yudu Trung Quốc',N'Cái','6000','6000','100','950',N'',N'Đăk Lăk','1308/QĐ-SYT;G0;N0;2019','20191029','','67009','1','1','3663513');
INSERT INTO VATTU(MA_VAT_TU,NHOM_VAT_TU,TEN_VAT_TU,MA_HIEU,QUY_CACH,HANG_SX,NUOC_SX,DON_VI_TINH,DON_GIA,DON_GIA_BH,TYLE_TT_BH,SO_LUONG,DANH_MUC,NHA_THAU,TT_THAU,TU_NGAY,DEN_NGAY,MA_CSKCB,LOAI_THAU,HT_THAU,ID) VALUES('N07.06.040',N'Đinh, nẹp, ghim, kim, khóa, ốc, vít, lồng dùng trong phẫu thuật các loại, các cỡ',N'Đinh, nẹp, ghim, kim, khóa, ốc, vít, lồng dùng trong phẫu thuật các loại, các cỡ','4-06-xx-xx',N'Hộp 1 cái',N'Medgal - Ba Lan',N'Medgal - Ba Lan',N'Cái','86000','86000','100','20',N'',N'Hoàng Lộc','1308/QĐ-SYT;G0;N0;2019','20191029','','67009','1','1','3722237');
INSERT INTO VATTU(MA_VAT_TU,NHOM_VAT_TU,TEN_VAT_TU,MA_HIEU,QUY_CACH,HANG_SX,NUOC_SX,DON_VI_TINH,DON_GIA,DON_GIA_BH,TYLE_TT_BH,SO_LUONG,DANH_MUC,NHA_THAU,TT_THAU,TU_NGAY,DEN_NGAY,MA_CSKCB,LOAI_THAU,HT_THAU,ID) VALUES('N07.06.040',N'Đinh, nẹp, ghim, kim, khóa, ốc, vít, lồng dùng trong phẫu thuật các loại, các cỡ',N'Đinh, nẹp, ghim, kim, khóa, ốc, vít, lồng dùng trong phẫu thuật các loại, các cỡ','',N'Cái',N'HEMC - Ấn độ',N'HEMC - Ấn độ',N'Cái','37000','37000','100','20',N'',N'Huỳnh Lê','1308/QĐ-SYT;G0;N0;2019','20191029','','67010','1','1','3722238');
INSERT INTO VATTU(MA_VAT_TU,NHOM_VAT_TU,TEN_VAT_TU,MA_HIEU,QUY_CACH,HANG_SX,NUOC_SX,DON_VI_TINH,DON_GIA,DON_GIA_BH,TYLE_TT_BH,SO_LUONG,DANH_MUC,NHA_THAU,TT_THAU,TU_NGAY,DEN_NGAY,MA_CSKCB,LOAI_THAU,HT_THAU,ID) VALUES('N07.06.040',N'Đinh, nẹp, ghim, kim, khóa, ốc, vít, lồng dùng trong phẫu thuật các loại, các cỡ',N'Đinh, nẹp, ghim, kim, khóa, ốc, vít, lồng dùng trong phẫu thuật các loại, các cỡ','',N'Cái',N'Medicor- Ấn Độ',N'Medicor- Ấn Độ',N'Cái','73500','73500','100','25',N'',N'Huỳnh Lê','1308/QĐ-SYT;G0;N0;2019','20191029','','67010','1','1','3722374');

-- Dữ liệu bảng DICHVU
INSERT INTO DICHVU(MA_DICH_VU,TEN_DICH_VU,DON_GIA,QUY_TRINH,CSKCB_CGKT,CSKCB_CLS,ID,MA_CSKCB) VALUES('18.0059.0001',N'Siêu âm dương vật','43900','20141003_3983/QĐ-BYT','','','57311846','67009');
INSERT INTO DICHVU(MA_DICH_VU,TEN_DICH_VU,DON_GIA,QUY_TRINH,CSKCB_CGKT,CSKCB_CLS,ID,MA_CSKCB) VALUES('01.0002.1778',N'Ghi điện tim cấp cứu tại giường','32800','20141003_3983/QĐ-BYT','','','57341743','67009');
INSERT INTO DICHVU(MA_DICH_VU,TEN_DICH_VU,DON_GIA,QUY_TRINH,CSKCB_CGKT,CSKCB_CLS,ID,MA_CSKCB) VALUES('15.0228.0932',N'Nội soi hạ họng ống cứng lấy dị vật gây tê/gây mê','513000','20121018_3978/QĐ-BYT','','','62380509','67010');
INSERT INTO DICHVU(MA_DICH_VU,TEN_DICH_VU,DON_GIA,QUY_TRINH,CSKCB_CGKT,CSKCB_CLS,ID,MA_CSKCB) VALUES('15.0226.1005',N'Nội soi hạ họng ống cứng chẩn đoán gây tê','290000','20121018_3978/QĐ-BYT','','','62716940','67010');

SELECT * FROM CSKCB;
SELECT * FROM THUOC;
SELECT * FROM TAIKHOANQUANTRI;
SELECT * FROM DICHVU;
SELECT * FROM VATTU;
SELECT * FROM NHANVIEN;


