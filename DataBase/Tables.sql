CREATE SCHEMA [master];
GO
CREATE SCHEMA [identy];
GO
GO

CREATE TABLE [master].[Status]
(
  [KeyId]            varchar(002) NOT NULL,
  [Name]             varchar(025) NOT NULL,
  [Description]      varchar(250) NOT NULL,
  [StateId]          varchar(002) NOT NULL,
  [IsSystem]         bit NOT NULL,
  [CreatedDate]      datetime NOT NULL,
  [CreatedBy]        varchar(005) NOT NULL,
  [LastModifiedDate] datetime NULL,
  [LastModifiedBy]   varchar(005) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
([KeyId] ASC
 )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [identy].[User](
  [KeyId]            varchar(005) NOT NULL,
  [UserName]         varchar(100) NOT NULL,
  [Password]         varchar(100) NOT NULL,
  [Description]      varchar(250) NOT NULL,
  [Observation]      varchar(250) NULL,
  [Names]            varchar(100) NULL,
  [Surnames]         varchar(100) NULL,
  [Phone]            varchar(100) NULL,
  [EMail]            varchar(250) NULL,
  [Image]            varbinary(max) NULL,
  [Token]            varchar(500) NULL,
  [RoleId]           varchar(005) NOT NULL,
  [StateId]          varchar(002) NOT NULL,
  [IsSystem]         bit NOT NULL,
  [CreatedDate]      datetime NOT NULL,
  [CreatedBy]        varchar(005) NOT NULL,
  [LastModifiedDate] datetime NULL,
  [LastModifiedBy]   varchar(005) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
([KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [identy].[Role]
(
  [KeyId]            varchar(005) NOT NULL,
  [Name]             varchar(100) NOT NULL,
  [Description]      varchar(250) NOT NULL,
  [Observation]      varchar(250) NULL,
  [StateId]          varchar(002) NOT NULL,
  [IsSystem]         bit NOT NULL,
  [CreatedDate]      datetime NOT NULL,
  [CreatedBy]        varchar(005) NOT NULL,
  [LastModifiedDate] datetime NULL,
  [LastModifiedBy]   varchar(005) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
([KeyId] ASC
 )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [master].[Company]
(
  [KeyId]            varchar(005) NOT NULL,
  [Ruc]              varchar(020) NOT NULL,
  [Description]      varchar(250) NOT NULL,
  [Observation]      varchar(250) NULL,
  [Address]          varchar(250) NULL,
  [Agent]            varchar(250) NULL,
  [Phone]            varchar(100) NULL,
  [EMail]            varchar(250) NULL,
  [Web]              varchar(500) NULL,
  [StateId]          varchar(002) NOT NULL,
  [IsSystem]         bit NOT NULL,
  [CreatedDate]      datetime NOT NULL,
  [CreatedBy]        varchar(005) NOT NULL,
  [LastModifiedDate] datetime NULL,
  [LastModifiedBy]   varchar(005) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
([KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [identy].[Role_x_Company]
(
  [RoleId]           varchar(005) NOT NULL,
  [CompanyId]        varchar(005) NOT NULL,
  [StateId]          varchar(002) NOT NULL,
  [IsSystem]         bit NOT NULL,
  [CreatedDate]      datetime NOT NULL,
  [CreatedBy]        varchar(005) NOT NULL,
  [LastModifiedDate] datetime NULL,
  [LastModifiedBy]   varchar(005) NULL,
 CONSTRAINT [PK_Role_x_Company] PRIMARY KEY CLUSTERED 
 ([RoleId] ASC, [CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [identy].[Role_x_Company]  WITH CHECK ADD  CONSTRAINT [FK_Role_x_Company_Company_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [master].[Company] ([KeyId])
ON DELETE CASCADE
GO

ALTER TABLE [identy].[Role_x_Company] CHECK CONSTRAINT [FK_Role_x_Company_Company_CompanyId]
GO

ALTER TABLE [identy].[Role_x_Company]  WITH CHECK ADD  CONSTRAINT [FK_Role_x_Company_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [identy].[Role] ([KeyId])
ON DELETE CASCADE
GO

ALTER TABLE [identy].[Role_x_Company] CHECK CONSTRAINT [FK_Role_x_Company_Role_RoleId]
GO

