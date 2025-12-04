using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonInfoSystem.Models;

[Table("Country")]
public class CountryEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int CountryId { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(20)]
    public string Continent { get; set; }
    public long Population { get; set; }

    [MaxLength(10)]
    public string Currency { get; set; }
    public List<CityEntity> Cities { get; set; } = new List<CityEntity>();

    public CountryEntity(string countryName, string countryContinent, long countryPopulation, string countryCurrency)
    {
        Name = countryName;
        Continent = countryContinent;
        Population = countryPopulation;
        Currency = countryCurrency;
    }

    public CountryEntity()
    {}
    public override string ToString()
    {
        return $"CountryId: {CountryId}, Name: {Name}, Continent: {Continent}, Population: {Population}, Currency: {Currency}";
    }
}
