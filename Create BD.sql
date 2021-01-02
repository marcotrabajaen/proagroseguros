USE MASTER
GO

CREATE DATABASE proagroseguros
Go

CREATE LOGIN uProAgroSeguros	
    WITH PASSWORD    = N'123456',
	DEFAULT_DATABASE = proagroseguros,
    CHECK_POLICY     = OFF,
    CHECK_EXPIRATION = OFF;
GO

USE proagroseguros
GO
CREATE USER [uproagroseguros] FOR LOGIN [uproagroseguros] WITH DEFAULT_SCHEMA=[dbo]
GO
EXEC sp_addrolemember N'db_datareader', N'uproagroseguros'
GO
EXEC sp_addrolemember N'db_datawriter', N'uproagroseguros'
GO

create table CAT_ESTADO (
idEstado INT IDENTITY(1,1) PRIMARY KEY
,Nombre nvarchar(50)
,Acronimo nvarchar(10)
)

create table CAT_USUARIO (
idUsuario INT IDENTITY(1,1) PRIMARY KEY
,Contrasenia nvarchar(10) default 'abcde'
,Nombre nvarchar(200)
,FechaCreacion datetime
,RFC nvarchar(50)
)

create table CAT_USUARIO_ESTADO (
idUsuarioEstado INT IDENTITY(1,1) PRIMARY KEY
,idUsuario int FOREIGN KEY REFERENCES CAT_USUARIO(idUsuario)
,idEstado int FOREIGN KEY REFERENCES CAT_ESTADO(idEstado)
)

create table CAT_GEORREFERENCIAS (
idGeorreferencias INT IDENTITY(1,1) PRIMARY KEY
,idEstado int FOREIGN KEY REFERENCES CAT_ESTADO(idEstado)
,Latitud float
,Longitud float
)
GO


SET IDENTITY_INSERT [dbo].[CAT_ESTADO] ON 
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (1, N'AGUASCALIENTES', N'AGS')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (2, N'BAJA CALIFORNIA', N'BCN')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (3, N'BAJA CALIFORNIA SUR', N'BCS')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (4, N'CAMPECHE', N'CAMP')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (5, N'COAHUILA', N'COAH')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (6, N'COLIMA', N'COL')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (7, N'CHIAPAS', N'CHIS')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (8, N'CHIHUAHUA', N'CHIH')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (9, N'DISTRITO FEDERAL', N'DF')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (10, N'DURANGO', N'DGO')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (11, N'GUANAJUATO', N'GTO')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (12, N'GUERRERO', N'GRO')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (13, N'HIDALGO', N'HGO')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (14, N'JALISCO', N'JAL')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (15, N'ESTADO DE MEXICO', N'MEX')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (16, N'MICHOACAN', N'MICH')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (17, N'MORELOS', N'MOR')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (18, N'NAYARIT', N'NAY')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (19, N'NUEVO LEON', N'NL')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (20, N'OAXACA', N'OAX')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (21, N'PUEBLA', N'PUE')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (22, N'QUERETARO', N'QRO')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (23, N'QUINTANA ROO', N'QROO')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (24, N'SAN LUIS POTOSI', N'SLP')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (25, N'SINALOA', N'SIN')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (26, N'SONORA', N'SON')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (27, N'TABASCO', N'TAB')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (28, N'TAMAULIPAS', N'TAMP')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (29, N'TLAXCALA', N'TLAX')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (30, N'VERACRUZ', N'VER')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (31, N'YUCATAN', N'YUC')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (32, N'ZACATECAS', N'ZAC')
INSERT [dbo].[CAT_ESTADO] ([idEstado], [Nombre], [Acronimo]) VALUES (33, N'CIUDAD DE MÉXICO', N'CDMX')
SET IDENTITY_INSERT [dbo].[CAT_ESTADO] OFF

SET IDENTITY_INSERT [dbo].[CAT_USUARIO] ON 
INSERT [dbo].[CAT_USUARIO] ([idUsuario], [Contrasenia], [Nombre], [FechaCreacion], [RFC]) VALUES (1, N'abcde', N'PORCICULTORES EL HIBRIDO S DE RL', CAST(N'2005-01-11T00:00:00.000' AS DateTime), N'PHI0501116U3')
INSERT [dbo].[CAT_USUARIO] ([idUsuario], [Contrasenia], [Nombre], [FechaCreacion], [RFC]) VALUES (2, N'abcde', N'AGROPECUARIA EL GIGANTE S.A. DE C.V.', CAST(N'2000-01-14T00:00:00.000' AS DateTime), N'AGI000114C70')
INSERT [dbo].[CAT_USUARIO] ([idUsuario], [Contrasenia], [Nombre], [FechaCreacion], [RFC]) VALUES (3, N'abcde', N'PROVEEDORES AGROALIMENTARIOS DEL DISTRITO DE RIEGO 01 SPR DE RL', CAST(N'2004-05-28T00:00:00.000' AS DateTime), N'PAD0405282B1')
INSERT [dbo].[CAT_USUARIO] ([idUsuario], [Contrasenia], [Nombre], [FechaCreacion], [RFC]) VALUES (4, N'abcde', N'EL SILOGISMO SPR DE RL', CAST(N'1997-11-06T00:00:00.000' AS DateTime), N'SIL971106652')
INSERT [dbo].[CAT_USUARIO] ([idUsuario], [Contrasenia], [Nombre], [FechaCreacion], [RFC]) VALUES (5, N'abcde', N'PRODUCTORES UNIDOS DE LAGOS, S.C. DE R.L. DE C.V.', CAST(N'2005-07-11T00:00:00.000' AS DateTime), N'PUL0507113N6')
INSERT [dbo].[CAT_USUARIO] ([idUsuario], [Contrasenia], [Nombre], [FechaCreacion], [RFC]) VALUES (6, N'abcde', N'ALIMENTOS PROCESADOS EL ZARCO S DE R.L. M.I. DE C.V.', CAST(N'2006-02-01T00:00:00.000' AS DateTime), N'APZ060201412')
INSERT [dbo].[CAT_USUARIO] ([idUsuario], [Contrasenia], [Nombre], [FechaCreacion], [RFC]) VALUES (7, N'abcde', N'HSBC MEXICO S.A., INSTITUCION DE BANCA MULTIPLE GRUPO FINANCIERO HSBC', CAST(N'1995-01-25T00:00:00.000' AS DateTime), N'HMI950125KG8')
INSERT [dbo].[CAT_USUARIO] ([idUsuario], [Contrasenia], [Nombre], [FechaCreacion], [RFC]) VALUES (8, N'abcde', N'UNION GANADERA LAS TROJES', CAST(N'2005-11-14T00:00:00.000' AS DateTime), N'UGD0511148J3')
INSERT [dbo].[CAT_USUARIO] ([idUsuario], [Contrasenia], [Nombre], [FechaCreacion], [RFC]) VALUES (9, N'abcde', N'QUESOS LOS MARTINEZ, S. DE R.L. M.I. DE C.V.', CAST(N'2005-06-14T00:00:00.000' AS DateTime), N'QMA050614F17')
INSERT [dbo].[CAT_USUARIO] ([idUsuario], [Contrasenia], [Nombre], [FechaCreacion], [RFC]) VALUES (10, N'abcde', N'RANCHO MEDIO KILO, S. P.R. DE R.L.', CAST(N'1998-02-03T00:00:00.000' AS DateTime), N'RMK9802033P7')
INSERT [dbo].[CAT_USUARIO] ([idUsuario], [Contrasenia], [Nombre], [FechaCreacion], [RFC]) VALUES (11, N'abcde', N'MARTIN RUIZ BERNAL, S. DE P.R. DE R.L.', CAST(N'2002-02-20T00:00:00.000' AS DateTime), N'MRB0112136W7')
INSERT [dbo].[CAT_USUARIO] ([idUsuario], [Contrasenia], [Nombre], [FechaCreacion], [RFC]) VALUES (12, N'abcde', N'CHIVOS Y BORREGOS DE AGUASCALIENTES, S.P.R. DE R.L', CAST(N'2006-02-13T00:00:00.000' AS DateTime), N'CBA051107TKA')
INSERT [dbo].[CAT_USUARIO] ([idUsuario], [Contrasenia], [Nombre], [FechaCreacion], [RFC]) VALUES (13, N'abcde', N'GANADEROS UNIDOS DE TEQUILILLA', CAST(N'2002-12-09T00:00:00.000' AS DateTime), N'GUT021209P8G')
INSERT [dbo].[CAT_USUARIO] ([idUsuario], [Contrasenia], [Nombre], [FechaCreacion], [RFC]) VALUES (14, N'abcde', N'COMUNIDAD PRODUCTORA 2000, S.P.R.DE R.L.', CAST(N'1999-12-10T00:00:00.000' AS DateTime), N'CPD9912105S7')
INSERT [dbo].[CAT_USUARIO] ([idUsuario], [Contrasenia], [Nombre], [FechaCreacion], [RFC]) VALUES (15, N'abcde', N'INOVAGRO, S.A. DE C.V.', CAST(N'2003-06-16T00:00:00.000' AS DateTime), N'INO030616JN5')
INSERT [dbo].[CAT_USUARIO] ([idUsuario], [Contrasenia], [Nombre], [FechaCreacion], [RFC]) VALUES (16, N'abcde', N'GANADERIA LA GREÑUDA, S.C. DE R.L.', CAST(N'2006-06-24T00:00:00.000' AS DateTime), N'GGR060624JV4')
INSERT [dbo].[CAT_USUARIO] ([idUsuario], [Contrasenia], [Nombre], [FechaCreacion], [RFC]) VALUES (17, N'abcde', N'PRODUCTORES DE LA ESTANCIA DE CUQUIO, S.C.  DE  R.L.', CAST(N'2005-10-21T00:00:00.000' AS DateTime), N'PEC051021HX7')
INSERT [dbo].[CAT_USUARIO] ([idUsuario], [Contrasenia], [Nombre], [FechaCreacion], [RFC]) VALUES (18, N'abcde', N'GRANJA EL 13 DE LOS ACUÑA, S.P.R.  DE  R.L.', CAST(N'2004-03-27T00:00:00.000' AS DateTime), N'GTA040327Q39')
INSERT [dbo].[CAT_USUARIO] ([idUsuario], [Contrasenia], [Nombre], [FechaCreacion], [RFC]) VALUES (19, N'abcde', N'EL GREÑERO, S. DE R.L. DE C.V.', CAST(N'2002-05-08T00:00:00.000' AS DateTime), N'GRE0205086JA')
INSERT [dbo].[CAT_USUARIO] ([idUsuario], [Contrasenia], [Nombre], [FechaCreacion], [RFC]) VALUES (20, N'abcde', N'AGRASISA, S.A. DE C.V.', CAST(N'2001-11-09T00:00:00.000' AS DateTime), N'AGR011109ST4')
SET IDENTITY_INSERT [dbo].[CAT_USUARIO] OFF

SET IDENTITY_INSERT [dbo].[CAT_USUARIO_ESTADO] ON 
INSERT [dbo].[CAT_USUARIO_ESTADO] ([idUsuarioEstado], [idUsuario], [idEstado]) VALUES (1, 1, 1)
INSERT [dbo].[CAT_USUARIO_ESTADO] ([idUsuarioEstado], [idUsuario], [idEstado]) VALUES (2, 2, 5)
INSERT [dbo].[CAT_USUARIO_ESTADO] ([idUsuarioEstado], [idUsuario], [idEstado]) VALUES (3, 3, 25)
INSERT [dbo].[CAT_USUARIO_ESTADO] ([idUsuarioEstado], [idUsuario], [idEstado]) VALUES (4, 4, 14)
INSERT [dbo].[CAT_USUARIO_ESTADO] ([idUsuarioEstado], [idUsuario], [idEstado]) VALUES (5, 5, 28)
INSERT [dbo].[CAT_USUARIO_ESTADO] ([idUsuarioEstado], [idUsuario], [idEstado]) VALUES (6, 6, 5)
INSERT [dbo].[CAT_USUARIO_ESTADO] ([idUsuarioEstado], [idUsuario], [idEstado]) VALUES (7, 7, 5)
INSERT [dbo].[CAT_USUARIO_ESTADO] ([idUsuarioEstado], [idUsuario], [idEstado]) VALUES (8, 8, 5)
INSERT [dbo].[CAT_USUARIO_ESTADO] ([idUsuarioEstado], [idUsuario], [idEstado]) VALUES (9, 9, 1)
INSERT [dbo].[CAT_USUARIO_ESTADO] ([idUsuarioEstado], [idUsuario], [idEstado]) VALUES (10, 10, 25)
INSERT [dbo].[CAT_USUARIO_ESTADO] ([idUsuarioEstado], [idUsuario], [idEstado]) VALUES (11, 11, 14)
INSERT [dbo].[CAT_USUARIO_ESTADO] ([idUsuarioEstado], [idUsuario], [idEstado]) VALUES (12, 12, 28)
INSERT [dbo].[CAT_USUARIO_ESTADO] ([idUsuarioEstado], [idUsuario], [idEstado]) VALUES (13, 13, 28)
INSERT [dbo].[CAT_USUARIO_ESTADO] ([idUsuarioEstado], [idUsuario], [idEstado]) VALUES (14, 14, 28)
INSERT [dbo].[CAT_USUARIO_ESTADO] ([idUsuarioEstado], [idUsuario], [idEstado]) VALUES (15, 15, 14)
INSERT [dbo].[CAT_USUARIO_ESTADO] ([idUsuarioEstado], [idUsuario], [idEstado]) VALUES (16, 16, 14)
INSERT [dbo].[CAT_USUARIO_ESTADO] ([idUsuarioEstado], [idUsuario], [idEstado]) VALUES (17, 17, 1)
INSERT [dbo].[CAT_USUARIO_ESTADO] ([idUsuarioEstado], [idUsuario], [idEstado]) VALUES (18, 18, 25)
INSERT [dbo].[CAT_USUARIO_ESTADO] ([idUsuarioEstado], [idUsuario], [idEstado]) VALUES (19, 19, 25)
INSERT [dbo].[CAT_USUARIO_ESTADO] ([idUsuarioEstado], [idUsuario], [idEstado]) VALUES (20, 20, 1)
SET IDENTITY_INSERT [dbo].[CAT_USUARIO_ESTADO] OFF

SET IDENTITY_INSERT [dbo].[CAT_GEORREFERENCIAS] ON 
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (1, 1, 21.13180225, -89.50884361)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (2, 1, 22.302625, 102.2263139)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (3, 1, 23.2336, 103.3168167)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (4, 1, 23.23353333, 103.3335528)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (5, 1, 22.07935, 102.0409833)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (6, 1, 22.39769444, 102.2899333)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (7, 1, 22.39863333, 102.2900556)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (8, 1, 21.98357222, 102.2667667)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (9, 1, 21.9836, 102.2502306)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (10, 1, 22.616775, 102.2335389)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (11, 5, 25.506789, -102.2433589)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (12, 5, 25.50705411, -102.2443927)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (13, 5, 26.30458298, -103.0647895)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (14, 5, 26.30687434, -103.0620606)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (15, 5, 26.30047677, -103.0553136)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (16, 5, 26.29786489, -103.0583045)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (17, 5, 26.30464132, -103.0648854)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (18, 5, 26.30694835, -103.0622138)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (19, 5, 26.31341072, -103.0691436)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (20, 5, 26.31077704, -103.0722422)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (21, 25, 24.20180556, 107.1031389)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (22, 25, 2.201583333, 107.1035556)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (23, 25, 24.22061111, 107.1337222)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (24, 25, 24.22238889, 107.1337222)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (25, 25, 24.10958333, 107.0839722)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (26, 25, 24.11113889, 107.08325)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (27, 25, 24.10941667, 107.0788889)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (28, 25, 24.10727778, 107.0763611)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (29, 25, 24.21880556, 107.1337778)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (30, 25, 24.22055556, 107.13375)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (31, 14, 20.62366667, 103.8016111)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (32, 14, 20.44083333, 103.9239167)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (33, 14, 20.48036111, 103.9556111)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (34, 14, 20.48425, 103.9726389)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (35, 14, 19.88372222, 103.372)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (36, 14, 19.62819444, 103.7716944)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (37, 14, 19.64733333, 103.7284444)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (38, 14, 19.65225, 103.7428056)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (39, 14, 19.65730556, 103.7916111)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (40, 14, 19.5935, 103.8120556)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (41, 28, 25.74877778, 97.57894444)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (42, 28, 25.30605556, 97.86688889)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (43, 28, 25.30605556, 97.86688889)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (44, 28, 24.61438889, 97.91577778)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (45, 28, 25.31441667, 97.79305556)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (46, 28, 24.61452778, 97.91575)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (47, 28, 25.29966667, 97.85988889)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (48, 28, 25.29966667, 97.85988889)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (49, 28, 25.74986111, 97.60216667)
INSERT [dbo].[CAT_GEORREFERENCIAS] ([idGeorreferencias], [idEstado], [Latitud], [Longitud]) VALUES (50, 28, 25.74986111, 97.60218611)
SET IDENTITY_INSERT [dbo].[CAT_GEORREFERENCIAS] OFF
GO