IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Clientes] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Cidade] nvarchar(max) NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
);

CREATE TABLE [Produtos] (
    [Id] int NOT NULL IDENTITY,
    [DescProduto] nvarchar(max) NOT NULL,
    [ValorUnt] real NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id])
);

CREATE TABLE [Vendas] (
    [Id] int NOT NULL IDENTITY,
    [IdCliente] int NOT NULL,
    [ClienteId] int NULL,
    [IdProduto] int NOT NULL,
    [ProdutoId] int NULL,
    [QtdVenda] int NOT NULL,
    [ValorUntVenda] int NOT NULL,
    [DataVenda] datetime2 NOT NULL,
    [ValorVenda] real NOT NULL,
    CONSTRAINT [PK_Vendas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Vendas_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id]),
    CONSTRAINT [FK_Vendas_Produtos_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [Produtos] ([Id])
);

CREATE INDEX [IX_Vendas_ClienteId] ON [Vendas] ([ClienteId]);

CREATE INDEX [IX_Vendas_ProdutoId] ON [Vendas] ([ProdutoId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250206141837_UpdateArchives', N'9.0.1');

ALTER TABLE [Vendas] DROP CONSTRAINT [FK_Vendas_Clientes_ClienteId];

ALTER TABLE [Vendas] DROP CONSTRAINT [FK_Vendas_Produtos_ProdutoId];

DECLARE @var sysname;
SELECT @var = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Vendas]') AND [c].[name] = N'ValorUntVenda');
IF @var IS NOT NULL EXEC(N'ALTER TABLE [Vendas] DROP CONSTRAINT [' + @var + '];');
ALTER TABLE [Vendas] DROP COLUMN [ValorUntVenda];

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Vendas]') AND [c].[name] = N'ValorVenda');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Vendas] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Vendas] DROP COLUMN [ValorVenda];

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Produtos]') AND [c].[name] = N'ValorUnt');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Produtos] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Produtos] DROP COLUMN [ValorUnt];

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Clientes]') AND [c].[name] = N'Nome');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Clientes] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Clientes] DROP COLUMN [Nome];

EXEC sp_rename N'[Vendas].[QtdVenda]', N'qtdVenda', 'COLUMN';

EXEC sp_rename N'[Vendas].[IdProduto]', N'idProduto', 'COLUMN';

EXEC sp_rename N'[Vendas].[ProdutoId]', N'ProdutoidProduto', 'COLUMN';

EXEC sp_rename N'[Vendas].[DataVenda]', N'dthVenda', 'COLUMN';

EXEC sp_rename N'[Vendas].[ClienteId]', N'ClienteIdCliente', 'COLUMN';

EXEC sp_rename N'[Vendas].[Id]', N'idVenda', 'COLUMN';

EXEC sp_rename N'[Vendas].[IX_Vendas_ProdutoId]', N'IX_Vendas_ProdutoidProduto', 'INDEX';

EXEC sp_rename N'[Vendas].[IX_Vendas_ClienteId]', N'IX_Vendas_ClienteIdCliente', 'INDEX';

EXEC sp_rename N'[Produtos].[DescProduto]', N'dscProduto', 'COLUMN';

EXEC sp_rename N'[Produtos].[Id]', N'idProduto', 'COLUMN';

EXEC sp_rename N'[Clientes].[Id]', N'IdCliente', 'COLUMN';

ALTER TABLE [Vendas] ADD [vlrUnitarioVenda] decimal(18,4) NOT NULL DEFAULT 0.0;

ALTER TABLE [Produtos] ADD [vlrUnitario] decimal(18,4) NOT NULL DEFAULT 0.0;

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Clientes]') AND [c].[name] = N'Cidade');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Clientes] DROP CONSTRAINT [' + @var4 + '];');
UPDATE [Clientes] SET [Cidade] = N'' WHERE [Cidade] IS NULL;
ALTER TABLE [Clientes] ALTER COLUMN [Cidade] nvarchar(max) NOT NULL;
ALTER TABLE [Clientes] ADD DEFAULT N'' FOR [Cidade];

ALTER TABLE [Clientes] ADD [nmCliente] nvarchar(max) NOT NULL DEFAULT N'';

ALTER TABLE [Vendas] ADD CONSTRAINT [FK_Vendas_Clientes_ClienteIdCliente] FOREIGN KEY ([ClienteIdCliente]) REFERENCES [Clientes] ([IdCliente]);

ALTER TABLE [Vendas] ADD CONSTRAINT [FK_Vendas_Produtos_ProdutoidProduto] FOREIGN KEY ([ProdutoidProduto]) REFERENCES [Produtos] ([idProduto]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250206193530_MigrationCreate', N'9.0.1');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250206194233_MigrationCreation', N'9.0.1');

COMMIT;
GO

