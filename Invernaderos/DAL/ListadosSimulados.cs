using ENT;
namespace DAL


{
    public class ListadosSimulados
    {
        public List<ClsInvernadero> listadoInvernaderosSimulado = new List<ClsInvernadero> {
            new ClsInvernadero (1,"Invernadero Norte"),
            new ClsInvernadero (2, "Invernadero Sur"),
            new ClsInvernadero (3, "Invernadero Este"),
            new ClsInvernadero (4, "Invernadero Oeste"),
            new ClsInvernadero (5, "Invernadero Central")
        };

        public List<ClsTemperatura> listadoTemperaturasSimulado = new List<ClsTemperatura>
        {
            new ClsTemperatura(1, new DateTime(2025,4, 25), 21.5, 25.0, 22.8, 60.0, 55.2, 58.4),
            new ClsTemperatura(1, new DateTime(2025, 4, 26), 22.0, 26.3, 23.5, 61.5, 57.0, 59.1),
            new ClsTemperatura(2, new DateTime(2025, 4, 25), 20.0, 23.5, 21.2, 63.0, 60.1, 62.5),
            new ClsTemperatura(2, new DateTime(2025, 4, 26), 19.8, 22.4, 20.9, 64.1, 61.0, 63.2),
            new ClsTemperatura(3, new DateTime(2025, 4, 25), 24.2, 28.1, 25.0, 55.0, 50.8, 52.9),
            new ClsTemperatura(3, new DateTime(2025, 4, 26), 23.5, 27.0, 24.3, 56.3, 52.7, 54.2),
            new ClsTemperatura(4, new DateTime(2025, 4, 25), 18.5, 21.3, 19.4, 66.0, 62.0, 64.5),
            new ClsTemperatura(5, new DateTime(2025, 4, 25), 22.5, 25.9, 23.7, 60.5, 58.0, 59.3),
            new ClsTemperatura(5, new DateTime(2025, 4, 26), 21.9, 24.5, 22.8, 61.0, 58.7, 60.1)
        };



    }
}
