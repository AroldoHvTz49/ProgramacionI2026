namespace Clase6
{
    public class Caja
    {
        private int ancho;
        private int alto;
        private int largo;

        public Caja(int ancho, int alto, int largo)
        {
            this.ancho = ancho;
            this.alto = alto;
            this.largo = largo;
        }

        public int getLargo()
        {
            return largo;
        }

        public int getAncho()
        {
            return ancho;
        }
        
        public int getAlto()
        {
            return alto;
        }

        public int superficieFrontal()
        {
            return alto * largo;
        }
    }
}
