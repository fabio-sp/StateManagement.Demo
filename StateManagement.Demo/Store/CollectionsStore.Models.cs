namespace StateManagement.Demo.Store;

public partial class CollectionsStore
{
    public record Collection(string Id, string Name);
    public record CurrentCollection(string CollectionId, string DisplayName, List<CollectionDataRow> Data);
    public record CollectionDataRow;
}