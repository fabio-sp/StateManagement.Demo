using StateManagement.Demo.Models;

namespace StateManagement.Demo.Tests.Store;

public class CollectionStateServiceTests
{
    // Write me some tests for collection state service class
    private readonly ICollectionStateService _collectionStateService;
    private readonly ICollectionService _mockCollectionService;

    public CollectionStateServiceTests()
    {
        _mockCollectionService = Substitute.For<ICollectionService>();
        _collectionStateService = new CollectionStateService(_mockCollectionService);
    }

    [Fact]
    public async Task LoadAvailableCollections_ShouldLoadCollections()
    {
        // Arrange
        var collections = new List<Collection> { new("1", "Test") };
        _mockCollectionService.GetCollections().Returns(collections.ToArray());

        // Act
        await _collectionStateService.LoadAvailableCollections();

        // Assert
        await _mockCollectionService.Received(1).GetCollections();
        Assert.Equal(collections, _collectionStateService.AvailableCollections);
    }

    [Fact]
    public async Task OpenCollection_ShouldAddCollectionToDashboard()
    {
        // Arrange
        var currentCollection = new CurrentCollection("1", "Test", new List<CollectionDataRow>());
        _mockCollectionService.GetCollectionData("1").Returns(currentCollection);

        // Act
        await _collectionStateService.OpenCollection("1");

        // Assert
        Assert.Contains(currentCollection, _collectionStateService.CollectionsInDashboard);
        await _mockCollectionService.Received(1).GetCollectionData("1");
    }
}