using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonInfoSystem.Models;

[Table("City")]
public class CityEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CityID { get; set; }

    [ForeignKey("CountryNavigation")]
    public int CountryID { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }
    public long Population { get; set; }

    public CountryEntity CountryNavigation { get; set; }
    public List<AdressEntity> Adressies { get; set; } = new List<AdressEntity>();

    public CityEntity(int countryID, string cityName, long cityPopulation)
    {
        this.CountryID = countryID;
        this.Name = cityName;
        this.Population = cityPopulation;
    }

    public CityEntity()
    { }

    public override string ToString()
    {
        return $"CityId: {this.CityID}, CountryId: {this.CountryID}, Name: {this.Name}, Population: {this.Population}";
    }
}