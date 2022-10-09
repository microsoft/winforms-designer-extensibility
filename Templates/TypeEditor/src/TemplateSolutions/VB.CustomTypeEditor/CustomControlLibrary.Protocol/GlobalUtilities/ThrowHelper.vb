Namespace Global.System.Runtime.CompilerServices

    Friend Module ThrowHelper
        ''' <summary>
        '''  Thows an <see cref="ArgumentNullException"/>.
        ''' </summary>
        ''' <remarks>
        '''  This is marked with NoInlining to ensure that the JIT can better inline calling code.
        ''' </remarks>
        ''' <exception cref="ArgumentNullException"></exception>
        <MethodImpl(MethodImplOptions.NoInlining)>
        Public Sub ThrowArgumentNullException(ByVal paramName As String)
            Throw New ArgumentNullException(paramName)
        End Sub

        ''' <summary>
        '''  Throws an <see cref="ArgumentException"/>.
        ''' </summary>
        ''' <remarks>
        '''  This is marked with NoInlining to ensure that the JIT can better inline calling code.
        ''' </remarks>
        ''' <exception cref="ArgumentException"></exception>
        <MethodImpl(MethodImplOptions.NoInlining)>
        Public Sub ThrowArgumentException(ByVal message As String, ByVal paramName As String)
            Throw New ArgumentException(message, paramName)
        End Sub

        ''' <summary>
        '''  Throws an <see cref="InvalidOperationException"/>.
        ''' </summary>
        ''' <remarks>
        '''  This is marked with NoInlining to ensure that the JIT can better inline calling code.
        ''' </remarks>
        ''' <exception cref="InvalidOperationException"></exception>
        <MethodImpl(MethodImplOptions.NoInlining)>
        Public Sub ThrowInvalidOperationException(ByVal message As String)
            Throw New InvalidOperationException(message)
        End Sub
    End Module

End Namespace
