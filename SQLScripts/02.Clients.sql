USE [d_Videogame_Store_DB]
GO

INSERT INTO [dbo].[Clients]
           ([Username]
           ,[Fullname]
           ,[Document]
           ,[Birthdate]
           ,[Email]
           ,[Phone]
           ,[Address]
           ,[UserId])
     VALUES
           ('jhonw', 'Jhon Wick', '123123123', '1990-01-01T00:00:00', 'jhonw@gmail.com', '3001112222', 'Calle 1 N 1', 2),
           ('sarasm', 'Sara Smith', '987654321', '1985-05-15T00:00:00', 'sarasm@gmail.com', '3002223333', 'Avenida 2 N 5', 2),
           ('miker', 'Mike Rogers', '456789012', '1982-11-30T00:00:00', 'miker@gmail.com', '3003334444', 'Calle 3 N 10', 2),
           ('laurad', 'Laura Davis', '345678901', '1993-08-20T00:00:00', 'laurad@gmail.com', '3004445555', 'Avenida 4 N 15', 2),
           ('davidp', 'David Peterson', '678901234', '1978-03-10T00:00:00', 'davidp@gmail.com', '3005556666', 'Calle 5 N 20', 2),
           ('monicac', 'Monica Clark', '901234567', '1987-07-25T00:00:00', 'monicac@gmail.com', '3006667777', 'Avenida 6 N 25', 2),
           ('stevem', 'Steve Miller', '234567890', '1995-12-05T00:00:00', 'stevem@gmail.com', '3007778888', 'Calle 7 N 30', 2),
           ('emilyj', 'Emily Johnson', '567890123', '1991-09-18T00:00:00', 'emilyj@gmail.com', '3008889999', 'Avenida 8 N 35', 2),
           ('peterg', 'Peter Gonzalez', '890123456', '1980-06-08T00:00:00', 'peterg@gmail.com', '3009990000', 'Calle 9 N 40', 2),
           ('lucyb', 'Lucy Baker', '012345678', '1998-04-12T00:00:00', 'lucyb@gmail.com', '3000001111', 'Avenida 10 N 45', 2);
GO


