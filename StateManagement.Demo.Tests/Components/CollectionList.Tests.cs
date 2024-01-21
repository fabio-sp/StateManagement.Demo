using StateManagement.Demo.Models;

namespace StateManagement.Demo.Tests.Components;

public class CollectionListTests : TestContext
{
    private readonly IState<CollectionsStore.State> _collectionState;
    private readonly IDispatcher _dispatcher;

    public CollectionListTests()
    {
        _dispatcher = Substitute.For<IDispatcher>();
        Services.AddSingleton(_dispatcher);
        var actionSubscriber = Substitute.For<IActionSubscriber>();
        Services.AddSingleton(actionSubscriber);
        _collectionState = Substitute.For<IState<CollectionsStore.State>>();
        Services.AddSingleton(_collectionState);
    }
    
    [Fact]
    public void WhenNoCollectionsAreAvailable_ThenNoTableRowsExist()
    {
        // Arrange
        _collectionState.Value.Returns(new CollectionsStore.State
        {
            AvailableCollections = ImmutableArray<Collection>.Empty
        });
        
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
        _collectionState.Value.Returns(new CollectionsStore.State
        {
            AvailableCollections = new[]{ collection }.ToImmutableArray()
        });
        
        var component = RenderComponent<CollectionList>();
        
        // Act
        var renderedCollectionRow = component.FindAll("table tbody tr")[0];
        renderedCollectionRow.Click();
        
        // Assert
        _dispatcher.Received().Dispatch(Arg.Is<CollectionsStore.OpenCollectionAction>(x => x.CollectionId == collectionId));
    }
}