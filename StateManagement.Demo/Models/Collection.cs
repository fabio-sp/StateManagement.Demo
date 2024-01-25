namespace StateManagement.Demo.Models;

public record Collection(string Id, string Name);
public record CollectionDetails(string CollectionId, string DisplayName, List<CollectionDataRow> Data);
public record CollectionDataRow;