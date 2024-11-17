using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace RootDesignerDemo
{
    internal class VsOutputWindowLogger
    {
        IVsOutputWindowPane _generalPane;

        public VsOutputWindowLogger(string outputPaneName)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            // Get the output window
            IVsOutputWindow outputWindow = ServiceProvider.GlobalProvider.GetService(typeof(SVsOutputWindow)) as IVsOutputWindow;

            var generalPaneGuid = VSConstants.GUID_OutWindowGeneralPane;
            outputWindow.CreatePane(ref generalPaneGuid, outputPaneName, 1, 1);
            outputWindow.GetPane(ref generalPaneGuid, out _generalPane);
            _generalPane.Activate();
        }

        public void WriteLine(string message)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            _ = _generalPane.OutputStringThreadSafe($"{message}\r\n");
        }
    }
}
