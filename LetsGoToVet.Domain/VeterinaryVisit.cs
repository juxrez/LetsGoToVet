namespace LetsGoToVet.Domain
{
    public class VeterinaryVisit
    {
        public int Id { get; set; }

        public string Reason { get; set; }

        public DateTime Date { get; set; }

        public int PetId { get; set; }

        public virtual Pet Pet { get; set; } 

        public int VetId { get; set; }

        public virtual Veterinary Veterinary { get; set; }

    }
}
