
namespace AnimalHelp.Domain.Model
{
    internal class LastId
    {
        public int UserId { get; set; }

        public LastId()
        {
            UserId = 0;
        }

        public LastId(int userId)
        {
            UserId = userId;
        }
    }
}
