namespace UI.Client
{
    public class ClientContainer : IClientContainer
    {
        public IUserClient User { get; private set; }
        public IComplaintClient Complaint { get; private set; }
        public IUserTypeClient UserType { get; private set; }

        public ClientContainer(HttpClient httpClient)
        {
            User = new UserClient(httpClient);
            Complaint = new ComplaintClient(httpClient);
            UserType = new UserTypeClient(httpClient);
        }
    }
}
