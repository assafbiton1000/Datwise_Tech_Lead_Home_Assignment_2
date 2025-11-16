																																									  -- create_schema.sql
SET NOCOUNT ON;

-- יצירת טבלה למשתמשים
IF OBJECT_ID('dbo.Users','U') IS NOT NULL DROP TABLE dbo.Users;
CREATE TABLE dbo.Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Email NVARCHAR(256) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL, -- לשימוש פשוט: SHA256 או hash דומה (כדאי לאחסן salt)
    FullName NVARCHAR(200) NULL,
    Role NVARCHAR(50) NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
CREATE INDEX IX_Users_Email ON dbo.Users(Email);

-- טבלה לדוגמה לדוחות / נתונים
IF OBJECT_ID('dbo.ReportsData','U') IS NOT NULL DROP TABLE dbo.ReportsData;
CREATE TABLE dbo.ReportsData (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Category NVARCHAR(100) NOT NULL,
    Region NVARCHAR(100) NULL,
    ValueAmount DECIMAL(18,2) NOT NULL,
    EventDate DATE NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
CREATE INDEX IX_ReportsData_EventDate ON dbo.ReportsData(EventDate);
CREATE INDEX IX_ReportsData_Category ON dbo.ReportsData(Category);

-- טבלת Audit (פשטות)
IF OBJECT_ID('dbo.AuditLog','U') IS NOT NULL DROP TABLE dbo.AuditLog;
CREATE TABLE dbo.AuditLog (
    AuditId INT IDENTITY(1,1) PRIMARY KEY,
    UserEmail NVARCHAR(256) NULL,
    Action NVARCHAR(200) NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);