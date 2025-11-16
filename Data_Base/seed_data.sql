																																														   -- seed_data.sql
-- נתוני דמה עבור Datwise

USE DatwiseDB; -- ודא שאתה על DB הנכון

-- לדוגמה: הוספת משתמש admin
-- NOTE: כאן אנו מאחסנים hash בסיסי (SHA256) של הסיסמה 'P@ssw0rd!' - להכניס salt בפרויקט אמיתי
IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Email = 'admin@datwise.com')
BEGIN
    INSERT INTO dbo.Users (Email, PasswordHash, FullName, Role)
    VALUES ('admin@datwise.com', HASHBYTES('SHA2_256', CONVERT(VARBINARY(256),'P@ssw0rd!')), 'Admin Datwise', 'Admin');
END

-- הוספת נתוני דמה ל-RepostsData
SET NOCOUNT ON;
DECLARE @i INT = 1;
WHILE @i <= 200
BEGIN
    INSERT INTO dbo.ReportsData (Category, Region, ValueAmount, EventDate)
    VALUES (
        CASE WHEN @i % 3 = 0 THEN 'Sales' WHEN @i % 3 = 1 THEN 'Marketing' ELSE 'Ops' END,
        CASE WHEN @i % 4 = 0 THEN 'North' WHEN @i % 4 = 1 THEN 'South' WHEN @i % 4 = 2 THEN 'East' ELSE 'West' END,
        ROUND(RAND(CHECKSUM(NEWID())) * 10000, 2),
        DATEADD(day, -(@i % 60), CAST(GETDATE() AS DATE))
    );
    SET @i = @i + 1;
END