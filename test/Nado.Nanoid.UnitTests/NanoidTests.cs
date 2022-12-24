// Copyright (c) 2017 zhu yu
// Licensed under the MIT License, see: https://github.com/codeyu/nanoid-net

using AutoFixture.Xunit2;
using Shouldly;

namespace BS.Nado.Nanoid.UnitTests;

public class NanoidTests
{
    private const int DefaultSize = 21;
    private const string DefaultAlphabet = "_-0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    [Fact]
    public void TestDefault()
    {
        string result = Nanoid.Generate();
        Assert.Equal(DefaultSize, result.Length);
    }

    [Fact]
    public void TestCustomSize()
    {
        string result = Nanoid.Generate(size: 10);
        Assert.Equal(10, result.Length);
    }

    [Fact]
    public void TestCustomAlphabet()
    {
        string result = Nanoid.Generate("1234abcd");
        Assert.Equal(DefaultSize, result.Length);
    }

    [Fact]
    public void TestCustomAlphabetAndSize()
    {
        string result = Nanoid.Generate("1234abcd", 7);
        Assert.Equal(7, result.Length);
    }

    [Fact]
    public void TestCustomRandom()
    {
        Random random = new(10);
        string result = Nanoid.Generate(random);
        Assert.Equal(DefaultSize, result.Length);
    }

    [Fact]
    public void TestSingleLetterAlphabet()
    {
        string actual = Nanoid.Generate("a", 5);

        Assert.Equal("aaaaa", actual);
    }

    [Theory]
    [InlineData(4, "adca")]
    [InlineData(18, "cbadcbadcbadcbadcc")]
    public void TestPredefinedRandomSequence(
        int size,
        string expected
    )
    {
        byte[] sequence = { 2, 255, 3, 7, 7, 7, 7, 7, 0, 1 };
        PredefinedRandomSequence random = new(sequence);
        string actual = Nanoid.Generate(random, "abcde", size);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task TestAsyncGenerate()
    {
        string result = await Nanoid.GenerateAsync();

        Assert.Equal(DefaultSize, result.Length);
    }

    [Fact]
    public void TestGeneratesUrlFriendlyIDs()
    {
        foreach (int dummy in Enumerable.Range(1, 10))
        {
            string result = Nanoid.Generate();
            Assert.Equal(DefaultSize, result.Length);

            foreach (char c in result)
            {
                Assert.Contains(c, result);
            }
        }
    }

    [Fact]
    public void TestHasNoCollisions()
    {
        const int count = 100 * 1000;
        Dictionary<string, bool> dictUsed = new();
        foreach (int dummy in Enumerable.Range(1, count))
        {
            string result = Nanoid.Generate();
            Assert.False(dictUsed.TryGetValue(result, out bool _));
            dictUsed.Add(result, true);
        }
    }

    [Fact]
    public void TestFlatDistribution()
    {
        const int count = 100 * 1000;
        Dictionary<char, int> chars = new();
        foreach (int dummy in Enumerable.Range(1, count))
        {
            string id = Nanoid.Generate();
            for (int i = 0; i < DefaultSize; i++)
            {
                char c = id[i];
                if (!chars.ContainsKey(c))
                {
                    chars.Add(c, 0);
                }

                chars[c] += 1;
            }
        }

        foreach (double distribution in chars.Select(c => c.Value * DefaultAlphabet.Length / (double)(count * DefaultSize)))
        {
            Assert.True(ToBeCloseTo(distribution, 1, 1));
        }
    }

    [Fact]
    public void TestMask()
    {
        for (int length = 1; length < 256; length++)
        {
            int mask1 = (2 << (int)Math.Floor(Math.Log(length - 1) / Math.Log(2))) - 1;
            int mask2 = (2 << (31 - Nanoid.Clz32((length - 1) | 1))) - 1;
            Assert.Equal(mask1, mask2);
        }
    }

    [Fact]
    public void Generate_with_null_alphabet_should_throw_ArgumentNullException()
    {
        // Act & Assert
#pragma warning disable CS8625
        Should.Throw<ArgumentNullException>(() => Nanoid.Generate(null, DefaultSize));
#pragma warning restore CS8625
    }

    [Fact]
    public void Generate_with_null_random_should_throw_ArgumentNullException()
    {
        // Act & Assert
#pragma warning disable CS8625
        Should.Throw<ArgumentNullException>(() => Nanoid.Generate(null, DefaultAlphabet));
#pragma warning restore CS8625
    }

    [Theory]
    [InlineAutoData("")]
    public void Generate_with_invalid_alphabet_size_should_throw_ArgumentOutOfRangeException(
        string alphabet
    )
    {
        // Act & Assert
        Should.Throw<ArgumentOutOfRangeException>(() => Nanoid.Generate(alphabet));
    }

    [Theory]
    [InlineAutoData(0)]
    [InlineAutoData(-1)]
    public void Generate_with_invalid_size_should_throw_ArgumentOutOfRangeException(
        int size
    )
    {
        // Act & Assert
        Should.Throw<ArgumentOutOfRangeException>(() => Nanoid.Generate(DefaultAlphabet, size));
    }

    private static bool ToBeCloseTo(
        double actual,
        double expected,
        int precision = 2
    )
    {
        bool pass = Math.Abs(expected - actual) < Math.Pow(10, -precision) / 2;
        return pass;
    }
}
