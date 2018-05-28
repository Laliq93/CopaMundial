import { Pais } from './pais';
import { I18nEquipo } from './i18n_equipo';

export class Equipo {
    private _pais: Pais;
    private _descripcion: I18nEquipo;
    private _status: boolean;    // el equipo participa aun o no en la competencia
    private _grupo: string;
    private _habilitado: boolean; // atributo para funcionalidad de que no hayan jugadores sin equipo

    // getters y setters de la clase
    get getPais(): Pais {
        return this._pais;
    }

    get getDescripcion(): I18nEquipo {
        return this._descripcion;
    }

    get getStatus(): boolean {
        return this._status;
    }

    get getGrupo(): string {
        return this._grupo;
    }

    get getHabilitado(): boolean {
        return this._habilitado;
    }

    set setPais(pais: Pais) {
        this._pais = pais;
    }

    set setDescripcion(descripcion: I18nEquipo) {
        this._descripcion = descripcion;
    }

    set setStatus(status: boolean) {
        this._status = status;
    }

    set setGrupo(grupo: string) {
        this._grupo = grupo;
    }

    set setHabilitado(habilitado: boolean) {
        this._habilitado = habilitado;
    }
}
