
CREATE SCHEMA [process];
GO

/*
SELECT DBO.EncryptString('123456789', '@')

SELECT DBO.DecryptString('±²³´µ¶·¸¹', '@')
*/

CREATE FUNCTION [process].[EncryptString](@Text VARCHAR(250), @Key VARCHAR(025))
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

CREATE FUNCTION [process].[DecryptString](@Text VARCHAR(250), @Key VARCHAR(025))
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
