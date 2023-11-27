create table [dbo].[Character] (
    [Id]        uniqueidentifier    not null    default(newSequentialId())  primary key clustered,
    [UserId]    uniqueidentifier    not null    foreign key references [dbo].[User]([Id]),
    [Name]      nvarchar(255)       not null,
    [Level]     int                 not null
);