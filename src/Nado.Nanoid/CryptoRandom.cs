// Copyright (c) 2017 zhu yu
// Licensed under the MIT License, see: https://github.com/codeyu/nanoid-net

using System.Security.Cryptography;

namespace BS.Nado.Nanoid;

/// <inheritdoc />
/// <summary>
///     Random using <see cref="RandomNumberGenerator" /> under the hood.
/// </summary>
internal sealed class CryptoRandom : Random
{
    /// <inheritdoc />
    public override void NextBytes(
        Span<byte> buffer
    )
    {
        RandomNumberGenerator.Fill(buffer);
    }
}
