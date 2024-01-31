CREATE TABLE [Categories] (
  [Id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Name] varchar(50) NOT NULL,
  [Description] varchar(200) NOT NULL
)
GO

CREATE TABLE [Goals] (
  [Id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Description] varchar(200) NOT NULL,
  [Deadline] datetime,
  [StatusId] integer NOT NULL,
  [DificultyId] integer,
  [CreatedAt] datetime NOT NULL DEFAULT (getDate()),
  [UpdatedAt] datetime
)
GO

CREATE TABLE [GoalsSkills] (
  [Id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [GoalId] integer NOT NULL,
  [SkillId] integer NOT NULL
)
GO

CREATE TABLE [Status] (
  [Id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Description] nvarchar(255) NOT NULL CHECK ([Description] IN ('Completed', 'In Progress')) NOT NULL
)
GO

CREATE TABLE [Skills] (
  [Id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Name] varchar(50) NOT NULL,
  [Description] varchar(200) NOT NULL,
  [CategoryId] integer NOT NULL,
  [CreatedAt] datetime NOT NULL DEFAULT (getDate()),
  [UpdatedAt] datetime
)
GO

CREATE TABLE [Users] (
  [Id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [GoalId] integer NOT NULL,
  [FirstName] nvarchar(50) NOT NULL,
  [LastName] nvarchar(50) NOT NULL,
  [UserDataId] integer NOT NULL
)
GO

CREATE TABLE [UserData] (
  [Id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Email] nvarchar(100) UNIQUE NOT NULL,
  [Password] nvarchar(200) NOT NULL
)
GO

CREATE TABLE [Dificulty] (
  [Id] integer PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Description] nvarchar(255) NOT NULL CHECK ([Description] IN ('Very Easy', 'Easy', 'Normal', 'Hard', 'Very Hard')) NOT NULL
)
GO

ALTER TABLE [Goals] ADD FOREIGN KEY ([StatusId]) REFERENCES [Status] ([Id])
GO

ALTER TABLE [Goals] ADD FOREIGN KEY ([DificultyId]) REFERENCES [Dificulty] ([Id])
GO

ALTER TABLE [GoalsSkills] ADD FOREIGN KEY ([GoalId]) REFERENCES [Goals] ([Id])
GO

ALTER TABLE [GoalsSkills] ADD FOREIGN KEY ([SkillId]) REFERENCES [Skills] ([Id])
GO

ALTER TABLE [Skills] ADD FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id])
GO

ALTER TABLE [Users] ADD FOREIGN KEY ([GoalId]) REFERENCES [Goals] ([Id])
GO

ALTER TABLE [UserData] ADD FOREIGN KEY ([Id]) REFERENCES [Users] ([UserDataId])
GO
