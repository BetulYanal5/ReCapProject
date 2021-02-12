CREATE TABLE [dbo].[Cars] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [BrandId]     INT           NOT NULL,
    [ColorId]     INT           NOT NULL,
    [ModelYear]   INT           NOT NULL,
    [DailyPrice]  MONEY         NOT NULL,
    [Description] NVARCHAR (25) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Cars_ToTable] FOREIGN KEY ([BrandId]) REFERENCES [Brands]([BrandId]), 
    CONSTRAINT [FK_Cars_ToTable_1] FOREIGN KEY ([ColorId]) REFERENCES [Colors]([ColorId])
);

