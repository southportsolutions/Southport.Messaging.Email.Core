﻿// ***********************************************************************
// Assembly         : Southport.Messaging.Email.Core
// Author           : RobertHAnstett
// Created          : 07-27-2021
//
// Last Modified By : RobertHAnstett
// Last Modified On : 07-27-2021
// ***********************************************************************
// <copyright file="IEmailFactory.cs" company="Southport Solutions, LLC">
//     2020
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Southport.Messaging.Email.Core
{
    /// <summary>
    /// Interface IEmailMessageFactory
    /// </summary>
    public interface IEmailMessageFactory
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>IEmailMessageCore.</returns>
        IEmailMessageCore Create();
    }
}