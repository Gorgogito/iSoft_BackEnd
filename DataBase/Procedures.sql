CREATE PROCEDURE [master].[StatusGetByID]
(@KeyId varchar(005))
AS
BEGIN
  SELECT [KeyId], [Name], [Description], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [master].[Status]
  WHERE KeyId = @KeyId;
END
GO

CREATE PROCEDURE [master].[StatusList]
AS
BEGIN
  SELECT [KeyId], [Name], [Description], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [master].[Status];
END
GO

---------------------------------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [identy].[UserInsert]
(
 @KeyId            varchar(005),
 @UserName         varchar(100),
 @Password         varchar(100),
 @Description      varchar(250),
 @Observation      varchar(250),
 @Names            varchar(100),
 @Surnames         varchar(100),
 @Phone            varchar(100),
 @EMail            varchar(250),
 @Image            varbinary(max),
 @RoleId           varchar(005),
 @StateId          varchar(002),
 @IsSystem         bit,
 @CreatedDate      datetime,
 @CreatedBy        varchar(005)
)
AS
BEGIN
  INSERT INTO [identy].[User]([KeyId], [UserName], [Password], [Description], [Observation], [Names], [Surnames], [Phone], [EMail], [Image], [RoleId], [StateId], [IsSystem], [CreatedDate], [CreatedBy])
  VALUES(@KeyId, @UserName, @Password, @Description, @Observation, @Names, @Surnames, @Phone, @EMail, @Image, @RoleId, @StateId, @IsSystem, @CreatedDate, @CreatedBy);
END
GO

CREATE PROCEDURE [identy].[UserUpdate]
(
 @KeyId            varchar(005),
 @UserName         varchar(100),
 @Password         varchar(100),
 @Description      varchar(250),
 @Observation      varchar(250),
 @Names            varchar(100),
 @Surnames         varchar(100),
 @Phone            varchar(100),
 @EMail            varchar(250),
 @Image            varbinary(max),
 @RoleId           varchar(005),
 @StateId          varchar(002),
 @IsSystem         bit,
 @LastModifiedDate datetime,
 @LastModifiedBy   varchar(005)
)
AS
BEGIN
  UPDATE [identy].[User]
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
      [RoleId]           = @RoleId,
      [StateId]          = @StateId,
      [IsSystem]         = @IsSystem,
      [LastModifiedDate] = @LastModifiedDate,
      [LastModifiedBy]   = @LastModifiedBy
  WHERE KeyId = @KeyId;
END
GO

CREATE PROCEDURE [identy].[UserDelete]
(@KeyId varchar(005))
AS
BEGIN
  DELETE [identy].[User]
  WHERE KeyId = @KeyId;
END
GO

CREATE PROCEDURE [identy].[UserList]
AS
BEGIN
  SELECT [KeyId], [UserName], [Password], [Description], [Observation], [Names], [Surnames], [Phone], [EMail], [Image], [RoleId], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [identy].[User];
END
GO

CREATE PROCEDURE [identy].[UserListWithPagination]
(
  @PageNumber int,
  @PageSize   int
)
AS
BEGIN
  SELECT [KeyId], [UserName], [Password], [Description], [Observation], [Names], [Surnames], [Phone], [EMail], [Image], [RoleId], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [identy].[User]
  ORDER BY [UserName], [Description]
  OFFSET (@PageNumber - 1) * @PageSize ROWS
  FETCH NEXT @PageSize ROWS ONLY
END
GO

CREATE PROCEDURE [identy].[UserGetByID]
(@KeyId varchar(005))
AS
BEGIN
  SELECT [KeyId], [UserName], [Password], [Description], [Observation], [Names], [Surnames], [Phone], [EMail], [Image], [RoleId], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [identy].[User]
  WHERE KeyId = @KeyId;
END
GO

CREATE PROCEDURE [identy].[UserGetByUserAndPassword]
(
  @UserName varchar(50),
  @Password varchar(50)
)
AS
BEGIN
    SELECT [KeyId], [UserName], [Password], [Description], [Names], [Surnames], [Phone], [EMail], [Image], [Token], [RoleId], [StateId], [IsSystem]
    FROM [identy].[User]
    WHERE UserName = @UserName and Password = [process].EncryptString(@Password, '@');
END
GO

---------------------------------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [identy].[RoleInsert]
(
 @KeyId            varchar(005),
 @Name             varchar(100),
 @Description      varchar(250),
 @Observation      varchar(250),
 @StateId          varchar(002),
 @IsSystem         bit,
 @CreatedDate      datetime,
 @CreatedBy        varchar(005)
)
AS
BEGIN
  INSERT INTO [identy].[Role]([KeyId], [Name], [Description], [Observation], [StateId], [IsSystem], [CreatedDate], [CreatedBy])
  VALUES(@KeyId, @Name, @Description, @Observation, @StateId, @IsSystem, @CreatedDate, @CreatedBy);
END
GO

CREATE PROCEDURE [identy].[RoleUpdate]
(
 @KeyId            varchar(005),
 @Name             varchar(100),
 @Description      varchar(250),
 @Observation      varchar(250),
 @StateId          varchar(002),
 @IsSystem         bit,
 @LastModifiedDate datetime,
 @LastModifiedBy   varchar(005)
)
AS
BEGIN
  UPDATE [identy].[Role]
    SET
      [Name]             = @Name,
      [Description]      = @Description,
      [Observation]      = @Observation,
      [StateId]          = @StateId,
      [IsSystem]         = @IsSystem,
      [LastModifiedDate] = @LastModifiedDate,
      [LastModifiedBy]   = @LastModifiedBy
  WHERE KeyId = @KeyId;
END
GO

CREATE PROCEDURE [identy].[RoleDelete]
(@KeyId varchar(005))
AS
BEGIN
  DELETE [identy].[Role]
  WHERE KeyId = @KeyId;
END
GO

CREATE PROCEDURE [identy].[RoleList]
AS
BEGIN
  SELECT [KeyId], [Name], [Description], [Observation], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [identy].[Role];
END
GO

CREATE PROCEDURE [identy].[RoleListWithPagination]
(
  @PageNumber int,
  @PageSize   int
)
AS
BEGIN
  SELECT [KeyId], [Name], [Description], [Observation], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [identy].[Role]
  ORDER BY [Name], [Description]
  OFFSET (@PageNumber - 1) * @PageSize ROWS
  FETCH NEXT @PageSize ROWS ONLY
END
GO

CREATE PROCEDURE [identy].[RoleGetByID]
(@KeyId varchar(005))
AS
BEGIN
  SELECT [KeyId], [Name], [Description], [Observation], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [identy].[Role]
  WHERE KeyId = @KeyId;
END
GO

---------------------------------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [master].[CompanyInsert]
(
 @KeyId            varchar(005),
 @Ruc              varchar(020),
 @Description      varchar(250),
 @Observation      varchar(250),
 @Address          varchar(250),
 @Agent            varchar(250),
 @Phone            varchar(100),
 @EMail            varchar(250),
 @Web              varchar(500),
 @StateId          varchar(002),
 @IsSystem         bit,
 @CreatedDate      datetime,
 @CreatedBy        varchar(05)
)
AS
BEGIN
    INSERT INTO [master].Company([KeyId], [Ruc], [Description], [Observation], [Address], [Agent], [Phone], [EMail], [Web], [StateId], [IsSystem], [CreatedDate], [CreatedBy])
    VALUES(@KeyId, @Ruc, @Description, @Observation, @Address, @Agent, @Phone, @EMail, @Web, @StateId, @IsSystem, @CreatedDate, @CreatedBy);
END
GO

CREATE PROCEDURE [master].[CompanyUpdate]
(
 @KeyId            varchar(005),
 @Ruc              varchar(020),
 @Description      varchar(250),
 @Observation      varchar(250),
 @Address          varchar(250),
 @Agent            varchar(250),
 @Phone            varchar(100),
 @EMail            varchar(250),
 @Web              varchar(500),
 @StateId          varchar(002),
 @IsSystem         bit,
 @LastModifiedDate datetime,
 @LastModifiedBy   varchar(005)
)
AS
BEGIN
  UPDATE [master].[Company]
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
      [LastModifiedDate] = @LastModifiedDate,
      [LastModifiedBy]   = @LastModifiedBy
  WHERE KeyId=@KeyId;
END
GO

CREATE PROCEDURE [master].[CompanyDelete]
(@KeyId varchar(005))
AS
BEGIN
  DELETE [master].[Company]
  WHERE KeyId = @KeyId;
END
GO

CREATE PROCEDURE [master].[CompanyList]
AS
BEGIN
  SELECT [KeyId], [Ruc], [Description], [Observation], [Address], [Agent], [Phone], [EMail], [Web], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [master].[Company];
END
GO

CREATE PROCEDURE [master].[CompanyListWithPagination]
(
  @PageNumber int,
  @PageSize   int
)
AS
BEGIN
  SELECT [KeyId], [Ruc], [Description], [Observation], [Address], [Agent], [Phone], [EMail], [Web], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [master].[Company]
  ORDER BY [Ruc], [Description]
  OFFSET (@PageNumber - 1) * @PageSize ROWS
  FETCH NEXT @PageSize ROWS ONLY
END
GO

CREATE PROCEDURE [master].[CompanyGetByID]
(@KeyId varchar(005))
AS
BEGIN
  SELECT [KeyId], [Ruc], [Description], [Observation], [Address], [Agent], [Phone], [EMail], [Web], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [master].[Company]
  WHERE KeyId = @KeyId;
END
GO

---------------------------------------------------------------------------------------------------------------------------------------------------
 
CREATE PROCEDURE [identy].[Role_x_CompanyInsert]
(
 @RoleId           varchar(005),
 @CompanyId        varchar(005),
 @StateId          varchar(002),
 @IsSystem         bit,
 @CreatedDate      datetime,
 @CreatedBy        varchar(005)
)
AS
BEGIN
  INSERT INTO [identy].[Role_x_Company] ([RoleId], [CompanyId], [StateId], [IsSystem], [CreatedDate], [CreatedBy])
  VALUES(@RoleId, @CompanyId, @StateId, @IsSystem, @CreatedDate, @CreatedBy);
END
GO

CREATE PROCEDURE [identy].[Role_x_CompanyUpdate]
(
 @RoleId           varchar(005),
 @CompanyId        varchar(005),
 @StateId          varchar(002),
 @IsSystem         bit,
 @LastModifiedDate datetime,
 @LastModifiedBy   varchar(005)
)
AS
BEGIN
  UPDATE [identy].[Role_x_Company]
    SET
      [StateId]          = @StateId,
      [IsSystem]         = @IsSystem,
      [LastModifiedDate] = @LastModifiedDate,
      [LastModifiedBy]   = @LastModifiedBy
  WHERE [RoleId] = @RoleId and [CompanyId] = @CompanyId;
END
GO

CREATE PROCEDURE [identy].[Role_x_CompanyDelete]
(
 @RoleId     varchar(005),
 @CompanyId  varchar(005)
)
AS
BEGIN
  DELETE [identy].[Role_x_Company]
  WHERE [RoleId] = @RoleId and [CompanyId] = @CompanyId;
END
GO

CREATE PROCEDURE [identy].[Role_x_CompanyList]
AS
BEGIN
  SELECT [RoleId], [CompanyId], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [identy].[Role_x_Company];
END
GO

CREATE PROCEDURE [identy].[Role_x_CompanyListWithPagination]
(
  @PageNumber int,
  @PageSize   int
)
AS
BEGIN
  SELECT [RoleId], [CompanyId], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [identy].[Role_x_Company]
  ORDER BY [RoleId], [CompanyId]
  OFFSET (@PageNumber - 1) * @PageSize ROWS
  FETCH NEXT @PageSize ROWS ONLY
END
GO

CREATE PROCEDURE [identy].[Role_x_CompanyGetByID]
(
 @RoleId    varchar(005),
 @CompanyId varchar(005)
)
AS
BEGIN
  SELECT [RoleId], [CompanyId], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [identy].[Role_x_Company]
  WHERE [RoleId] = @RoleId and [CompanyId] = @CompanyId;
END
GO