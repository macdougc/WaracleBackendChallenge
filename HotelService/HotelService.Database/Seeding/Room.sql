MERGE INTO dbo.Room AS t

USING (
    -- Hotel Paradiso (2 rooms of each type: Single x2, Double x2, Deluxe x2)
    SELECT [Id] = N'9b1d3f4a-7c2e-4f6a-8b9c-0123456789ab', [HotelId] = N'77e58efd-3f3d-484a-9258-c6aea1c9022c', [RoomType] = N'Single', [Capacity] = 1
    UNION ALL
    SELECT [Id] = N'a2c3d4e5-6f70-41a2-b3c4-112233445566', [HotelId] = N'77e58efd-3f3d-484a-9258-c6aea1c9022c', [RoomType] = N'Single', [Capacity] = 1
    UNION ALL
    SELECT [Id] = N'b3d4e5f6-7a81-4b2c-9123-223344556677', [HotelId] = N'77e58efd-3f3d-484a-9258-c6aea1c9022c', [RoomType] = N'Double', [Capacity] = 2
    UNION ALL
    SELECT [Id] = N'c4e5f6a7-8b92-4c3d-0123-334455667788', [HotelId] = N'77e58efd-3f3d-484a-9258-c6aea1c9022c', [RoomType] = N'Double', [Capacity] = 2
    UNION ALL
    SELECT [Id] = N'd5f6a7b8-9c03-4d4e-1123-445566778899', [HotelId] = N'77e58efd-3f3d-484a-9258-c6aea1c9022c', [RoomType] = N'Deluxe', [Capacity] = 3
    UNION ALL
    SELECT [Id] = N'e6a7b8c9-0d14-4e5f-2234-556677889900', [HotelId] = N'77e58efd-3f3d-484a-9258-c6aea1c9022c', [RoomType] = N'Deluxe', [Capacity] = 3

    -- Gleneagles
    UNION ALL
    SELECT [Id] = N'f7b8c9d0-1e25-4f60-3345-66778899aabb', [HotelId] = N'dc9cf466-15a4-4301-be8c-7a86a2d84de7', [RoomType] = N'Single', [Capacity] = 1
    UNION ALL
    SELECT [Id] = N'81c9d0e1-2f36-4012-4456-778899aabbcc', [HotelId] = N'dc9cf466-15a4-4301-be8c-7a86a2d84de7', [RoomType] = N'Single', [Capacity] = 1
    UNION ALL
    SELECT [Id] = N'92d0e1f2-3a47-4023-5567-8899aabbccdd', [HotelId] = N'dc9cf466-15a4-4301-be8c-7a86a2d84de7', [RoomType] = N'Double', [Capacity] = 2
    UNION ALL
    SELECT [Id] = N'a3e1f2a3-4b58-4134-6678-99aabbccdd00', [HotelId] = N'dc9cf466-15a4-4301-be8c-7a86a2d84de7', [RoomType] = N'Double', [Capacity] = 2
    UNION ALL
    SELECT [Id] = N'b4f2a3b4-5c69-4245-7789-aabbccddeeff', [HotelId] = N'dc9cf466-15a4-4301-be8c-7a86a2d84de7', [RoomType] = N'Deluxe', [Capacity] = 3
    UNION ALL
    SELECT [Id] = N'c5a3b4c5-6d7a-4356-889a-bbccddeeff11', [HotelId] = N'dc9cf466-15a4-4301-be8c-7a86a2d84de7', [RoomType] = N'Deluxe', [Capacity] = 3

    -- Premier Inn Glasgow
    UNION ALL
    SELECT [Id] = N'd6b4c5d6-7e8b-4467-99ab-ccddeeff1122', [HotelId] = N'610d5924-8a4e-4319-a0a7-a35ea352b190', [RoomType] = N'Single', [Capacity] = 1
    UNION ALL
    SELECT [Id] = N'e7c5d6e7-8f9c-4578-a0bc-ddeeff112233', [HotelId] = N'610d5924-8a4e-4319-a0a7-a35ea352b190', [RoomType] = N'Single', [Capacity] = 1
    UNION ALL
    SELECT [Id] = N'f8d6e7f8-90ad-4689-b1cd-eeff11223344', [HotelId] = N'610d5924-8a4e-4319-a0a7-a35ea352b190', [RoomType] = N'Double', [Capacity] = 2
    UNION ALL
    SELECT [Id] = N'09a7b8c9-01be-479a-c2de-ff1122334455', [HotelId] = N'610d5924-8a4e-4319-a0a7-a35ea352b190', [RoomType] = N'Double', [Capacity] = 2
    UNION ALL
    SELECT [Id] = N'1a2b3c4d-12cf-48ab-d3ef-112233445566', [HotelId] = N'610d5924-8a4e-4319-a0a7-a35ea352b190', [RoomType] = N'Deluxe', [Capacity] = 3
    UNION ALL
    SELECT [Id] = N'2b3c4d5e-23df-49bc-e4f0-223344556677', [HotelId] = N'610d5924-8a4e-4319-a0a7-a35ea352b190', [RoomType] = N'Deluxe', [Capacity] = 3

    -- Bellagio
    UNION ALL
    SELECT [Id] = N'3c4d5e6f-34ef-4acd-f501-334455667788', [HotelId] = N'2bee3442-790b-482f-9e4b-9d960cb2199b', [RoomType] = N'Single', [Capacity] = 1
    UNION ALL
    SELECT [Id] = N'4d5e6f70-45ff-4bde-0602-445566778899', [HotelId] = N'2bee3442-790b-482f-9e4b-9d960cb2199b', [RoomType] = N'Single', [Capacity] = 1
    UNION ALL
    SELECT [Id] = N'5e6f7081-56af-4cef-1703-5566778899aa', [HotelId] = N'2bee3442-790b-482f-9e4b-9d960cb2199b', [RoomType] = N'Double', [Capacity] = 2
    UNION ALL
    SELECT [Id] = N'6f708192-67bf-4d0f-2804-66778899aabb', [HotelId] = N'2bee3442-790b-482f-9e4b-9d960cb2199b', [RoomType] = N'Double', [Capacity] = 2
    UNION ALL
    SELECT [Id] = N'708192a3-78cf-4e10-3905-778899aabbcc', [HotelId] = N'2bee3442-790b-482f-9e4b-9d960cb2199b', [RoomType] = N'Deluxe', [Capacity] = 3
    UNION ALL
    SELECT [Id] = N'8192a3b4-89df-4f21-4a06-8899aabbccdd', [HotelId] = N'2bee3442-790b-482f-9e4b-9d960cb2199b', [RoomType] = N'Deluxe', [Capacity] = 3

    -- Tucan Apartamento
    UNION ALL
    SELECT [Id] = N'92a3b4c5-9aef-4022-5b07-99aabbccdd00', [HotelId] = N'1141d499-f2ec-4ae0-ae78-058462cbf18a', [RoomType] = N'Single', [Capacity] = 1
    UNION ALL
    SELECT [Id] = N'a3b4c5d6-ab0f-4133-6c08-aabbccddeeff', [HotelId] = N'1141d499-f2ec-4ae0-ae78-058462cbf18a', [RoomType] = N'Single', [Capacity] = 1
    UNION ALL
    SELECT [Id] = N'b4c5d6e7-bc1f-4244-7d09-bbccddeeff11', [HotelId] = N'1141d499-f2ec-4ae0-ae78-058462cbf18a', [RoomType] = N'Double', [Capacity] = 2
    UNION ALL
    SELECT [Id] = N'c5d6e7f8-cd2f-4355-8e0a-ccddee112233', [HotelId] = N'1141d499-f2ec-4ae0-ae78-058462cbf18a', [RoomType] = N'Double', [Capacity] = 2
    UNION ALL
    SELECT [Id] = N'd6e7f809-de3f-4466-9f0b-ddeeff223344', [HotelId] = N'1141d499-f2ec-4ae0-ae78-058462cbf18a', [RoomType] = N'Deluxe', [Capacity] = 3
    UNION ALL
    SELECT [Id] = N'e7f8091a-ef4f-4577-a00c-ee1122334455', [HotelId] = N'1141d499-f2ec-4ae0-ae78-058462cbf18a', [RoomType] = N'Deluxe', [Capacity] = 3
) AS s
ON t.[Id] = s.[Id]

WHEN NOT MATCHED THEN
    INSERT ([Id], [HotelId], [RoomType], [Capacity])
    VALUES (s.[Id], s.[HotelId], s.[RoomType], s.[Capacity])

WHEN MATCHED THEN
    UPDATE
    SET t.[HotelId] = s.[HotelId],
        t.[RoomType] = s.[RoomType],
        t.[Capacity] = s.[Capacity];
