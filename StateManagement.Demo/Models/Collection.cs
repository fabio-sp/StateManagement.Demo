namespace StateManagement.Demo.Models;

public record Collection(string Id, string Name);
public record CurrentCollection(string CollectionId, string DisplayName, List<CollectionDataRow> Data);
public record CollectionDataRow;