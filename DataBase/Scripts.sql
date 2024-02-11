
INSERT INTO [identy].[Role]
([KeyId], [Name], [Description], [Observation], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy])
SELECT '00001', 'ADMINISTRADORES', 'Rol de Asdministradores', '', '01', 1, GETDATE(), '00000', GETDATE(), '00000'
UNION ALL
SELECT '00002', 'USUARIOS', 'Rol de Usuarios', '', '01', 1, GETDATE(), '00000', GETDATE(), '00000';
GO

INSERT INTO [identy].[User]
([KeyId], [UserName], [Password], [Description], [Observation], [Names], [Surnames], [Phone], [EMail], [Image], [RoleId], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy])
SELECT '00000', 'ADMIN', '±²³´µ¶·¸¹', 'AMINISTRADOR', 'Usuario Administrador', 'ADMIN', '', '0', '@', NULL, '00001', '01', 1, GETDATE(), '00000', GETDATE(), '00000';
GO

INSERT INTO [master].[Status]
([KeyId], [Name], [Description], [StateId], [IsSystem], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy])
SELECT
'01', 'ACTIVO', 'Estado activo', '01', 1, GETDATE(), '00000', GETDATE(), '00000'
UNION ALL
SELECT
'99', 'INACTIVO', 'Estado inactivo', '01', 1, GETDATE(), '00000', GETDATE(), '00000';
GO

