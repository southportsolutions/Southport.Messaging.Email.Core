// ***********************************************************************
// Assembly         : Southport.Messaging.Email.Core
// Author           : RobertHAnstett
// Created          : 07-27-2021
//
// Last Modified By : RobertHAnstett
// Last Modified On : 03-06-2022
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
        /// <returns>IEmailMessage TInterface.</returns>
        IEmailMessageCore Create();
    }
}