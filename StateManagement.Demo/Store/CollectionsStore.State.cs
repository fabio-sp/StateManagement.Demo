namespace StateManagement.Demo.Store;

public partial class CollectionsStore
{
    [FeatureState]
    public record State
    {
        public ImmutableArray<Collection> AvailableCollections { get; init; } = ImmutableArray<Collection>.Empty;
        public ImmutableArray<CurrentCollection> CollectionsInDashboard { get; init; } = ImmutableArray<CurrentCollection>.Empty;
    }
}