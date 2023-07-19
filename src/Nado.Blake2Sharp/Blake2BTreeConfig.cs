﻿// BLAKE2 reference source code package - C# implementation

// Written in 2012 by Christian Winnerlein  <codesinchaos@gmail.com>

// To the extent possible under law, the author(s) have dedicated all copyright
// and related and neighboring rights to this software to the public domain
// worldwide. This software is distributed without any warranty.

// You should have received a copy of the CC0 Public Domain Dedication along with
// this software. If not, see <http://creativecommons.org/publicdomain/zero/1.0/>.

namespace BS.Nado.Blake2Sharp;

public sealed class Blake2BTreeConfig : ICloneable
{
    public Blake2BTreeConfig()
    {
        IntermediateHashSize = 64;
    }

    public int IntermediateHashSize { get; set; }
    public int MaxHeight { get; set; }
    public long LeafSize { get; set; }
    public int FanOut { get; set; }

    object ICloneable.Clone()
    {
        return Clone();
    }

    public Blake2BTreeConfig Clone()
    {
        Blake2BTreeConfig result = new();
        result.IntermediateHashSize = IntermediateHashSize;
        result.MaxHeight = MaxHeight;
        result.LeafSize = LeafSize;
        result.FanOut = FanOut;
        return result;
    }

    public static Blake2BTreeConfig CreateInterleaved(
        int parallelism
    )
    {
        Blake2BTreeConfig result = new();
        result.FanOut = parallelism;
        result.MaxHeight = 2;
        result.IntermediateHashSize = 64;
        return result;
    }
}
