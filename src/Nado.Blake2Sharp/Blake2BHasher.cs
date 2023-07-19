// BLAKE2 reference source code package - C# implementation

// Written in 2012 by Christian Winnerlein  <codesinchaos@gmail.com>

// To the extent possible under law, the author(s) have dedicated all copyright
// and related and neighboring rights to this software to the public domain
// worldwide. This software is distributed without any warranty.

// You should have received a copy of the CC0 Public Domain Dedication along with
// this software. If not, see <http://creativecommons.org/publicdomain/zero/1.0/>.

namespace BS.Nado.Blake2Sharp;

internal class Blake2BHasher : Hasher
{
    private static readonly Blake2BConfig DefaultConfig = new();
    private readonly Blake2BCore _core = new();
    private readonly byte[]? _key;
    private readonly int _outputSizeInBytes;
    private readonly ulong[] _rawConfig;

    public Blake2BHasher(
        Blake2BConfig? config
    )
    {
        if (config == null)
        {
            config = DefaultConfig;
        }

        _rawConfig = Blake2IvBuilder.ConfigB(config, null);
        if (config.Key != null && config.Key.Length != 0)
        {
            _key = new byte[128];
            Array.Copy(config.Key, _key, config.Key.Length);
        }

        _outputSizeInBytes = config.OutputSizeInBytes;
        Init();
    }

    public override void Init()
    {
        _core.Initialize(_rawConfig);
        if (_key != null)
        {
            _core.HashCore(_key, 0, _key.Length);
        }
    }

    public override byte[] Finish()
    {
        byte[] fullResult = _core.HashFinal();
        if (_outputSizeInBytes != fullResult.Length)
        {
            byte[] result = new byte[_outputSizeInBytes];
            Array.Copy(fullResult, result, result.Length);
            return result;
        }
        else
        {
            return fullResult;
        }
    }

    public override void Update(
        byte[] data,
        int start,
        int count
    )
    {
        _core.HashCore(data, start, count);
    }
}
