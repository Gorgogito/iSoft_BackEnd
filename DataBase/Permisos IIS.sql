exec sp_grantlogin 'IIS APPPOOL\iSoft'
use iSoft_Master
exec sp_grantdbaccess 'IIS APPPOOL\iSoft'


GRANT ALTER TO [IIS APPPOOL\iSoft];
GO
GRANT CREATE TABLE TO [IIS APPPOOL\iSoft];
GO
GRANT SELECT TO [IIS APPPOOL\iSoft]
GO
GRANT EXECUTE ON SCHEMA ::dbo TO [IIS APPPOOL\iSoft]
GO


DECLARE @SCHEMA VARCHAR(500), @NAME VARCHAR(500)

DECLARE RUTINAS_CUR CURSOR FOR   
SELECT SPECIFIC_SCHEMA, ROUTINE_NAME FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_TYPE IN ('PROCEDURE', 'FUNCTION')
ORDER BY ROUTINE_TYPE, SPECIFIC_SCHEMA, ROUTINE_NAME;

OPEN RUTINAS_CUR  
  
FETCH NEXT FROM RUTINAS_CUR   
INTO @SCHEMA, @NAME;
  
WHILE @@FETCH_STATUS = 0
BEGIN
  
  EXEC ('GRANT EXECUTE ON OBJECT::[' + @SCHEMA + '].[' + @NAME + ']
        TO [IIS APPPOOL\iSoft];');

  --PRINT 'GRANT EXECUTE ON OBJECT::[' + @SCHEMA + '].[' + @NAME + ']
  --      TO [IIS APPPOOL\iSoft];'  

  FETCH NEXT FROM RUTINAS_CUR   
  INTO @SCHEMA, @NAME;
END
CLOSE RUTINAS_CUR;
DEALLOCATE RUTINAS_CUR;
