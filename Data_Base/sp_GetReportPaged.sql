																																											-- sp_GetReportPaged.sql
-- Stored Procedure שמחזירה רשומות מדוח עם Paging ו-TotalCount

CREATE OR ALTER PROCEDURE dbo.sp_GetReportPaged
    @PageNumber INT = 1,
    @PageSize INT = 20,
    @CategoryFilter NVARCHAR(100) = NULL,
    @RegionFilter NVARCHAR(100) = NULL,
    @FromDate DATE = NULL,
    @ToDate DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;

    ;WITH Filtered AS (
        SELECT Id, Category, Region, ValueAmount, EventDate
        FROM dbo.ReportsData
        WHERE (@CategoryFilter IS NULL OR Category = @CategoryFilter)
          AND (@RegionFilter IS NULL OR Region = @RegionFilter)
          AND (@FromDate IS NULL OR EventDate >= @FromDate)
          AND (@ToDate IS NULL OR EventDate <= @ToDate)
    )
    SELECT COUNT(1) AS TotalCount INTO #TmpCount FROM Filtered;

    SELECT f.Id, f.Category, f.Region, f.ValueAmount, f.EventDate
    FROM Filtered f
    ORDER BY f.EventDate DESC, f.Id DESC
    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;

    SELECT TotalCount FROM #TmpCount;

END