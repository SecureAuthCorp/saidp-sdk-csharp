using System;
using System.ComponentModel;

namespace SecureAuth.Admin.Sdk
{
    public class Enums
    {     
        public enum DFPDesktopMode
        {
            NoCookie = 0,
            Cookie = 1
        }

        public enum DFPMobileMode
        {
            Cookie = 0,
            MobileApp = 1
        }

        public enum DFPOrderBy
        {
            CreateTime = 0,
            LastAccessTime = 1
        }

        public enum DFPAllowToReplaceWhenExceedMaxAccount
        {
            NotAllow = 0,
            Allow = 1
        }
        
        public enum KioskOption
        {
            PublicPrivate = 0,
            PublicOnly = 1,
            PrivateOnly = 2
        }

        public enum DefaultKiosk
        {
            Public = 0,
            Private = 1,
            NoDefault = -1
        }

        public enum MembershipIndex
        {
            ADSamAccountName = 0,
            ADUPN = 1,
            ADAM = 2,
            Domino = 3,
            eDirectory = 4,
            SunOne = 5,
            Tivoli = 6,
            OpenLDAP = 7,
            OtherLDAP = 8,
            SQLServer = 9,
            Custom = 10,
            ODBC = 11,
            ASPNETDB = 12,
            WebService = 13,
            Oracle = 14,
            NoDataStore = 15,
            WebAdmin = 16,
            Azure = 17
        }
        
        public enum ProfileIndex
        {
            ADSamAccountName = 0,
            ADUPN = 1,
            ADAM = 2,
            Domino = 3,
            eDirectory = 4,
            SunOne = 5,
            Tivoli = 6,
            OpenLDAP = 7,
            OtherLDAP = 8,
            SQLServer = 9,
            ODBC = 10,
            ASPNETDB = 11,
            WebService = 12,
            NoDataStore = 13,
            Oracle = 14,
            Azure = 15,
            REST = 16
        }
                
        public enum ReceiveToken
        {
            None = 0,
            Token = 1,
            ClearTextQueryString = 2,
            XORBase64QueryString = 3,
            SendTokenOnly = 4,
            SendXORBase64Only = 5,
            ReceiveTokenOnly = 6
        }

        public enum UsernameDisplayField
        {
            AuthenticatedUserId = 0,
            FirstName = 1,
            LastName = 2,
            Phone1 = 3,
            Phone2 = 4,
            Phone3 = 5,
            Phone4 = 6,
            Email1 = 7,
            Email2 = 8,
            Email3 = 21,
            Email4 = 22,
            AuxId1 = 9,
            AuxId2 = 12,
            AuxId3 = 13,
            AuxId4 = 14,
            AuxId5 = 15,
            AuxId6 = 16,
            AuxId7 = 17,
            AuxId8 = 18,
            AuxId9 = 19,
            AuxId10 = 20,
            Email1UsernameOnly = 10,
            Email2UsernameOnly = 11,
            Email3UsernameOnly = 23,
            Email4UsernameOnly = 24,
            CustomToken = 31
        }

        public enum UsernameLocation
        {
            NotShown = 0,
            ShowInHeader = 1
        }

        public enum ForgotUsernameUrlLocation
        {
            PageFooter = 0,
            UnderInputField = 1
        }

        public enum ForgotPasswordUrlLocation
        {
            PageFooter = 0,
            UnderInputField = 1
        }

        public enum RestartLoginUrlLocation
        {
            NotShown = 0,
            Footer = 1,
            Header = 2,
            Dynamic = 3
        }

        public enum DisclaimerLocation
        {
            NotShown = 0,
            PageFooter = 1
        }
        
        public enum LdapMembershipConnectionMode
        {
            Secure,
            SSL,
            Standard
        }

        public enum LdapMembershipValidateUserType
        {
            Search = 0,
            Bind = 1
        }

        public enum LdapMembershipUserGroupCheckType
        {
            AllowAccess = 0,
            DenyAccess = 1
        }

        public enum SqlMembershipPasswordFormat
        {
            Clear,
            Hashed,
            Encrypted
        }

        public enum OracleMembershipPasswordFormat
        {
            Clear,
            SHA1,
            SHA2,
            MD5
        }

        public enum ProfileProviderName
        {
            LDAPProfileProvider,
            SqlProfileProvider,
            ODBCProfileProvider,
            ASPNETProfileProvider,
            WebServiceProfileProvider,
            emptyProvider,
            OracleProfileProvider,
            AzureProfileProvider,
            RESTProfileProvider
        }

        public enum RestServiceProfileAuthenticationMethod
        {
            Basic,
            Bearer,
            Cookie
        }

        public enum LdapProfileConnectionProtection
        {
            Secure,
            SSL,
            Standard
        }

        public enum ProfileFieldSource
        {
            DefaultProvider = -1,
            DirectoryServer = 0,
            SqlServer = 1,
            ODBC = 2,
            ASPNETDB = 3,
            WebService = 4,
            Azure = 5,
            Oracle = 6,
            REST = 7
        }

        public enum ProfileFieldDataFormat
        {
            PlainText = 0,
            StandardEncryption = 1,
            AdvancedEncryption = 2,
            StandardHash = 3,
            PlainBinary = 100,
            JSON = 99,
            EncryptedJSON = 98
        }

        public enum DeviceRecognitionIntegrationMethod
        {
            CertificationEnrollmentAndValidation = 1,
            CertificateEnrollmentOnly = 2,
            MobileEnrollemntandValidation = 3
        }

        public enum DeviceRecognitionClientSideControl
        {
            JavaApplet = 0,
            BrowserPlugins = 1,
            UniversalBrowserCredentials = 2,
            DeviceBrowserFingerprinting = 3
        }

        public enum DefaultWorkflow
        {
            UsernameOnly = 999,
            Username_SecondFactor = 2,
            ValidPersistentTokenOnly = 9,
            UsernameAndPassword = 7,
            UsernameAndPassword_SecondFactor = 3,
            Username_Password = 1,
            Username_SecondFactor_Password = 0,
            ValidPersistentToken_Password = 6,
            ValidPersistentToken_SecondFactor = 4,
            ValidPersistentToken_SecondFactor_Password = 5
        }

        public enum WorkflowPasswordThrottleAction
        {
            BlockUseUntilTimeLimitExpires = 0,
            LockUserAfterExceedingAttempts = 1
        }

        public enum WorkflowPasswordThrottleStorage
        {
            AuxID1,
            AuxID2,
            AuxID3,
            AuxID4,
            AuxID5,
            AuxID6,
            AuxID7,
            AuxID8,
            AuxID9,
            AuxID10,
            Email1,
            Email2,
            Email3,
            Email4,
            Phone1,
            Phone2,
            Phone3,
            Phone4
        }

        public enum DisplayTimeoutMessage
        {
            Disabled = 0,
            DisplayTimeout = 1,
            AutoRestart = 2
        }

        public enum BeginSite
        {
            BasicAuthentication,
            CertificateFinderV1,
            CertificateFinderV2,
            ClientSideSsl,
            FingerprintFinder,
            FormPost,
            MultiWorkflow,
            NativeCertificateFinder,
            WindowsSso,
            WindowsSsoSkipWorkflow,
            CiscoIse,
            YubiKey,
            Custom
        }

        public enum ReceiveTokenDataType
        {
            UserData = 0,
            Name = 1
        }

        public enum SendTokenDataType
        {
            UserId = 0,
            Password = 1,
            Phone1 = 3,
            Phone2 = 4,
            Phone3 = 5,
            Phone4 = 6,
            Email1 = 7,
            Email2 = 8,
            Email3 = 21,
            Email4 = 22,
            AuxID1 = 2,
            AuxID2 = 11,
            AuxID3 = 12,
            AuxID4 = 13,
            AuxID5 = 14,
            AuxID6 = 15,
            AuxID7 = 16,
            AuxID8 = 17,
            AuxID9 = 18,
            AuxID10 = 19,
            FirstName = 9,
            LastName = 10,
            Custom = 20
        }

        public enum AdaptiveAuthAnalyzeEngineStateType
        {
            IpCountry,
            IpReputationThreatData,
            UserGroup,
            GeoVelocity,
            UserRisk
        }

        public enum AdaptiveAuthIpCountryRestrictionType
        {
            ip,
            country
        }

        public enum AdaptiveAuthInListAction
        {
            [Description("in")]
            Allow,
            [Description("notin")]
            Deny
        }

        public enum AdaptiveAuthAction
        {
            HardStop,
            Redirect,
            TwoFactor,
            SkipTwoFactor,
            Continue,
            Authenticated,
            Disable
        }
        
        public enum AdaptiveAuthUserGroupRestrictionType
        {
            user,
            group
        }

        public enum AdaptiveAuthUserRiskProfileField
        {
            Phone1,
            Phone2,
            Phone3,
            Phone4,
            Email1,
            Email2,
            Email3,
            Email4,
            AuxID1,
            AuxID2,
            AuxID3,
            AuxID4,
            AuxID5,
            AuxID6,
            AuxID7,
            AuxID8,
            AuxID9,
            AuxID10
        }
        
        public enum MultifactorPushNotificationAcceptMethod
        {
            AcceptButton = 0,
            DisplaySymbol = 1
        }

        public enum MultiFactorPhoneField
        {
            Disabled = 0,
            VoiceOnly = 1,
            SmsTextOnly = 2,
            VoiceAndSmsText = 3,
            LoginRequest = 4
        }

        public enum MultiFactorPhoneSmsSelect
        {
            Voice = 0,
            SmsText = 1
        }

        public enum MultiFactorPhoneNumberSource
        {
            mobile,
            landline,
            @virtual,
            landline_tollfree,
            landline_premium,
            pager,
            unknown
        }

        public enum MultiFactorCarrierStorageField
        {
            AuxID1,
            AuxID2,
            AuxID3,
            AuxID4,
            AuxID5,
            AuxID6,
            AuxID7,
            AuxID8,
            AuxID9,
            AuxID10,
            Email1,
            Email2,
            Email3,
            Email4,
            Phone1,
            Phone2,
            Phone3,
            Phone4
        }

        public enum MultiFactorListAction
        {
            Allow,
            Block
        }

        public enum MultiFactorEmailField
        {
            TrueHtmlLink,
            TrueTextLink,
            True,
            TrueTEXT,
            False
        }

        public enum MultiFactorKbFormat
        {
            Base64 = 1,
            Encryption = 2
        }

        public enum MultiFactorPushNotificationRequestType
        {
            Disabled = 0,
            Passcode = 1,
            AcceptDeny = 2,
            PasscodeAndAcceptDeny = 3
        }

        public enum MultiFactorPushNotificationExceedMaxCountAction
        {
            NotAllowToReplace = 0,
            AllowToReplace = 1
        }

        public enum MultiFactorPushNotificationReplaceOrderBy
        {
            CreatedTime = 0,
            LastAccessTime = 1
        }

        public enum MultiFactorYubiKeyStorage
        {
            HardwareToken,
            AuxID1,
            AuxID2,
            AuxID3,
            AuxID4,
            AuxID5,
            AuxID6,
            AuxID7,
            AuxID8,
            AuxID9,
            AuxID10
        }

        public enum MultiFactorThrottleAction
        {
            BlockUseUntilTimeLimitExpires = 0,
            LockUserAfterExceedingAttempts = 1
        }

        public enum MultiFactorThrottleStorage
        {
            Session,
            AuxID1,
            AuxID2,
            AuxID3,
            AuxID4,
            AuxID5,
            AuxID6,
            AuxID7,
            AuxID8,
            AuxID9,
            AuxID10,
            Email1,
            Email2,
            Email3,
            Email4,
            Phone1,
            Phone2,
            Phone3,
            Phone4
        }

        public enum MultiFactorRegistrationMethod
        {
            Phone,
            Email,
            KBQ,
            Help,
            PIN,
            OATH,
            PushNotification,
            YubiKey,
            VIPCredential
        }

        public enum PostAuthRedirectType
        {
            Custom = 0,
            Saml2SpInitiated = 12,
            Saml2IdpInitiated = 13,
            Saml2SpInitiatedByPost = 14,
            WsFederation = 25
        }

        public enum PostAuthUserIdMappingType
        {
            AuthenticatedUserId = 0,
            FirstName = 1,
            LastName = 2,
            Phone1 = 3,
            Phone2 = 4,
            Phone3 = 5,
            Phone4 = 6,
            Email1 = 7,
            Email2 = 8,
            Email3 = 27,
            Email4 = 28,
            AuxId1 = 9,
            AuxId2 = 12,
            AuxId3 = 13,
            AuxId4 = 14,
            AuxId5 = 15,
            AuxId6 = 16,
            AuxId7 = 17,
            AuxId8 = 18,
            AuxId9 = 19,
            AuxId10 = 20,
            GlobalAuxId1 = 21,
            GlobalAuxId2 = 22,
            GlobalAuxId3 = 23,
            GlobalAuxId4 = 24,
            GlobalAuxId5 = 25,
            Email1UsernameOnly = 10,
            Email2UsernameOnly = 11,
            Email3UsernameOnly = 29,
            Email4UsernameOnly = 30,
            GroupList = 26,
            FullGroupDnLis = 32,
            CustomTokenValue = 31
        }

        public enum PostAuthWsFedSamlSigningAlgorithm
        {
            SHA1,
            SHA2
        }

        public enum PostAuthSamlEncryptionMethod
        {
            [Description("")]
            Empty,
            [Description("http://www.w3.org/2001/04/xmlenc#kw-aes128")]
            XmlEncAES128KeyWrapUrl,
            [Description("http://www.w3.org/2001/04/xmlenc#aes128-cbc")]
            XmlEncAES128Url,
            [Description("http://www.w3.org/2001/04/xmlenc#kw-aes192")]
            XmlEncAES192KeyWrapUrl,
            [Description("http://www.w3.org/2001/04/xmlenc#aes192-cbc")]
            XmlEncAES192Url,
            [Description("http://www.w3.org/2001/04/xmlenc#kw-aes256")]
            XmlEncAES256KeyWrapUrl,
            [Description("http://www.w3.org/2001/04/xmlenc#aes256-cbc")]
            XmlEncAES256Url,
            [Description("http://www.w3.org/2001/04/xmlenc#des-cbc")]
            XmlEncDESUrl,
            [Description("http://www.w3.org/2001/04/xmlenc#Content")]
            XmlEncElementContentUrl,
            [Description("http://www.w3.org/2001/04/xmlenc#Element")]
            XmlEncElementUrl,
            [Description("http://www.w3.org/2001/04/xmlenc#EncryptedKey")]
            XmlEncEncryptedKeyUrl,
            [Description("http://www.w3.org/2001/04/xmlenc#")]
            XmlEncNamespaceUrl,
            [Description("http://www.w3.org/2001/04/xmlenc#rsa-1_5")]
            XmlEncRSA15Url,
            [Description("http://www.w3.org/2001/04/xmlenc#rsa-oaep-mgf1p")]
            XmlEncRSAOAEPUrl,
            [Description("http://www.w3.org/2001/04/xmlenc#sha256")]
            XmlEncSHA256Url,
            [Description("http://www.w3.org/2001/04/xmlenc#sha512")]
            XmlEncSHA512Url,
            [Description("http://www.w3.org/2001/04/xmlenc#kw-tripledes")]
            XmlEncTripleDESKeyWrapUrl,
            [Description("http://www.w3.org/2001/04/xmlenc#tripledes-cbc")]
            XmlEncTripleDESUrl
        }

        public enum PostAuthAuthenticationMethod
        {
            [Description("")]
            Empty,
            [Description("urn:oasis:names:tc:SAML:1.0:am:HardwareToken")]
            HardwareToken,
            [Description("urn:ietf:rfc:1510")]
            Rfc1510,
            [Description("urn:oasis:names:tc:SAML:1.0:am:password")]
            Password,
            [Description("urn:oasis:names:tc:SAML:1.0:am:PGP")]
            PGP,
            [Description("urn:ietf:rfc:2945")]
            Rfc2945,
            [Description("urn:oasis:names:tc:SAML:1.0:am:SPKI")]
            Spki,
            [Description("urn:ietf:rfc:2246")]
            Rfc2246,
            [Description("urn:oasis:names:tc:SAML:1.0:am:unspecified")]
            Unspecified,
            [Description("urn:oasis:names:tc:SAML:1.0:am:X509-PKI")]
            X509Pki,
            [Description("urn:oasis:names:tc:SAML:1.0:am:XKMS")]
            Xkms,
            [Description("urn:ietf:rfc:3075")]
            Rfc3075
        }

        public enum PostAuthConfirmationMethod
        {
            [Description("")]
            Empty,
            [Description("urn:oasis:names:tc:SAML:1.0:cm:bearer")]
            Bearer,
            [Description("urn:oasis:names:tc:SAML:1.0:cm:sender-vouches")]
            SenderVouches,
            [Description("urn:oasis:names:tc:SAML:1.0:cm:holder-of-key")]
            HolderOfKey,
            [Description("urn:oasis:names:tc:SAML:1.0:cm:artifact")]
            Artifact
        }

        public enum PostAuthSamlAuthenticationContextClass
        {
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:AuthenticatedTelephony")]
            AuthenticatedTelephony,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:InternetProtocol")]
            InternetProtocol,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:InternetProtocolPassword")]
            InternetProtocolPassword,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:Kerberos")]
            Kerberos,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:MobileOneFactorContract")]
            MobileOneFactorContract,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:MobileOneFactorUnregistered")]
            MobileOneFactorUnregistered,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:MobileTwoFactorContract")]
            MobileTwoFactorContract,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:MobileTwoFactorUnregistered")]
            MobileTwoFactorUnregistered,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:NomadTelephony")]
            NomadTelephony,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:Password")]
            Password,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:PasswordProtectedTransport")]
            PasswordProtectedTransport,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:PersonalTelephony")]
            PersonalTelephony,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:PGP")]
            Pgp,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:PreviousSession")]
            PreviousSession,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:SecureRemotePassword")]
            SecureRemotePassword,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:Smartcard")]
            Smartcard,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:SmartcardPKI")]
            SmartcardPki,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:SoftwarePKI")]
            SoftwarePki,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:SPKI")]
            Spki,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:Telephony")]
            Telephony,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:TimeSyncToken")]
            TimeSyncToken,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:TLSClient")]
            TlsClient,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:unspecified")]
            Unspecified,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:X509")]
            X509,
            [Description("urn:oasis:names:tc:SAML:2.0:ac:classes:XMLDSig")]
            XmlDSig
        }

        public enum PostAuthMachineKeyDecryption
        {
            [Description("Auto")]
            Auto,
            [Description("DES")]
            DES,
            [Description("3DES")]
            _3DES,
            [Description("AES")]
            AES
        }

        public enum PostAuthWsTrustEndpoint
        {
            UsernameMixed05,
            WindowsTransport05,
            IssuedTokenMixedAsymmetricBasic25605,
            UsernameMixed13,
            WindowsTransport13,
            IssuedTokenMixedAsymmetricBasic25613
        }
        
        public enum WsTrustRequestBlockingConditionLogic
        {
            AND,
            OR
        }

        public enum WsTrustBlockingRule
        {
            Allow,
            Deny
        }

        public enum SyslogRfcSpec
        {
            [Description("Syslogger")]
            None,
            [Description("SysloggerRFC3164")]
            RFC3164,
            [Description("SysloggerRFC3164LEEF")]
            RFC3164LEEF,
            [Description("SysloggerRFC3164CEF")]
            RFC3164CEF,
            [Description("SysloggerRFC5424")]
            RFC5424
        }

        public enum TimeUnit
        {
            Minutes,
            Hours,
            Days
        }       
    }
}
