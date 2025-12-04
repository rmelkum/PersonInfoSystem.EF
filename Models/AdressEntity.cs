using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonInfoSystem.Models;

[Table("Adress")]
public class AdressEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AdressId { get; set; }

    [ForeignKey("CityNavigation")]
    public int CityId { get; set; }

    [MaxLength(100)]
    public string Adress { get; set; }

    [MaxLength(10)]
    public string ZipCode { get; set; }

    public CityEntity CityNavigation { get; set; }
    public List<PersonAddressEntity> PersonAdresses { get; set; } = new List<PersonAddressEntity>();

    public AdressEntity(int cityid, string adressName, string zipCode)
    {
        this.CityId = cityid;
        this.Adress = adressName;
        this.ZipCode = zipCode;
    }

    public AdressEntity()
    { }
}