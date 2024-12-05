﻿/*
 * Copyright (c) Gustave Monce and Contributors
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnifiedUpdatePlatform.Services.WindowsUpdate;

namespace UUPDownload.DownloadRequest;

public class UpdateScan(
    UpdateData updateData,
    BuildTargets.EditionPlanningWithLanguage[] targets,
    MachineType architecture,
    string buildString,
    string title,
    string description)
{
    public UpdateData UpdateData { get; init; } = updateData;
    public BuildTargets.EditionPlanningWithLanguage[] Targets { get; init; } = targets;
    public MachineType Architecture { get; init; } = architecture;
    public string BuildString { get; init; } = buildString;
    public string Title { get; init; } = title;
    public string Description { get; init; } = description;

    public string Serialize()
    {
        var xmlSerializer = new XmlSerializer(typeof(UpdateScan));
        var ns = new XmlSerializerNamespaces([
            new("s", "http://www.w3.org/2003/05/soap-envelope"),
            new("a", "http://www.w3.org/2005/08/addressing")
        ]);

        using var stringWriter = new StringWriter();
        using var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true });
        xmlSerializer.Serialize(xmlWriter, this, ns);
        return stringWriter.ToString().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n", "");
    }
}
