BEGIN TRANSACTION;
CREATE TABLE [dbo].[Grade] (
    [Value] real NOT NULL,
    [CreatedAt] datetimeoffset NOT NULL DEFAULT (GETUTCDATE()),
    [UpdatedAt] datetimeoffset NOT NULL DEFAULT (GETUTCDATE()),
    [Version] rowversion NOT NULL,
    [GradeId] uniqueidentifier NOT NULL DEFAULT (NEWID()),
    [TeacherId] uniqueidentifier NOT NULL,
    [StudentId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Grade] PRIMARY KEY ([GradeId]),
    CONSTRAINT [FK_Grade_Student_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Student] ([StudentId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Grade_Teacher_TeacherId] FOREIGN KEY ([TeacherId]) REFERENCES [dbo].[Teacher] ([TeacherId]) ON DELETE CASCADE
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'GradeId', N'StudentId', N'TeacherId', N'Value') AND [object_id] = OBJECT_ID(N'[dbo].[Grade]'))
    SET IDENTITY_INSERT [dbo].[Grade] ON;
INSERT INTO [dbo].[Grade] ([GradeId], [StudentId], [TeacherId], [Value])
VALUES ('0655b98d-8437-4a63-be12-b172c869b6a3', '2942cb83-78f5-47d0-bf5b-7afc902da439', '44d3a8bf-a043-4587-a642-c4905c775e70', CAST(4.6 AS real)),
('178a3671-dd4e-451d-ab7e-65897a78997d', '41133742-0044-4ca8-bdc8-95ed7f82ec49', '44d3a8bf-a043-4587-a642-c4905c775e70', CAST(2.8 AS real)),
('31e9714a-a075-493c-9774-d29653968859', '650da35f-27a7-4e0a-8f27-f474da063fa1', 'bc6d7998-128e-4e30-afa9-6aa7a3af9b85', CAST(3.2 AS real)),
('729617e4-7a24-433e-ae7f-c7fa36e80a1b', '65ecd151-b88f-4d34-bf53-40bc70c0114d', 'ec5598c7-d66e-4197-ba2b-ba75d31c7227', CAST(5 AS real)),
('ab8d7d96-e41a-4ede-8c19-2561d091ed5c', '65ecd151-b88f-4d34-bf53-40bc70c0114d', '8a05ac05-874c-4613-b29e-6fcd8feac250', CAST(4.7 AS real)),
('bfc36aea-6078-4f9e-832c-8e50c37c5599', '650da35f-27a7-4e0a-8f27-f474da063fa1', 'c9dbbc9c-cff7-45f8-8578-dedd939aa239', CAST(4.3 AS real)),
('d3960faa-ca0b-457b-ae0e-2dc5b5e53abd', '2942cb83-78f5-47d0-bf5b-7afc902da439', '8a05ac05-874c-4613-b29e-6fcd8feac250', CAST(4.1 AS real)),
('e3e942da-ce8d-41ac-973c-3bcaf848646f', '41133742-0044-4ca8-bdc8-95ed7f82ec49', 'c9dbbc9c-cff7-45f8-8578-dedd939aa239', CAST(3.1 AS real));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'GradeId', N'StudentId', N'TeacherId', N'Value') AND [object_id] = OBJECT_ID(N'[dbo].[Grade]'))
    SET IDENTITY_INSERT [dbo].[Grade] OFF;

CREATE INDEX [IX_Grade_StudentId] ON [dbo].[Grade] ([StudentId]);

CREATE INDEX [IX_Grade_TeacherId_StudentId] ON [dbo].[Grade] ([TeacherId], [StudentId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250918072536_CreateGrade', N'9.0.9');

COMMIT;
GO
