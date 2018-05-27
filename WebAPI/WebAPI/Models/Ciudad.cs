using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Ciudad
{
    
        private int _id;
        private string _nombreCiudad;
        private int _poblacion;
        private string _descripcion;
        private string _localizacion;
        private string _fotopath;
    
    public Ciudad()
    {

    }


    public Ciudad(int id, string nombreCiudad, int poblacion, string descripcion, string localizacion, string foto)
    {
        _id = id;
        _nombreCiudad = nombreCiudad;
        _poblacion = poblacion;
        _descripcion = descripcion;
        _localizacion = localizacion;
        _fotopath = foto;
    }
    public Ciudad(string nombreCiudad, int poblacion, string descripcion, string localizacion, string foto)
    {
        _nombreCiudad = nombreCiudad;
        _poblacion = poblacion;
        _descripcion = descripcion;
        _localizacion = localizacion;
        _fotopath = foto;
    }

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public string  nombreCiudad
    {
        get { return _nombreCiudad; }
        set { _nombreCiudad = value; }
    }

    public string poblacion 
    {
        get { return _poblacion; }
        set { _poblacion = value; }
    }
    public string descripcion
    {
        get { return _descripcion; }
        set { _descripcion = value; }
    }

    public string localizacion
    {
        get { return _localizacion; }
        set { _localizacion = value; }
    }

    public string foto
    {
        get { return _fotopath; }
        set { _fotopath = value; }
    }

}
