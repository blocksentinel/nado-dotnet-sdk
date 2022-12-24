// Copyright (c) 2017 zhu yu
// Licensed under the MIT License, see: https://github.com/codeyu/nanoid-net

namespace BS.Nado.Nanoid;

/// <summary>
///     A tiny, secure, URL-friendly, unique string ID generator.
/// </summary>
public static class Nanoid
{
    private const string DefaultAlphabet = "_-0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const int DefaultSize = 21;
    private static readonly CryptoRandom Random = new();

    /// <summary>
    ///     Generate the Nano ID asynchronously.
    /// </summary>
    /// <param name="alphabet"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static Task<string> GenerateAsync(
        string alphabet = DefaultAlphabet,
        int size = DefaultSize
    )
    {
        return Task.Run(() => Generate(Random, alphabet, size));
    }

    /// <summary>
    ///     Generate the Nano ID.
    /// </summary>
    /// <param name="alphabet"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static string Generate(
        string alphabet = DefaultAlphabet,
        int size = DefaultSize
    )
    {
        return Generate(Random, alphabet, size);
    }

    /// <summary>
    ///     Generate the Nano ID using a custom Random instance.
    /// </summary>
    /// <param name="random"></param>
    /// <param name="alphabet"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static string Generate(
        Random random,
        string alphabet = DefaultAlphabet,
        int size = DefaultSize
    )
    {
        if (random == null)
        {
            throw new ArgumentNullException(nameof(random));
        }

        if (alphabet == null)
        {
            throw new ArgumentNullException(nameof(alphabet));
        }

        if (alphabet.Length is <= 0 or >= 256)
        {
            throw new ArgumentOutOfRangeException(nameof(alphabet), alphabet.Length,
                "Alphabet must contain between 1 and 255 (inclusive) symbols");
        }

        if (size <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(size), size, "Size must be greater than 0");
        }

        // See https://github.com/ai/nanoid/blob/master/format.js for
        // explanation why masking is use (`random % alphabet` is a common
        // mistake security-wise).
        int mask = (2 << (31 - Clz32((alphabet.Length - 1) | 1))) - 1;
        int step = (int)Math.Ceiling(1.6 * mask * size / alphabet.Length);

        Span<char> idBuilder = stackalloc char[size];
        Span<byte> bytes = stackalloc byte[step];

        int cnt = 0;

        while (true)
        {
            random.NextBytes(bytes);

            for (int i = 0; i < step; i++)
            {
                int alphabetIndex = bytes[i] & mask;

                if (alphabetIndex >= alphabet.Length)
                {
                    continue;
                }

                idBuilder[cnt] = alphabet[alphabetIndex];
                if (++cnt == size)
                {
                    return new string(idBuilder);
                }
            }
        }
    }

    /// <summary>
    ///     Counts leading zeros of <paramref name="x" />.
    /// </summary>
    /// <param name="x">Input number.</param>
    /// <returns>Number of leading zeros.</returns>
    /// <remarks>
    ///     Courtesy of spender/Sunsetquest see https://stackoverflow.com/a/10439333/623392.
    /// </remarks>
    internal static int Clz32(
        int x
    )
    {
        const int numIntBits = sizeof(int) * 8; //compile time constant
        //do the smearing
        x |= x >> 1;
        x |= x >> 2;
        x |= x >> 4;
        x |= x >> 8;
        x |= x >> 16;
        //count the ones
        x -= (x >> 1) & 0x55555555;
        x = ((x >> 2) & 0x33333333) + (x & 0x33333333);
        x = ((x >> 4) + x) & 0x0f0f0f0f;
        x += x >> 8;
        x += x >> 16;

        return numIntBits - (x & 0x0000003f); //subtract # of 1s from 32
    }
}
