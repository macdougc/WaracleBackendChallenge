using AutoMapper;
using HotelService.Shared.Data;
using HotelService.Shared.Dtos;
using HotelService.Shared.Exceptions;
using HotelService.Shared.Model;
using static HotelService.Shared.Exceptions.NotFoundException;

namespace HotelService.Services;

public class BookingService(IHotelRepository hotelRepository, IMapper mapper) : IBookingService
{

    public async Task<BookingDto> GetBookingByReferenceAsync(int reference, CancellationToken cancellationToken)
    {
        var booking = await hotelRepository.GetBookingByBookingReferenceAsync(reference, cancellationToken);

        EnsureWasFound(booking, $"No booking found for reference {reference}");

        return mapper.Map<BookingDto>(booking);
    }

    public async Task<BookingDto?> CreateRoomBooking(CreateRoomBookingDto createRoomBookingDto, CancellationToken cancellationToken)
    {
        var room = await hotelRepository.GetRoomByIdAsync(createRoomBookingDto.RoomId, cancellationToken);

        EnsureWasFound(room, $"No room found for id {createRoomBookingDto.RoomId}");

        ValidateBooking(createRoomBookingDto, room);

        var booking = new Booking()
        {
            StartDate = createRoomBookingDto.StartDate,
            EndDate = createRoomBookingDto.EndDate,
            NumberOfPeople = createRoomBookingDto.NumberOfPeople,
            Room = room,
            BookedDate = DateTime.UtcNow,
        };

        try
        {
            room.AddBooking(booking);
            hotelRepository.AddBooking(booking);
            await hotelRepository.SaveChangesAsync(cancellationToken);
            return mapper.Map<BookingDto>(booking);
        }
        catch (Exception ex)
        {
            throw new InternalServerErrorException("An error occurred while creating the booking", ex);
        }
    }

    private static void ValidateBooking(CreateRoomBookingDto createRoomBookingDto, Room room)
    {
        if (createRoomBookingDto.StartDate >= createRoomBookingDto.EndDate)
        {
            throw new ValidationFailedException("Start date must be before end date");
        }
        if (createRoomBookingDto.NumberOfPeople > room.Capacity)
        {
            throw new ValidationFailedException($"Number of people exceeds room capacity of {room.Capacity}");
        }
        if (room.Bookings.Any(b => (b.StartDate <= createRoomBookingDto.EndDate && b.StartDate >= createRoomBookingDto.StartDate)
                                    || (b.EndDate <= createRoomBookingDto.EndDate && b.EndDate >= createRoomBookingDto.StartDate)))
        {
            throw new ValidationFailedException("Room is already booked for the selected dates");
        }
    }
}
