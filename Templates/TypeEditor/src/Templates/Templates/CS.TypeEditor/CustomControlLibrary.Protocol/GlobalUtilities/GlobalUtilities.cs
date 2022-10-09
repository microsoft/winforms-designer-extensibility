// -------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All Rights Reserved.
// -------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.DotNet.DesignTools.Protocol;
using Microsoft.WinForms.Utilities.Shared;

#pragma warning disable VSTHRD003 // Avoid awaiting foreign Tasks

internal static class GlobalUtilities
{
    private const string ValueCannotBeAnEmptyString = "Value cannot be an empty string!";
    private const string ValueCannotBeNull = "Value cannot be null!";

    /// <summary>
    ///  If the specified <paramref name="value"/> is <see langword="null"/>, throw an
    ///  <see cref="InvalidOperationException"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIfNull<T>([NotNull] T? value)
    {
        if (value is null)
        {
            ThrowHelper.ThrowInvalidOperationException(ValueCannotBeNull);
        }
    }

    /// <summary>
    ///  If the specified <paramref name="value"/> is <see langword="null"/>, throw an
    ///  <see cref="InvalidOperationException"/>. Otherwise, return the value passed.
    /// </summary>
    /// <exception cref="InvalidOperationException"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T OrThrowIfNull<T>([NotNull] this T? value)
    {
        ThrowIfNull(value);
        return value;
    }

    /// <summary>
    ///  Awaits the specified <paramref name="task"/>. If the result is <see langword="null"/>,
    ///  throw an <see cref="InvalidOperationException"/>. Otherwise, return the result.
    /// </summary>
    /// <exception cref="InvalidOperationException"/>
    public static async Task<T> OrThrowIfNullAsync<T>(this Task<T?> task)
        => (await task).OrThrowIfNull();

    /// <summary>
    ///  If <paramref name="value"/> is <see langword="null"/> or an empty <see cref="string"/>
    ///  <see cref="InvalidOperationException"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIfNullOrEmpty([NotNull] string? value)
    {
        if (value.IsNullOrEmpty())
        {
            ThrowIfNull(value);
            ThrowHelper.ThrowInvalidOperationException(ValueCannotBeAnEmptyString);
        }
    }

    /// <summary>
    ///  If <paramref name="value"/> is <see langword="null"/> or an empty <see cref="string"/>
    ///  <see cref="InvalidOperationException"/>. Otherwise, return the value passed.
    /// </summary>
    /// <exception cref="InvalidOperationException"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string OrThrowIfNullOrEmpty([NotNull] string? value)
    {
        ThrowIfNullOrEmpty(value);
        return value;
    }

    /// <summary>
    ///  If <paramref name="argument"/> is <see langword="null"/>, throw an <see cref="ArgumentNullException"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
#if NET6_0_OR_GREATER
    [Obsolete("Use ArgumentNullException.ThrowIfNull(...) instead.")]
#endif
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIfArgumentIsNull(
        [NotNull] object? argument,
        [CallerArgumentExpression("argument")] string? paramName = null)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(argument, paramName);
#else
        if (argument is null)
        {
            ThrowHelper.ThrowArgumentNullException(paramName);
        }
#endif
    }

    /// <summary>
    ///  If <paramref name="argument"/> is <see langword="null"/>, throw an <see cref="ArgumentNullException"/>.
    ///  Otherwise, return the value of <paramref name="argument"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T OrThrowIfArgumentIsNull<T>(
        [NotNull] this T? argument,
        [CallerArgumentExpression("argument")] string? paramName = null)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(argument, paramName);
#else
        ThrowIfArgumentIsNull(argument, paramName);
#endif

        return argument;
    }

    /// <summary>
    ///  If <paramref name="argument"/> is <see langword="null"/> or an empty <see cref="string"/>,
    ///  throw an <see cref="ArgumentNullException"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
#if NET7_0_OR_GREATER
    [Obsolete("Use ArgumentException.ThrowIfNullOrEmpty(...) instead.")]
#endif
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIfArgumentIsNullOrEmpty(
        [NotNull] string? argument,
        [CallerArgumentExpression("argument")] string? paramName = null)
    {
#if NET7_0_OR_GREATER
        ArgumentException.ThrowIfNullOrEmpty(argument, paramName);
#else
        if (argument.IsNullOrEmpty())
        {
#if NET6_0_OR_GREATER            
            ArgumentNullException.ThrowIfNull(argument, paramName);
#else
            ThrowIfArgumentIsNull(argument, paramName);
#endif
            ThrowHelper.ThrowArgumentException(ValueCannotBeAnEmptyString, paramName);
        }
#endif
        }

    /// <summary>
    ///  If <paramref name="sessionId"/> is <see langword="null"/>,
    ///  throw an <see cref="ArgumentNullException"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static SessionId OrThrowIfArgumentIsNull(
        this SessionId sessionId,
        [CallerArgumentExpression("sessionId")] string? paramName = null)
    {
        if (sessionId.IsNull)
        {
            throw new ArgumentNullException(nameof(sessionId));
        }

        return sessionId;
    }

    /// <summary>
    ///  If <paramref name="argument"/> is <see langword="null"/> or an empty <see cref="string"/>,
    ///  throw an <see cref="ArgumentNullException"/>. Otherwise, return the value of <paramref name="argument"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string OrThrowIfArgumentIsNullOrEmpty(
        [NotNull] this string? argument,
        [CallerArgumentExpression("argument")] string? paramName = null)
    {
        ThrowIfArgumentIsNullOrEmpty(argument, paramName);
        return argument;
    }

    /// <summary>
    ///  Indicates whether the specified string is <see langword="null"/> or an empty <see cref="string"/>.
    /// </summary>
    /// <remarks>
    ///  This method can be used to workaround the fact that string.IsNullOrEmpty doesn't have nullable
    ///  annotations on .NET Framework.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value)
        => string.IsNullOrEmpty(value);
}
