CREATE TRIGGER usersDateModified
ON [dbo].[Users]
AFTER UPDATE
AS
	UPDATE [dbo].[Users]
	SET dateModified = CURRENT_TIMESTAMP
	WHERE userID = (SELECT TOP (1) userID FROM inserted)
GO;

CREATE TRIGGER notebooksDateModified
ON [dbo].[Notebooks]
AFTER UPDATE
AS
	UPDATE [dbo].[Notebooks]
	SET dateModified = CURRENT_TIMESTAMP
	WHERE notebookID = (SELECT TOP (1) notebookID FROM inserted)
GO;

CREATE TRIGGER notesDateModified
ON [dbo].[Notes]
AFTER UPDATE
AS
	UPDATE [dbo].[Notes]
	SET dateModified = CURRENT_TIMESTAMP
	WHERE noteID = (SELECT TOP (1) noteID FROM inserted)
GO;