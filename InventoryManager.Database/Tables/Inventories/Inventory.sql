create table [dbo].[Inventory] (
    [Id]            uniqueidentifier    not null    default(newSequentialId())  primary key clustered,
    [CharacterId]   uniqueidentifier    not null    foreign key references [dbo].[Character]([Id]),
    [Type]          tinyint             not null
);