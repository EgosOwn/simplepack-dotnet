# SimplePack-dotnet 🧳


This is a dotnet binary encoding library intended to encode bytes messages suitable for transmission over text-only channels, e.g. certain document formats, instant messages, and web pages.

* Custom human meaningful header/footer
* Built in checksum for error detection (not cryptographic)
* No new lines or odd characters (uses base58). This means less mangling by external services.

## Install

Available on nuget: https://www.nuget.org/packages/SimplePack-base58/


## Usage

```
SimplePack packer = new SimplePack("MyHeader ", " MyFooter");

# encode
packer.encode(arbitraryBytes);
# decode
packer.decode("MyHeader <encode result data> MyFooter");

```

