#




# Things to improve

. Make Controller asynchronous, e.g. send a GetHotel command and handle it with Azure Function.
. Improve the DBContext implementation to use a factory.
. Add logging to the application.
. Add fuzzy search for hotel names.
. Separate Hotel, Room and Booking into microservices.
. Add User Services and authentication.
. Add checks for threadsafe room booking (lock row on read on room?).
. Add FluentValidation for requests
. Publish to Azure (multiple errors when trying to setup free Azure)
