namespace StateManagement.Demo.Store;

public partial class CollectionsStore
{
    public record LoadCollectionsAction;
    public record UpdateCollectionsAction(Collection[] Collections);
    public record OpenCollectionAction(string CollectionId);
    public record AddCurrentCollectionToDashboardAction(CurrentCollection CurrentCollection);

    public record AskQuestionAction(string Text);
}