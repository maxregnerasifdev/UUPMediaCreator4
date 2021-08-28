﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System.Text.Json.Serialization;

namespace Microsoft.StoreServices.DisplayCatalog.Product
{
    public class Image
    {
        [JsonPropertyName("FileId")]
        public string FileId;

        [JsonPropertyName("EISListingIdentifier")]
        public EISListingIdentifier EISListingIdentifier;

        [JsonPropertyName("BackgroundColor")]
        public string BackgroundColor;

        [JsonPropertyName("Caption")]
        public string Caption;

        [JsonPropertyName("FileSizeInBytes")]
        public int FileSizeInBytes;

        [JsonPropertyName("ForegroundColor")]
        public string ForegroundColor;

        [JsonPropertyName("Height")]
        public int Height;

        [JsonPropertyName("ImagePositionInfo")]
        public string ImagePositionInfo;

        [JsonPropertyName("ImagePurpose")]
        public string ImagePurpose;

        [JsonPropertyName("UnscaledImageSHA256Hash")]
        public string UnscaledImageSHA256Hash;

        [JsonPropertyName("Uri")]
        public string Uri;

        [JsonPropertyName("Width")]
        public int Width;

        [JsonPropertyName("logo")]
        public object Logo;

        [JsonPropertyName("CmsUri")]
        public string CmsUri;

        [JsonPropertyName("LocalizedUri")]
        public string LocalizedUri;

        [JsonPropertyName("AssetIdentity")]
        public string AssetIdentity;

        [JsonPropertyName("CropSafeZone")]
        public object CropSafeZone;
    }
}