using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using FluentAssertions;
using HotelService.Services;
using HotelService.Shared.Data;
using HotelService.Shared.Dtos;
using HotelService.Shared.Exceptions;
using HotelService.Shared.Model;
using Moq;
using Xunit;

namespace HotelService.Tests.Services;

public class BookingServiceTests
{
    private readonly IFixture _fixture;
    private readonly Mock<IHotelRepository> _repositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly BookingService _sut;

    public BookingServiceTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(_ => _fixture.Behaviors.Remove(_));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        _repositoryMock = new Mock<IHotelRepository>();
        _mapperMock = new Mock<IMapper>();
        _sut = new BookingService(_repositoryMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task CreateRoomBooking_ReturnsMappedDtoAsync()
    {
        // Arrange
        var startDate = new DateTime(2026, 05, 01);
        var endDate = new DateTime(2026, 05, 05);

        var room = _fixture.Build<Room>()
            .Without(r => r.Bookings)
            .Create();

        var request = _fixture.Build<CreateRoomBookingDto>()
            .With(r => r.StartDate, startDate)
            .With(r => r.EndDate, endDate)
            .With(r => r.NumberOfPeople, room.Capacity)
            .Create();

        var booking = _fixture.Create<Booking>();
        var bookingDto = _fixture.Create<BookingDto>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        _repositoryMock.Setup(r => r.GetRoomByIdAsync(request.RoomId, cancellationToken))
            .ReturnsAsync(room);

        _repositoryMock.Setup(r => r.AddBooking(It.Is<Booking>(b => b.StartDate == request.StartDate &&
                                                                    b.EndDate == request.EndDate &&
                                                                    b.NumberOfPeople == request.NumberOfPeople &&
                                                                    b.Room == room)))
            .Verifiable();

        _mapperMock.Setup(m => m.Map<BookingDto>(It.IsAny<Booking>()))
            .Returns(bookingDto);

        // Act
        var result = await _sut.CreateRoomBooking(request, cancellationToken);

        // Assert
        result.Should().BeEquivalentTo(bookingDto);
        _repositoryMock.Verify(r => r.AddBooking(It.Is<Booking>(b => b.StartDate == request.StartDate &&
                                                                    b.EndDate == request.EndDate &&
                                                                    b.NumberOfPeople == request.NumberOfPeople &&
                                                                    b.Room == room)), Times.Once);
    }

    [Fact]
    public async Task CreateRoomBooking_ThrowesExceptionWhenDatesInvalid()
    {
        // Arrange
        var startDate = new DateTime(2026, 05, 08);
        var endDate = new DateTime(2026, 05, 05);

        var room = _fixture.Build<Room>()
            .Without(r => r.Bookings)
            .Create();

        var request = _fixture.Build<CreateRoomBookingDto>()
            .With(r => r.StartDate, startDate)
            .With(r => r.EndDate, endDate)
            .With(r => r.NumberOfPeople, room.Capacity)
            .Create();

        var booking = _fixture.Create<Booking>();
        var bookingDto = _fixture.Create<BookingDto>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        _repositoryMock.Setup(r => r.GetRoomByIdAsync(request.RoomId, cancellationToken))
            .ReturnsAsync(room);

        _repositoryMock.Setup(r => r.AddBooking(It.IsAny<Booking>()))
            .Verifiable();

        _mapperMock.Setup(m => m.Map<BookingDto>(It.IsAny<Booking>()))
            .Returns(bookingDto);

        // Act
        Func<Task> invocation = () => _sut.CreateRoomBooking(request, cancellationToken);

        // Assert
        await invocation
            .Should()
            .ThrowAsync<ValidationFailedException>();

        _repositoryMock.Verify(r => r.AddBooking(It.IsAny<Booking>()), Times.Never);
    }

    [Fact]
    public async Task CreateRoomBooking_ThrowesExceptionWhenCapacityReached()
    {
        // Arrange
        var startDate = new DateTime(2026, 05, 01);
        var endDate = new DateTime(2026, 05, 05);

        var room = _fixture.Build<Room>()
            .Without(r => r.Bookings)
            .Create();

        var request = _fixture.Build<CreateRoomBookingDto>()
            .With(r => r.StartDate, startDate)
            .With(r => r.EndDate, endDate)
            .With(r => r.NumberOfPeople, room.Capacity + 2)
            .Create();

        var booking = _fixture.Create<Booking>();
        var bookingDto = _fixture.Create<BookingDto>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        _repositoryMock.Setup(r => r.GetRoomByIdAsync(request.RoomId, cancellationToken))
            .ReturnsAsync(room);

        _repositoryMock.Setup(r => r.AddBooking(It.IsAny<Booking>()))
            .Verifiable();

        _mapperMock.Setup(m => m.Map<BookingDto>(It.IsAny<Booking>()))
            .Returns(bookingDto);

        // Act
        Func<Task> invocation = () => _sut.CreateRoomBooking(request, cancellationToken);

        // Assert
        await invocation
            .Should()
            .ThrowAsync<ValidationFailedException>();

        _repositoryMock.Verify(r => r.AddBooking(It.IsAny<Booking>()), Times.Never);
    }

    [Fact]
    public async Task CreateRoomBooking_ThrowesExceptionWhenRoomBooked()
    {
        // Arrange
        var startDate = new DateTime(2026, 05, 01);
        var endDate = new DateTime(2026, 05, 05);
        var existingBooking = _fixture.Build<Booking>()
            .With(b => b.StartDate, new DateTime(2026, 05, 03))
            .With(b => b.EndDate, new DateTime(2026, 05, 07))
            .Create();

        var room = _fixture.Build<Room>()
            .With(r => r.Bookings, [existingBooking])
            .Create();

        var request = _fixture.Build<CreateRoomBookingDto>()
            .With(r => r.StartDate, startDate)
            .With(r => r.EndDate, endDate)
            .With(r => r.NumberOfPeople, room.Capacity)
            .Create();

        var booking = _fixture.Create<Booking>();
        var bookingDto = _fixture.Create<BookingDto>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        _repositoryMock.Setup(r => r.GetRoomByIdAsync(request.RoomId, cancellationToken))
            .ReturnsAsync(room);

        _repositoryMock.Setup(r => r.AddBooking(It.IsAny<Booking>()))
            .Verifiable();

        _mapperMock.Setup(m => m.Map<BookingDto>(It.IsAny<Booking>()))
            .Returns(bookingDto);

        // Act
        Func<Task> invocation = () => _sut.CreateRoomBooking(request, cancellationToken);

        // Assert
        await invocation
            .Should()
            .ThrowAsync<ValidationFailedException>();

        _repositoryMock.Verify(r => r.AddBooking(It.IsAny<Booking>()), Times.Never);
    }
}