// *****************************************************************************
// UnhandledEventActionException.cs
//
// Author:
//       Olavo Henrique Dias <olavodias@gmail.com>
//
// Copyright (c) 2023 Olavo Henrique Dias
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// *****************************************************************************
using System;
namespace GitHubApps.Exceptions;

/// <summary>
/// An exception thrown when there is no event handler for the event/action combination
/// </summary>
public class UnhandledEventActionException: System.Exception
{
    /// <include file='documentation_shared.xml' path='Documentation/ErrorMessages/Parameters[@name="default_error_message"]/*'/>
    private const string DEFAULT_ERROR_MESSAGE = "The action {1} for event {0} is not handled";

    /// <summary>
    /// The event that was triggered
    /// </summary>
    public string EventName { get; protected set; }
    /// <summary>
    /// The action inside the event that was triggered
    /// </summary>
    public string Action { get; protected set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnhandledEventActionException"/>
    /// </summary>
    /// <param name="eventName">The event that was triggered</param>
    /// <param name="action">The action inside the event that was triggered</param>
    public UnhandledEventActionException(string eventName, string action): this(eventName, action, null) { }

    /// <inheritdoc cref="UnhandledEventActionException(string, string)"/>
    /// <param name="eventName">The event that was triggered</param>
    /// <param name="action">The action inside the event that was triggered</param>
    /// <include file='documentation_shared.xml' path='Documentation/ErrorMessages/Parameters[@name="innerException"]/*'/>
    public UnhandledEventActionException(string eventName, string action, Exception? innerException): this(string.Format(DEFAULT_ERROR_MESSAGE, eventName, action), eventName, action, innerException) { }

    /// <inheritdoc cref="UnhandledEventActionException(string, string, Exception?)"/>
    /// <param name="eventName">The event that was triggered</param>
    /// <param name="action">The action inside the event that was triggered</param>
    /// <include file='documentation_shared.xml' path='Documentation/ErrorMessages/Parameters[@name="message"]/*'/>
    /// <include file='documentation_shared.xml' path='Documentation/ErrorMessages/Parameters[@name="innerException"]/*'/>
    public UnhandledEventActionException(string? message, string eventName, string action, Exception? innerException): base(message, innerException)
    {
        EventName = eventName;
        Action = action;
    }

}

