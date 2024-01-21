namespace StateManagement.Demo.Tests.Store.Collections;

public class CollectionsEffectsTests
{
    private readonly ICollectionService _collectionService = Substitute.For<ICollectionService>();
    private readonly IConversationService _conversationService = Substitute.For<IConversationService>();
    private readonly ILogger<CollectionsStore> _logger = Substitute.For<ILogger<CollectionsStore>>();
    private readonly IDispatcher _dispatcher = Substitute.For<IDispatcher>();

    [Fact]
    public async Task HandleOpenCollectionAction_RetrieveDataFromApi_ThenDispatchAddCollectionToDashboardAction()
    {
        // Arrange
        var collectionId = "id";
        var action = new CollectionsStore.OpenCollectionAction(collectionId);

        // Act
        var store = new CollectionsStore(_collectionService, _logger, _conversationService);
        await store.HandleOpenCollectionAction(action, _dispatcher);

        // Assert
        await _collectionService.Received().GetCollectionData(collectionId);
        _dispatcher.Dispatch(Arg.Any<CollectionsStore.AddCurrentCollectionToDashboardAction>());
    }
    
    [Fact]
    public async Task HandleOpenCollectionAction_LogErrorMessage_WhenApiErrorOccurs()
    {
        // Arrange
        var collectionId = "id";
        var action = new CollectionsStore.OpenCollectionAction(collectionId);

        var errorMessage = "error-message";
        var thrownException = new Exception(errorMessage);
        _collectionService.GetCollectionData(Arg.Any<string>()).ThrowsForAnyArgs(thrownException);

        // Act
        var store = new CollectionsStore(_collectionService, _logger, _conversationService);
        await store.HandleOpenCollectionAction(action, _dispatcher);

        // Assert
        await _collectionService.Received().GetCollectionData(collectionId);
        _logger.Received().LogError(thrownException, errorMessage);
    }
}