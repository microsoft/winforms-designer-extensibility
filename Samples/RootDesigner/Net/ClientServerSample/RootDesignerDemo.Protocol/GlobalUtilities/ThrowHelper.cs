using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Microsoft.WinForms.Utilities.Shared;

internal static class ThrowHelper
{
    /// <summary>
    ///  Throws an <see cref="ArgumentNullException"/>.
    /// </summary>
    /// <remarks>
    ///  This is marked with NoInlining to ensure that the JIT can better inline calling code.
    /// </remarks>
    /// <exception cref="ArgumentNullException"></exception>
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowArgumentNullException(string? paramName)
        => throw new ArgumentNullException(paramName);

    /// <summary>
    ///  Throws an <see cref="ArgumentException"/>.
    /// </summary>
    /// <remarks>
    ///  This is marked with NoInlining to ensure that the JIT can better inline calling code.
    /// </remarks>
    /// <exception cref="ArgumentException"></exception>
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowArgumentException(string message, string? paramName)
        => throw new ArgumentException(message, paramName);

    /// <summary>
    ///  Throws an <see cref="InvalidOperationException"/>.
    /// </summary>
    /// <remarks>
    ///  This is marked with NoInlining to ensure that the JIT can better inline calling code.
    /// </remarks>
    /// <exception cref="InvalidOperationException"></exception>
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowInvalidOperationException(string message)
        => throw new InvalidOperationException(message);
}
