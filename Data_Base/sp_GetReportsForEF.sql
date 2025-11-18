USE [DatwiseDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetReportsForEF]    Script Date: 18/11/2025 20:16:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_GetReportsForEF]
    @CategoryFilter NVARCHAR(100) = NULL,
    @RegionFilter NVARCHAR(100) = NULL,
    @FromDate DATE = NULL,
    @ToDate DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Category, Region, ValueAmount, EventDate
    FROM dbo.ReportsData
    WHERE (@CategoryFilter IS NULL OR Category = @CategoryFilter)
      AND (@RegionFilter IS NULL OR Region = @RegionFilter)
      AND (@FromDate IS NULL OR EventDate >= @FromDate)
      AND (@ToDate IS NULL OR EventDate <= @ToDate)
    ORDER BY EventDate DESC, Id DESC;
END