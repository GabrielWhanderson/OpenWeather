namespace OpenWeather.Models
{
    public class WeatherResponse
        {
            public Coords coords { get; set; }
            public List<Weather> weather { get; set; }
            public string Base { get; set; }
            public Main main { get; set; }
            public int visibility { get; set; }
            public Wind wind { get; set; }
            public Rain rain { get; set; }
            public Clouds clouds { get; set; }
            public System system { get; set; }
            public int Timezone { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
            public int Cod { get; set; }
    }
}
