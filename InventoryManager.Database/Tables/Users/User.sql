create table [dbo].[User] (
    [Id]        uniqueidentifier    not null    default(newSequentialId())  primary key clustered,
    [Email]     nvarchar(555)       not null    unique nonclustered,
    [Password]  nvarchar(255)       not null
);