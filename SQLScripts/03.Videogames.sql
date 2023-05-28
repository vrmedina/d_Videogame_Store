USE [d_Videogame_Store_DB]
GO

INSERT INTO [dbo].[Videogames]
           ([Name]
           ,[Year]
           ,[Protagonists]
           ,[Director]
           ,[Producer]
           ,[Platform]
           ,[UserId])
     VALUES
           ('The Legend of Zelda: Breath of the Wild', 2017, 'Link', 'Hidemaro Fujibayashi', 'Eiji Aonuma', 'Nintendo Switch', 1),
           ('The Last of Us Part II', 2020, 'Ellie', 'Neil Druckmann', 'Hermen Hulst', 'PlayStation 4, PlayStation 5', 1),
           ('Red Dead Redemption 2', 2018, 'Arthur Morgan', 'Rob Nelson', 'Dan Houser', 'PlayStation 4, Xbox One', 1),
           ('Super Mario Odyssey', 2017, 'Mario', 'Kenta Motokura', 'Yoshiaki Koizumi', 'Nintendo Switch', 1),
           ('God of War', 2018, 'Kratos', 'Cory Barlog', 'Shannon Studstill', 'PlayStation 4', 1),
           ('Cyberpunk 2077', 2020, 'V', 'Adam Badowski', 'Michal Nowakowski', 'PlayStation 4, Xbox One, Microsoft Windows', 1),
           ('Assassin''s Creed Valhalla', 2020, 'Eivor', 'Ashraf Ismail', 'Julien Laferrière', 'PlayStation 4, PlayStation 5, Xbox One, Xbox Series X/S, Microsoft Windows', 1),
           ('Animal Crossing: New Horizons', 2020, 'Player Character', 'Aya Kyogoku', 'Katsuya Eguchi', 'Nintendo Switch', 1),
           ('Resident Evil Village', 2021, 'Ethan Winters', 'Morimasa Sato', 'Tsuyoshi Kanda', 'PlayStation 4, PlayStation 5, Xbox One, Xbox Series X/S, Microsoft Windows', 1),
           ('Final Fantasy VII Remake', 2020, 'Cloud Strife', 'Tetsuya Nomura', 'Yoshinori Kitase', 'PlayStation 4', 1);
GO


