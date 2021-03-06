USE [master]
GO
/****** Object:  Database [EczaneUygulamasi]    Script Date: 15.12.2018 14:34:18 ******/
CREATE DATABASE [EczaneUygulamasi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EczaneUygulamasi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\EczaneUygulamasi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EczaneUygulamasi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\EczaneUygulamasi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [EczaneUygulamasi] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EczaneUygulamasi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EczaneUygulamasi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EczaneUygulamasi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EczaneUygulamasi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EczaneUygulamasi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EczaneUygulamasi] SET ARITHABORT OFF 
GO
ALTER DATABASE [EczaneUygulamasi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EczaneUygulamasi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EczaneUygulamasi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EczaneUygulamasi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EczaneUygulamasi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EczaneUygulamasi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EczaneUygulamasi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EczaneUygulamasi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EczaneUygulamasi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EczaneUygulamasi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EczaneUygulamasi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EczaneUygulamasi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EczaneUygulamasi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EczaneUygulamasi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EczaneUygulamasi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EczaneUygulamasi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EczaneUygulamasi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EczaneUygulamasi] SET RECOVERY FULL 
GO
ALTER DATABASE [EczaneUygulamasi] SET  MULTI_USER 
GO
ALTER DATABASE [EczaneUygulamasi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EczaneUygulamasi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EczaneUygulamasi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EczaneUygulamasi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EczaneUygulamasi] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'EczaneUygulamasi', N'ON'
GO
ALTER DATABASE [EczaneUygulamasi] SET QUERY_STORE = OFF
GO
USE [EczaneUygulamasi]
GO
/****** Object:  Table [dbo].[Cevap]    Script Date: 15.12.2018 14:34:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cevap](
	[cevapID] [int] IDENTITY(1,1) NOT NULL,
	[soruID] [int] NULL,
	[yoneticiID] [int] NULL,
	[cevapAciklama] [varchar](300) NULL,
	[cevapTarih] [date] NULL,
 CONSTRAINT [PK_Cevap] PRIMARY KEY CLUSTERED 
(
	[cevapID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Firma]    Script Date: 15.12.2018 14:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Firma](
	[firmaID] [int] IDENTITY(1,1) NOT NULL,
	[firmaIsim] [varchar](30) NULL,
 CONSTRAINT [PK_Firma] PRIMARY KEY CLUSTERED 
(
	[firmaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Haber]    Script Date: 15.12.2018 14:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Haber](
	[haberID] [int] IDENTITY(1,1) NOT NULL,
	[yoneticiID] [int] NULL,
	[haberAciklama] [varchar](300) NULL,
	[haberTarih] [date] NULL,
	[haberResim] [varchar](50) NULL,
	[haberBaslik] [varchar](100) NULL,
 CONSTRAINT [PK_Haber] PRIMARY KEY CLUSTERED 
(
	[haberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ilac]    Script Date: 15.12.2018 14:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ilac](
	[ilacID] [int] IDENTITY(1,1) NOT NULL,
	[ilacFirmaID] [int] NULL,
	[ilacKategoriID] [int] NULL,
	[ilacResim] [varchar](50) NULL,
 CONSTRAINT [PK_Ilac] PRIMARY KEY CLUSTERED 
(
	[ilacID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IlacDetay]    Script Date: 15.12.2018 14:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IlacDetay](
	[ilacID] [int] NOT NULL,
	[ilacIsim] [varchar](20) NULL,
	[ilacAciklama] [varchar](100) NULL,
	[ilacAdet] [int] NULL,
 CONSTRAINT [PK_IlacDetay] PRIMARY KEY CLUSTERED 
(
	[ilacID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kategori]    Script Date: 15.12.2018 14:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategori](
	[kategoriID] [int] IDENTITY(1,1) NOT NULL,
	[kategoriIsim] [varchar](30) NULL,
 CONSTRAINT [PK_Kategori] PRIMARY KEY CLUSTERED 
(
	[kategoriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanici]    Script Date: 15.12.2018 14:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanici](
	[kullaniciID] [int] IDENTITY(1,1) NOT NULL,
	[kullaniciYetkiKodu] [int] NULL,
	[kullaniciAdi] [varchar](10) NULL,
	[kullaniciSifre] [varchar](10) NULL,
 CONSTRAINT [PK_Kullanici] PRIMARY KEY CLUSTERED 
(
	[kullaniciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Satis]    Script Date: 15.12.2018 14:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Satis](
	[satisID] [int] IDENTITY(1,1) NOT NULL,
	[ilacID] [int] NULL,
	[uyeID] [int] NULL,
	[satisTarih] [date] NULL,
	[satisAdet] [int] NULL,
 CONSTRAINT [PK_Satis] PRIMARY KEY CLUSTERED 
(
	[satisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Siparis]    Script Date: 15.12.2018 14:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Siparis](
	[siparisID] [int] IDENTITY(1,1) NOT NULL,
	[ilacID] [int] NULL,
	[yoneticiID] [int] NULL,
	[siparisTarihi] [date] NULL,
	[siparisAdet] [int] NULL,
 CONSTRAINT [PK_Siparis] PRIMARY KEY CLUSTERED 
(
	[siparisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Soru]    Script Date: 15.12.2018 14:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Soru](
	[soruID] [int] IDENTITY(1,1) NOT NULL,
	[uyeID] [int] NULL,
	[soruAciklama] [varchar](300) NULL,
	[soruTarih] [date] NULL,
 CONSTRAINT [PK_Soru] PRIMARY KEY CLUSTERED 
(
	[soruID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Uye]    Script Date: 15.12.2018 14:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uye](
	[uyeID] [int] NOT NULL,
	[uyeIsim] [varchar](13) NULL,
	[uyeSoyisim] [varchar](15) NULL,
 CONSTRAINT [PK_Uye] PRIMARY KEY CLUSTERED 
(
	[uyeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yonetici]    Script Date: 15.12.2018 14:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yonetici](
	[yoneticiID] [int] NOT NULL,
	[yoneticiIsim] [varchar](13) NULL,
	[yoneticiSoyisim] [varchar](15) NULL,
 CONSTRAINT [PK_Yonetici] PRIMARY KEY CLUSTERED 
(
	[yoneticiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cevap]  WITH CHECK ADD  CONSTRAINT [FK_Cevap_Soru] FOREIGN KEY([soruID])
REFERENCES [dbo].[Soru] ([soruID])
GO
ALTER TABLE [dbo].[Cevap] CHECK CONSTRAINT [FK_Cevap_Soru]
GO
ALTER TABLE [dbo].[Cevap]  WITH CHECK ADD  CONSTRAINT [FK_Cevap_Yonetici] FOREIGN KEY([yoneticiID])
REFERENCES [dbo].[Yonetici] ([yoneticiID])
GO
ALTER TABLE [dbo].[Cevap] CHECK CONSTRAINT [FK_Cevap_Yonetici]
GO
ALTER TABLE [dbo].[Haber]  WITH CHECK ADD  CONSTRAINT [FK_Haber_Yonetici] FOREIGN KEY([yoneticiID])
REFERENCES [dbo].[Yonetici] ([yoneticiID])
GO
ALTER TABLE [dbo].[Haber] CHECK CONSTRAINT [FK_Haber_Yonetici]
GO
ALTER TABLE [dbo].[Ilac]  WITH CHECK ADD  CONSTRAINT [FK_Ilac_Firma] FOREIGN KEY([ilacFirmaID])
REFERENCES [dbo].[Firma] ([firmaID])
GO
ALTER TABLE [dbo].[Ilac] CHECK CONSTRAINT [FK_Ilac_Firma]
GO
ALTER TABLE [dbo].[Ilac]  WITH CHECK ADD  CONSTRAINT [FK_Ilac_Kategori] FOREIGN KEY([ilacKategoriID])
REFERENCES [dbo].[Kategori] ([kategoriID])
GO
ALTER TABLE [dbo].[Ilac] CHECK CONSTRAINT [FK_Ilac_Kategori]
GO
ALTER TABLE [dbo].[IlacDetay]  WITH CHECK ADD  CONSTRAINT [FK_IlacDetay_Ilac] FOREIGN KEY([ilacID])
REFERENCES [dbo].[Ilac] ([ilacID])
GO
ALTER TABLE [dbo].[IlacDetay] CHECK CONSTRAINT [FK_IlacDetay_Ilac]
GO
ALTER TABLE [dbo].[Satis]  WITH CHECK ADD  CONSTRAINT [FK_Satis_Ilac] FOREIGN KEY([ilacID])
REFERENCES [dbo].[Ilac] ([ilacID])
GO
ALTER TABLE [dbo].[Satis] CHECK CONSTRAINT [FK_Satis_Ilac]
GO
ALTER TABLE [dbo].[Satis]  WITH CHECK ADD  CONSTRAINT [FK_Satis_Uye] FOREIGN KEY([uyeID])
REFERENCES [dbo].[Uye] ([uyeID])
GO
ALTER TABLE [dbo].[Satis] CHECK CONSTRAINT [FK_Satis_Uye]
GO
ALTER TABLE [dbo].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Siparis_Ilac] FOREIGN KEY([ilacID])
REFERENCES [dbo].[Ilac] ([ilacID])
GO
ALTER TABLE [dbo].[Siparis] CHECK CONSTRAINT [FK_Siparis_Ilac]
GO
ALTER TABLE [dbo].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Siparis_Yonetici] FOREIGN KEY([yoneticiID])
REFERENCES [dbo].[Yonetici] ([yoneticiID])
GO
ALTER TABLE [dbo].[Siparis] CHECK CONSTRAINT [FK_Siparis_Yonetici]
GO
ALTER TABLE [dbo].[Soru]  WITH CHECK ADD  CONSTRAINT [FK_Soru_Uye] FOREIGN KEY([uyeID])
REFERENCES [dbo].[Uye] ([uyeID])
GO
ALTER TABLE [dbo].[Soru] CHECK CONSTRAINT [FK_Soru_Uye]
GO
ALTER TABLE [dbo].[Uye]  WITH CHECK ADD  CONSTRAINT [FK_Uye_Kullanici] FOREIGN KEY([uyeID])
REFERENCES [dbo].[Kullanici] ([kullaniciID])
GO
ALTER TABLE [dbo].[Uye] CHECK CONSTRAINT [FK_Uye_Kullanici]
GO
ALTER TABLE [dbo].[Yonetici]  WITH CHECK ADD  CONSTRAINT [FK_Yonetici_Kullanici] FOREIGN KEY([yoneticiID])
REFERENCES [dbo].[Kullanici] ([kullaniciID])
GO
ALTER TABLE [dbo].[Yonetici] CHECK CONSTRAINT [FK_Yonetici_Kullanici]
GO
/****** Object:  StoredProcedure [dbo].[HaberListele]    Script Date: 15.12.2018 14:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[HaberListele]
as
Select 
  h1.haberID,
  y1.yoneticiIsim+' '+y1.yoneticiSoyisim as 'Yönetici adı soyad',
  h1.haberBaslik,
  h1.haberAciklama,
  h1.haberTarih,
  h1.haberResim
 
 
from 
Haber h1 inner join Yonetici y1 on h1.yoneticiID=y1.yoneticiID;
GO
/****** Object:  StoredProcedure [dbo].[ilacEkle]    Script Date: 15.12.2018 14:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   proc [dbo].[ilacEkle] @ilacisim nvarchar(30),@ilacAciklama nvarchar(300),@ilacAdet int, @firmaIsim nvarchar(50), @kategoriIsim nvarchar(50), @resim nvarchar(100)
as
declare @firmaID int
Select TOP 1 @firmaID=firmaID from Firma Where firmaIsim=@firmaIsim
declare @kategoriID int
Select TOP 1 @kategoriID=kategoriID from Kategori Where kategoriIsim=@kategoriIsim

insert into Ilac(ilacFirmaID,ilacKategoriID,ilacResim) values(@firmaID,@kategoriID,@resim)

declare @ilacID int
Select top 1 @ilacID=ilacID from Ilac Order by ilacID desc

insert into IlacDetay(ilacID,ilacIsim,ilacAciklama,ilacAdet) values (@ilacID,@ilacisim,@ilacAciklama,@ilacAdet)
GO
/****** Object:  StoredProcedure [dbo].[ilacListele]    Script Date: 15.12.2018 14:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   procedure [dbo].[ilacListele]
as
select
		"t2"."ilacID",
		"t2"."ilacIsim",
		"t2"."ilacAciklama",
		"t3"."firmaIsim",
		"t4"."kategoriIsim",
		"t2"."ilacAdet"
	from 
		"Ilac" as "t1" inner join "IlacDetay" as "t2" on "t1"."ilacID"="t2"."ilacID"
		inner join "Firma" as "t3" on "t1"."ilacFirmaID"="t3"."firmaID"
		inner join "Kategori" as "t4" on "t1"."ilacKategoriID"="t4"."kategoriID"

order by "t2"."ilacAdet" desc
GO
/****** Object:  StoredProcedure [dbo].[ilacSil]    Script Date: 15.12.2018 14:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ilacSil] @ilacID int
as
Delete from IlacDetay Where ilacID=@ilacID
Delete from Ilac Where ilacID=@ilacID
GO
/****** Object:  StoredProcedure [dbo].[ilacToplamSatis]    Script Date: 15.12.2018 14:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ilacToplamSatis]
as
select
		"t2"."ilacIsim",
		"t2"."ilacAciklama",
		"t3"."firmaIsim",
		"t4"."kategoriIsim",
		(select sum("b"."satisAdet") from "Satis" as "b" where "t1"."ilacID"="b"."ilacID" ) as "satisAdedi"
	from 
		"Ilac" as "t1" inner join "IlacDetay" as "t2" on "t1"."ilacID"="t2"."ilacID"
		inner join "Firma" as "t3" on "t1"."ilacFirmaID"="t3"."firmaID"
		inner join "Kategori" as "t4" on "t1"."ilacKategoriID"="t4"."kategoriID"
	order by "satisAdedi"
GO
/****** Object:  StoredProcedure [dbo].[ilacToplamSiparis]    Script Date: 15.12.2018 14:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ilacToplamSiparis]
as
select
		"t2"."ilacIsim",
		"t2"."ilacAciklama",
		"t3"."firmaIsim",
		"t4"."kategoriIsim",
		(select sum("b"."siparisAdet") from "Siparis" as "b" where "t1"."ilacID"="b"."ilacID" ) as "siparisAdedi"
	from 
		"Ilac" as "t1" inner join "IlacDetay" as "t2" on "t1"."ilacID"="t2"."ilacID"
		inner join "Firma" as "t3" on "t1"."ilacFirmaID"="t3"."firmaID"
		inner join "Kategori" as "t4" on "t1"."ilacKategoriID"="t4"."kategoriID"
	order by "siparisAdedi"
GO
/****** Object:  StoredProcedure [dbo].[SadeceIlacListele]    Script Date: 15.12.2018 14:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure  [dbo].[SadeceIlacListele]
as
Select i1.ilacID,f1.firmaIsim,k1.kategoriIsim,i1.ilacResim from Ilac i1 inner join Firma f1 on
i1.ilacFirmaID=f1.firmaID 
inner join Kategori k1 on
i1.ilacKategoriID=k1.kategoriID
GO
/****** Object:  Trigger [dbo].[otomatikSiparis]    Script Date: 15.12.2018 14:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[otomatikSiparis]
on [dbo].[IlacDetay]
after update
as 
begin
	declare @id int 
	Select @id=ilacID from inserted
	
	declare @ilacAdedi int
	Select @ilacAdedi="ilacAdet" from "IlacDetay" Where "ilacID"=@id
	
	if(@ilacAdedi>5)
	begin
		return
	end	
	
	insert into Siparis (ilacID,yoneticiID,siparisTarihi,siparisAdet) values(@id,4,getDATE(),20)
	
end	
GO
ALTER TABLE [dbo].[IlacDetay] ENABLE TRIGGER [otomatikSiparis]
GO
/****** Object:  Trigger [dbo].[urunAdetCikarma]    Script Date: 15.12.2018 14:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[urunAdetCikarma]
on [dbo].[Satis]
after insert
as 
begin
	declare @id int 
	Select @id=ilacID from inserted
	
	declare @cikarilacakAdet int
	Select @cikarilacakAdet="satisAdet" from inserted
	
	declare @oncekiIlacAdet int
	Select @oncekiIlacAdet="ilacAdet" from "IlacDetay" Where "ilacID"=@id

	update "IlacDetay" Set "ilacAdet"=@oncekiIlacAdet-@cikarilacakAdet Where "ilacID"=@id
end	
GO
ALTER TABLE [dbo].[Satis] ENABLE TRIGGER [urunAdetCikarma]
GO
/****** Object:  Trigger [dbo].[urunAdetEkleme]    Script Date: 15.12.2018 14:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[urunAdetEkleme]
on [dbo].[Siparis]
after insert
as 
begin
	declare @id int 
	Select @id=ilacID from inserted
	
	declare @eklenecekAdet int
	Select @eklenecekAdet="siparisAdet" from inserted
	
	declare @oncekiIlacAdet int
	Select @oncekiIlacAdet="ilacAdet" from "IlacDetay" Where "ilacID"=@id

	update "IlacDetay" Set "ilacAdet"=@oncekiIlacAdet+@eklenecekAdet Where "ilacID"=@id
end	
GO
ALTER TABLE [dbo].[Siparis] ENABLE TRIGGER [urunAdetEkleme]
GO
/****** Object:  Trigger [dbo].[otomatikSoruCevap]    Script Date: 15.12.2018 14:34:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[otomatikSoruCevap]
on [dbo].[Soru]
after insert
as 
begin
	declare @id int 
	Select @id=soruID from inserted

	insert into Cevap(soruID,yoneticiID,cevapAciklama,cevapTarih) values(@id,4,'En kısa zamanda dönüş yapılacaktır.',getDate())
end	
GO
ALTER TABLE [dbo].[Soru] ENABLE TRIGGER [otomatikSoruCevap]
GO
USE [master]
GO
ALTER DATABASE [EczaneUygulamasi] SET  READ_WRITE 
GO
