namespace entidad
{
    public class proveedor
    {
        public int IdProveedor { get; set; }
        public string Documento { get; set; }
        public string RazonSocial { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
        public string FechaIngreso { get; set; }
        public int IdDireccion { get; set; }
        public string Direccion { get; set; }
        public int IdUsuario { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string Sector { get; set; }
        public string Calle { get; set; }
        public string CodigoPostal { get; set; }
        // Nueva propiedad agregada
        public int DiasEntrega { get; set; }

    }
}
