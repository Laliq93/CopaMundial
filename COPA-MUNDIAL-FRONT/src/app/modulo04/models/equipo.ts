export class Equipo {
    iso: string;
    nombre: string;
    descripcion: string;
    status: boolean;    // el equipo participa aun o no en la competencia
    habilitado: boolean; // atributo para funcionalidad de que no hayan jugadores sin equipo
}