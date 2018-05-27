import { Injectable } from '@angular/core';

@Injectable() 

export class Usuario_10 {
    public Id: number;
    public NombreUsuario: string;
    public Nombre: string;
    public Apellido: string;
    public FechaNacimiento: string;
    public Correo: string;
    public Genero: string;
    public Password: string; 
    public FotoPath: string;
    public EsAdmin: boolean;
    public Activo: boolean; 
}