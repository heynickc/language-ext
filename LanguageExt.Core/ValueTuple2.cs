﻿using System;
using LanguageExt;
using static LanguageExt.Prelude;
using System.Diagnostics.Contracts;

public static class ValueTuple2Extensions
{
    /// <summary>
    /// Append an extra item to the tuple
    /// </summary>
    [Pure]
    public static ValueTuple<T1, T2, T3> Append<T1, T2, T3>(this ValueTuple<T1, T2> self, T3 third) =>
        VTuple(self.Item1, self.Item2, third);

    /// <summary>
    /// Sum
    /// </summary>
    [Pure]
    public static int Sum(this ValueTuple<int, int> self) =>
        self.Item1 + self.Item2;

    /// <summary>
    /// Sum
    /// </summary>
    [Pure]
    public static double Sum(this ValueTuple<double, double> self) =>
        self.Item1 + self.Item2;

    /// <summary>
    /// Sum
    /// </summary>
    [Pure]
    public static float Sum(this ValueTuple<float, float> self) =>
        self.Item1 + self.Item2;

    /// <summary>
    /// Sum
    /// </summary>
    [Pure]
    public static decimal Sum(this ValueTuple<decimal, decimal> self) =>
        self.Item1 + self.Item2;

    /// <summary>
    /// Map to R
    /// </summary>
    [Pure]
    public static R Map<T1, T2, R>(this ValueTuple<T1, T2> self, Func<T1, T2, R> map) =>
        map(self.Item1, self.Item2);

    /// <summary>
    /// Map to tuple
    /// </summary>
    [Pure]
    public static ValueTuple<R1, R2> Map<T1, T2, R1, R2>(this ValueTuple<T1, T2> self, Func<ValueTuple<T1, T2>, ValueTuple<R1, R2>> map) =>
        map(self);

    /// <summary>
    /// Bi-map to tuple
    /// </summary>
    [Pure]
    public static ValueTuple<R1, R2> BiMap<T1, T2, R1, R2>(this ValueTuple<T1, T2> self, Func<T1, R1> firstMap, Func<T2, R2> secondMap) =>
        VTuple(firstMap(self.Item1), secondMap(self.Item2));

    /// <summary>
    /// First item-map to tuple
    /// </summary>
    [Pure]
    public static ValueTuple<R1, T2> MapFirst<T1, T2, R1>(this ValueTuple<T1, T2> self, Func<T1, R1> firstMap) =>
        VTuple(firstMap(self.Item1), self.Item2);

    /// <summary>
    /// Second item-map to tuple
    /// </summary>
    [Pure]
    public static ValueTuple<T1, R2> MapSecond<T1, T2, R2>(this ValueTuple<T1, T2> self, Func<T2, R2> secondMap) =>
        VTuple(self.Item1, secondMap(self.Item2));

    /// <summary>
    /// Map to tuple
    /// </summary>
    [Pure]
    public static ValueTuple<R1, R2> Select<T1, T2, R1, R2>(this ValueTuple<T1, T2> self, Func<ValueTuple<T1, T2>, ValueTuple<R1, R2>> map) =>
        map(self);

    /// <summary>
    /// Iterate
    /// </summary>
    public static Unit Iter<T1, T2>(this ValueTuple<T1, T2> self, Action<T1, T2> func)
    {
        func(self.Item1, self.Item2);
        return Unit.Default;
    }

    /// <summary>
    /// Iterate
    /// </summary>
    public static Unit Iter<T1, T2>(this ValueTuple<T1, T2> self, Action<T1> first, Action<T2> second)
    {
        first(self.Item1);
        second(self.Item2);
        return Unit.Default;
    }

    /// <summary>
    /// Fold
    /// </summary>
    [Pure]
    public static S Fold<T1, T2, S>(this ValueTuple<T1, T2> self, S state, Func<S, T1, T2, S> fold) =>
        fold(state, self.Item1, self.Item2);

    /// <summary>
    /// Bi-fold
    /// </summary>
    [Pure]
    public static S BiFold<T1, T2, S>(this ValueTuple<T1, T2> self, S state, Func<S, T1, S> firstFold, Func<S, T2, S> secondFold) =>
        secondFold(firstFold(state, self.Item1), self.Item2);

    /// <summary>
    /// Bi-fold
    /// </summary>
    [Pure]
    public static S BiFoldBack<T1, T2, S>(this ValueTuple<T1, T2> self, S state, Func<S, T2, S> firstFold, Func<S, T1, S> secondFold) =>
        secondFold(firstFold(state, self.Item2), self.Item1);
}