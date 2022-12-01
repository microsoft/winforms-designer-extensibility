Imports System.Windows.Forms

Friend Module ErrorProviderExtension
    ''' <summary>
    '''  Marks the provided control as errored if the <see paramref="errorCondition"/> is not met.
    ''' </summary>
    ''' <param name="errorProvider">ErrorProvider component instance.</param>
    ''' <param name="control">Control, on which the Error to set on if errorCondition is true.</param>
    ''' <param name="errorCondition">Function delegate which checks the error condition.</param>
    ''' <param name="errorText">Error text to be assigned in the error case.</param>
    ''' <returns>true, if an error occured.</returns>
    <System.Runtime.CompilerServices.Extension>
    Public Function SetErrorOrNull(
        errorProvider As ErrorProvider,
        control As Control,
        errorCondition As Func(Of Boolean),
        errorText As String) As Boolean

        If errorCondition() Then
            errorProvider.SetError(control, errorText)
            Return True
        End If

        errorProvider.SetError(control, Nothing)

        Return False
    End Function
End Module
