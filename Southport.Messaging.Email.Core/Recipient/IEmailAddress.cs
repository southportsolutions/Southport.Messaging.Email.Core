﻿// ***********************************************************************
// Assembly         : Southport.Messaging.Email.Core
// Author           : RobertHAnstett
// Created          : 12-27-2020
//
// Last Modified By : RobertHAnstett
// Last Modified On : 12-27-2020
// ***********************************************************************
// <copyright file="IEmailAddress.cs" company="Southport Solutions, LLC">
//     2020
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Southport.Messaging.Email.Core.Recipient
{
    /// <summary>
    /// Interface IEmailAddress
    /// </summary>
    public interface IEmailAddress
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        string Address { get; set; }
        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns><c>true</c> if Address is a valid email address, <c>false</c> otherwise.</returns>
        bool Validate();
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        string ToString();
    }
}