# FkThat.CoreLib

Various commonly usable components.

## Abstractions

Abstractions and their implementation to help writing more unit-testing friendly code.

### IClock, SystemClock

Provides the current DateTimeOffset.

### ITimeZone, SystemTimeZone

Provides the local TimeZoneInfo.

### IRandomGenerator

The abstract random data generator.

#### CryptoRandomGenerator

The implementation of IRandomGenerator with the modern
System.Security.Cryptography.RandomNumberGenerator.

#### PseudoRandomGenerator

The implementation of IRandomGenerator with the legacy System.Random type.

### IGuidGenerator

The abstract guid generator.

#### V4GuidGenerator

The random (version 4) GUID generator.

#### V7GuidGenerator

The version 7 (sequential) GUID generator.

### Console abstractions

#### IConsoleText

The abstraction of the text console input/output.

#### IConsoleStdio

The abstraction of the stream (binary) console input/output.

#### IConsoleKeyboard

The abstraction of the keyboard console input.

#### SystemConsole

The default (system) implementation of IConsole\* interfaces
