using StateManagement.Demo.Models;

namespace StateManagement.Demo.Tests.Components;

public class CollectionListTests : TestContext
{
    private readonly ICollectionStateService _collectionState;
    
    public CollectionListTests()
    {
        _collectionState = Substitute.For<ICollectionStateService>();
        Services.AddSingleton(_collectionState);
    }
    
    [Fact]
    public void WhenNoCollectionsAreAvailable_ThenNoTableRowsExist()
    {
        // Arrange
        _collectionState.AvailableCollections.Returns([]);
        
        var component = RenderComponent<CollectionList>();
        
        // Act
        var collectionTableRowsElements = component.FindAll("table tbody tr");
        
        // Assert
        Assert.Empty(collectionTableRowsElements);
    }
    
    [Fact]
    public void WhenCollectionRowIsClicked_ThenOpenCollectionActionIsDispatched()
    {
        // Arrange
        var collectionId = "collection-id";
        var collectionName = "collection-name";
        var collection = new Collection(collectionId, collectionName);
        _collectionState.AvailableCollections.Returns([collection]);
        
        var component = RenderComponent<CollectionList>();
        
        // Act
        var renderedCollectionRow = component.FindAll("table tbody tr")[0];
        renderedCollectionRow.Click();
        
        // Assert
        _collectionState.Received().OpenCollection(Arg.Is<string>(x => x == collectionId));
    }
}