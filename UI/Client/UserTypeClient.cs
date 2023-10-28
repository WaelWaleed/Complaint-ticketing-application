namespace UI.Client
{
    public class UserTypeClient:Client<DTO.UserType>, IUserTypeClient
    {
        public UserTypeClient(HttpClient httpClient):base(httpClient)
        {
            
        }
    }
}
