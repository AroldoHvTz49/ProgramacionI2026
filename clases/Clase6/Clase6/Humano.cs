namespace Clase6
{
    public class Humano
    {
        private string primerNombre;
        private string primerApellido;
        private string colorDeOjos;

        public Humano(string primerNombre)
        {
            this.primerNombre = primerNombre;
        }

        public Humano(string primerNombre, string primerApellido)
        {
            this.primerNombre = primerNombre;
            this.primerApellido = primerApellido;
        }

        public Humano(string primerNombre, string primerApellido, string colorDeOjos)
        {
            this.primerNombre = primerNombre;
            this.primerApellido = primerApellido;
            this.colorDeOjos = colorDeOjos;
        }

        public void presentarse()
        {
            Console.WriteLine("Hola, mi nombre es {0}  {1}  {2}", primerNombre, primerApellido, colorDeOjos);
        }
    }
}
