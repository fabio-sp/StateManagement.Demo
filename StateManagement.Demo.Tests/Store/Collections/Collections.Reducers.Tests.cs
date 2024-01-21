namespace StateManagement.Demo.Tests.Store.Collections;

public class CollectionsReducersTests
{
    [Fact]
    public void AddCurrentCollectionToDashboardAction_AddCollectionToEmptyList_WhenReduced()
    {
        // Arrange
        var initialState = new CollectionsStore.State()
        {
            CollectionsInDashboard = ImmutableArray<CollectionsStore.CurrentCollection>.Empty
        };
        
        var currentCollection = new CollectionsStore.CurrentCollection("id","name",new());
        var action = new CollectionsStore.AddCurrentCollectionToDashboardAction(currentCollection);
        
        // Act
        var newState = CollectionsStore.AddCurrentCollectionActionReducer(initialState, action);

        // Assert
        Assert.Equal(newState.CollectionsInDashboard.First(), currentCollection);
    }
}