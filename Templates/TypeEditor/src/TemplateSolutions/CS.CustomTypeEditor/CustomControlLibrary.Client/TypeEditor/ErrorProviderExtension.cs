using System;
using System.Windows.Forms;

namespace CustomControlLibrary.Designer.Client
{
    internal static class ErrorProviderExtension
    {
        /// <summary>
        ///  Marks the provided control as errored if the <see paramref="errorCondition"/> is not met.
        /// </summary>
        /// <param name="errorProvider">ErrorProvider component instance.</param>
        /// <param name="control">Control, on which the Error to set on if errorCondition is true.</param>
        /// <param name="errorCondition">Function delegate which checks the error condition.</param>
        /// <param name="errorText">Error text to be assigned in the error case.</param>
        /// <returns>true, if an error occured.</returns>
        public static bool SetErrorOrNull(this ErrorProvider errorProvider, Control control, Func<bool> errorCondition, string errorText)
        {
            if (errorCondition())
            {
                errorProvider.SetError(control, errorText);
                return true;
            }

            errorProvider.SetError(control, null);
            return false;
        }
    }
}
