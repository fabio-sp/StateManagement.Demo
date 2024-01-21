namespace StateManagement.Demo.Store;

public partial class CollectionsStore
{
    [ReducerMethod]
    public static State AddCurrentCollectionActionReducer(State state, AddCurrentCollectionToDashboardAction toDashboardAction)
        => state with { CollectionsInDashboard = state.CollectionsInDashboard.Add(toDashboardAction.CurrentCollection) };

    [ReducerMethod]
    public static State UpdateCollectionsActionReducer(State state, UpdateCollectionsAction action)
        => state with { AvailableCollections = ImmutableArray.Create(action.Collections) };
}