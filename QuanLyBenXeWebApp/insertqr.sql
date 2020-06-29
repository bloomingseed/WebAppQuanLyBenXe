

use BenXeDaNang;
INSERT INTO NHAXE VALUES ('NX00000001',N'Nhà Xe A',1,'19001900001','#ff0000',N'96 Nguyễn Lương Bằng, Đà Nẵng','09/06/2020');
INSERT INTO NHAXE VALUES ('NX00000002',N'Nhà Xe B',1,'19001900002','#00ff00',N'92 Tôn Đức Thắng, Đà Nẵng','07/5/2020');
INSERT INTO NHAXE VALUES ('NX00000003',N'Nhà Xe C',2,'19001900003','#0000ff',N'96 Ninh Tốn, Đà Nẵng','07/1/2020');
INSERT INTO NHAXE VALUES ('NX00000004',N'Nhà Xe D',3,'19001900004','#000000',N'01 Thượng Nguồn,thành phố X','07/12/2019');
INSERT INTO NHAXE VALUES ('NX00000005',N'Nhà Xe E',5,'19001900005','#ffffff',N'752 Tân Lộ, tỉnh W','07/5/2010');
INSERT INTO NHAXE VALUES ('NX00000006',N'Nhà Xe F',8,'19001900006','#dddddd',N'101 Đốm, tỉnh A','07/4/2020');


insert into TAIXE VAlues ('TX00000001',N'Trần',N'Nghĩa',1,N'Quảng Nam','0906442968');
insert into TAIXE VAlues ('TX00000002',N'Trần',N'Hoàng',1,N'Thành phố X','0905432212');
insert into TAIXE VAlues ('TX00000003',N'Nguyễn',N'Hoạ',1,N'Quảng Ngãi','0906442968');
insert into TAIXE VAlues ('TX00000004',N'Nguyễn',N'Nguyễn',1,N'Đà Nẵng','0905432212');
insert into TAIXE VAlues ('TX00000005',N'Nguyễn',N'Tấn',1,null,'0906442968');
insert into TAIXE VAlues ('TX00000006',N'Hoàng',N'Hoàng',1,null,'0905432212');
insert into TAIXE VAlues ('TX00000010',N'Hoàng',N'Nghĩa',1,null,'0906442968');
insert into TAIXE VAlues ('TX00000011',N'Lê',N'Trung',0,N'Tỉnh A','0905432212');

insert into XEKHACH values ('XK00000001','NX00000001','TX00000001','A00000031122',45,300000);
insert into XEKHACH values ('XK00000002','NX00000002','TX00000002','A00000032222',40,300000);
insert into XEKHACH values ('XK00000003','NX00000003','TX00000003','A00000031322',40,350000);
insert into XEKHACH values ('XK00000004','NX00000003','TX00000004','A00000032422',30,250000);
insert into XEKHACH values ('XK00000005','NX00000004','TX00000005','A00000031522',35,250000);
insert into XEKHACH values ('XK00000006','NX00000005','TX00000006','A00000032622',50,250000);
insert into XEKHACH values ('XK00000010','NX00000006','TX00000010','A00000031722',45,200000);
insert into XEKHACH values ('XK00000011','NX00000006','TX00000011','A00000032822',40,200000);

insert into DIEMDUNG  values ('DD00000001',N'Gia Lai',N'Chư Prông',N'Ia Phìn',N'Hoàng Tiên',null);
insert into DIEMDUNG  values ('DD00000002',N'Gia Lai',N'Chư Sê',null,null,null);
insert into DIEMDUNG  values ('DD00000003',N'Quảng Nam',N'Quế Sơn',N'Quế Phong',null,null);
insert into DIEMDUNG  values ('DD00000004',N'Quảng Nam',N'Tam kỳ',null,null,null);
insert into DIEMDUNG  values ('DD00000005',N'Quảng Nam',N'Núi Thành',N'Tam Thanh',null,null);
insert into DIEMDUNG  values ('DD00000006',N'Đà Nẵng',N'Liên Chiểu',null,null,N'108 Nguyễn Lương Bằng');
insert into DIEMDUNG  values ('DD00000007',N'Đà Nẵng',N'Ngũ Hành Sơn',null, null,N'92 X');
insert into DIEMDUNG  values ('DD00000008',N'Đà Nẵng',N'Hải Châu',null,null,N'9981 YYY');

insert into XEKHACH_DIEMDUNG values ('XK00000001','DD00000001','18:30:00','08:00:00','20:00:00','8:30:00');
insert into XEKHACH_DIEMDUNG values ('XK00000001','DD00000002','18:30:00','08:30:00','19:00:00','9:30:00');
insert into XEKHACH_DIEMDUNG values ('XK00000002','DD00000003','17:30:00','17:30:00','06:30:00','06:30:00');
insert into XEKHACH_DIEMDUNG values ('XK00000002','DD00000004','17:30:00','17:30:00','06:30:00','06:30:00');
insert into XEKHACH_DIEMDUNG values ('XK00000003','DD00000005','17:30:00','17:30:00','06:30:00','06:30:00');
insert into XEKHACH_DIEMDUNG values ('XK00000004','DD00000006','17:30:00','17:30:00','06:30:00','06:30:00');
insert into XEKHACH_DIEMDUNG values ('XK00000005','DD00000007','17:30:00','17:30:00','06:30:00','06:30:00');
insert into XEKHACH_DIEMDUNG values ('XK00000006','DD00000008','17:30:00','17:30:00','06:30:00','06:30:00');
insert into XEKHACH_DIEMDUNG values ('XK00000005','DD00000001','17:30:00','17:30:00','06:30:00','06:30:00');
insert into XEKHACH_DIEMDUNG values ('XK00000003','DD00000006','17:30:00','17:30:00','06:30:00','06:30:00');

