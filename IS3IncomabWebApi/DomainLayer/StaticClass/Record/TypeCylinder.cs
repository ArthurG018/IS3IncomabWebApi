namespace IS3IncomabWebApi.DomainLayer.StaticClass.Record
{
    public readonly record struct TypeCylinder (int Id, String Name, int Capacity, String UnityMeasure)
    {
        public static readonly TypeCylinder DioxidoCarbono = new (0,"DIOXIDO DE CARBONO",10,"M3");
        public static readonly TypeCylinder OxigenoIndustrial = new (1, "OXIGENO INDUSTRIAL", 10, "M3");
        public static readonly TypeCylinder OxigenoMedicinal = new (2, "OXIGENO MEDICINAL 99.5% V/V GA", 10, "M3");
        public static readonly TypeCylinder NitrogenoGas = new (3, "NITROGENO GAS", 10, "M3");
        public static readonly TypeCylinder ArgonCilindroSTD = new (4, "ARGON CILINDRO STD.", 10, "M3");
        public static readonly TypeCylinder AcetilenoCilindroSTD6 = new (5, "ACETILENO CILIN. STD.", 6, "KG");
        public static readonly TypeCylinder AcetilenoCilindroSTD7 = new (6, "ACETILENO CILIN. STD.", 7, "KG");
        public static readonly TypeCylinder AcetilenoCilindroSTD8 = new (7, "ACETILENO CILIN. STD.", 8, "KG");
        public static readonly TypeCylinder AireSintetico = new (8, "AIRE SINTETICO 4.7", 10, "M3");

        public static readonly TypeCylinder[] ListTypeCylinders = new TypeCylinder[]
        {
            DioxidoCarbono,
            OxigenoIndustrial,
            OxigenoMedicinal,
            NitrogenoGas,
            ArgonCilindroSTD,
            AcetilenoCilindroSTD6,
            AcetilenoCilindroSTD7,
            AcetilenoCilindroSTD8,
            AireSintetico
        };
        public static TypeCylinder? TypeCylinderGetId(int id)
        {
            
            foreach (var item in TypeCylinder.ListTypeCylinders)
            {
                if(item.Id == id) return item;
            }
            return null;
        }
       
    }
}
