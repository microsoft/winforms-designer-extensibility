' -------------------------------------------------------------------
' Copyright (c) Microsoft Corporation. All Rights Reserved.
' -------------------------------------------------------------------

Imports System.Runtime.CompilerServices
Imports Microsoft.DotNet.DesignTools.Protocol

#Disable Warning BCVSTHRD003 ' Avoid awaiting foreign Tasks

Namespace Global

    Friend Module GlobalUtilities
        Private Const ValueCannotBeAnEmptyString As String = "Value cannot be an empty string!"
        Private Const ValueCannotBeNull As String = "Value cannot be null!"

        ''' <summary>
        '''  If the specified <paramref name="value"/> is <see langword="null"/>, throw an
        '''  <see cref="InvalidOperationException"/>.
        ''' </summary>
        ''' <exception cref="InvalidOperationException"/>
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Sub ThrowIfNull(Of T)(ByVal value As T)
            If value Is Nothing Then
                ThrowHelper.ThrowInvalidOperationException(ValueCannotBeNull)
            End If
        End Sub

        ''' <summary>
        '''  If the specified <paramref name="value"/> is <see langword="null"/>, throw an
        '''  <see cref="InvalidOperationException"/>. Otherwise, return the value passed.
        ''' </summary>
        ''' <exception cref="InvalidOperationException"/>
        <Extension, MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function OrThrowIfNull(Of T)(value As T) As T
            ThrowIfNull(value)
            Return value
        End Function

        ''' <summary>
        '''  Awaits the specified <paramref name="task"/>. If the result is <see langword="null"/>,
        '''  throw an <see cref="InvalidOperationException"/>. Otherwise, return the result.
        ''' </summary>
        ''' <exception cref="InvalidOperationException"/>
        <System.Runtime.CompilerServices.Extension>
        Public Async Function OrThrowIfNullAsync(Of T)(ByVal task As Task(Of T)) As Task(Of T)
            Return (Await task).OrThrowIfNull()
        End Function

        ''' <summary>
        '''  If <paramref name="value"/> is <see langword="null"/> or an empty <see cref="String"/>
        '''  <see cref="InvalidOperationException"/>.
        ''' </summary>
        ''' <exception cref="InvalidOperationException"/>
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Sub ThrowIfNullOrEmpty(ByVal value As String)
            If value.IsNullOrEmpty() Then
                ThrowIfNull(value)
                ThrowHelper.ThrowInvalidOperationException(ValueCannotBeAnEmptyString)
            End If
        End Sub

        ''' <summary>
        '''  If <paramref name="value"/> is <see langword="null"/> or an empty <see cref="String"/>
        '''  <see cref="InvalidOperationException"/>. Otherwise, return the value passed.
        ''' </summary>
        ''' <exception cref="InvalidOperationException"/>
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function OrThrowIfNullOrEmpty(ByVal value As String) As String
            ThrowIfNullOrEmpty(value)
            Return value
        End Function

        ''' <summary>
        '''  If <paramref name="argument"/> is <see langword="null"/>, throw an <see cref="ArgumentNullException"/>.
        ''' </summary>
        ''' <exception cref="ArgumentNullException"/>
#If NET6_0_OR_GREATER Then
        <Obsolete("Use ArgumentNullException.ThrowIfNull(...) instead.")>
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Sub ThrowIfArgumentIsNull(
            ByVal argument As Object,
            <CallerArgumentExpression("argument")> Optional ByVal paramName As String = Nothing)
            ArgumentNullException.ThrowIfNull(argument, paramName)
#Else
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Sub ThrowIfArgumentIsNull(
        ByVal argument As Object,
        <CallerArgumentExpression("argument")> Optional ByVal paramName As String = Nothing)
            If argument Is Nothing Then
                ThrowHelper.ThrowArgumentNullException(paramName)
            End If
#End If
        End Sub

        ''' <summary>
        '''  If <paramref name="argument"/> is <see langword="null"/>, throw an <see cref="ArgumentNullException"/>.
        '''  Otherwise, return the value of <paramref name="argument"/>.
        ''' </summary>
        ''' <exception cref="ArgumentNullException"/>
        <Extension, MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function OrThrowIfArgumentIsNull(Of T)(
            argument As T,
            <CallerArgumentExpression("argument")> Optional ByVal paramName As String = Nothing) As T
#If NET6_0_OR_GREATER Then
            ArgumentNullException.ThrowIfNull(argument, paramName)
#Else
            ThrowIfArgumentIsNull(argument, paramName)
#End If

            Return argument
        End Function

        ''' <summary>
        '''  If <paramref name="argument"/> is <see langword="null"/> or an empty <see cref="String"/>,
        '''  throw an <see cref="ArgumentNullException"/>.
        ''' </summary>
        ''' <exception cref="ArgumentNullException"/>
#If NET7_0_OR_GREATER Then
    <Obsolete("Use ArgumentException.ThrowIfNullOrEmpty(...) instead.")>
    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Sub ThrowIfArgumentIsNullOrEmpty(ByVal argument As String, <CallerArgumentExpression("argument")> Optional ByVal paramName As String = Nothing)
		ArgumentException.ThrowIfNullOrEmpty(argument, paramName)
#Else
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Sub ThrowIfArgumentIsNullOrEmpty(
            argument As String,
            <CallerArgumentExpression("argument")> Optional paramName As String = Nothing)

            If argument.IsNullOrEmpty() Then
#If NET6_0_OR_GREATER Then
                ArgumentNullException.ThrowIfNull(argument, paramName)
#Else
                ThrowIfArgumentIsNull(argument, paramName)
#End If
                ThrowHelper.ThrowArgumentException(ValueCannotBeAnEmptyString, paramName)
            End If
#End If
        End Sub

        ''' <summary>
        '''  If <paramref name="sessionId"/> is <see langword="null"/>,
        '''  throw an <see cref="ArgumentNullException"/>.
        ''' </summary>
        ''' <exception cref="ArgumentNullException"/>
        <System.Runtime.CompilerServices.Extension>
        Public Function OrThrowIfArgumentIsNull(
            sessionId As SessionId,
            <CallerArgumentExpression("sessionId")> Optional ByVal paramName As String = Nothing) As SessionId

            If sessionId.IsNull Then
                Throw New ArgumentNullException(NameOf(sessionId))
            End If

            Return sessionId
        End Function

        ''' <summary>
        '''  If <paramref name="argument"/> is <see langword="null"/> or an empty <see cref="String"/>,
        '''  throw an <see cref="ArgumentNullException"/>. Otherwise, return the value of <paramref name="argument"/>.
        ''' </summary>
        ''' <exception cref="ArgumentNullException"/>
        <Extension, MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function OrThrowIfArgumentIsNullOrEmpty(
            argument As String,
            <CallerArgumentExpression("argument")> Optional ByVal paramName As String = Nothing) As String

            ThrowIfArgumentIsNullOrEmpty(argument, paramName)

            Return argument
        End Function

        ''' <summary>
        '''  Indicates whether the specified string is <see langword="null"/> or an empty <see cref="String"/>.
        ''' </summary>
        ''' <remarks>
        '''  This method can be used to workaround the fact that string.IsNullOrEmpty doesn't have nullable
        '''  annotations on .NET Framework.
        ''' </remarks>
        <Extension, MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function IsNullOrEmpty(value As String) As Boolean
            Return String.IsNullOrEmpty(value)
        End Function
    End Module

End Namespace
