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

public class HotelServiceTests
{
    private readonly IFixture _fixture;
    private readonly Mock<IHotelRepository> _repositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly HotelService.Services.HotelService _sut;

    public HotelServiceTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(_ => _fixture.Behaviors.Remove(_));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        _repositoryMock = new Mock<IHotelRepository>();
        _mapperMock = new Mock<IMapper>();
        _sut = new HotelService.Services.HotelService(_repositoryMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task GetHotelByNameAsync_ReturnsMappedDtoAsync()
    {
        // Arrange
        var hotel = _fixture.Create<Hotel>();
        var hotelDto = _fixture.Create<HotelDto>();
        var hotelName = _fixture.Create<string>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        _repositoryMock.Setup(r => r.GetHotelByNameAsync(hotelName, cancellationToken))
            .ReturnsAsync(hotel);

        _mapperMock.Setup(m => m.Map<HotelDto>(hotel))
            .Returns(hotelDto);

        // Act
        var result = await _sut.GetHotelByNameAsync(hotelName, cancellationToken);

        // Assert
        result.Should().BeEquivalentTo(hotelDto);
        _repositoryMock.Verify(r => r.GetHotelByNameAsync(hotelName, cancellationToken), Times.Once);
    }

    [Fact]
    public async Task GetHotelByNameAsync_ThrowsErrorWhenNoHotelFound()
    {
        // Arrange
        var hotel = _fixture.Create<Hotel>();
        var hotelDto = _fixture.Create<HotelDto>();
        var hotelName = _fixture.Create<string>();
        var cancellationToken = _fixture.Create<CancellationToken>();

        _repositoryMock.Setup(r => r.GetHotelByNameAsync(hotelName, cancellationToken))
            .ReturnsAsync(hotel);

        _mapperMock.Setup(m => m.Map<HotelDto>(hotel))
            .Returns(hotelDto);

        // Act
        Func<Task> invocation = () => _sut.GetHotelByNameAsync(string.Empty, cancellationToken);

        await invocation
            .Should()
            .ThrowAsync<NotFoundException>();
    }
}
