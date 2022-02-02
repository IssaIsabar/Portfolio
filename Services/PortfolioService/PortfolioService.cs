using IssaPortfolio.Models;
using IssaPortfolio.Services.PortfolioService;
using System.Net.Http.Json;

namespace IssaPortfolio.Services.PortfolioService
{
    public class PortfolioService : IPortfolioService
    {
        private readonly HttpClient _http;
        public List<PortfolioItem> PortfolioItems { get; set; } = new List<PortfolioItem>();


        public int Count => PortfolioItems.Count;

        public PortfolioService(HttpClient http)
        {
            _http = http;
        }

        public async Task LoadPortfolioItems()
        {
            PortfolioItems = await _http.GetFromJsonAsync<List<PortfolioItem>>("api/PortfolioItem");
        }


        public async Task AddPortfolioItem(string name, string desc, string imgUrl)
        {

            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(desc) && !string.IsNullOrWhiteSpace(imgUrl))
            {
                var item = new PortfolioItem(name, desc, imgUrl);
                await _http.PostAsJsonAsync("api/PortfolioItem", item);

            }

        }
    }
}
//    public void DeleteItem(PortfolioItem item)
//    {
//        Storage.Items.Remove(item);
//    }

//    void UpdateItem(PortfolioItem item)
//    {

//    }
//}


//public class Building
//{
//    public string Location { get; set; }
//    public List<Floor> Floors { get; set; }
//}

//public class Floor
//{
//    public int FloorNr { get; set; }
//    public List<Apartment> Apartments { get; set; }
//}

//public class Apartment
//{
//    public int Size { get; set; }
//    public double Rent { get; set; }
//    public bool Rented { get; set; }
//    public List<Room> Rooms { get; set; }
//}

//public class Room
//{
//    public RoomType Type { get; set; } = RoomType.Restroom;
//}


//public enum RoomType
//{
//    Bedroom,
//    Restroom,
//    Livingroom,
//    WC,
//    Shower,
//    Closet
//}