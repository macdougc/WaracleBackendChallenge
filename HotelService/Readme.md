# API Endpooints

GET https://localhost:7233/api/v1/hotel/find-hotel/{HotelName} - Finds a hgotel matching the name.
GET https://localhost:7233/api/v1/booking/{reference} - Finds a booking matching the reference.
POST https://localhost:7233/api/v1/booking/create - Creates a booking. Body: { "roomId": "1", "numberOfPeople": 1, "bookingEmail": "test@test.com", "startDate": "2024-01-01", "endDate": "2024-01-02" }
POST https://localhost:7233/api/v1/hotel/find-rooms - Finds available rooms matching search criteria. Body: { "numberOfPeople": 1, "startDate": "2024-01-01", "endDate": "2024-01-02" }
POST https://localhost:7233/api/v1/hotel/remove-all-data Removes all data from DB
POST https://localhost:7233/api/v1/hotel/create-seeding-data Creates seeding data in DB for Hotels and Rooms


# Things to improve

. Make Controller asynchronous, e.g. send a CreateBooking command and handle it with Azure Function.
. Implement CQRS pattern with focus on reads.
. Improve the DBContext implementation to use a factory.
. Use Azure KeyVault to store secrets instead of appsettings.json.
. Add logging to the application.
. Add fuzzy search for hotel names.
. Separate into microservices.
. Add User Services and authentication.
. Add checks for threadsafe room booking (lock row on read on room? Add timestamp version?).
. Add FluentValidation for requests
. Publish to Azure (multiple errors when trying to setup free Azure)
