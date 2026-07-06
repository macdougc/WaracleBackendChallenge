using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using HotelService.Controllers;
using HotelService.Services;
using HotelService.Shared.Dtos;
using HotelService.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace HotelService.Tests.Controllers;

public class BookingControllerTests
{
    private readonly IFixture _fixture;
    private readonly Mock<IBookingService> _bookingServiceMock;
    private readonly BookingController _sut;

    public BookingControllerTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        _bookingServiceMock = new Mock<IBookingService>();
        _sut = new BookingController(_bookingServiceMock.Object);
    }

    [Fact]
    public async Task CreateRoomBooking_ReturnsBookingDto()
    {
        // Arrange
        var request = _fixture.Create<CreateRoomBookingDto>();
        var createdBookingDto = _fixture.Create<BookingDto>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        _bookingServiceMock.Setup(s => s.CreateRoomBooking(request, cancellationToken))
            .ReturnsAsync(createdBookingDto);

        // Act
        var result = await _sut.CreateRoomBooking(request, cancellationToken);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var createdResult = (OkObjectResult)result;
        createdResult.Value.Should().BeEquivalentTo(createdBookingDto);
        _bookingServiceMock.Verify(s => s.CreateRoomBooking(request, cancellationToken), Times.Once);
    }

    [Fact]
    public async Task GetBookingByReference_ReturnsBooking()
    {
        // Arrange
        var reference = _fixture.Create<int>();
        var bookingDto = _fixture.Create<BookingDto>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        _bookingServiceMock.Setup(s => s.GetBookingByReferenceAsync(reference, cancellationToken))
            .ReturnsAsync(bookingDto);

        // Act
        var result = await _sut.GetBookingByReference(reference, cancellationToken);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var createdResult = (OkObjectResult)result;
        createdResult.Value.Should().BeEquivalentTo(bookingDto);
        _bookingServiceMock.Verify(s => s.GetBookingByReferenceAsync(reference, cancellationToken), Times.Once);
    }
}
