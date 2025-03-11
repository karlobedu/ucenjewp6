using System.ComponentModel.DataAnnotations;

namespace EdunovaAPP.Models.DTO
{
    
    ///<summary>
    /// DTO klasa koja predstavlja graf grupe.
    /// </summary>
    public record GrafGrupaDTO(string NazivGrupe, int UkupnoPolaznika);
}
