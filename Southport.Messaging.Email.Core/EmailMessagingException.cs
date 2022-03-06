// ***********************************************************************
// Assembly         : Southport.Messaging.Email.Core
// Author           : RobertHAnstett
// Created          : 03-06-2022
//
// Last Modified By : RobertHAnstett
// Last Modified On : 03-06-2022
// ***********************************************************************
// <copyright file="EmailMessagingException.cs" company="Southport Solutions, LLC">
//     2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Southport.Messaging.Email.Core
{
    /// <summary>
    /// Class EmailMessagingException.
    /// Implements the <see cref="System.Exception" />
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class EmailMessagingException : Exception
    {
        public EmailMessagingException(string message) : base(message){}
    }
}
