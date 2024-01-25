namespace StateManagement.Demo.Tests.Components;

public class CollectionListTests : TestContext
{
    private readonly ICollectionStateService _collectionStateService;
    
    public CollectionListTests()
    {
        _collectionStateService = Substitute.For<ICollectionStateService>();
        Services.AddSingleton(_collectionStateService);
    }
    
    [Fact]
    public void WhenNoCollectionsAreAvailable_ThenNoTableRowsExist()
    {
        // Arrange
        _collectionStateService.AvailableCollections.Returns([]);
        var component = RenderComponent<CollectionList>();
        
        // Act
        var collectionTableRowsElements = component.FindAll("table tbody tr");
        
        // Assert
        Assert.Empty(collectionTableRowsElements);
    }
    
    [Fact]
    public void WhenCollectionRowIsClicked_ThenOpenCollectionMethodIsInvoked()
    {
        // Arrange
        var collection = new Collection("1", "Test1");
        _collectionStateService.AvailableCollections.Returns([collection]);
        var component = RenderComponent<CollectionList>();
        
        // Act
        var renderedCollectionRow = component.FindAll("table tbody tr")[0];
        renderedCollectionRow.Click();
        
        // Assert
        _collectionStateService.Received().OpenCollection(Arg.Is<string>(x => x == collection.Id));
    }
}