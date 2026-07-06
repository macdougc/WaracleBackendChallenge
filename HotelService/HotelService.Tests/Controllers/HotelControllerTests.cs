using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Moq;
using HotelService.Controllers;
using HotelService.Services;
using HotelService.Shared.Dtos;
using HotelService.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using System.Threading;
using System.Threading.Tasks;

namespace HotelService.Tests.Controllers;

public class HotelControllerTests
{
    private readonly IFixture _fixture;
    private readonly Mock<IHotelService> _hotelServiceMock;
    private readonly HotelController _sut;

    public HotelControllerTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        _hotelServiceMock = new Mock<IHotelService>();
        _sut = new HotelController(_hotelServiceMock.Object);
    }

    [Fact]
    public async Task GetHotelByName_ReturnsOkResult_WithHotelAsync()
    {
        // Arrange
        var hotel = _fixture.Create<HotelDto>();
        var name = _fixture.Create<string>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        _hotelServiceMock.Setup(s => s.GetHotelByNameAsync(name, cancellationToken))
            .ReturnsAsync(hotel);

        // Act
        var result = await _sut.GetHotelByName(name, cancellationToken);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = (OkObjectResult)result;
        okResult.Value.Should().BeEquivalentTo(hotel);
        _hotelServiceMock.Verify(s => s.GetHotelByNameAsync(name, cancellationToken), Times.Once);
    }

    [Fact]
    public async Task GetAvailableRooms_ReturnsOkResult_WithRoomsAsync()
    {
        // Arrange
        var rooms = _fixture.CreateMany<RoomDto>();
        var request = _fixture.Create<SearchAvailableRoomsDto>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        _hotelServiceMock.Setup(s => s.GetAvailableRoomsAsync(request, cancellationToken))
            .ReturnsAsync(rooms);

        // Act
        var result = await _sut.GetAvailableRooms(request, cancellationToken);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = (OkObjectResult)result;
        okResult.Value.Should().BeEquivalentTo(rooms);
        _hotelServiceMock.Verify(s => s.GetAvailableRoomsAsync(request, cancellationToken), Times.Once);
    }

}
