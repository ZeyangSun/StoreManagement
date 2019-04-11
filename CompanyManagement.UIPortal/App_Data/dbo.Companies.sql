USE [CompanyMag]
GO

/****** Object: Table [dbo].[Companies] Script Date: 4/3/2019 8:01:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Companies] (
    [Id]                 UNIQUEIDENTIFIER NOT NULL,
    [Name]               NVARCHAR (255)   NOT NULL,
    [OrganizationNumber] INT              NOT NULL,
    [Notes]              NVARCHAR (MAX)   NULL
);


