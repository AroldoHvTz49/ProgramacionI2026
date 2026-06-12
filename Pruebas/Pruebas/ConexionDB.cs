using Supabase;

namespace Pruebas
{
    public static class ConexionDB
    {
        private static string url = "https://hfxdxkvngvljnsljhymy.supabase.co"; // Supabase URL
        private static string key = "sb_publishable_PVkoX7XBOcwTM6_0CpH21A_96R5c0bQ"; // Supabase Key

        // Propiedad global que usarán todos los formularios
        public static Supabase.Client Supabase { get; private set; }

        public static async System.Threading.Tasks.Task Inicializar()
        {
            if (Supabase == null)
            {
                var options = new SupabaseOptions { AutoConnectRealtime = true };
                Supabase = new Supabase.Client(url, key, options);
                await Supabase.InitializeAsync();
            }
        }
    }
}
