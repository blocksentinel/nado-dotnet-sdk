// Copyright (c) 2017 zhu yu
// Licensed under the MIT License, see: https://github.com/codeyu/nanoid-net

namespace BS.Nado.Nanoid.UnitTests;

public class PredefinedRandomSequence : Random
{
    private readonly byte[] _sequence;

    public PredefinedRandomSequence(
        byte[] sequence
    )
    {
        _sequence = sequence;
    }

    public override void NextBytes(
        byte[] buffer
    )
    {
        using IEnumerator<byte> seq = GetSequence(buffer.Length).GetEnumerator();
        for (int i = 0; i < buffer.Length; i++)
        {
            seq.MoveNext();
            buffer[i] = seq.Current;
        }
    }

    public override void NextBytes(
        Span<byte> buffer
    )
    {
        byte[] bytes = new byte[buffer.Length];
        NextBytes(bytes);
        bytes.CopyTo(buffer);
    }

    private IEnumerable<byte> GetSequence(
        int size
    )
    {
        IEnumerable<byte> result = _sequence.AsEnumerable();
        // Update the sequence to match nanoid.js tests and implementation
        // which takes random bytes in reverse order (as of 3489e1e3b0dd7678b72c30f5fb00b806c8ce4fef).
        for (int i = 0; i < size / _sequence.Length; i++)
        {
            IEnumerable<byte> enumerable = result as byte[] ?? result.ToArray();
            result = enumerable.Concat(enumerable);
        }

        return result.Take(size).Reverse();
    }
}
