﻿#region License

// Copyright (c) 2014 The Sentry Team and individual contributors.
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted
// provided that the following conditions are met:
// 
//     1. Redistributions of source code must retain the above copyright notice, this list of
//        conditions and the following disclaimer.
// 
//     2. Redistributions in binary form must reproduce the above copyright notice, this list of
//        conditions and the following disclaimer in the documentation and/or other materials
//        provided with the distribution.
// 
//     3. Neither the name of the Sentry nor the names of its contributors may be used to
//        endorse or promote products derived from this software without specific prior written
//        permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR
// IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;

using NUnit.Framework;

using SharpRaven.UnitTests.Utilities;

namespace SharpRaven.UnitTests.RavenClientTests
{
    [TestFixture]
    public class RavenClientTests
    {
        [Test]
        public void Constructor_NullDsn_ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new RavenClient((Dsn)null));
            Assert.That(exception.ParamName, Is.EqualTo("dsn"));
        }


        [Test]
        public void Constructor_NullDsnString_ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new RavenClient((string)null));
            Assert.That(exception.ParamName, Is.EqualTo("dsn"));
        }


        [Test]
        public void Constructor_StringDsn_CurrentDsnEqualsDsn()
        {
            IRavenClient ravenClient = new RavenClient(TestHelper.DsnUri);
            Assert.That(ravenClient.CurrentDsn.ToString(), Is.EqualTo(TestHelper.DsnUri));
        }


        [Test]
        public void Logger_IsRoot()
        {
            IRavenClient ravenClient = new RavenClient(TestHelper.DsnUri);
            Assert.That(ravenClient.Logger, Is.EqualTo("root"));
        }


        [Test]
        public void Release_IsNullByDefault()
        {
            IRavenClient ravenClient = new RavenClient(TestHelper.DsnUri);

            Assert.That(ravenClient.Release, Is.Null);
        }
    }
}