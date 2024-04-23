# FkThat.CoreLib

The library of simple commonly used types that mostly wraps the .NET types with some flavors
like segregating abstract contracts and implementations.

## IClock, SystemClock

Provides the current DateTimeOffset and the local TimeZoneInfo.

## IRandomGenerator

The abstract random data generator.

### CryptoRandomGenerator

The implementation of IRandomGenerator with the modern
System.Security.Cryptography.RandomNumberGenerator.

### PseudoRandomGenerator

The implementation of IRandomGenerator with the legacy System.Random type.

## IGuidGenerator

The abstract guid generator.

### V4GuidGenerator

The random (version 4) GUID generator.

### V7GuidGenerator

The version 7 (sequential) GUID generator.
