// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

#if NETSTANDARD1_3
// [[ISSUE60]] Remove this entire file when Core CLR gets support for EncryptedXml.
// This is just a dummy implementation of the class that always throws.
// The only reason it's here (albeit internal) is to provide a nice error message if key
// material that was generated by Desktop CLR needs to be read by Core CLR.

using System;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.DataProtection.XmlEncryption
{
    internal sealed class EncryptedXmlDecryptor : IXmlDecryptor
    {
        private readonly ILogger _logger;

        public EncryptedXmlDecryptor()
            : this(loggerFactory: null)
        {
        }

        public EncryptedXmlDecryptor(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory?.CreateLogger<EncryptedXmlDecryptor>();
        }

        public XElement Decrypt(XElement encryptedElement)
        {
            if (_logger.IsErrorLevelEnabled())
            {
                _logger.LogError(Resources.EncryptedXmlDecryptor_DoesNotWorkOnCoreClr);
            }

            throw new PlatformNotSupportedException(Resources.EncryptedXmlDecryptor_DoesNotWorkOnCoreClr);
        }
    }
}

#endif
