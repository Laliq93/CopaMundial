export class Equipo {
    public iso: string;
    public nombre: string;
    public descripcion: string;
    public grupo: string;
    public status: boolean;    // el equipo participa aun o no en la competencia
    public habilitado: boolean; // atributo para funcionalidad de que no hayan jugadores sin equipo
}