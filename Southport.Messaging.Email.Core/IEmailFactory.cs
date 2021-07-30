// ***********************************************************************
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
    public interface IEmailMessageFactory<TInterface> : IEmailMessageCore where TInterface : IEmailMessageCore
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>IEmailMessage TInterface.</returns>
        IEmailMessage<TInterface> Create();
    }
}