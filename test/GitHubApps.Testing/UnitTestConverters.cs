// *****************************************************************************
// UnitTestConverters.cs
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
using GitHubApps.Models;
using Newtonsoft.Json;

namespace GitHubApps.Testing;

/// <summary>
/// Test Data Converters
/// </summary>
[TestClass]
public sealed class UnitTestConverters
{
    /// <summary>
    /// Tests the <see cref="GitHubDateTimeConverter"/> class
    /// </summary>
    [TestMethod]
    public void TestDateTimeConverter()
    {
        var convertedData = JsonConvert.DeserializeObject<DateTimeConverterData>(TestHelper.GetFileData("ConverterData", "TemplateDateTime.json"));

        Assert.IsNotNull(convertedData);
        Assert.AreEqual("String Field", convertedData.StringField);
        Assert.AreEqual(new DateTime(2023, 1, 1, 0, 0, 0), convertedData.DateTimeField);
        Assert.AreEqual(new DateTime(2023, 1, 1, 0, 0, 0), convertedData.DateTimeFieldTZ);        
        Assert.AreEqual(new DateTime(2023, 1, 1, 0, 0, 0), convertedData.DateTimeFieldNumeric);
    }

}


class DateTimeConverterData
{

    public string? StringField { get; set; }

    [JsonConverter(typeof(GitHubDateTimeConverter))]
    public DateTime? DateTimeField { get; set; }

    [JsonConverter(typeof(GitHubDateTimeConverter))]
    public DateTime? DateTimeFieldTZ { get; set; }

    [JsonConverter(typeof(GitHubDateTimeConverter))]
    public DateTime? DateTimeFieldNumeric { get; set; }

}