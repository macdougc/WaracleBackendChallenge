MERGE INTO dbo.Hotel AS t

USING (SELECT [Id]                      = N'77e58efd-3f3d-484a-9258-c6aea1c9022c',
              [Name]                    = N'Hotel Paradiso'
       UNION ALL
       SELECT [Id]                      = N'dc9cf466-15a4-4301-be8c-7a86a2d84de7',
              [Name]                    = N'Gleneagles'
       UNION ALL
       SELECT [Id]                      = N'610d5924-8a4e-4319-a0a7-a35ea352b190',
              [Name]                    = N'Premier Inn Glasgow'
       UNION ALL
       SELECT [Id]                      = N'2bee3442-790b-482f-9e4b-9d960cb2199b',
              [Name]                    = N'Bellagio'
       UNION ALL
       SELECT [Id]                      = N'1141d499-f2ec-4ae0-ae78-058462cbf18a',
              [Name]                    = N'Tucan Apartamento') AS s
ON t.[Id] = s.[Id]

WHEN NOT MATCHED THEN
    INSERT ([Id],
            [Name])

    VALUES (s.[Id],
            s.[Name])

WHEN MATCHED THEN
    UPDATE
    SET t.[Name] = s.[Name];