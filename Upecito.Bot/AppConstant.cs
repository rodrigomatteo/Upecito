namespace Upecito.Bot
{
    public static class AppConstant
    {
        public static class Intencion
        {
            public const string ASISTENCIA = "Asistencia";
            public const string MATRICULA = "Matricula";
            public const string CREDITOS = "Creditos";
            public const string PROMEDIO = "Promedio";
            public const string RETIRO = "Retiro";
            public const string PROGRAMACION = "Programacion Academica";
            public const string CALENDARIO = "Calendario Academico";
            public const string ORGANIZACION = "Organizacion del Aula Virtual";
            public const string DEFAULT = "Default Fallback Intent";
        }

        public static class EstadoSolicitud
        {
            public const string PENDIENTE = "P";
            public const string ATENDIDO = "A";
            public const string DERIVADA = "D";
            public const string ATENDIDADERIVACION = "R";
            public const string INVALIDO = "I";
            public const string FALTAINFORMACION = "F";
            public const string CANCELADA = "C";
        }
    }
}