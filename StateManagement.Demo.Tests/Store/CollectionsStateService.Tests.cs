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
        List<Collection> collections = [ 
            new("1", "Test1"),
            new("2", "Test2"),
            new("3", "Test3"), 
            new("4", "Test4") 
        ];
        _mockCollectionService.GetAll().Returns(collections.ToArray());

        // Act
        await _collectionStateService.LoadAvailableCollections();

        // Assert
        await _mockCollectionService.Received(1).GetAll();
        Assert.Equal(collections, _collectionStateService.AvailableCollections);
    }

    [Fact]
    public async Task OpenCollection_ShouldAddCollectionToDashboard()
    {
        // Arrange
        var collection = new CollectionDetails("1", "Test1", []);
        _mockCollectionService.Get("1").Returns(collection);

        // Act
        await _collectionStateService.OpenCollection("1");

        // Assert
        Assert.Contains(collection, _collectionStateService.DashboardCollections);
        await _mockCollectionService.Received(1).Get("1");
    }
}