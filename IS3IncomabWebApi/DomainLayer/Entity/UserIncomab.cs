namespace IS3IncomabWebApi.DomainLayer.Entity
{
    public class UserIncomab
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public String? UserName {  get; set; }
        public String? Password { get; set; }
        public int IsActive { get; set; }
    }
}
