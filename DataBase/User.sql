USE MASTER;
GO
CREATE LOGIN iSoft   
    WITH PASSWORD = 'iSoft';  
GO  

-- Crear usuario iSoft para el login iSoft.
CREATE USER iSoft FOR LOGIN iSoft;  
GO  


GRANT BACKUP DATABASE TO [iSoft];
GO

GRANT CREATE DATABASE TO [iSoft];
GO

GRANT ALTER SERVER STATE TO [iSoft];
GO

--- CREAR BASE DE DATOS


USE iSoft_Master;
go

CREATE USER iSoft FOR LOGIN iSoft;  
GO  



GRANT ALTER TO [iSoft];
GO
GRANT CREATE TABLE TO [iSoft];
GO
GRANT SELECT TO [iSoft]
GO
GRANT EXECUTE ON SCHEMA ::dbo TO [iSoft]
GO

ALTER ROLE [db_datareader] ADD MEMBER [iSoft];
GO

ALTER ROLE [db_datawriter] ADD MEMBER [iSoft];
GO


--- LOGUEARSE CON iSoft