using MauiEdit.Services;
using MauiEdit.ViewModels;

namespace MauiEdit.UnitTest;

public class MainFormUiControllerTest {

    [Fact]
    public async Task MainFormNewDocumentTest() {
        var service = SimpleTestServiceProvider.GetInstance();
        var dialogService = (SimpleUnitTestDialogService?)service.GetService(typeof(IDialogService));
        int dialogState = 0;

        Assert.NotNull(dialogService);

        MainFormController mainFormController = new(service)
        {
            // Clear the main document.
            TextDocument = string.Empty
        };

        // Assert that the New command is disabled, and cannot be called.
        Assert.False(mainFormController.NewDocumentCommand.CanExecute(null));

        // Assign a new document.
        mainFormController.TextDocument = MainFormController.GetTestText();

        // Assert that the New command is enabled, and _can_ be called.
        Assert.True(mainFormController.NewDocumentCommand.CanExecute(null));

        // Simulate that the user is requesting to 'New' the document,
        // but return "No" on the MessageDialogBox to actually clear it.
        dialogService!.ShowMessageBoxRequested += DialogService_ShowMessageBoxRequested;

        // Test the first time; the state machine returns "No" the first time.
        await mainFormController.NewDocumentCommand.ExecuteAsync(null);
        Assert.Equal(MainFormController.GetTestText(), mainFormController.TextDocument);

        // Test the second time; our state machine returns "Yes" the second time.
        await mainFormController.NewDocumentCommand.ExecuteAsync(null);
        Assert.Equal(string.Empty, mainFormController.TextDocument);

        void DialogService_ShowMessageBoxRequested(object? sender, ShowMessageBoxResultEventArgs e)
            => e.ResultButtonText = dialogState++ switch {
                0 => MainFormController.NoButtonText,
                1 => MainFormController.YesButtonText,
                _ => string.Empty
            };
    }
}
