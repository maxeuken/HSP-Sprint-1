CREATE TABLE [dbo].[Zahnradwerte]
(
	[Art] VARCHAR(50) NOT NULL PRIMARY KEY,
	[Bezeichnung] VARCHAR(50) NOT NULL PRIMARY KEY,
	[Flankenhärte] INT NOT NULL PRIMARY KEY,
	[Zahnfußdauerfestigkeit] INT NOT NULL PRIMARY KEY,
	[Zahnflankendauerfestigkeit] INT NOT NULL PRIMARY KEY,

)
