/*
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
using CommandLine;
using UnifiedUpdatePlatform.Services.WindowsUpdate;

namespace UUPDownload;

[Verb("request-download", isDefault: true, HelpText = "Request a download from zero using a number of different request parameters.")]
internal class DownloadRequestOptions
{
    [Option('s', "reporting-sku", Required = true, HelpText = "The sku to report to the Windows Update servers. Example: Professional")]
    public required OSSkuId ReportingSku { get; init; }

    [Option('v', "reporting-version", Required = true, HelpText = "The version to report to the Windows Update servers. Example: 10.0.20152.1000")]
    public required string ReportingVersion { get; init; }

    [Option('t', "machine-type", Required = true, HelpText = "The architecture to report to the Windows Update servers. Example: amd64")]
    public required MachineType MachineType { get; init; }

    [Option('r', "flight-ring", Required = true, HelpText = "The ring to report to the Windows Update servers. Example: Retail, other example: External or Internal")]
    public required string FlightRing { get; init; }

    [Option('c', "current-branch", Required = true, HelpText = "The branch to report to the Windows Update servers. Example: 19h1_release")]
    public required string CurrentBranch { get; init; }

    [Option('b', "flighting-branch-name", Required = false, Default = "", HelpText = "The flighting branch name to report to the Windows Update servers. Example: Retail, other example: CanaryChannel, Dev, Beta or ReleasePreview")]
    public string FlightingBranchName { get; init; } = string.Empty;

    [Option('y', "sync-current-version-only", Required = false, Default = false, HelpText = "Only get updates for the current version, enables getting cumulative updates.")]
    public bool SyncCurrentVersionOnly { get; init; }

    [Option('a', "branch-readiness-level", Required = false, Default = "CB", HelpText = "The branch readiness level to report to the Windows Update servers. Example: CB")]
    public string BranchReadinessLevel { get; init; } = "CB";

    [Option('o', "output-folder", Required = false, Default = ".", HelpText = "The folder to use for downloading the update files.")]
    public string OutputFolder { get; init; } = ".";

    [Option('e', "edition", Required = false, Default = "", HelpText = "The edition to get. Must be used with the language parameter. Omit either of these to download everything. Example: Professional")]
    public string Edition { get; init; } = string.Empty;

    [Option('l', "language", Required = false, Default = "", HelpText = "The language to get. Must be used with the edition parameter. Omit either of these to download everything. Example: en-US")]
    public string Language { get; init; } = string.Empty;

    [Option('z', "releasetype", Required = false, Default = "Production", HelpText = "The release type to report to the Windows Update servers. Example: Production")]
    public string ReleaseType { get; init; } = "Production";

    [Option('n', "contenttype", Required = false, Default = "Mainline", HelpText = "The content type to report to the Windows Update servers. Example: Mainline, Custom")]
    public string ContentType { get; init; } = "Mainline";

    [Option('m', "mail", Required = false, Default = "", HelpText = "Email for the Windows Insider account to use to generate authorization tokens (Optional)")]
    public string Mail { get; init; } = string.Empty;

    [Option('p', "password", Required = false, Default = "", HelpText = "Password for the Windows Insider account to use to generate authorization tokens (If 2FA, must be generated app password) (Optional)")]
    public string Password { get; init; } = string.Empty;
}

[Verb("replay-download", isDefault: false, HelpText = "Replay a download from zero using a *.uupmcreplay file.")]
internal class DownloadReplayOptions
{
    [Option('r', "replay-metadata", Required = true, HelpText = @"The path to a *.uupmcreplay file to replay an older update and resume the download process. Example: D:\20236.1005.uupmcreplay")]
    public required string ReplayMetadata { get; init; }

    [Option('t', "machine-type", Required = true, HelpText = "The architecture to report to the Windows Update servers. Example: amd64")]
    public required MachineType MachineType { get; init; }

    [Option('o', "output-folder", Required = false, Default = ".", HelpText = "The folder to use for downloading the update files.")]
    public string OutputFolder { get; init; } = ".";

    [Option('e', "edition", Required = false, Default = "", HelpText = "The edition to get. Must be used with the language parameter. Omit either of these to download everything. Example: Professional")]
    public string Edition { get; init; } = string.Empty;

    [Option('l', "language", Required = false, Default = "", HelpText = "The language to get. Must be used with the edition parameter. Omit either of these to download everything. Example: en-US")]
    public string Language { get; init; } = string.Empty;

    [Option("fixup", Required = false, HelpText = @"Applies a fixup to files in output folder. Example: Appx")]
    public Fixup? Fixup { get; init; }

    [Option("appxroot", Required = false, HelpText = @"The folder containing the appx files for use with the Appx fixup")]
    public string? AppxRoot { get; init; }

    [Option("cabsroot", Required = false, HelpText = @"The folder containing the cab files for use with the Appx fixup")]
    public string? CabsRoot { get; init; }
}

[Verb("get-builds", isDefault: false, HelpText = "Get builds in all rings matching the request type")]
internal class GetBuildsOptions
{
    [Option('s', "reporting-sku", Required = true, HelpText = "The sku to report to the Windows Update servers. Example: Professional")]
    public required OSSkuId ReportingSku { get; init; }

    [Option('t', "machine-type", Required = true, HelpText = "The architecture to report to the Windows Update servers. Example: amd64")]
    public required MachineType MachineType { get; init; }

    [Option('m', "mail", Required = false, Default = "", HelpText = "Email for the Windows Insider account to use to generate authorization tokens (Optional)")]
    public string Mail { get; init; } = string.Empty;

    [Option('p', "password", Required = false, Default = "", HelpText = "Password for the Windows Insider account to use to generate authorization tokens (If 2FA, must be generated app password) (Optional)")]
    public string Password { get; init; } = string.Empty;

    [Option("preview-targeting-attribute", Required = false, Default = "", HelpText = "The name of the set of targeting attributes to use. (Optional, Preview)")]
    public string TargetingAttribute { get; init; } = string.Empty;
}
