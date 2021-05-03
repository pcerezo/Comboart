using UnityEditorInternal;

namespace DefaultNamespace
{
    public class Movimiento
    {
        private string nombre;
        private float potencia;
        private string tipo;

        public Movimiento(string nombre, float potencia, string tipo)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.potencia = potencia;
        }

        public string getNombre()
        {
            return nombre;
        }

        public string getTipo()
        {
            return tipo;
        }

        public float getPotencia()
        {
            return potencia;
        }
    }
}