USE [master]
GO

CREATE DATABASE [Identity]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Identity', FILENAME = N'D:\SQLDatabases\Data\Identity.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Identity_log', FILENAME = N'D:\SQLDatabases\Log\Identity.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Identity].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Identity] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Identity] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Identity] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Identity] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Identity] SET ARITHABORT OFF 
GO
ALTER DATABASE [Identity] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Identity] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Identity] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Identity] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Identity] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Identity] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Identity] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Identity] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Identity] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Identity] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Identity] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Identity] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Identity] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Identity] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Identity] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Identity] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Identity] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Identity] SET RECOVERY FULL 
GO
ALTER DATABASE [Identity] SET  MULTI_USER 
GO
ALTER DATABASE [Identity] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Identity] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Identity] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Identity] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Identity] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Identity] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Identity] SET QUERY_STORE = OFF
GO
ALTER DATABASE [Identity] SET  READ_WRITE 
GO

USE [Identity]
GO
/*
SELECT DBO.EncryptString('123456789', '@')

SELECT DBO.DecryptString('±²³´µ¶·¸¹', '@')
*/

CREATE FUNCTION EncryptString(@Text VARCHAR(250), @Key VARCHAR(025))
RETURNS VARCHAR(250)
AS
BEGIN
  DECLARE @I   INT;
  DECLARE @RET VARCHAR(250);
  DECLARE @C1  INT;
  DECLARE @C2  INT;
  SET  @I = 0;
  SET @RET = '';
  IF(LEN(@Key) > 0)
  BEGIN
    WHILE @I < LEN(@Text)
	BEGIN
	  SET @I = @I + 1;
      SET @C1 = ASCII(SUBSTRING(@Text, @I, 1));
      If (@I > LEN(@Key))
	  BEGIN
        SET @C2 = ASCII(SUBSTRING(@Key, @I % LEN(@Key) + 1, 1));
	  END
      ELSE
	  BEGIN
        SET @C2 = ASCII(SUBSTRING(@Key, @I, 1));
      END
      SET @C1 = @C1 + @C2 + 64;
      IF (@C1 > 255) 
	  BEGIN SET @C1 = @C1 - 256 END
      SET @RET = @RET + CHAR(@C1);
    END
  END
  ELSE
  BEGIN
    SET @RET = @Text;
  END
  RETURN @RET;
END;
GO

CREATE FUNCTION DecryptString(@Text VARCHAR(250), @Key VARCHAR(025))
RETURNS VARCHAR(250)
AS
BEGIN
  DECLARE @I   INT;
  DECLARE @RET VARCHAR(250);
  DECLARE @C1  INT;
  DECLARE @C2  INT;
  SET  @I = 0;
  SET @RET = '';
  IF(LEN(@Key) > 0)
  BEGIN
    WHILE @I < LEN(@Text)
	BEGIN
	  SET @I = @I + 1;
      SET @C1 = ASCII(SUBSTRING(@Text, @I, 1));
      If (@I > LEN(@Key))
	  BEGIN
        SET @C2 = ASCII(SUBSTRING(@Key, @I % LEN(@Key) + 1, 1));
	  END
      ELSE
	  BEGIN
        SET @C2 = ASCII(SUBSTRING(@Key, @I, 1));
      END
      SET @C1 = @C1 - @C2 - 64;
      IF (SIGN(@C1) = -1) 
	  BEGIN SET @C1 = 256 + @C1 END
      SET @RET = @RET + CHAR(@C1);
    END
  END
  ELSE
  BEGIN
    SET @RET = @Text;
  END
  RETURN @RET;
END;
GO


CREATE TABLE [dbo].[Status](
	[KeyId] [nvarchar](2) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[StateId] [nvarchar](2) NOT NULL,
	[IsSystem] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](5) NOT NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](5) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
([KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Company](
	[KeyId] [nvarchar](5) NOT NULL,
	[Ruc] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Observation] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Agent] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[EMail] [nvarchar](max) NULL,
	[Web] [nvarchar](max) NULL,
	[StateId] [nvarchar](2) NOT NULL,
	[IsSystem] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](5) NOT NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](5) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
([KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Role](
	[KeyId] [nvarchar](5) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Observation] [nvarchar](max) NULL,
	[StateId] [nvarchar](2) NOT NULL,
	[IsSystem] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](5) NOT NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](5) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
([KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[User](
	[KeyId] [nvarchar](5) NOT NULL,
	[UserName] [nvarchar](450) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Observation] [nvarchar](max) NULL,
	[Names] [nvarchar](max) NULL,
	[Surnames] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[EMail] [nvarchar](max) NULL,
	[Image] [varbinary](max) NULL,
	[Token] [nvarchar](max) NULL,
	[RoleId] [nvarchar](5) NOT NULL,
	[StateId] [nvarchar](2) NOT NULL,
	[IsSystem] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](5) NOT NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](5) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
([KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Role_x_Company](
	[RoleId] [nvarchar](5) NOT NULL,
	[CompanyId] [nvarchar](5) NOT NULL,
	[StateId] [nvarchar](2) NOT NULL,
	[IsSystem] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](5) NOT NULL,
	[LastModifiedDate] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](5) NULL,
 CONSTRAINT [PK_Role_x_Company] PRIMARY KEY CLUSTERED 
([RoleId] ASC, [CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Role_x_Company]  WITH CHECK ADD  CONSTRAINT [FK_Role_x_Company_Company_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([KeyId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Role_x_Company] CHECK CONSTRAINT [FK_Role_x_Company_Company_CompanyId]
GO
ALTER TABLE [dbo].[Role_x_Company]  WITH CHECK ADD  CONSTRAINT [FK_Role_x_Company_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([KeyId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Role_x_Company] CHECK CONSTRAINT [FK_Role_x_Company_Role_RoleId]
GO
GO


INSERT INTO [Status]
([KeyId], [Name], [Description], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy])
SELECT '01', 'ACTIVO', 'REGISTRO ACTIVO', '01', 1, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '99', 'INACTIVO', 'REGISTRO INACTIVO', '01', 1, GETDATE(), '00001', GETDATE(), '00001';
GO

INSERT INTO [Company]
([KeyId], [Ruc], [Description], [Observation], [Address], [Agent], [Phone], [EMail], [Web], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy])
SELECT '00001', '00000000000', 'EMPRESA DE PRUEBA 01', '', 'ACA', 'YO', '900000000', 'EMPRESA01@MAIL.COM', 'HTTPS//:EMPRESA01.PE', '01', 0, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00002', '01111111110', 'EMPRESA DE PRUEBA 02', '', 'ACA', 'YO', '900000002', 'EMPRESA01@MAIL.COM', 'HTTPS//:EMPRESA01.PE', '01', 0, GETDATE(), '00001', GETDATE(), '00001';
GO

INSERT INTO [Role]
([KeyId], [Name], [Description], [Observation], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy])
SELECT '00001', 'ADMINISTRADOR', 'Los usuarios asignados al rol de administrador tienen derechos ilimitados y pueden crear, modificar o eliminar otros inicios de sesión.', 'ADMINISTRADOR DEL SISTEMA', '01', 1, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00002', 'USUARIO AVANZADO', 'Los usuarios asignados al rol de usuario avanzado pueden realizar todas las operaciones dentro de una cuenta, excepto realizar cambios en el acceso de otros usuarios.', 'USUARIO AVANZADO DEL SISTEMA', '01', 1, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00003', 'USUARIO', 'Los usuarios con rol de usuario tienen permisos de acceso restringido a la funcionalidad dentro de una cuenta.', 'USUARIO DEL SISTEMA', '01', 1, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00004', 'VISOR', 'Los usuarios con rol Visor (solo lectura) solo pueden ver datos en el sistema y no pueden actualizar nada.', 'VISOR DEL SISTEMA', '01', 1, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00005', 'OPERADOR', 'Los usuarios asignados al rol de operador tienen permisos de acceso restringido a la funcionalidad dentro de una cuenta.', 'OPERADOR DEL SISTEMA', '01', 1, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00006', 'INACTIVO', 'La cuenta de usuario con rol inactivo sigue en el servicio del sistema, pero se deniega a un usuario inactivo que inicie sesión. Utilice el estado para desactivar temporalmente una cuenta de usuario. Puede cambiar el estado y activar la cuenta en cualquier momento.', 'INACTIVO DEL SISTEMA', '01', 1, GETDATE(), '00001', GETDATE(), '00001';
GO

INSERT INTO [User]
([KeyId], [UserName], [Password], [Description], [Observation], [Names], [Surnames], [Phone], [EMail], [Image], [Token], [RoleId], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy])
SELECT '00001', 'ADMIN', '±²³´µ¶·¸¹', 'CUENTA ADMIN', '', 'ADMIN', '', '123456789', 'ADMIN@MAIL.COM', NULL, '', '00001', '01', 0, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00002', 'USUARIO_01', '±²³´µ¶·¸¹', 'CUENTA USUARIO 01', '', 'USER 01', '', '123456789', 'USUARIO_01@MAIL.COM', NULL, '', '00003', '01', 0, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00003', 'USUARIO_02', '±²³´µ¶·¸¹', 'CUENTA USUARIO 02', '', 'USER 02', '', '123456789', 'USUARIO_02@MAIL.COM', NULL, '', '00003', '01', 0, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00004', 'USUARIO_03', '±²³´µ¶·¸¹', 'CUENTA USUARIO 03', '', 'USER 03', '', '123456789', 'USUARIO_03@MAIL.COM', NULL, '', '00003', '01', 0, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00005', 'OPERADOR_01', '±²³´µ¶·¸¹', 'CUENTA OPERADOR 01', '', 'OPERADOR 01', '', '123456789', 'OPERADOR_01@MAIL.COM', NULL, '', '00005', '01', 0, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00006', 'OPERADOR_02', '±²³´µ¶·¸¹', 'CUENTA OPERADOR 02', '', 'OPERADOR 02', '', '123456789', 'OPERADOR_02@MAIL.COM', NULL, '', '00005', '01', 0, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00007', 'OPERADOR_03', '±²³´µ¶·¸¹', 'CUENTA OPERADOR 03', '', 'OPERADOR 03', '', '123456789', 'OPERADOR_03@MAIL.COM', NULL, '', '00005', '01', 0, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00008', 'VISOR', '±²³´µ¶·¸¹', 'CUENTA VISOR', '', 'VISOR', '', '123456789', 'VISOR@MAIL.COM', NULL, '', '00004', '01', 0, GETDATE(), '00001', GETDATE(), '00001';
GO

INSERT INTO [Role_x_Company]
([RoleId], [CompanyId], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy])
SELECT '00001', '00001', '01', 0, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00002', '00001', '01', 0, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00003', '00001', '01', 0, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00004', '00001', '01', 0, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00005', '00001', '01', 0, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00006', '00001', '01', 0, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00001', '00002', '01', 0, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00002', '00002', '01', 0, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00003', '00002', '01', 0, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00004', '00002', '01', 0, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00005', '00002', '01', 0, GETDATE(), '00001', GETDATE(), '00001'
UNION ALL
SELECT '00006', '00002', '01', 0, GETDATE(), '00001', GETDATE(), '00001';
GO


---------------------------------------------------------------------------------

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CompanyInsert]
(
 @KeyId            nvarchar(5),
 @Ruc              nvarchar(max),
 @Description      nvarchar(max),
 @Observation      nvarchar(max),
 @Address          nvarchar(max),
 @Agent            nvarchar(max),
 @Phone            nvarchar(max),
 @EMail            nvarchar(max),
 @Web              nvarchar(max),
 @StateId          nvarchar(2),
 @IsSystem         bit,
 @CreatedDate      datetime2(7),
 @CreatedBy        nvarchar(5),
 @LastModifiedDate datetime2(7),
 @LastModifiedBy   nvarchar(5)
)
AS
BEGIN
    INSERT INTO Company([KeyId], [Ruc], [Description], [Observation], [Address], [Agent], [Phone], [EMail], [Web], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy])
    VALUES(@KeyId, @Ruc, @Description, @Observation, @Address, @Agent, @Phone, @EMail, @Web, @StateId, @IsSystem, @CreatedDate, @CreatedBy, @LastModifiedDate, @LastModifiedBy);
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CompanyUpdate]
(
 @KeyId            nvarchar(5),
 @Ruc              nvarchar(max),
 @Description      nvarchar(max),
 @Observation      nvarchar(max),
 @Address          nvarchar(max),
 @Agent            nvarchar(max),
 @Phone            nvarchar(max),
 @EMail            nvarchar(max),
 @Web              nvarchar(max),
 @StateId          nvarchar(2),
 @IsSystem         bit,
 @CreatedDate      datetime2(7),
 @CreatedBy        nvarchar(5),
 @LastModifiedDate datetime2(7),
 @LastModifiedBy   nvarchar(5)
)
AS
BEGIN
  UPDATE Company
    SET
      [Ruc]              = @Ruc,
      [Description]      = @Description,
      [Observation]      = @Observation,
      [Address]          = @Address,
      [Agent]            = @Agent,
      [Phone]            = @Phone,
      [EMail]            = @EMail,
      [Web]              = @Web,
      [StateId]          = @StateId,
      [IsSystem]         = @IsSystem,
      [CreatedDate]      = @CreatedDate,
      [CreatedBy]        = @CreatedBy,
      [LastModifiedDate] = @LastModifiedDate,
      [LastModifiedBy]   = @LastModifiedBy
  WHERE KeyId = @KeyId;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CompanyDelete]
(@KeyId nvarchar(5))
AS
BEGIN
  DELETE Company
  WHERE KeyId = @KeyId;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CompanyGetByID]
(@KeyId nvarchar(5))
AS
BEGIN
  SELECT [KeyId], [Ruc], [Description], [Observation], [Address], [Agent], [Phone], [EMail], [Web], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM Company
  WHERE KeyId = @KeyId;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CompanyList]
AS
BEGIN
  SELECT [KeyId], [Ruc], [Description], [Observation], [Address], [Agent], [Phone], [EMail], [Web], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM Company;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CompanyListWithPagination]
(
  @PageNumber int,
  @PageSize   int
)
AS
BEGIN
  SELECT [KeyId], [Ruc], [Description], [Observation], [Address], [Agent], [Phone], [EMail], [Web], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM Company
  ORDER BY [Ruc], [Description]
  OFFSET (@PageNumber - 1) * @PageSize ROWS
  FETCH NEXT @PageSize ROWS ONLY
END
GO

---------------------------------------------------------------------------------------

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleInsert]
(
 @KeyId            nvarchar(5),
 @Name             nvarchar(max),
 @Description      nvarchar(max),
 @Observation      nvarchar(max),
 @StateId          nvarchar(2),
 @IsSystem         bit,
 @CreatedDate      datetime2(7),
 @CreatedBy        nvarchar(5),
 @LastModifiedDate datetime2(7),
 @LastModifiedBy   nvarchar(5)
)
AS
BEGIN
  INSERT INTO Role([KeyId], [Name], [Description], [Observation], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy])
  VALUES(@KeyId, @Name, @Description, @Observation, @StateId, @IsSystem, @CreatedDate, @CreatedBy, @LastModifiedDate, @LastModifiedBy);
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleUpdate]
(
 @KeyId            nvarchar(5),
 @Name             nvarchar(max),
 @Description      nvarchar(max),
 @Observation      nvarchar(max),
 @StateId          nvarchar(2),
 @IsSystem         bit,
 @CreatedDate      datetime2(7),
 @CreatedBy        nvarchar(5),
 @LastModifiedDate datetime2(7),
 @LastModifiedBy   nvarchar(5)
)
AS
BEGIN
  UPDATE [Role]
    SET
      [Name]             = @Name,
      [Description]      = @Description,
      [Observation]      = @Observation,
      [StateId]          = @StateId,
      [IsSystem]         = @IsSystem,
      [CreatedDate]      = @CreatedDate,
      [CreatedBy]        = @CreatedBy,
      [LastModifiedDate] = @LastModifiedDate,
      [LastModifiedBy]   = @LastModifiedBy
  WHERE KeyId = @KeyId;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleDelete]
(@KeyId nvarchar(5))
AS
BEGIN
  DELETE [Role]
  WHERE KeyId = @KeyId;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleGetByID]
(@KeyId nvarchar(5))
AS
BEGIN
  SELECT [KeyId], [Name], [Description], [Observation], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Role]
  WHERE KeyId = @KeyId;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleList]
AS
BEGIN
  SELECT [KeyId], [Name], [Description], [Observation], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Role];
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleListWithPagination]
(
  @PageNumber int,
  @PageSize   int
)
AS
BEGIN
  SELECT [KeyId], [Name], [Description], [Observation], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Role]
  ORDER BY [Name], [Description]
  OFFSET (@PageNumber - 1) * @PageSize ROWS
  FETCH NEXT @PageSize ROWS ONLY
END
GO



---------------------------------------------------------------------------------------

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserInsert]
(
 @KeyId            nvarchar(5),
 @UserName         nvarchar(450),
 @Password         nvarchar(max),
 @Description      nvarchar(max),
 @Observation      nvarchar(max),
 @Names            nvarchar(max),
 @Surnames         nvarchar(max),
 @Phone            nvarchar(max),
 @EMail            nvarchar(max),
 @Image            varbinary(max),
 @Token            nvarchar(max),
 @RoleId           nvarchar(5),
 @StateId          nvarchar(2),
 @IsSystem         bit,
 @CreatedDate      datetime2(7),
 @CreatedBy        nvarchar(5),
 @LastModifiedDate datetime2(7),
 @LastModifiedBy   nvarchar(5)
)
AS
BEGIN
  INSERT INTO [User]([KeyId], [UserName], [Password], [Description], [Observation], [Names], [Surnames], [Phone], [EMail], [Image], [Token], [RoleId], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy])
  VALUES(@KeyId, @UserName, @Password, @Description, @Observation, @Names, @Surnames, @Phone, @EMail, @Image, @Token, @RoleId, @StateId, @IsSystem, @CreatedDate, @CreatedBy, @LastModifiedDate, @LastModifiedBy);
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserUpdate]
(
 @KeyId            nvarchar(5),
 @UserName         nvarchar(450),
 @Password         nvarchar(max),
 @Description      nvarchar(max),
 @Observation      nvarchar(max),
 @Names            nvarchar(max),
 @Surnames         nvarchar(max),
 @Phone            nvarchar(max),
 @EMail            nvarchar(max),
 @Image            varbinary(max),
 @Token            nvarchar(max),
 @RoleId           nvarchar(5),
 @StateId          nvarchar(2),
 @IsSystem         bit,
 @CreatedDate      datetime2(7),
 @CreatedBy        nvarchar(5),
 @LastModifiedDate datetime2(7),
 @LastModifiedBy   nvarchar(5)
)
AS
BEGIN
  UPDATE [User]
    SET
      [UserName]         = @UserName,
      [Password]         = @Password,
      [Description]      = @Description,
      [Observation]      = @Observation,
      [Names]            = @Names,
      [Surnames]         = @Surnames,
      [Phone]            = @Phone,
      [EMail]            = @EMail,
      [Image]            = @Image,
      [Token]            = @Token,
      [RoleId]           = @RoleId,
      [StateId]          = @StateId,
      [IsSystem]         = @IsSystem,
      [CreatedDate]      = @CreatedDate,
      [CreatedBy]        = @CreatedBy,
      [LastModifiedDate] = @LastModifiedDate,
      [LastModifiedBy]   = @LastModifiedBy
  WHERE KeyId = @KeyId;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserDelete]
(@KeyId nvarchar(5))
AS
BEGIN
  DELETE [User]
  WHERE KeyId = @KeyId;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserGetByID]
(@KeyId nvarchar(5))
AS
BEGIN
  SELECT [KeyId], [UserName], [Password], [Description], [Observation], [Names], [Surnames], [Phone], [EMail], [Image], [Token], [RoleId], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [User]
  WHERE KeyId = @KeyId;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserList]
AS
BEGIN
  SELECT [KeyId], [UserName], [Password], [Description], [Observation], [Names], [Surnames], [Phone], [EMail], [Image], [Token], [RoleId], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [User];
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserListWithPagination]
(
  @PageNumber int,
  @PageSize   int
)
AS
BEGIN
  SELECT [KeyId], [UserName], [Password], [Description], [Observation], [Names], [Surnames], [Phone], [EMail], [Image], [Token], [RoleId], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [User]
  ORDER BY [UserName], [Description]
  OFFSET (@PageNumber - 1) * @PageSize ROWS
  FETCH NEXT @PageSize ROWS ONLY
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserGetByUserAndPassword]
(
  @UserName varchar(50),
  @Password varchar(50)
)
AS
BEGIN
    SELECT [KeyId], [UserName], [Password], [Description], [Observation], [Names], [Surnames], [Phone], [EMail], [Image], [Token], [RoleId], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
    FROM [User]
    WHERE UserName = @UserName and Password = DBO.EncryptString(@Password, '@');
END
GO



---------------------------------------------------------------------------------------


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StatusGetByID]
(@KeyId nvarchar(5))
AS
BEGIN
  SELECT [KeyId], [Name], [Description], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Status]
  WHERE KeyId = @KeyId;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StatusList]
AS
BEGIN
  SELECT [KeyId], [Name], [Description], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Status];
END
GO




---------------------------------------------------------------------------------------

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_x_CompanyInsert]
(
 @RoleId           nvarchar(5),
 @CompanyId        nvarchar(5),
 @StateId          nvarchar(2),
 @IsSystem         bit,
 @CreatedDate      datetime2(7),
 @CreatedBy        nvarchar(5),
 @LastModifiedDate datetime2(7),
 @LastModifiedBy   nvarchar(5)
)
AS
BEGIN
  INSERT INTO [Role_x_Company] ([RoleId], [CompanyId], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy])
  VALUES(@RoleId, @CompanyId, @StateId, @IsSystem, @CreatedDate, @CreatedBy, @LastModifiedDate, @LastModifiedBy);
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_x_CompanyUpdate]
(
 @RoleId           nvarchar(5),
 @CompanyId        nvarchar(5),
 @StateId          nvarchar(2),
 @IsSystem         bit,
 @CreatedDate      datetime2(7),
 @CreatedBy        nvarchar(5),
 @LastModifiedDate datetime2(7),
 @LastModifiedBy   nvarchar(5)
)
AS
BEGIN
  UPDATE [Role_x_Company]
    SET
      [StateId]          = @StateId,
      [IsSystem]         = @IsSystem,
      [CreatedDate]      = @CreatedDate,
      [CreatedBy]        = @CreatedBy,
      [LastModifiedDate] = @LastModifiedDate,
      [LastModifiedBy]   = @LastModifiedBy
  WHERE [RoleId] = @RoleId and [CompanyId] = @CompanyId;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_x_CompanyDelete]
(
 @RoleId           nvarchar(5),
 @CompanyId        nvarchar(5)
)
AS
BEGIN
  DELETE [Role_x_Company]
  WHERE [RoleId] = @RoleId and [CompanyId] = @CompanyId;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_x_CompanyGetByID]
(
 @RoleId           nvarchar(5),
 @CompanyId        nvarchar(5)
)
AS
BEGIN
  SELECT [RoleId], [CompanyId], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Role_x_Company]
  WHERE [RoleId] = @RoleId and [CompanyId] = @CompanyId;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_x_CompanyList]
AS
BEGIN
  SELECT [RoleId], [CompanyId], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Role_x_Company];
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_x_CompanyListWithPagination]
(
  @PageNumber int,
  @PageSize   int
)
AS
BEGIN
  SELECT [RoleId], [CompanyId], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Role_x_Company]
  ORDER BY [RoleId], [CompanyId]
  OFFSET (@PageNumber - 1) * @PageSize ROWS
  FETCH NEXT @PageSize ROWS ONLY
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserGetByUserAndPassword]
(
  @UserName varchar(50),
  @Password varchar(50)
)
AS
BEGIN
    SELECT [KeyId], [UserName], [Password], [Description], [Observation], [Names], [Surnames], [Phone], [EMail], [Image], [Token], [RoleId], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
    FROM [User]
    WHERE UserName = @UserName and Password = DBO.EncryptString(@Password, '@');
END
GO


