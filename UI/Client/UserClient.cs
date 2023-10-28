namespace UI.Client
{
    public class UserClient:Client<DTO.User>, IUserClient
    {
        public UserClient(HttpClient httpClient):base(httpClient)
        {
            
        }
    }
}
