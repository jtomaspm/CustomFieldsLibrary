CREATE TABLE [Entity_Type](
	[Name] VARCHAR(256) PRIMARY KEY
);

GO

CREATE TABLE [Entity] (
	[Id] INTEGER PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(256) NOT NULL,
	[Type]  VARCHAR(256) NOT NULL,
	FOREIGN KEY ([Type]) REFERENCES [Entity_Type]([Name])
);

GO

CREATE TABLE [Depot] (
	[Id] INTEGER PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(256) NOT NULL,
	[Location] VARCHAR(256) NOT NULL,
	[Owener_Id] INTEGER NOT NULL,
	FOREIGN KEY ([Owener_Id]) REFERENCES [Entity]([Id])
);

GO

CREATE TABLE [Container_Type](
	[Id] INTEGER PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(256) NOT NULL,
	[Size] FLOAT NOT NULL,
);

GO

CREATE TABLE [Container] (
	[Id] INTEGER PRIMARY KEY IDENTITY(1,1),
	[Code] VARCHAR(256) NOT NULL,
	[Container_Type_Id] INTEGER NOT NULL,
	[Owener_Id] INTEGER NOT NULL,
	FOREIGN KEY ([Owener_Id]) REFERENCES [Entity]([Id]),
	FOREIGN KEY ([Container_Type_Id]) REFERENCES [Container_Type]([Id])
);

GO

CREATE TABLE [Operation_Type](
	[Name] VARCHAR(256) PRIMARY KEY,
);

GO

CREATE TABLE [Operation](
	[Id] INTEGER PRIMARY KEY IDENTITY(1,1),
	[Container_Id] INTEGER NOT NULL,
	[Operation_Type] VARCHAR(256) NOT NULL,
	[Depot_Id] INTEGER NOT NULL,
	[Date] DATETIME NOT NULL,
	FOREIGN KEY ([Container_Id]) REFERENCES [Container]([Id]),
	FOREIGN KEY ([Operation_Type]) REFERENCES [Operation_Type]([Name]),
	FOREIGN KEY ([Depot_Id]) REFERENCES [Depot]([Id])
);

GO

INSERT INTO [Entity_Type] ([Name]) VALUES ('Client');
INSERT INTO [Entity_Type] ([Name]) VALUES ('Partner');
INSERT INTO [Entity_Type] ([Name]) VALUES ('Owner');
INSERT INTO [Entity_Type] ([Name]) VALUES ('Supplier');

GO

INSERT INTO [Operation_Type] ([Name]) VALUES ('In');
INSERT INTO [Operation_Type] ([Name]) VALUES ('Out');

GO

INSERT INTO [Container_Type] ([Name], [Size]) VALUES ('20DV', 20);
INSERT INTO [Container_Type] ([Name], [Size]) VALUES ('40DV', 40);

GO

INSERT INTO [Entity] ([Name], [Type]) VALUES ('Jt, Lda','Owner');
INSERT INTO [Entity] ([Name], [Type]) VALUES ('MAEIL','Partner');
INSERT INTO [Entity] ([Name], [Type]) VALUES ('MSC','Client');
INSERT INTO [Entity] ([Name], [Type]) VALUES ('Norrack, Lda','Supplier');
INSERT INTO [Entity] ([Name], [Type]) VALUES ('MAERSK','Client');
INSERT INTO [Entity] ([Name], [Type]) VALUES ('KLABBIN','Client');

GO

INSERT INTO [Depot] ([Location],[Name],[Owener_Id]) VALUES ('Lisboa, Portugal', 'Depot Lisboa', 1);
INSERT INTO [Depot] ([Location],[Name],[Owener_Id]) VALUES ('Porto, Portugal', 'Depot Porto', 1);

GO

INSERT INTO [Container] ([Code], [Container_Type_Id], [Owener_Id]) VALUES ('MC00000001', 1, 3);
INSERT INTO [Container] ([Code], [Container_Type_Id], [Owener_Id]) VALUES ('MC00000002', 1, 3);
INSERT INTO [Container] ([Code], [Container_Type_Id], [Owener_Id]) VALUES ('MC00000003', 1, 3);
INSERT INTO [Container] ([Code], [Container_Type_Id], [Owener_Id]) VALUES ('MC00000004', 2, 3);
INSERT INTO [Container] ([Code], [Container_Type_Id], [Owener_Id]) VALUES ('MC00000005', 2, 3);
INSERT INTO [Container] ([Code], [Container_Type_Id], [Owener_Id]) VALUES ('MC00000006', 2, 3);
INSERT INTO [Container] ([Code], [Container_Type_Id], [Owener_Id]) VALUES ('MA00000001', 1, 5);
INSERT INTO [Container] ([Code], [Container_Type_Id], [Owener_Id]) VALUES ('MA00000002', 1, 5);
INSERT INTO [Container] ([Code], [Container_Type_Id], [Owener_Id]) VALUES ('MA00000003', 2, 5);
INSERT INTO [Container] ([Code], [Container_Type_Id], [Owener_Id]) VALUES ('MA00000004', 2, 5);
INSERT INTO [Container] ([Code], [Container_Type_Id], [Owener_Id]) VALUES ('KL00000001', 1, 6);
INSERT INTO [Container] ([Code], [Container_Type_Id], [Owener_Id]) VALUES ('KL00000002', 2, 6);

GO

INSERT INTO [Operation] ([Container_Id], [Date], [Depot_Id], [Operation_Type]) VALUES (1 , GETDATE(), 1, 'In');
INSERT INTO [Operation] ([Container_Id], [Date], [Depot_Id], [Operation_Type]) VALUES (2 , GETDATE(), 2, 'In');
INSERT INTO [Operation] ([Container_Id], [Date], [Depot_Id], [Operation_Type]) VALUES (3 , GETDATE(), 1, 'In');
INSERT INTO [Operation] ([Container_Id], [Date], [Depot_Id], [Operation_Type]) VALUES (4 , GETDATE(), 2, 'In');
INSERT INTO [Operation] ([Container_Id], [Date], [Depot_Id], [Operation_Type]) VALUES (5 , GETDATE(), 1, 'In');
INSERT INTO [Operation] ([Container_Id], [Date], [Depot_Id], [Operation_Type]) VALUES (6 , GETDATE(), 2, 'In');
INSERT INTO [Operation] ([Container_Id], [Date], [Depot_Id], [Operation_Type]) VALUES (7 , GETDATE(), 1, 'In');
INSERT INTO [Operation] ([Container_Id], [Date], [Depot_Id], [Operation_Type]) VALUES (8 , GETDATE(), 2, 'In');
INSERT INTO [Operation] ([Container_Id], [Date], [Depot_Id], [Operation_Type]) VALUES (9 , GETDATE(), 1, 'In');
INSERT INTO [Operation] ([Container_Id], [Date], [Depot_Id], [Operation_Type]) VALUES (10 , GETDATE(), 2, 'In');
INSERT INTO [Operation] ([Container_Id], [Date], [Depot_Id], [Operation_Type]) VALUES (11 , GETDATE(), 1, 'In');
INSERT INTO [Operation] ([Container_Id], [Date], [Depot_Id], [Operation_Type]) VALUES (12 , GETDATE(), 2, 'In');