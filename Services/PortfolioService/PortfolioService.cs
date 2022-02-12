﻿using IssaPortfolio.Library;
using IssaPortfolio.Services.PortfolioService;
using RestSharp;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace IssaPortfolio.Services.PortfolioService
{
    public class PortfolioService
    {

        public PortfolioService()
        {
    
        }

        public async Task<List<PortfolioItem>?> LoadPortfolioItems()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    return await client.GetFromJsonAsync<List<PortfolioItem>>("https://localhost:7142/api/PortfolioItem/getitems");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return null;
            // PortfolioItems = await _http.GetFromJsonAsync<List<PortfolioItem>>("api/PortfolioItem");
        }
        public async Task AddPortfolioItem(string name, string desc, string imgUrl)
        {
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(desc) && !string.IsNullOrWhiteSpace(imgUrl))
            {
                var item = new PortfolioItem(name, desc, imgUrl);

                using (var _http = new HttpClient())
                { 
                    await _http.PostAsJsonAsync("api/PortfolioItem/postportfolio", item);
                }
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