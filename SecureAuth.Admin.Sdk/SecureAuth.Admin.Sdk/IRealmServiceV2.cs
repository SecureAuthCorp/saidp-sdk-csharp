namespace SecureAuth.Admin.Sdk
{
    public interface IRealmServiceV2
    {
        RealmResponse GetRealm(string realmId);
        RealmResponse CreateRealm();
        BaseResponse UpdateOverview(OverviewRequest request);
        BaseResponse UpdateDataMembership(DataMembershipRequest request);
        BaseResponse UpdateDataProfile(DataProfileRequest request);
        BaseResponse UpdateDataGlobalAux(DataGlobalAuxRequest request);
        BaseResponse UpdateWorkflow(WorkflowRequest request);
        BaseResponse UpdateAdaptiveAuth(AdaptiveAuthRequestV2 request);
        BaseResponse UpdateMultifactor(MultifactorRequest request);
        BaseResponse UpdatePostAuth(PostAuthRequest request);
        BaseResponse UpdateLogSettings(LogSettingRequest request);
        BaseResponse UpdateApi(ApiSettingRequest request);
        RealmApiResponse GenerateApiCredentials(string realmId);
        PhoneCarrierResponse GetPhoneCarriers(string realmId);
        BaseResponse UploadCompanyLogo(OverviewRequest request);
        BaseResponse UploadApplicationLogo(OverviewRequest request);
        BaseResponse UploadEmailLogo(OverviewRequest request);
        TestConnectionResponse TestUserRiskProviderConnection(UserRiskProviderRequest request);
    }
}
