using UnityEngine;
using System;

public class Property : MonoBehaviour
{
    public int CountryId { get; set; }
    public int? OwnerId { get; set; }
    public int NumberOfHouses
    { get; set; }
    public int Price;
    public int HousePrice;
    public int HotelPrice;
    public int Rent;
    public int RentPerHouse;
    bool HotelBuilt;
    public int HotelRent;
    

    void BuyProperty(int ownerId)
    {
        if (OwnerId==null)
        {
            OwnerId = ownerId;
        }
    }
    void BuildHouse()
    {
        if(NumberOfHouses < 4)
        {
            NumberOfHouses++;
        }
    }
    void BuildHotel()
    {
        if (NumberOfHouses == 4)
        {
            HotelBuilt = true;
        }
    }
    int GetRent()
    {
        if (HotelBuilt)
        {
            return Rent + HotelRent;
        }
        else
        {
            return Rent + NumberOfHouses * RentPerHouse;
        }
    }
}
