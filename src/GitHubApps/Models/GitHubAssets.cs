using System;
namespace GitHubApps.Models;

/// <summary>
/// Represents GitHub Assets
/// </summary>
public sealed class GitHubAssets
{

    #region Properties

    /// <summary>
    /// The download URL
    /// </summary>
    public string? BrowserDownloadURL { get; set; }
    /// <summary>
    /// The Content Type
    /// </summary>
    public string? ContentType { get; set; }
    /// <summary>
    /// The date and time the Asset was created
    /// </summary>
    public DateTime? CreatedAt { get; set; }
    /// <summary>
    /// The total of downloads of the asset
    /// </summary>
    public int DownloadCount { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=ID]"/>
    public long ID { get; set; }
    /// <summary>
    /// The asset label
    /// </summary>
    public string? Label { get; set; }
    /// <summary>
    /// The name of the asset
    /// </summary>
    public string? Name { get; set; }
    /// <include file="documentation_shared.xml" path="Documentation/RepetitiveProperties/RepetitiveProperty[@name=NodeID]"/>
    public string? NodeID { get; set; }
    /// <summary>
    /// The size of the asset
    /// </summary>
    public int Size { get; set; }
    /// <summary>
    /// The state of the asset
    /// </summary>
    public GitHubAssetStates? State { get; set; }
    /// <summary>
    /// The date and time the asset was uploaded
    /// </summary>
    public DateTime? UploadedAt { get; set; }
    /// <summary>
    /// The GitHub account who uploaded the asset
    /// </summary>
    public GitHubAccount? Uploader { get; set; }
    /// <summary>
    /// The URL
    /// </summary>
    public string? URL { get; set; }

    #endregion Properties

    /// <summary>
    /// Initializes a new instance of the <see cref="GitHubAssets"/> class
    /// </summary>
    public GitHubAssets()
	{
	}
}

/// <summary>
/// A list of valid values for the <see cref="GitHubAssets.State"/>
/// </summary>
public enum GitHubAssetStates
{
    /// <summary>
    /// The asset state is uploaded
    /// </summary>
    Uploaded
}