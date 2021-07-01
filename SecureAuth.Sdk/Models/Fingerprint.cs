using System.Runtime.Serialization;

namespace SecureAuth.Sdk.Models
{
    [DataContract(Name = "fingerprint")]
    public class Fingerprint
    {
        [DataMember(Name = "fonts", EmitDefaultValue = false)]
        public string Fonts { get; set; }

        [DataMember(Name = "plugins", EmitDefaultValue = false)]
        public string Plugins { get; set; }

        [DataMember(Name = "timezone", EmitDefaultValue = false)]
        public string TimeZone { get; set; }

        [DataMember(Name = "localStorage", EmitDefaultValue = false)]
        public bool LocalStorage { get; set; }

        [DataMember(Name = "sessionStorage", EmitDefaultValue = false)]
        public bool SessionStorage { get; set; }

        [DataMember(Name = "language", EmitDefaultValue = false)]
        public string Language { get; set; }

        [DataMember(Name = "cookieSupport", EmitDefaultValue = false)]
        public bool CookieSupport { get; set; }

        [DataMember(Name = "uaBrowser", EmitDefaultValue = false)]
        public UaBrowser UaBrowser { get; set; }

        [DataMember(Name = "uaString", EmitDefaultValue = false)]
        public string UaString { get; set; }

        [DataMember(Name = "uaDevice", EmitDefaultValue = false)]
        public UaDevice UaDevice { get; set; }

        [DataMember(Name = "uaEngine", EmitDefaultValue = false)]
        public UaEngine UaEngine { get; set; }

        [DataMember(Name = "uaOS", EmitDefaultValue = false)]
        public UaOs UaOs { get; set; }

        [DataMember(Name = "uaCPU", EmitDefaultValue = false)]
        public UaCpu UaCpu { get; set; }

        [DataMember(Name = "touchSupport", EmitDefaultValue = false)]
        public TouchSupport TouchSupport { get; set; }

        [DataMember(Name = "uaPlatform", EmitDefaultValue = false)]
        public string UaPlatform { get; set; }

        [DataMember(Name = "colorDepth", EmitDefaultValue = false)]
        public int ColorDepth { get; set; }

        [DataMember(Name = "pixelRatio", EmitDefaultValue = false)]
        public double PixelRatio { get; set; }

        [DataMember(Name = "screenResolution", EmitDefaultValue = false)]
        public string ScreenResolution { get; set; }

        [DataMember(Name = "availableScreenResolution", EmitDefaultValue = false)]
        public string AvailableScreenResolution { get; set; }

        [DataMember(Name = "timezoneOffset", EmitDefaultValue = false)]
        public int TimeZoneOffset { get; set; }

        [DataMember(Name = "indexedDb", EmitDefaultValue = false)]
        public bool IndexedDb { get; set; }

        [DataMember(Name = "addBehavior", EmitDefaultValue = false)]
        public bool AddBehavior { get; set; }

        [DataMember(Name = "openDatabase", EmitDefaultValue = false)]
        public bool OpenDatabase { get; set; }

        [DataMember(Name = "cpuClass", EmitDefaultValue = false)]
        public string CpuClass { get; set; }

        [DataMember(Name = "platform", EmitDefaultValue = false)]
        public string Platform { get; set; }

        [DataMember(Name = "doNotTrack", EmitDefaultValue = false)]
        public string DoNotTrack { get; set; }

        [DataMember(Name = "canvas", EmitDefaultValue = false)]
        public string Canvas { get; set; }

        [DataMember(Name = "webGl", EmitDefaultValue = false)]
        public string WebGl { get; set; }

        [DataMember(Name = "adBlock", EmitDefaultValue = false)]
        public bool AdBlock { get; set; }

        [DataMember(Name = "userTamperLanguage", EmitDefaultValue = false)]
        public bool UserTamperLanguage { get; set; }

        [DataMember(Name = "userTamperScreenResolution", EmitDefaultValue = false)]
        public bool UserTamperScreenResolution { get; set; }

        [DataMember(Name = "userTamperOS", EmitDefaultValue = false)]
        public bool UserTamperOS { get; set; }

        [DataMember(Name = "userTamperBrowser", EmitDefaultValue = false)]
        public bool UserTamperBrowser { get; set; }
    }
}