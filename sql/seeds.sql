INSERT INTO Users (userID) VALUES ('test');

UPDATE Users SET userID = 'test1' WHERE userID = 'test';

INSERT INTO [dbo].[Profiles] (fk_userID, name, email, picture, nickname) VALUES ('test1', 'test name', 'testemail@email.com', 'http://placekitten.com/g/200/300', 'test nickname');

INSERT INTO [dbo].[Notebooks] (fk_userID, name) VALUES ('test1', 'test notebook');

INSERT INTO [dbo].[Notes] (fk_notebookID, title, type, content) VALUES ('3e29c566-f7d9-4922-9b53-6908d344990d', 'test note', 0, 'test content');