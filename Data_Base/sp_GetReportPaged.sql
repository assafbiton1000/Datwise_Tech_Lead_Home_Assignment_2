USE [DatwiseDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetReportPaged]    Script Date: 18/11/2025 20:15:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_GetReportPaged]
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

    -- ספירה כללית
    SELECT COUNT(*) AS TotalCount
    FROM dbo.ReportsData
    WHERE (@CategoryFilter IS NULL OR Category = @CategoryFilter)
      AND (@RegionFilter IS NULL OR Region = @RegionFilter)
      AND (@FromDate IS NULL OR EventDate >= @FromDate)
      AND (@ToDate IS NULL OR EventDate <= @ToDate);

    -- רשומות העמוד המבוקש
    SELECT Id, Category, Region, ValueAmount, EventDate
    FROM dbo.ReportsData
    WHERE (@CategoryFilter IS NULL OR Category = @CategoryFilter)
      AND (@RegionFilter IS NULL OR Region = @RegionFilter)
      AND (@FromDate IS NULL OR EventDate >= @FromDate)
      AND (@ToDate IS NULL OR EventDate <= @ToDate)
    ORDER BY EventDate DESC, Id DESC
    OFFSET @Offset ROWS
    FETCH NEXT @PageSize ROWS ONLY;
END;