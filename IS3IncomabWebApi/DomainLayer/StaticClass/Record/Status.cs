namespace IS3IncomabWebApi.DomainLayer.StaticClass.Record
{
    public readonly record struct Status (int Id, String Name)
    {
        public static readonly Status Garantia = new (1, "GARANTIA");
        public static readonly Status Cliente = new (2, "CLIENTE");
        public static readonly Status Disponible = new (3, "DISPONIBLE");
        public static readonly Status Defectuoso = new (4, "DEFECTUOSO");
        public static readonly Status Devuelto = new (5, "DEVUELTO");

        public static readonly Status[] ListStatus = new Status[]
        {
            Garantia, 
            Cliente, 
            Disponible, 
            Defectuoso, 
            Devuelto
        };

        public static Status? StatusGetId(int id)
        {

            foreach (var item in Status.ListStatus)
            {
                if (item.Id == id) return item;
            }
            return null;
        }

    }
}
