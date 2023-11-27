create table [dbo].[Item] (
    [Id]            uniqueidentifier    not null    default(newSequentialId())  primary key clustered,
    [InventoryId]   uniqueidentifier    null        foreign key references [dbo].[Inventory]([Id]),
    [Name]          nvarchar(255)       not null,
    [Description]   nvarchar(2000)      not null,
    [RequiredLevel] int                 not null,
    [PowerLevel]    int                 not null,
    [Weight]        decimal             not null,
    [Rarity]        tinyint             not null,
    [Slot]          tinyint             not null
);