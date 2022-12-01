' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.

' Copied and translated to VB from https://github/dotnet/runtime

' Note: This attribute was introduced in .NET Core 3.0.

Namespace Global.System.Runtime.CompilerServices

    <AttributeUsage(AttributeTargets.Parameter, AllowMultiple:=False, Inherited:=False)>
    Friend NotInheritable Class CallerArgumentExpressionAttribute
        Inherits Attribute

        Public Sub New(ByVal parameterName As String)
            Me.ParameterName = parameterName
        End Sub

        Public ReadOnly Property ParameterName() As String
    End Class

End Namespace
