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
CREATE TABLE [dbo].[Teacher] (
    [DocumentNumber] varchar(20) NOT NULL,
    [Mobile] varchar(20) NOT NULL,
    [Firstname] varchar(50) NOT NULL,
    [Lastname] varchar(50) NOT NULL,
    [Email] varchar(100) NOT NULL,
    [Subject] nvarchar(max) NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL DEFAULT (GETUTCDATE()),
    [UpdatedAt] datetimeoffset NOT NULL DEFAULT (GETUTCDATE()),
    [Version] rowversion NOT NULL,
    [TeacherId] uniqueidentifier NOT NULL DEFAULT (NEWID()),
    CONSTRAINT [PK_Teacher] PRIMARY KEY ([TeacherId])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'TeacherId', N'DocumentNumber', N'Email', N'Firstname', N'Lastname', N'Mobile', N'Subject') AND [object_id] = OBJECT_ID(N'[dbo].[Teacher]'))
    SET IDENTITY_INSERT [dbo].[Teacher] ON;
INSERT INTO [dbo].[Teacher] ([TeacherId], [DocumentNumber], [Email], [Firstname], [Lastname], [Mobile], [Subject])
VALUES ('2356f96f-fa55-4b35-86c9-4dcbc0d04924', '5928371046', 'patricia.mora@demo.edu', 'Patricia', 'Mora', '3119283746', N'PhysicalEducation'),
('44d3a8bf-a043-4587-a642-c4905c775e70', '3049182736', 'jorge.valencia@demo.edu', 'Jorge', 'Valencia', '3048261937', N'PoliticalScience'),
('4e6b055a-4699-4c61-a476-f2a98f23cc54', '7102938465', 'ricardo.salinas@demo.edu', 'Ricardo', 'Salinas', '3103847261', N'Physics'),
('686692a7-2cbc-42c9-97b1-f99cdc454edb', '3759102846', 'hector.ruiz@demo.edu', 'Héctor', 'Ruiz', '3147382916', N'Physics'),
('8a05ac05-874c-4613-b29e-6fcd8feac250', '9831047265', 'ana.pineda@demo.edu', 'Ana', 'Pineda', '3007123845', N'Mathematics'),
('bc6d7998-128e-4e30-afa9-6aa7a3af9b85', '8493027165', 'marcela.cruz@demo.edu', 'Marcela', 'Cruz', '3059172836', N'Chemistry'),
('c9dbbc9c-cff7-45f8-8578-dedd939aa239', '6572039184', 'claudia.herrera@demo.edu', 'Claudia', 'Herrera', '3021749382', N'Biology'),
('e41385d8-e050-4ac3-a924-c3237731dace', '6293847102', 'sandra.luna@demo.edu', 'Sandra', 'Luna', '3138294750', N'Chemistry'),
('e81bfaa9-dc56-4703-b3dd-1564fc21d33a', '4382910675', 'fernando.garcia@demo.edu', 'Fernando', 'García', '3126471938', N'Mathematics'),
('ec5598c7-d66e-4197-ba2b-ba75d31c7227', '1203984756', 'luis.montoya@demo.edu', 'Luis', 'Montoya', '3019837264', N'Spanish');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'TeacherId', N'DocumentNumber', N'Email', N'Firstname', N'Lastname', N'Mobile', N'Subject') AND [object_id] = OBJECT_ID(N'[dbo].[Teacher]'))
    SET IDENTITY_INSERT [dbo].[Teacher] OFF;

CREATE UNIQUE INDEX [IX_Teacher_DocumentNumber_Mobile_Email] ON [dbo].[Teacher] ([DocumentNumber], [Mobile], [Email]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250918070238_CreateTeacher', N'9.0.9');

COMMIT;
GO
