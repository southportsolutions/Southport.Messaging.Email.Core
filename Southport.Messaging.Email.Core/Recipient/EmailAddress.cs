﻿// ***********************************************************************
// Assembly         : Southport.Messaging.Email.Core
// Author           : RobertHAnstett
// Created          : 12-27-2020
//
// Last Modified By : RobertHAnstett
// Last Modified On : 07-28-2021
// ***********************************************************************
// <copyright file="EmailAddress.cs" company="Southport Solutions, LLC">
//     2020
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Southport.Messaging.Email.Core.Recipient
{
    /// <summary>
    /// Class EmailAddress.
    /// Implements the <see cref="Southport.Messaging.Email.Core.Recipient.IEmailAddress" />
    /// </summary>
    /// <seealso cref="Southport.Messaging.Email.Core.Recipient.IEmailAddress" />
    public class EmailAddress : IEmailAddress
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailAddress"/> class.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="name">The name.</param>
        public EmailAddress(string address, string name = null)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentNullException(nameof(address));
            }

            Address = address;
            Name = name;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name))
            {
                return Address;
            }

            return $"{Name} <{Address}>";
        }

        /// <summary>
        /// The email regex expressions
        /// </summary>
        public const string RegexExpressions = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
        
        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns><c>true</c> if Address is a valid email address, <c>false</c> otherwise.</returns>
        public bool Validate()
        {
            return Validate(Address);
        }

        /// <summary>
        /// Validates the specified address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns><c>true</c> if the address matches to the regex, <c>false</c> otherwise.</returns>
        public static bool Validate(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                    RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    RegexExpressions,
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public bool IsValid => Validate();
    }
}