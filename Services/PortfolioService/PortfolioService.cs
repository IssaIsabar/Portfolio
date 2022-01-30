using IssaPortfolio.Models;

public class PortfolioService
{
    public int Count => Storage.Items.Count;

    public PortfolioService()
    {
   
    }

    public List<PortfolioItem> GetItems()
    { 
        return Storage.Items;
    }

    public bool AddItem(string name, string desc, string imgUrl)
    {
        if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(desc) && !string.IsNullOrWhiteSpace(imgUrl))
        { 
            var item = new PortfolioItem(name, desc, imgUrl);
            Storage.Items.Add(item);

            return true;
        }
        
        return false;

    }

    public void DeleteItem(PortfolioItem item)
    {
        Storage.Items.Remove(item);
    }

    void UpdateItem(PortfolioItem item)
    { 
       
    }
}


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