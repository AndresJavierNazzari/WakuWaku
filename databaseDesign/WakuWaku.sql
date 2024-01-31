CREATE TABLE [Categories] (
  [Id] integer PRIMARY KEY,
  [Name] varchar(200),
  [Description] varchar(200)
)
GO

CREATE TABLE [Goals] (
  [Id] integer PRIMARY KEY,
  [Description] varchar(200),
  [DateOfCreation] datetime,
  [Deadline] datetime,
  [StatusId] integer
)
GO

CREATE TABLE [GoalsSkills] (
  [Id] integer PRIMARY KEY,
  [GoalId] integer,
  [SkillId] integer
)
GO

CREATE TABLE [Status] (
  [Id] integer PRIMARY KEY,
  [Description] varchar(200)
)
GO

CREATE TABLE [Skills] (
  [Id] integer PRIMARY KEY,
  [Name] varchar(200),
  [CategoryId] integer
)
GO

CREATE TABLE [Users] (
  [Id] integer PRIMARY KEY,
  [Email] nvarchar(200) UNIQUE,
  [FirstName] nvarchar(200),
  [LastName] nvarchar(200),
  [Password] nvarchar(200)
)
GO

CREATE TABLE [UsersGoals] (
  [Id] integer PRIMARY KEY,
  [GoalId] integer,
  [UserId] integer
)
GO

ALTER TABLE [UsersGoals] ADD FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
GO

ALTER TABLE [UsersGoals] ADD FOREIGN KEY ([GoalId]) REFERENCES [Goals] ([Id])
GO

ALTER TABLE [Goals] ADD FOREIGN KEY ([StatusId]) REFERENCES [Status] ([Id])
GO

ALTER TABLE [Categories] ADD FOREIGN KEY ([Id]) REFERENCES [Skills] ([CategoryId])
GO

ALTER TABLE [GoalsSkills] ADD FOREIGN KEY ([GoalId]) REFERENCES [Goals] ([Id])
GO

ALTER TABLE [GoalsSkills] ADD FOREIGN KEY ([SkillId]) REFERENCES [Skills] ([Id])
GO
