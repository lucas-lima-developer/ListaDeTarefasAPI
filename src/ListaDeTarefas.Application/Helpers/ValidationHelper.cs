namespace ListaDeTarefas.Application.Helpers
{
    public static class ValidationHelper
    {
        public static bool BeAValidPriority(string priority)
        {
            return priority == "baixa" || priority == "média" || priority == "alta";
        }
    }
}
