using System;
using System.Collections.Generic;
using System.IO;
using Southport.Messaging.Email.Core.EmailAttachments;
using Southport.Messaging.Email.Core.Recipient;
using Xunit;
using Xunit.Abstractions;

namespace Southport.Messaging.Email.Core.Test
{
    public class EmailAddressUnitTest
    {
        public readonly List<string> ValidEmailAddresses =
        [
            "email@example.com",
            "firstname.lastname@example.com",
            "email@subdomain.example.com",
            "firstname+lastname@example.com",
            "email@123.123.123.123",
            "email@[123.123.123.123]",
            "\"email\"@example.com",
            "1234567890@example.com",
            "email@example-one.com",
            "email@example.name",
            "email@example.museum",
            "email@example.co.jp",
            "firstname-lastname@example.com"
        ];

        public readonly List<string> InvalidEmailAddresses =
        [
            "plainaddress",
            "#@%^%#$@#$@#.com",
            "@example.com",
            "Joe Smith <email@example.com>",
            "email.example.com",
            "email@example@example.com",
            ".email@example.com",
            "email.@example.com",
            "email..email@example.com",
            "あいうえお@example.com",
            "email@example.com (Joe Smith)",
            "email@example",
            "email@-example.com",
            "email@example..com",
            "Abc..123@example.com"
        ];

        private readonly  ITestOutputHelper _output;

        public EmailAddressUnitTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void EmailAddress_Static_Validation_Valid()
        {
            foreach (var validEmailAddress in ValidEmailAddresses)
            {
                _output.WriteLine(validEmailAddress);
                Assert.True(EmailAddress.Validate(validEmailAddress));
            }
        }

        [Fact]
        public void EmailAddress_Static_Validation_Invalid()
        {
            foreach (var invalidEmailAddress in InvalidEmailAddresses)
            {
                _output.WriteLine(invalidEmailAddress);
                Assert.False(EmailAddress.Validate(invalidEmailAddress));
            }
        }

        [Fact]
        public void EmailAddress_Validation_Valid()
        {
            foreach (var validEmailAddress in ValidEmailAddresses)
            {
                _output.WriteLine(validEmailAddress);
                Assert.True(new EmailAddress(validEmailAddress).Validate());
            }
        }

        [Fact]
        public void EmailAddress_Validation_Invalid()
        {
            foreach (var invalidEmailAddress in InvalidEmailAddresses)
            {
                _output.WriteLine(invalidEmailAddress);
                Assert.False(new EmailAddress(invalidEmailAddress).Validate());
            }
        }

        [Fact]
        public void EmailAddress_Consutrctor_NullAddress()
        {
            Assert.Throws<ArgumentNullException>(() => new EmailAddress(null));
        }
    }
}
