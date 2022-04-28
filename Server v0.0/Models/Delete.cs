namespace Server_v0._0.Models
{
    public class Delete
    {
        public static string DelStatus(bool IsDeleted)
        {
            if (IsDeleted)
            {
                return "Восстановить";
            }
            else
            {
                return "Удалить";
            }
        }

        public static string DelColor(bool IsDeleted)
        {
            if (IsDeleted)
            {
                return "background-color:#0a0a0a0a";
            }
            else
            {
                return "background-color:#fff";
            }
        }
    }
}
