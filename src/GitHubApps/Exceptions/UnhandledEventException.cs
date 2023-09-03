// *****************************************************************************
// UnhandledEventException.cs
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
/// An exception thrown when there is no event handler for the event combination
/// </summary>
public class UnhandledEventException: System.Exception
{
    /// <include file='documentation_shared.xml' path='Documentation/ErrorMessages/Parameters[@name="default_error_message"]/*'/>
    private const string DEFAULT_ERROR_MESSAGE = "The event {0} is not handled";

    /// <summary>
    /// The name of the event
    /// </summary>
    public string EventName { get; protected set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnhandledEventException"/>
    /// </summary>
    /// <param name="eventName">The name of the event</param>
    public UnhandledEventException(string eventName): this(eventName, null) { }

    /// <inheritdoc cref="UnhandledEventException.UnhandledEventException(string)"/>
    /// <param name="eventName">The name of the event</param>
    /// <include file='documentation_shared.xml' path='Documentation/ErrorMessages/Parameters[@name="innerException"]/*'/>
    public UnhandledEventException(string eventName, Exception? innerException): this(String.Format(DEFAULT_ERROR_MESSAGE, eventName), eventName, innerException) { }

    /// <inheritdoc cref="UnhandledEventException.UnhandledEventException(string)"/>
    /// <param name="eventName">The name of the event</param>
    /// <include file='documentation_shared.xml' path='Documentation/ErrorMessages/Parameters[@name="message"]/*'/>
    /// <include file='documentation_shared.xml' path='Documentation/ErrorMessages/Parameters[@name="innerException"]/*'/>
    public UnhandledEventException(string? message, string eventName, Exception? innerException): base(message, innerException)
    {
        EventName = eventName;
    }
}
